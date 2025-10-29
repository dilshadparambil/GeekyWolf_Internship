using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;


namespace AdoApp
{
    //1) Write a program to connect to SQL Server, read data from Employee table
    //Create a table Employee(Id, Name, Salary) and perform Insert, Update, and Delete using ADO.NET.
    public class Employee
    {
        public void Answer()
        {
            DataBaseConnection db = new DataBaseConnection();
            db.SelectEmployee();

            int newEmployeeId = db.InsertEmployee("Eve Davis", 80000);
            db.SelectEmployee();
            db.UpdateEmployee(newEmployeeId, "Eve Johnson", 82000);
            db.SelectEmployee();
            db.DeleteEmployee(newEmployeeId);
            db.SelectEmployee();

            db.GetEmployeeCount();

            db.DisplayEmployeesDisconnected();

            db.ModifyAndUpdateEmployees();
            db.SelectEmployee();

        }
    }

    public class DataBaseConnection
    {
        string cs = @"Data Source=localhost,1433;Initial Catalog=adodb;User ID=sa;Password=qwer@1234;Trust Server Certificate=True";

        public void SelectEmployee()
        {
            //2) Display all rows from the Employee table using SqlDataReader.
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand selectCmd = new SqlCommand("SELECT * FROM Employee", conn);
                SqlDataReader dr = selectCmd.ExecuteReader();
                Console.WriteLine("ID\tName\t\tSalary");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["Id"]}\t{dr["Name"]}\t{dr["Salary"]}");
                }
            }
        }

        public int InsertEmployee(string name, decimal salary)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand insertCmd = new SqlCommand("INSERT INTO Employee(Name, Salary) VALUES(@Name, @Salary); SELECT SCOPE_IDENTITY();", conn);
                insertCmd.Parameters.AddWithValue("@Name",name);
                insertCmd.Parameters.AddWithValue("@Salary", salary);

                var result = insertCmd.ExecuteScalar();
                Console.WriteLine($"\nInsert successful.\n");
                return Convert.ToInt32(result);
            }
        }

        public void UpdateEmployee(int id, string newName, decimal newSalary)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand updateCmd = new SqlCommand("UPDATE Employee SET Name = @Name, Salary = @Salary WHERE Id = @Id", conn);
                updateCmd.Parameters.AddWithValue("@Id", id);
                updateCmd.Parameters.AddWithValue("@Name", newName);
                updateCmd.Parameters.AddWithValue("@Salary", newSalary);
                int rowsAffected = updateCmd.ExecuteNonQuery();
                Console.WriteLine($"\n{rowsAffected} row Updated.\n");
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand deleteCmd = new SqlCommand("DELETE FROM Employee WHERE Id = @Id", conn);
                deleteCmd.Parameters.AddWithValue("@Id", id);
                int rowsAffected =deleteCmd.ExecuteNonQuery();
                Console.WriteLine($"\nRows Deleted: {rowsAffected}\n");
            }
        }

        public void GetEmployeeCount()
        {
            //3) Display the total employee count using ExecuteScalar().
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand empCountCmd = new SqlCommand("SELECT COUNT(*) FROM Employee", conn);
                var count = empCountCmd.ExecuteScalar();
                Console.WriteLine($"\nTotal employee count: {Convert.ToInt32(count)}");
            }
        }

        public void DisplayEmployeesDisconnected()
        {
            //4) Display all rows from the Employee table using disconnected mode.
            //Display all employees and their Name, Salary.
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Name, Salary FROM Employee", cs);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "Employees");

            Console.WriteLine("\nDisplaying in disconnected mode.");
            Console.WriteLine("ID\tName\t\tSalary");
            foreach (DataRow row in dataSet.Tables["Employees"].Rows)
            {
                Console.WriteLine($"{row["Id"]}\t{row["Name"]}\t{row["Salary"]}");
            }
        }
        public void ModifyAndUpdateEmployees()
        {
            //5) Use SqlDataAdapter and DataSet to retrieve all employees.
            //Modify data in the DataSet and update the database using da.Update().
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Name, Salary FROM Employee", conn);
                DataSet dataSet = new DataSet();
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.Fill(dataSet, "Employees");

                if (dataSet.Tables["Employees"].Rows.Count > 0)
                {
                    DataRow rowToModify = dataSet.Tables["Employees"].Rows[0];
                    Console.WriteLine($"\nGiving '{rowToModify["Name"]}' a 1234 salary increase in local DataSet...");
                    rowToModify["Salary"] = Convert.ToDecimal(rowToModify["Salary"]) + 1234;
                }

                adapter.Update(dataSet, "Employees");
            }
        }

    }

}
