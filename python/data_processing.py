import json
import re

# 读取包含文本数据的文件
with open('en1.ini', 'r') as f:
    text_data = f.read()

# 使用正则表达式查找 JavaScript 对象格式的部分
pattern = r'{[^}]*}'  # 匹配 {...} 形式的文本
matches = re.findall(pattern, text_data)

# 初始化一个空的列表来存储有效的 JSON 数据
valid_json_data = []

# 尝试解析每个匹配到的文本并将其转换为 Python 字典
for match in matches:
    try:
        json_data = json.loads(match)
        valid_json_data.append(json_data)
    except json.JSONDecodeError:
        # 如果解析失败，跳过此部分
        continue

# 现在 valid_json_data 列表包含了有效的 JSON 数据

# 如果需要将它们写入 Excel，可以使用 pandas
import pandas as pd

# 合并所有 JSON 数据成一个大字典
merged_json_data = {}
for json_data in valid_json_data:
    merged_json_data.update(json_data)

# 转换为 DataFrame
df = pd.DataFrame(merged_json_data.items(), columns=['key', 'value'])

# 将 DataFrame 写入 Excel 文件
df.to_excel('output.xlsx', index=False)
