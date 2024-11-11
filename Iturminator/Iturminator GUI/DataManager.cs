using System.Data;
using ClosedXML.Excel;


namespace Iturminator.Data
{
    public class DataManager
    {
        private static DataManager _instance;
        public static DataManager Instance => _instance ??= new DataManager();

        public DataTable MainDataTable { get; set; }
        public DataTable EnrichingDataTable { get; set; }
        public DataTable FinalDataTable { get; set; }

        public DataTable CombineData(string mainColumn, string enrichingColumn)
        {
            // Step 1: Index the EnrichingDataTable based on the enrichingColumn
            var enrichingDict = new Dictionary<string, DataRow>();
            foreach (DataRow row in EnrichingDataTable.Rows)
            {
                var key = row[enrichingColumn]?.ToString();
                if (!string.IsNullOrEmpty(key) && !enrichingDict.ContainsKey(key))
                {
                    enrichingDict[key] = row;
                }
            }

            // Step 2: Create a copy of MainDataTable to store combined data
            var combinedTable = MainDataTable.Copy();

            // Add columns from EnrichingDataTable if necessary
            foreach (DataColumn col in EnrichingDataTable.Columns)
            {
                if (!combinedTable.Columns.Contains(col.ColumnName))
                {
                    combinedTable.Columns.Add(col.ColumnName, col.DataType);
                }
            }

            // Step 3: Combine data using the dictionary for fast lookups
            foreach (DataRow mainRow in combinedTable.Rows)
            {
                var mainValue = mainRow[mainColumn]?.ToString();
                if (!string.IsNullOrEmpty(mainValue) && enrichingDict.TryGetValue(mainValue, out DataRow enrichingRow))
                {
                    // Copy values from the matching enrichingRow into the mainRow
                    foreach (DataColumn col in EnrichingDataTable.Columns)
                    {
                        mainRow[col.ColumnName] = enrichingRow[col];
                    }
                }
            }

            return combinedTable;
        }

        public DataTable LoadDataFromExcel(string filePath, string sheetName = null)
        {
            var dataTable = new DataTable();

            // Open the workbook
            using (var workbook = new XLWorkbook(filePath))
            {
                // Select the sheet (use the first sheet if none specified)
                var worksheet = sheetName != null ? workbook.Worksheet(sheetName) : workbook.Worksheet(1);

                if (worksheet == null)
                {
                    throw new ArgumentException("Specified sheet does not exist in the workbook.");
                }

                // Load column headers from the first row
                bool isFirstRow = true;
                foreach (var row in worksheet.RowsUsed())
                {
                    if (isFirstRow)
                    {
                        foreach (var cell in row.CellsUsed())
                        {
                            string columnName = cell.Value.ToString();
                            if (!dataTable.Columns.Contains(columnName))
                            {
                                dataTable.Columns.Add(columnName);
                            }
                            else
                            {
                                // Handle duplicate column names
                                dataTable.Columns.Add(columnName + "_Duplicate");
                            }
                        }
                        isFirstRow = false;
                    }
                    else
                    {
                        // Load data rows
                        var dataRow = dataTable.NewRow();
                        int columnIndex = 0;
                        foreach (var cell in row.CellsUsed())
                        {
                            dataRow[columnIndex] = cell.IsEmpty() ? DBNull.Value : cell.Value;
                            columnIndex++;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }

            return dataTable;
        }

        private DataManager() { } // Private constructor to prevent instantiation
    }
}
