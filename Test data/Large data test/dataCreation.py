import pandas as pd
import random
import string

# Function to generate random English text
def generate_random_english_text(length=10):
    return ''.join(random.choices(string.ascii_letters + string.digits, k=length))

# Function to generate random Hebrew text
def generate_random_hebrew_text(length=10):
    hebrew_letters = [chr(i) for i in range(1488, 1515)]  # Unicode range for Hebrew letters
    return ''.join(random.choices(hebrew_letters, k=length))

# Function to generate a row of random data
def generate_random_row(row_id):
    row = [row_id]  # First column is the ID
    for _ in range(29):  # Next 99 columns
        #choice = random.choice(["number", "english", "hebrew"])
        choice = random.choice(["number", "english"])
        if choice == "number":
            row.append(random.randint(1, 10000))  # Random integer
        elif choice == "english":
            row.append(generate_random_english_text())
        elif choice == "hebrew":
            row.append(generate_random_hebrew_text())
    return row

# Generate a large DataFrame
def generate_large_excel_file(row_count, file_name):
    print(f"Generating {row_count} rows of data...")
    column_names = ["ID"] + [f"Column_{i}" for i in range(1, 30)]
    data = [generate_random_row(row_id) for row_id in range(1, row_count + 1)]

    # Create a DataFrame
    df = pd.DataFrame(data, columns=column_names)

    # Save to an Excel file
    print(f"Saving data to {file_name}...")
    df.to_excel(file_name, index=False, engine="openpyxl")
    print(f"File {file_name} created successfully!")

# Generate a file with 3000 rows
generate_large_excel_file(300, "english enriching.xlsx")
