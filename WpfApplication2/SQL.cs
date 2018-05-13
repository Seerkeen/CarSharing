using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    class SQL
    {
        const string connectionString = @"Data Source=DESKTOP-BOL7PC8\SQLEXPRESS;Initial Catalog=Cars;Integrated Security=True";
        public Order CheckOrder(int id)
        {
            Order order = new Order();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE Id = @a", connection);
                cmd.Parameters.AddWithValue("@a", id);
                SqlDataReader data;
                try
                {
                    connection.Open();
                    data = cmd.ExecuteReader();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    connection.Close();
                    adapter.Fill(table);
                    order.Id = (int)table.Rows[0].ItemArray[0];
                    order.Name = (string)table.Rows[0].ItemArray[1];
                    order.CarId = (int)table.Rows[0].ItemArray[2];
                    Console.WriteLine(order);
                }
                catch
                {
                    return null;
                }
            }
            return order;
        }
        public List<Car> SelectAllCars()
        {

            List<Car> cars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CarsT", connection);
                SqlDataReader data;
                try
                {
                    connection.Open();
                    data = cmd.ExecuteReader();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    connection.Close();
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        cars.Add(new Car() { Id = (int)row.ItemArray[0], Name = (string)row.ItemArray[1], Color = (string)row.ItemArray[2], Year = (int)row.ItemArray[3], Availability = (bool)row.ItemArray[4] });
                    }
                }
                catch
                {
                    return null;
                }
            }
            return cars;
        }
        public void CreateOrder(int id, string name)
        {
            Order order=new Order();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES (@name,@id)", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    //Console.WriteLine(order);
                }
                catch
                {
                    //return null;
                }
            }
            //  return order;
        }
    }
}
