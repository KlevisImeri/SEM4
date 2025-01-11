
using System;
using System.Data.SqlClient;

class Program {
  static void Main() {
    try {
      using (SqlConnection conn = new SqlConnection("Data Source=(local); Initial Catalog=SzoftechDB; Integrated Security=True")) {
        conn.Open();
        string insertQuery = "INSERT INTO Product (ProductID, Name, Price) VALUES (@ProductID, @Name, @Price)";

        using (SqlCommand command = new SqlCommand(insertQuery, conn)) {
          // Set parameter values
          command.Parameters.AddWithValue("@ProductID", 1);
          command.Parameters.AddWithValue("@Name", "Sample Product");
          command.Parameters.AddWithValue("@Price", 99.99);

          // Execute the command
          int rowsAffected = command.ExecuteNonQuery();
          Console.WriteLine("Rows affected: " + rowsAffected);
        }
      }
    } catch (Exception ex) {
      Console.WriteLine("An error occurred: " + ex.Message);
    }
  }
}
