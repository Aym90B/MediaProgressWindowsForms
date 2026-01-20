# MediaProgress (WinForms Edition)

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Windows Build Status](https://img.shields.io/badge/build-windows-brightgreen)]()
[![Releases](https://img.shields.io/github/v/release/Aym90B/MediaProgressWindowsForms)]()
[![Issues](https://img.shields.io/github/issues/Aym90B/MediaProgressWindowsForms)]()

A professional 3‑tier desktop application to organize, track and discover media (Movies, Series and Episodes) using real-time IMDb data and local caching. Built with WinForms (Presentation), a Business Logic Layer (BLL) and a Data Access Layer (DAL) using ADO.NET and SQL Server.

## Table of Contents
- [About](#about)
- [Key features](#key-features)
- [Architecture](#architecture)
- [Requirements](#requirements)
- [Installation](#installation)
- [Database setup](#database-setup)
- [Configuration](#configuration)
- [Usage](#usage)
- [Development](#development)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## About
MediaProgress helps users catalogue and track their media consumption with advanced filters (time-optimized, narrative complexity/mood), intelligent sorting by IMDb rating, and simplified progress states (Watching / Completed). It leverages the power of the `api.imdbapi.dev` to keep your local database updated with the latest releases automatically.

## Key features
- **Automated IMDb Sync**: One-click "Daily Updates" to fetch and merge new media from IMDb directly into your local database.
- **Comprehensive Episode Import**: Select any TV series and instantly import all its episodes, including season numbers, episode numbers, ratings, and vote counts.
- **Intelligent Media Cataloging**: Supports Movies, Series, Games, and more with robust data handling.
- **Progress Tracking**: Seamlessly track "Watching" and "Completed" states.
- **Advanced Filtering**: 
  - Time-based filtering for viewing sessions.
  - "Script Complexity" and Narrative Type filters.
  - Culture-invariant rating parsing (supports all regional decimal formats).
- **Smart Sorting**: Prioritizes unwatched high-rated titles based on live IMDb metrics.
- **Modular Architecture**: Clean separation between UI, Business Logic (BLL), and Data Access (DAL).

## Architecture
- **Presentation Layer**: WinForms C# GUI with dynamic update controls.
- **Business Logic Layer (BLL)**: 
  - `ImdbService`: Handles real-time API communication with `api.imdbapi.dev` and OMDb.
  - State management for media transitions and complexity calculations.
- **Data Access Layer (DAL)**: Optimized ADO.NET for high-performance SQL Server interaction.

## Requirements
- Windows 10/11
- .NET Framework 4.8+ / .NET 6.0+
- Visual Studio 2022 (for development)
- Microsoft SQL Server (LocalDB, Express, or Developer Edition)
- Internet connection (for automated sync features)

## Installation
1. Clone the repository:
   ```powershell
   git clone https://github.com/Aym90B/MediaProgressWindowsForms.git
   cd MediaProgressWindowsForms
   ```
2. Open the solution in Visual Studio and restore NuGet packages.
3. Build the solution and run the UI project.

## Database setup
1. Create the database schema by running the script at `/Database/Schema.sql` in SQL Server Management Studio (SSMS).
2. The application will handle data population through the **Daily Updates** feature.
3. (Optional) For legacy bulk imports, use official IMDb TSV files from [IMDb Interfaces](https://www.imdb.com/interfaces/).

## Configuration
Update your UI project's `App.config` to point to your SQL Server instance:
```xml
<connectionStrings>
  <add name="MediaDbConn"
       connectionString="Data Source=YOUR_LOCAL_SERVER;Initial Catalog=MediaProgress;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Usage
- **Daily Updates**: Open the "Updates" screen and click "Get Daily Updates" to synchronize your database with the latest IMDb releases since the year 2000.
- **Episode Import**: Find a series, select it, and use the "Import Episodes" button to pull in all seasons and episode ratings automatically.
- **Deep Scan**: Enable "Deep Scan" during searches to fetch enhanced metadata including Genres, Runtime, and detailed Ratings for multiple titles at once.

## Roadmap 🚀
MediaProgress is evolving into a universal media hub:
- [x] **Automated Data Sync**: Implemented via `imdbapi.dev` integration.
- [x] **Episode Management**: Full hierarchy import and rating sync.
- [ ] **Video Games Module**: Advanced integration for gaming libraries and platform tracking.
- [ ] **Books & Literature**: Support for reading progress and author metadata.
- [ ] **User Profiles**: Multi-user support with personalized viewing lists.

## Contributing 🤝
Contributions are welcome! We are currently focusing on:
- **Platform Integrations**: Adding more streaming platform indicators (Netflix, OSN+, HBO, etc.).
- **UI/UX Refinement**: Modernizing the WinForms interface with enhanced responsiveness.
- **Data Mapping**: Refining the "Complexity" algorithm with community-driven metrics.

If you have ideas or fixes, please open an issue or submit a pull request!

## License
This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Contact
Author: Ayman Bahih — [GitHub](https://github.com/Aym90B) · [LinkedIn](https://www.linkedin.com/in/ayman-bahih)

## Attribution & Legal
- Metadata provided by [imdbapi.dev](https://imdbapi.dev) and [IMDb](https://www.imdb.com/interfaces/).
- This project is intended for personal, non-commercial use only.
