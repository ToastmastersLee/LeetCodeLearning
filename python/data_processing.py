import pandas as pd
ini_path = 'en.ini'
ini_data = {}
with open(ini_path, 'r') as f:
    for line in f:
        key, value = line.strip().split('=')
        ini_data[key] = value
xml_data = {'Name': 'Lee', 'Name': '妍子'}  # 你可以使用适合的XML库来处理XML文件

df = pd.DataFrame([ini_data, xml_data])
excel_path = 'output1.xlsx'
df.to_excel(excel_path, index=False)
