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


# In[9]:


communities_geo = "./india_district.geojson" # geojson file


# In[10]:


grand = pd.read_csv("./GrandDAta.csv")


# In[18]:


m1 = folium.Map(location=[20, 80], zoom_start=6, tiles = None)

for i in range(len(grand.index)):
    html = ""
    latlng = []
    for j in range(len(grand.columns)):
        if grand.columns[j] == "Lat" or grand.columns[j] == "Lng":
            latlng.append(grand.iloc[i][j])
        else:    
            html += str(grand.columns[j]) + ": " + str(grand.iloc[i][j]) + "<br>"   
    #print(latlng)
    #print(html)
    iframe = folium.IFrame(html)
    popup = folium.Popup(iframe,
                     min_width = 300,
                     max_width = 300)
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
    data = grand,
    columns = ['District', 'Urgency Level'],
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




