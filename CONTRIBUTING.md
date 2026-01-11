Contributing to MediaProgress
First off, thank you for considering contributing to MediaProgress! It’s people like you who make open-source a great place to learn and build.

🏗 Architectural Rules
To maintain the integrity of the 3-Tier Architecture, all contributors must follow these structural rules:

Presentation Layer (MediaProgress.UI): - No direct SQL queries.

No business logic or calculations.

Role: Handle user input and display data received from the BLL.

Business Logic Layer (MediaProgress.BLL): - This is where the "Complexity" and "Time-based" filters live.

All data validation must happen here.

Role: Act as a bridge between the UI and the DAL.

Data Access Layer (MediaProgress.DAL): - Use ADO.NET (SqlConnection, SqlCommand).

Role: Execute queries and return DataTables or Lists to the BLL.

🛠 Specific Challenges to Solve
We are currently looking for help with the following:

1. Incremental IMDb Updates
The current project requires a full re-import of IMDb datasets. We need a service (perhaps a C# Console App) that can:

Compare local TitleIDs with the latest IMDb .tsv file.

Perform a Delta Sync (Insert only new records).

Update AverageRating for existing records without overwriting user-specific progress.

2. Game & Book Module Expansion
We have the SQL schema ready for Games and Books. We need:

New WinForms interfaces for these categories.

BLL logic to handle specific metadata (e.g., Author for books, Platform for games).

📝 Coding Standards
Naming Conventions: Use PascalCase for methods and classes, and camelCase for local variables.

SQL Safety: Never use string concatenation for queries. Always use SqlParameters to prevent SQL injection.

Comments: Explain the why behind complex logic, especially for the "Script Complexity" filtering algorithms.

🚀 How to Submit a Change
Fork the repository.

Create a Branch for your feature (git checkout -b feature/AmazingFeature).

Commit your changes (git commit -m 'Add some AmazingFeature').

Push to the Branch (git push origin feature/AmazingFeature).

Open a Pull Request.
