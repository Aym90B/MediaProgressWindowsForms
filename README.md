MediaProgress
A Full-Stack .NET application for tracking personal media consumption using IMDB metadata.

!

📌 Project Overview
MediaProgress is a management tool designed to help users track their progress through movies and TV series. It leverages official IMDB datasets to provide accurate metadata while allowing users to log status, ratings, and completion dates.

This project showcases:

Backend: ASP.NET Core MVC with Entity Framework Core.

Database: Relational design in Microsoft SQL Server (T-SQL).

Data Handling: Custom ETL logic for processing large TSV datasets.

🚀 Technical Stack
Language: C#

Framework: .NET 8.0 (ASP.NET Core MVC)

ORM: Entity Framework Core / ADO.NET

Database: Microsoft SQL Server

Frontend: HTML5, CSS3, JavaScript, Bootstrap

Reporting: Power BI (Production Dashboards)

📂 Database Schema
The database is built on a relational model designed for high performance and data integrity.

Key Tables: Users, MediaTitles, UserProgress, Genres, Ratings.

Design: Normalized to 3NF with optimized indexing on TitleID.

⚙️ Setup & Installation
1. Prerequisites
Visual Studio 2022

SQL Server Express

.NET 8.0 SDK

2. Clone the Repository
Bash

git clone https://github.com/Aym90B/MediaProgress.git
cd MediaProgress
3. Data & Copyrights (IMDB)
To comply with IMDB's Terms of Use, this repository does not include raw data files.

Download the datasets from the Official IMDB Datasets Page.

Recommended files: title.basics.tsv.gz and title.ratings.tsv.gz.

Use the DataImporter tool in the /Tools directory to populate your local database.

4. Configuration
Update the ConnectionStrings in appsettings.json:

JSON

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=MediaProgress;Trusted_Connection=True;"
}
🤝 Contributing
Contributions are what make the open-source community such an amazing place to learn, inspire, and create.

Fork the Project.

Create your Feature Branch (git checkout -b feature/NewFeature).

Commit your Changes (git commit -m 'Add NewFeature').

Push to the Branch (git push origin feature/NewFeature).

Open a Pull Request.

⚖️ License
Distributed under the MIT License. See LICENSE for more information.

📧 Contact
Ayman Bahih - aymanbahih@gmail.com

Project Link: https://github.com/Aym90B/MediaProgress
