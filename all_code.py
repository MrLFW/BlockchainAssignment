import glob
import os

input_directory = "./BlockchainAssignment"
output_file = "all_code.txt"

cs_files = glob.glob(os.path.join(input_directory, "*.cs"), recursive=True)

with open(output_file, "w", encoding="utf-8") as outfile:
    for file_path in cs_files:
        filename = os.path.basename(file_path)
        outfile.write(f"// ==== File: {filename} ====\n\n")
        with open(file_path, "r", encoding="utf-8") as infile:
            outfile.write(infile.read())
        outfile.write("\n\n")
