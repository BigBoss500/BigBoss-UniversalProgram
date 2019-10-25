import re
import requests

def VkUserInfo():
    string = requests.get("https://vk.com/foaf.php?id=1")
    name = re.search(r'<foaf:name>(.*?)</foaf:name>', string.text)
    print(name.group(1))
VkUserInfo()