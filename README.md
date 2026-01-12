# MediaProgress (WinForms Edition)

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Windows Build Status](https://img.shields.io/badge/build-windows-brightgreen)]()
[![Releases](https://img.shields.io/github/v/release/Aym90B/MediaProgressWindowsForms)]()
[![Issues](https://img.shields.io/github/issues/Aym90B/MediaProgressWindowsForms)]()

A professional 3‑tier desktop application to organize, track and discover media (Movies, Series and Episodes) using a local IMDb dataset. Built with WinForms (Presentation), a Business Logic Layer (BLL) and a Data Access Layer (DAL) using ADO.NET and SQL Server.

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
MediaProgress helps users catalogue and track their media consumption with advanced filters (time-optimized, narrative complexity/mood), intelligent sorting by IMDb rating, and simplified progress states (Watching / Completed). It is designed for local, personal use with a local SQL Server instance.

## Key features
- Intelligent media cataloging from local IMDb TSV datasets
- Progress tracking (Watching, Completed)
- Time-based filtering to find items that fit a viewing session
- "Script Complexity" filter (custom complexity rating per title)
- Smart sorting prioritizing unwatched high-rated titles
- 3-tier architecture: WinForms UI, BLL, DAL for modularity and maintainability
- Prioritize the next to watch episode based on time availability and IMDB user ratings.
- Filter media based on the platform (Netflix, OSN+, HBO, Crunchyroll etc..) 

## Architecture
- Presentation Layer: WinForms C# GUI
- Business Logic Layer (BLL): State transitions, complexity calculations, filters
- Data Access Layer (DAL): ADO.NET, optimized for large SQL Server datasets

## Requirements
- Windows 10 or later
- .NET Framework / .NET runtime: (specify version, e.g., .NET 6.0 or .NET Framework 4.8) — update accordingly
- Visual Studio 2019/2022 (for development)
- Microsoft SQL Server (Developer/Express recommended)
- IMDb data (.tsv) downloaded from IMDb Interfaces

## Installation
1. Clone the repository:
   ```powershell
   git clone https://github.com/Aym90B/MediaProgressWindowsForms.git
   cd MediaProgressWindowsForms
   ```

2. Open the solution in Visual Studio and restore NuGet packages.

3. Build the solution (Release or Debug) and run the UI project.

## Database setup
To comply with IMDb terms, raw datasets are not included. Download official datasets from:
- https://www.imdb.com/interfaces/

Typical steps:
1. Download the needed TSV files (e.g., title.basics.tsv.gz, title.ratings.tsv.gz).
2. Unzip the files into a folder you control (e.g., C:\IMDbData).
3. Create the database schema by running the provided script:
   - The schema script is at `/Database/Schema.sql` — open it in SQL Server Management Studio and execute it on your target database.
   - Example in SSMS:
     1. Connect to your local SQL Server instance.
     2. File → Open → Database/Schema.sql
     3. Execute

4. Import TSV data into the database using SQL Server Import Wizard or a bulk-import script. Map columns carefully to the schema.

Suggested minimal schema for complexity table (add to /Database/Schema.sql):
```sql
CREATE TABLE MediaComplexity (
    TitleID VARCHAR(20) PRIMARY KEY,
    ComplexityLevel INT NOT NULL, -- 1 (Light) to 5 (Heavy)
    NarrativeType VARCHAR(50),
    CONSTRAINT FK_MediaTitles_TitleID FOREIGN KEY (TitleID)
      REFERENCES MediaTitles(TitleID)
);
```

## Configuration
Update your UI project's App.config (or use appsettings.json depending on project) to point to your database. Example App.config snippet:
```xml
<connectionStrings>
  <add name="MediaDbConn"
       connectionString="Data Source=YOUR_LOCAL_SERVER;Initial Catalog=MediaProgress;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```
Security note: Prefer using Integrated Security or environment-based secrets instead of embedding credentials directly in VCS.

## Usage
- Start the application.
- Configure the connection string if first run (UI → Settings).
- Use the search bar to look up titles from the local index.
- Apply filters such as Time Available, Complexity (Light/Medium/Heavy), Narrative Type.
- Mark progress: Watching, Completed.

Add screenshots or a short GIF to this section (place images in /docs or /assets and reference them):
![Main view screenshot](docs/screenshot-main.png)

## Development
- Branching: use feature branches off `main`.
- Commit messages: follow Conventional Commits (recommended).
- Run unit tests: (add commands here if you have tests)
- To debug BLL/DAL, set the Startup Project to the UI and attach debugger.

🚀 Future Roadmap & Vision
MediaProgress is designed to be a universal consumption tracker. Future updates will include:

Video Games Module: Full database integration for gaming libraries and platform tracking.

Books & Literature: Support for reading progress, authors, and genre-based complexity.

Automated Data Sync: Currently, the project requires manual importing of IMDb TSV files. I am looking to implement an automated sync service.

🤝 How to Contribute
I am actively looking for developers to help expand the ecosystem. Specifically, I am seeking contributions for:

⚡ The "Delta Update" Challenge
Current Gap: The project currently lacks an automated way to fetch and merge newly created media from the daily IMDb dataset updates into the existing local SQL database without re-importing everything.

We (since we now) need help with:

Incremental Sync Logic: A C# or SQL service that identifies only the new records in the .tsv files.

Web Scraper/API Integration: Exploring ways to fetch real-time updates for specific titles using the IMDb ID.

Data Mapping: Improving the "Complexity/Difficulty" algorithm using community-driven data.

If you have ideas for new metrics, platform integrations, or UI enhancements, please open an issue or submit a pull request!

## License
This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Contact
Author: Ayman Bahih — [GitHub](https://github.com/Aym90B) · [LinkedIn](https://www.linkedin.com/in/ayman-bahih)

(If you prefer direct email, see my GitHub profile. Consider removing or limiting phone number/email from the public README for privacy.)

## Attribution & Legal
- Metadata sourced from IMDb; users must download data directly from IMDb according to their terms of use.
- Data is intended for personal, non-commercial use only.
