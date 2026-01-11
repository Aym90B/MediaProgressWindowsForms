MediaProgress (WinForms Edition)
A Professional 3-Tier Desktop Application for Media Lifecycle Management.

📝 Project Overview
MediaProgress is an enterprise-style desktop solution designed to streamline how users organize, track, and discover media content. By leveraging a local instance of the IMDb database, the application provides a high-performance environment to manage vast libraries of movies and TV shows.

🌟 Key Features
Intelligent Media Cataloging: Seamlessly search and archive titles from a local SQL database containing millions of IMDb records.

Simplified Progress Tracking: Focused tracking allowing users to set a "Watching" status for series and a "Completed" status for all categories (Movies, Series, and Episodes).

Time-Optimized Filtering: Filter content based on available time, ensuring the right content is selected for your current session.

Cognitive Load & Mood Filtering: A unique "Script Complexity" filter that categorizes media by difficulty. This allows users to choose "Light" content for relaxation or "Heavy/Complex" scripts for deep following, based on their current mood.

Smart Sorting: Automatically prioritize unwatched media by IMDb Average Rating, focusing on high-quality content first.

🏗 System Architecture
The project is built using a strict 3-Tier Architecture to ensure modularity:

Presentation Layer (WinForms): An intuitive C# interface for efficient user interaction.

Business Logic Layer (BLL): Handles state transitions, time-based calculations, and the logic for the "Mood/Complexity" filtering.

Data Access Layer (DAL): High-performance ADO.NET layer for rapid data retrieval from large SQL Server datasets.

⚙️ Setup & Installation
1. Database Configuration
To remain compliant with IMDb Copyrights, raw data files are not hosted here.

Download official .tsv datasets from IMDb Interfaces.

Execute the provided script in /Database/Schema.sql to generate the structure.

Use the SQL Server Import Wizard to map files to your local tables.

2. Connection Configuration
Update your local App.config file in the UI project:

XML

<connectionStrings>
  <add name="MediaDbConn" 
       connectionString="Data Source=YOUR_LOCAL_SERVER;Initial Catalog=MediaProgress;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
🚀 Future Roadmap & Vision
MediaProgress is designed to be a universal consumption tracker. Future updates will include:

Video Games Module: Full database integration for gaming libraries and platform tracking.

Books & Literature: Support for reading progress, authors, and genre-based complexity.

Open to Suggestions: I am actively looking for ways to expand this project. If you have ideas for new metrics, platform integrations, or UI enhancements, please open an issue!

👨‍💻 Author & Contact Information
Ayman Bahih Full-Stack Developer & System Administrator

📍 Location: Tripoli, Libya

📞 Mobile: +218 91 963 8519

📧 Email: aymanbahih@gmail.com

🔗 LinkedIn: linkedin.com/in/ayman-bahih

💻 GitHub: github.com/Aym90B

⚖️ License & Legal
Code License: MIT License.

Data Source: Metadata is sourced from IMDb. Intended for personal, non-commercial use only.

How to implement the "Complexity" SQL:
Since "Difficulty" isn't a standard IMDb field, you can explain that your BLL calculates this or uses a custom table. Here is a suggested SQL structure for your /Database/Schema.sql:

SQL

CREATE TABLE MediaComplexity (
    TitleID VARCHAR(20) PRIMARY KEY,
    ComplexityLevel INT, -- 1 (Light) to 5 (Heavy)
    NarrativeType VARCHAR(50),
    FOREIGN KEY (TitleID) REFERENCES MediaTitles(TitleID)
);
