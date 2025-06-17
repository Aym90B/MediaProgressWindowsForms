using System;
using System.Data;
using System.Data.SqlClient;

namespace MediaProgressDataAccessLayer
{
    public class clsCategoryDataAccess
    {
        public static bool GetCategoryInfoByID(int ID, ref string Name
           )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Categories WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Name = (string)reader["Name"];
                  


                    // allows null in database so we should handle null
                    //if (reader["Seasons"] != DBNull.Value)
                    //{
                    //    Season = (int)reader["Season"];
                    //}
                    //else
                    //{
                    //    Season = -1;
                    //}
                    //if (reader["SeriesID"] != DBNull.Value)
                    //{
                    //    SeriesID = (int)reader["SeriesID"];
                    //}
                    //else
                    //{
                    //    SeriesID = -1;
                    //}

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

        public static bool GetCategoryInfoByName(string Name, ref int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Categories WHERE Name = @Name";

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
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewCategory(string Name)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Categories (Name)
                             VALUES (@Name);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
          


            //if (Season != -1 && Season != null)
            //    command.Parameters.AddWithValue("@Season", Season);
            //else
            //    command.Parameters.AddWithValue("@Season", System.DBNull.Value);

            //if (SeriesID != -1 && SeriesID != null)
            //    command.Parameters.AddWithValue("@SeriesID", SeriesID);
            //else
            //    command.Parameters.AddWithValue("@SeriesID", System.DBNull.Value);

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

        public static bool UpdateCategory(int ID, string Name)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Main  
                            set Name = @Name
                               
                              
                                where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
          


            //if (Season != -1 && Season != null)
            //    command.Parameters.AddWithValue("@Season", Season);
            //else
            //    command.Parameters.AddWithValue("@Seasons", System.DBNull.Value);

            //if (SeriesID != -1 && SeriesID != null)
            //    command.Parameters.AddWithValue("@SeriesID", SeriesID);
            //else
            //    command.Parameters.AddWithValue("@SeriesID", System.DBNull.Value);


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

        public static DataTable GetAllCategories()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Categories";

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

        public static bool DeleteCategory(int ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Categories
                                where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsCategoryExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Categories WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
