using System;
using System.Data;
using System.Data.SqlClient;

namespace MediaProgressDataAccessLayer
{
    public class clsBookDataAccess
    {
        public static bool GetBookInfoByID(int BookID, ref int NumberOfPages, ref int CurrentPage
           )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Main WHERE BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    NumberOfPages = (int)reader["NumberOfPages"];
                   
                    CurrentPage = (int)reader["CurrentPage"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static float GetBookPercentageCompletion(int ID)
        {
            float PercentageOfCompletion = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT PercentageOfCompletion FROM Main WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["PercentageOfCompletion"] != DBNull.Value)
                    {
                        PercentageOfCompletion = (float)(double)reader["PercentageOfCompletion"];
                    }
                    else
                    {
                        PercentageOfCompletion = 0;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                PercentageOfCompletion = 0;
            }
            finally
            {
                connection.Close();
            }
            return PercentageOfCompletion;
        }

        public static bool GetBookInfoByName(string Name, ref int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Main WHERE Name = @Name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ID = (int)reader["ID"];

                    if (reader["Name"] != DBNull.Value)
                    {
                        Name = (string)reader["Name"];
                    }
                    else
                    {
                        Name = "";
                    }



                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewBook(int NumberOfPages, int CurrentPage, int BookID, string Author, string ISBN)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Books (NumberOfPages, CurrentPage, BookID, Author, ISBN)
                             VALUES (@NumberOfPages, @CurrentPage, @BookID, @Author, @ISBN);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            if (NumberOfPages != -1 && NumberOfPages.ToString() != null)
                command.Parameters.AddWithValue("@NumberOfPages", NumberOfPages);
            else
                command.Parameters.AddWithValue("@NumberOfPages", System.DBNull.Value);

            if (CurrentPage != -1 && CurrentPage.ToString() != null)
                command.Parameters.AddWithValue("@CurrentPage", CurrentPage);
            else
                command.Parameters.AddWithValue("@CurrentPage", System.DBNull.Value);

            if (ID != -1 && ID.ToString() != null)
                command.Parameters.AddWithValue("@BookID", BookID);
            else
                command.Parameters.AddWithValue("@BookID", System.DBNull.Value);

            if (Author != null && Author.ToString() != null)
                command.Parameters.AddWithValue("@Author", Author);
            else
                command.Parameters.AddWithValue("@Author", System.DBNull.Value);

            if (ISBN != null && Author.ToString() != null)
                command.Parameters.AddWithValue("@ISBN", ISBN);
            else
                command.Parameters.AddWithValue("@ISBN", System.DBNull.Value);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ID;
        }

        public static bool UpdateBook(int ID, int NumberOfPages, int CurrentPage, string Author, string ISBN)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Books 
                                set 
                                NumberOfPages = @NumberOfPages,
                                CurrentPage = @CurrentPage,
                                Author = @Author,
                                ISBN = @ISBN
                              
                                where ID = @ID";
          

            SqlCommand command = new SqlCommand(query, connection);

            //command.Parameters.AddWithValue("@BookID", BookID);
            //command.Parameters.AddWithValue("@NumberOfPages", NumberOfPages);
            //command.Parameters.AddWithValue("@CurrentPage", CurrentPage);
            //command.Parameters.AddWithValue("@Author", Author);
            //command.Parameters.AddWithValue("@ISBN", ISBN);

            if (ID != -1 && ID.ToString() != null)
                command.Parameters.AddWithValue("@ID", ID);
            else
                command.Parameters.AddWithValue("@ID", System.DBNull.Value);


            if (NumberOfPages != -1 && NumberOfPages.ToString() != null)
                command.Parameters.AddWithValue("@NumberOfPages", NumberOfPages);
            else
                command.Parameters.AddWithValue("@NumberOfPages", System.DBNull.Value);

            if (CurrentPage != -1 && CurrentPage.ToString() != null)
                command.Parameters.AddWithValue("@CurrentPage", CurrentPage);
            else
                command.Parameters.AddWithValue("@CurrentPage", System.DBNull.Value);
            if (Author != null && Author.ToString() != null)
                command.Parameters.AddWithValue("@Author", Author);
            else
                command.Parameters.AddWithValue("@Author", System.DBNull.Value);

            if (ISBN != null && Author.ToString() != null)
                command.Parameters.AddWithValue("@ISBN", ISBN);
            else
                command.Parameters.AddWithValue("@ISBN", System.DBNull.Value);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllBooks()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * From Books";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeleteBook(int BookID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Books 
                                where BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsBookExist(int BookID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Series WHERE BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable getAllBooksWithinAvailableTime(int Duration)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
Select Main.Name as BookName,
Main.Rating,
Main.Duration,
main.StartPlaying,
Main.PercentageOfCompletion,
Main.WhereToWatch,
Books.NumberOfPages,
Books.currentPage
From Main join Books on Main.ID = Books.ID Where Main.Duration <= @Duration
	";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Duration", Duration);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
    }
}
