using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace ComputersMannager
{
    internal class DataAccess
    {
        public int InsertCategory(string connectionString)
        {
            string categoryName;
            Console.WriteLine("insert category name");
            categoryName = Console.ReadLine();
            string query = "INSERT INTO Categories(categoryName)" +
                "VALUES(@CategoryName)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 20).Value = categoryName;

                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowsAffected;
            }
        }
        public int InsertProduct(string connectionString)
        {
            string productName,description,imageurl;
            int price, categoryId;
            Console.WriteLine("insert product name");
            productName = Console.ReadLine();
            Console.WriteLine("insert description");
            description = Console.ReadLine();
            Console.WriteLine("insert image url");
            imageurl = Console.ReadLine();
            Console.WriteLine("insert price");
            price = int.Parse(Console.ReadLine());
            Console.WriteLine("insert category Id");
            categoryId = int.Parse(Console.ReadLine());
            string query = "INSERT INTO Products(productName,description,imageurl,price,categoryId)" +
                "VALUES(@productName,@description,@imageurl,@price,@categoryId)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@productName", SqlDbType.VarChar, 10).Value = productName;
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = description;
                cmd.Parameters.Add("@imageurl", SqlDbType.VarChar, 50).Value = imageurl;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;



                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowsAffected;
            }
        }

        internal void readDataCategories(string connectionString)
        {
            string queryString = "select * from Categories";
            using (SqlConnection connection= new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
        internal void readDataProducts(string connectionString)
        {
            string queryString = "select * from Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
