# Weather

技術加值面：
加上快取機制：例如用 MemoryCache 或 Redis 減少 API 請求頻率。

加上前端（Blazor, React, Vue）：讓 UI 更美觀更互動。

加上地理資訊視覺化：整合 Leaflet.js 或 Google Maps SDK，標出天氣熱點。

加上背景排程（BackgroundService）：定時更新天氣資料到資料庫。

Docker 化：整個專案容器化部署，展示 DevOps 能力。

多語系切換 + 台語/客語地名處理：針對台灣在地化做在地 UX 改進。

商業/應用面：
天氣預報 + 旅遊建議：例如日月潭這週天氣晴，推薦景點。

與災防系統連動：像是下雨量超過某值就提醒可能淹水。

可查歷史資料趨勢圖：用圖表顯示最近幾天溫度變化。

加入路線花費時間，並根據時間推薦天氣用品。

做成app。

引用

[open-meteo](https://open-meteo.com/en/docs?latitude=25.033&longitude=121.5654&hourly=temperature_2m,rain,precipitation_probability,apparent_temperature) by Open-meteo

[open-meteo-dotnet](https://github.com/AlienDwarf/open-meteo-dotnet) by [AlienDwarf](https://github.com/AlienDwarf/open-meteo-dotnet)

[台灣行政區列表.json](https://gist.github.com/memochou1993/aa9b6b1185221f88a03109f10d32e5e2) by [memochou1993](https://gist.github.com/memochou1993)
