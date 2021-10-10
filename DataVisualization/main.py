#!/usr/bin/env python
# coding: utf-8

# In[1]:


import folium
import pandas as pd
import numpy as np
import http.client, urllib.parse
import json
import random
from IndianNameGenerator import *
import time


# In[38]:


pip install IndianNameGenerator


# In[41]:


randomPunjabi()


# In[2]:


m = folium.Map(location=[15, 80], tiles = None, zoom_start = 5)
attr_tiles = [["Tiles &copy; Esri &mdash; Sources: GEBCO, NOAA, CHS, OSU, UNH, CSUMB, National Geographic, DeLorme, NAVTEQ, and Esri",'https://server.arcgisonline.com/ArcGIS/rest/services/Ocean_Basemap/MapServer/tile/{z}/{y}/{x}']] 
attr_tiles.append(['&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>', 'https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png'])
folium.TileLayer(name = "Water Distribution", attr = attr_tiles[0][0], tiles = attr_tiles[0][1]).add_to(m)
folium.TileLayer(name = "Areas", attr = attr_tiles[1][0], tiles = attr_tiles[1][1]).add_to(m)
folium.LayerControl().add_to(m)


# In[82]:


lat = np.random.randint(1800000, 2100000, 100)/100000.0


# In[83]:


lng = np.random.randint(7400000, 7700000, 100)/100000.0


# In[84]:


lng


# In[85]:


num_of_people = np.random.randint(1, 9, 100)


# In[86]:


num_of_people


# In[87]:


elder = []
for num in num_of_people:
    elder.append(random.randint(0, num))
elder


# In[88]:


children = []
temp = num_of_people - elder
for num in temp:
    children.append(random.randint(0, num))


# In[89]:


children


# In[90]:


Status = np.random.randint(1, 4, 100)


# In[91]:


Status


# In[92]:


Bedding = []
for num in num_of_people:
    Bedding.append(random.randint(0, num))


# In[93]:


name = []
for i in range(100):
    name.append(randomPunjabi())


# In[94]:


name


# In[95]:


Bedding


# In[115]:


phones = []
for i in range(100):
    phone = "+91-"
    for j in range(10):
        phone += str(random.randint(0, 9))
    phones.append(phone)


# In[97]:


phones


# In[98]:


df = pd.DataFrame()


# In[99]:


df['Name'] = name


# In[100]:


df['Lat'] = lat


# In[101]:


df["Lng"] = lng


# In[102]:


df['Number of People'] = num_of_people


# In[103]:


df["The Erderly"] = elder


# In[104]:


df["Children"] = children


# In[105]:


df["Status"] = Status


# In[106]:


df["Bedding"] = Bedding


# In[116]:


df["Contact Information"] = phones


# In[123]:


df.head()


# In[118]:


df.info()


# In[119]:


districts = []
conn = http.client.HTTPConnection('geocode.xyz')


for i in range(100):
    latlng = [df.iloc[i][1], df.iloc[i][2]]
    # print(latlng)
    
    params = urllib.parse.urlencode({
        'auth': '123348575592456280597x92039',
        'locate': ", ".join( repr(e) for e in latlng ),
        'region': 'IN',
        'json': 1,
        })
    conn.request('GET', '/?{}'.format(params))

    res = conn.getresponse()
    data = res.read()

    data = data.decode()
    data = json.loads(data)
    
    # print(data)

    region = data["region"].split(",")[0]
    districts.append(region)
    time.sleep(1)
    print(region)
    
df["District"] = districts


# In[121]:


df.to_csv("./simulation_data.csv")


# In[122]:


df["Urgency"] = df["Number of People"] * df["Status"]


# In[124]:


summary = df[["District",'Number of People', 'The Erderly', 'Children', "Bedding", "Urgency"]].copy()


# In[125]:


summary.head()


# In[129]:


summary = summary.groupby("District").sum()


# In[130]:


summary.to_csv("./summary_data.csv")


# In[3]:


summary = pd.read_csv("./summary_data.csv")


# In[133]:


summary = summary.reset_index()


# In[4]:


summary


# In[2]:


communities_geo = "./india_district.geojson" # geojson file


# In[23]:



# create a plain world map
m = folium.Map(location=[20, 80], zoom_start=6, tiles = None)
#attr_tiles = [["Tiles &copy; Esri &mdash; Sources: GEBCO, NOAA, CHS, OSU, UNH, CSUMB, National Geographic, DeLorme, NAVTEQ, and Esri",'https://server.arcgisonline.com/ArcGIS/rest/services/Ocean_Basemap/MapServer/tile/{z}/{y}/{x}']] 
#attr_tiles.append(['&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>', 'https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png'])
#folium.TileLayer(name = "Water Distribution", attr = attr_tiles[0][0], tiles = attr_tiles[0][1]).add_to(m)
#folium.TileLayer(name = "Areas", attr = attr_tiles[1][0], tiles = attr_tiles[1][1]).add_to(m)
#folium.LayerControl().add_to(m)


# generate choropleth map 
'''communities_map.choropleth(
    geo_data=communities_geo,
    data=summary,
    columns=['District', 'Number of People'],
    key_on='feature.properties.NAME_2',
    fill_color='YlGnBu', 
    fill_opacity=0.6, 
    line_opacity=1,
    legend_name='Births per 1000 inhabitants',
    smooth_factor=0)'''

choropleth = folium.Choropleth(
    name = "Number of People",
    geo_data=communities_geo,
    data = summary,
    columns = ['District', 'Number of People'],
    key_on = 'feature.properties.NAME_2',
    fill_color='YlGnBu', 
    fill_opacity=0.3, 
    line_opacity=1,
    legend_name='The Numer of people',
    highlight=True,
    smooth_factor=0).add_to(m)

choropleth = folium.Choropleth(
    name = "The Elderly",
    geo_data=communities_geo,
    data = summary,
    columns = ['District', 'The Elderly'],
    key_on = 'feature.properties.NAME_2',
    fill_color='BuGn', 
    fill_opacity=0.3, 
    line_opacity=1,
    legend_name='The Numer of the Erderly',
    highlight=True,
    smooth_factor=0).add_to(m)

choropleth = folium.Choropleth(
    name = "Children",
    geo_data=communities_geo,
    data = summary,
    columns = ['District', 'Children'],
    key_on = 'feature.properties.NAME_2',
    fill_color='OrRd', 
    fill_opacity=0.3, 
    line_opacity=1,
    legend_name='The Numer of Children',
    highlight=True,
    smooth_factor=0).add_to(m)

choropleth = folium.Choropleth(
    name = "Bedding",
    geo_data=communities_geo,
    data = summary,
    columns = ['District', 'Bedding'],
    key_on = 'feature.properties.NAME_2',
    fill_color='RdPu', 
    fill_opacity=0.3, 
    line_opacity=1,
    legend_name='The Numer of Bedding Needed',
    highlight=True,
    smooth_factor=0).add_to(m)

style_function = "font-size: 15px; font-weight: bold"
choropleth.geojson.add_child(
    folium.features.GeoJsonTooltip(['NAME_2'], style=style_function, labels=False))

# create a layer control
folium.LayerControl().add_to(m)

# display map
m


# In[16]:


m1 = folium.Map(location=[20, 80], zoom_start=6, tiles = None)
#attr_tiles = [["Tiles &copy; Esri &mdash; Sources: GEBCO, NOAA, CHS, OSU, UNH, CSUMB, National Geographic, DeLorme, NAVTEQ, and Esri",'https://server.arcgisonline.com/ArcGIS/rest/services/Ocean_Basemap/MapServer/tile/{z}/{y}/{x}']] 
#attr_tiles.append(['&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>', 'https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png'])
#folium.TileLayer(name = "Water Distribution", attr = attr_tiles[0][0], tiles = attr_tiles[0][1]).add_to(m)
#folium.TileLayer(name = "Areas", attr = attr_tiles[1][0], tiles = attr_tiles[1][1]).add_to(m)
#folium.LayerControl().add_to(m)


for i in range(len(grand.index)):
    html = ""
    latlng = []
    for j in range(len(grand.columns)):
        if grand.columns[j] == "Lat" or grand.columns[j] == "Lng":
            latlng.append(grand.iloc[i][j])
        elif grand.columns[j] != "District":    
            html += str(grand.columns[j]) + ": " + str(grand.iloc[i][j]) + "<br>"   
    print(latlng)
    print(html)
    iframe = folium.IFrame(html)
    popup = folium.Popup(iframe,
                     min_width=200,
                     max_width=200)
    folium.Marker(
    latlng, popup = popup
    ).add_to(m1)

# generate choropleth map 
'''communities_map.choropleth(
    geo_data=communities_geo,
    data=summary,
    columns=['District', 'Number of People'],
    key_on='feature.properties.NAME_2',
    fill_color='YlGnBu', 
    fill_opacity=0.6, 
    line_opacity=1,
    legend_name='Births per 1000 inhabitants',
    smooth_factor=0)'''

choropleth = folium.Choropleth(
    name = "Urgency Summary",
    geo_data=communities_geo,
    data = summary,
    columns = ['District', 'Urgency'],
    key_on = 'feature.properties.NAME_2',
    fill_color='YlGnBu', 
    fill_opacity=0.6, 
    line_opacity=1,
    legend_name='The Urgency Level',
    highlight=True,
    smooth_factor=0).add_to(m1)

# create a layer control
#folium.LayerControl().add_to(m)

# display map
m1


# In[14]:





# In[11]:


grand = pd.read_csv("./GrandDAta.csv")


# In[12]:


grand.head()


# In[ ]:


for i in range(len(grand.index)):
    html = ""
    latlng = []
    for j in range(len(grand.columns)):
        if grand.columns[j] == "Lat" or grand.columns[j] == "Lng":
            latlng.append(grand.iloc[i][j])
        elif grand.columns[j] != "District":    
            html += str(grand.columns[j]) + ": " + str(grand.iloc[i][j]) + "<br>"   
    print(latlng)
    print(html)
    iframe = folium.IFrame(html)
    popup = folium.Popup(iframe,
                     min_width=200,
                     max_width=200)
    folium.Marker(
    latlng, popup = popup
    ).add_to(m1)


# In[ ]:





# In[ ]:





# In[68]:


s = "Warangal, Telangana".split(",")[0]


# In[69]:


s


# In[73]:


for i in range(50):
    print(i)
    time.sleep(1)


# In[80]:


latlng = [12.23123, 2.231231]
ss =  ", ".join( repr(e) for e in latlng )
print(type(s))


# In[ ]:





# In[ ]:





# In[ ]:





# In[ ]:





# In[3]:


data = pd.read_csv("./data.csv")
data.replace(to_replace = np.nan, value = 0, inplace = True)


# In[4]:


data.head()


# In[ ]:


for i in range(len(data.index)):
    html = ""
    latlng = []
    for j in range(len(data.columns)):
        if data.columns[j] == "Latitude" or data.columns[j] == "Longitude":
            latlng.append(data.iloc[i][j])
        else:    
            html += str(data.columns[j]) + ": " + str(data.iloc[i][j]) + "<br>"    
    iframe = folium.IFrame(html)
    popup = folium.Popup(iframe,
                     min_width=200,
                     max_width=200)
    folium.Marker(
    latlng, popup = popup
    ).add_to(m)


# In[19]:


m1 = folium.Map(location=[20, 80], zoom_start=6, tiles = None)
#attr_tiles = [["Tiles &copy; Esri &mdash; Sources: GEBCO, NOAA, CHS, OSU, UNH, CSUMB, National Geographic, DeLorme, NAVTEQ, and Esri",'https://server.arcgisonline.com/ArcGIS/rest/services/Ocean_Basemap/MapServer/tile/{z}/{y}/{x}']] 
#attr_tiles.append(['&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>', 'https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png'])
#folium.TileLayer(name = "Water Distribution", attr = attr_tiles[0][0], tiles = attr_tiles[0][1]).add_to(m)
#folium.TileLayer(name = "Areas", attr = attr_tiles[1][0], tiles = attr_tiles[1][1]).add_to(m)
#folium.LayerControl().add_to(m)


for i in range(len(grand.index)):
    html = ""
    latlng = []
    for j in range(len(grand.columns)):
        if grand.columns[j] == "Lat" or grand.columns[j] == "Lng":
            latlng.append(grand.iloc[i][j])
        else:    
            html += str(grand.columns[j]) + ": " + str(grand.iloc[i][j]) + "<br>"   
    print(latlng)
    print(html)
    iframe = folium.IFrame(html)
    popup = folium.Popup(iframe,
                     min_width=200,
                     max_width=200)
    folium.Marker(
    latlng, popup = popup
    ).add_to(m1)

# generate choropleth map 
'''communities_map.choropleth(
    geo_data=communities_geo,
    data=summary,
    columns=['District', 'Number of People'],
    key_on='feature.properties.NAME_2',
    fill_color='YlGnBu', 
    fill_opacity=0.6, 
    line_opacity=1,
    legend_name='Births per 1000 inhabitants',
    smooth_factor=0)'''

choropleth = folium.Choropleth(
    name = "Urgency Summary",
    geo_data=communities_geo,
    data = summary,
    columns = ['District', 'Urgency'],
    key_on = 'feature.properties.NAME_2',
    fill_color='YlGnBu', 
    fill_opacity=0.6, 
    line_opacity=1,
    legend_name='The Urgency Level',
    highlight=True,
    smooth_factor=0).add_to(m1)

# create a layer control
#folium.LayerControl().add_to(m)

# display map
m1


# In[ ]:




