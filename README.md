# ☁️ Weather 預報系統架構設計（基於 DDD）

---

## 🎯 目標功能：

1. **服務 1**：查詢某地區的即時天氣  
2. **服務 2**：顯示七天預報  
3. **服務 3**：通知用戶特定天氣變化（例如下雨提醒）

---

## Middleware 的設計用途

Middleware 的設計目的是處理 跨領域關注（cross-cutting concerns），例如：

驗證（Authentication）

授權（Authorization）

記錄（Logging）

錯誤處理（Error handling）

請求/回應轉換（Request/Response transformation）

快取（Caching）

---

## 🧱 架構分層（DDD）

---

### 1. 表現層（Presentation Layer）

**目的：**  
- 負責與使用者互動，接收輸入（前端傳來的資料、API 請求）
- 呼叫應用層（執行對應的 use case）
- 回傳結果到前端

**流程：**
1. 前端：選取行政區、取得經緯度並傳回後端
2. 後端：
   - 接收前端資訊
   - 呼叫應用層取得結果
   - 回傳資料給前端顯示

---

### 2. 應用層（Application Layer）

**目的：**
- 🧩 **協調流程**（但不實作業務邏輯）
- 🔗 **串接各層**
- ✅ **處理驗證、流程控制與回傳資料**

**流程：**
1. 接收表現層的 DTO
2. 呼叫三個服務（即時天氣、七天預報、下雨提醒）
3. 各服務再去呼叫：
   - **領域層**：處理業務邏輯
   - **Infrastructure 層**：存取資料、API、通知
4. 組合結果後返回 DTO 給表現層

---

### 3. 領域層（Domain Layer）⭐️ 核心

**目的：**
- 🧠 定義核心業務邏輯與規則
- 🔐 維護商業不變性
- 💡 建模真實世界概念（城市、天氣、提醒）
- ❌ 不依賴技術實作

**流程：**
1. 定義 Entity / Value Object / 聚合（如：`City`, `WeatherForecast`, `WeatherAlert`）
2. 實作業務邏輯（如：是否產生雨天提醒）
3. 使用 Domain Service（如邏輯橫跨多個 Entity）
4. 定義領域事件（如：`RainAlertTriggered`）
5. 驗證商業規則與資料一致性
6. 定義 Infrastructure 用的介面（如：`IWeatherRepository`, `INotificationSender`）

> **介面應放在哪裡？**  
> - ✅ 與商業邏輯強耦合 → 放在 **領域層**  
> - 🧩 協調流程用途 → 放在 **應用層**

---

### 4. 基礎設施層（Infrastructure Layer）

**目的：**
- 封裝技術細節，支援上層邏輯

**功能實作：**
1. Repository：實作 `IWeatherRepository`，用於資料存取（DB、Redis...）
2. 第三方 API 客戶端：如 `WeatherApiClient`，包裝 OpenMeteo API
3. 通知服務：如 Email、推播（FcmSender 等）
4. 快取機制：如 Redis 快取即時天氣結果
5. 定時排程任務：如 `WeatherSyncJob` 自動更新天氣
6. Logging / 監控 / 錯誤追蹤（視需求）
7. 保持對核心邏輯低侵入（依賴介面而非直接耦合）

---

## 🗂️ 資料夾結構建議

📁 Domain  
├── 📁 Entities  
│   ├── City.cs  
│   ├── WeatherForecast.cs  
│   └── WeatherAlert.cs  
├── 📁 Services  
│   ├── WeatherService.cs  
│   └── WeatherAlertService.cs  
└── 📁 Interfaces  
    └── IWeatherRepository.cs  

📁 Application  
├── 📁 Services  
│   └── WeatherOrchestratorService.cs  
└── 📁 Interfaces  
    ├── IForecastService.cs  
    └── IWeatherAlertNotifier.cs  

📁 Infrastructure  
├── WeatherRepositorySql.cs            # implements IWeatherRepository  
├── ForecastServiceExternalApi.cs     # implements IForecastService  
└── WeatherPushNotificationService.cs # implements IWeatherAlertNotifier  

---

## 🧪 技術加值功能（Technical Add-ons）

- ✅ 加上快取機制（MemoryCache 或 Redis）
- 🎨 加上前端框架（Blazor、React、Vue）
- 🗺️ 加上地圖視覺化（Leaflet.js、Google Maps SDK）
- 🔁 背景排程任務（BackgroundService）
- 🐳 Docker 化部署（展示 DevOps 能力）
- 🌍 多語系切換，台語/客語地名處理（在地化 UX）

---

## 💼 應用/商業加值方向

- 🌤️ 天氣預報 + 旅遊建議（搭配景點推薦）
- 🚨 與災防系統連動（如即時雨量通知）
- 📊 可查歷史趨勢圖（例如溫度、降雨變化）
- 🧳 搭配路線建議：根據時間建議攜帶物品
- 📱 做成跨平台 App（整合所有服務）

---

## 🔗 資源參考

- [Open-Meteo API](https://open-meteo.com/en/docs?latitude=25.033&longitude=121.5654&hourly=temperature_2m,rain,precipitation_probability,apparent_temperature)
- [open-meteo-dotnet](https://github.com/AlienDwarf/open-meteo-dotnet) by [AlienDwarf](https://github.com/AlienDwarf)
- [台灣行政區列表.json](https://gist.github.com/memochou1993/aa9b6b1185221f88a03109f10d32e5e2) by [memochou1993](https://gist.github.com/memochou1993)

---
