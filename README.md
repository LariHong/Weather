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

V1構造
1. 表現層（Presentation Layer）
目的：
負責與使用者互動，接收輸入（前端傳來的資料、API 請求）呼叫應用層（把輸入轉交給應用層執行對應的 use case）回傳輸出。

步驟:
前端: 選取行政區 獲得經緯度 傳回後端
後端: 
  1 接收前端資訊 
  2 呼叫應用層 獲取結果
  3 回傳結果回前端


🔹 2. 應用層（Application Layer）
目的：
🧩 負責流程
🔗 負責串接各層（但不自己做細節）
🧼 不寫業務邏輯，只 orchestrate
驗證輸入資料（城市名稱有沒有輸入？格式對嗎？）
控制流程（先查快取，沒有再查外部 API）
呼叫  領域層（例如處理預報、比較天氣變化等邏輯）
呼叫 Infrastructure（資料庫儲存、呼叫第三方 API、發通知）
組合回應結果（用 DTO 回傳給表現層）

步驟:
1 接收表現層的DTO 
2 呼叫服務丟入DTO
  呼叫服務服務1 查詢某地區的即時天氣
  呼叫服務服務2 顯示七天預報
  呼叫服務服務3 通知用戶特定天氣變化（例如下雨提醒）
3 各服務呼叫 領域層 Infrastructure 
4 回傳 各服務的結果並返還DTO 回應用層

🔹 3. 領域層（Domain Layer）⭐ 核心
目的：
系統的心臟，負責處理所有核心業務邏輯。
🧠 定義核心業務邏輯與規則
🧩 建模真實世界概念（如天氣、提醒、城市）
🔐 保證業務不變性（Invariants）
🚫 不關心技術實作（資料庫、API、Email 都不知道）
步驟:
1 建立 Entity / Value Object / 聚合（Aggregate）	例如：WeatherForecast、City、WeatherAlert	封裝業務邏輯與狀態，代表業務中的真實角色
2️ 實作 業務邏輯	例如：判斷是否要觸發下雨提醒、分析天氣趨勢	把「業務知識」放在正確的地方、集中管理
3️ 使用 Domain Service（如邏輯無法歸類到某個物件）	例如：天氣警告產生邏輯	管理跨多個 Entity 的業務邏輯
4️ 定義 領域事件（Domain Events）	例如：RainAlertTriggered	解耦業務事件與後續處理（如通知）
5️ 驗證不變性與商業規則	例如：一天只能有一筆天氣紀錄	維持資料一致性、業務正確性
6️ 定義與 Infrastructure 互動的界面（Repository/Service）	例如：IWeatherRepository、INotificationSender	隔離依賴，讓領域層保持技術中立、可測試
  把這些介面放在哪？
  如果介面跟「商業邏輯有強耦合」：
  ➤ 放在 領域層（例如：IWeatherRepository）
  
  如果是協調用途、偏應用流程（非核心商業邏輯）：
  ➤ 放在 應用層（例如：IWeatherAlertNotifier）


🔹 4. 基礎設施層（Infrastructure Layer）
目的：
處理技術細節，支援其他層。

步驟:
1️ 實作 Repository 介面	如：IWeatherRepository → WeatherRepositorySql	提供資料存取功能（DB、Redis...），但遵守領域定義的介面
2️ 實作 第三方 API 封裝	如：WeatherApiClient → 呼叫 OpenWeather API	與外部服務整合，隱藏實作細節給應用層
3 實作 Email / 通知 / 推播服務	如：EmailNotificationSender、FcmSender	發送天氣警示等通知行為
4️ 實作 快取服務	如：RedisCacheService	快取即時天氣結果，加速系統效率
5️ 實作 定時任務 / 排程器	如：WeatherSyncJob	定期抓取天氣資料、自動發送通知
6️ 實作 Logging、監控、錯誤追蹤（視需要）	如：使用 Serilog、Datadog 等	系統健康與問題追蹤
7️ 維持對核心邏輯的低侵入	所有實作都應依賴 interface，避免污染領域與應用層	確保未來技術替換不影響核心邏輯


資料夾結構
/Domain
  /Entities
    - City.cs
    - WeatherForecast.cs
    - WeatherAlert.cs
  /Services
    - WeatherService.cs
    - WeatherAlertService.cs
  /Interfaces
    - IWeatherRepository.cs

/Application
  /Services
    - WeatherOrchestratorService.cs
  /Interfaces
    - IForecastService.cs
    - IWeatherAlertNotifier.cs

/Infrastructure
  - WeatherRepositorySql.cs : implements IWeatherRepository
  - ForecastServiceExternalApi.cs : implements IForecastService
  - WeatherPushNotificationService.cs : implements IWeatherAlertNotifier

引用

[open-meteo](https://open-meteo.com/en/docs?latitude=25.033&longitude=121.5654&hourly=temperature_2m,rain,precipitation_probability,apparent_temperature) by Open-meteo

[open-meteo-dotnet](https://github.com/AlienDwarf/open-meteo-dotnet) by [AlienDwarf](https://github.com/AlienDwarf/open-meteo-dotnet)

[台灣行政區列表.json](https://gist.github.com/memochou1993/aa9b6b1185221f88a03109f10d32e5e2) by [memochou1993](https://gist.github.com/memochou1993)
