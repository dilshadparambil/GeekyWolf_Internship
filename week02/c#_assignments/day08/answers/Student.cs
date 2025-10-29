using AdoApp;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoApp
{
    public class Student
    {
        public void Answer()
        {
            DataBaseConnection db = new DataBaseConnection();
            db.SelectStudent();
            db.InsertStudentInline("Frank Green", "Class 12");
            db.SelectStudent();

            db.GetStudentById(1);

            int newStudentId = db.InsertStudentWithOutput("Grace Hall", "Class 9");
            Console.WriteLine($"New student inserted with ID: {newStudentId}\n");
            db.SelectStudent();

            db.DeleteStudent(newStudentId);
            db.DeleteStudent(999);
            db.SelectStudent();

            db.UpdateStudent(1, "David Lee Jr.", "Class 10A");
            db.SelectStudent();

        }

        public class DataBaseConnection
        {
            string cs = @"Data Source=localhost,1433;Initial Catalog=adodb;User ID=sa;Password=qwer@1234;Trust Server Certificate=True";

            public void SelectStudent()
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand selectCmd = new SqlCommand("SELECT * FROM Student", conn);
                    SqlDataReader dr = selectCmd.ExecuteReader();
                    Console.WriteLine("ID\tName\t\tClass");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["Id"]}\t{dr["Name"]}\t{dr["Class"]}");
                    }
                }
            }

            public void InsertStudentInline(string name, string className)
            {
                //6) Create a parameterized inline query to insert new students(avoid SQL injection).
                //Create a table Student(Id, Name, Class)
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand insertcmd = new SqlCommand("INSERT INTO Student (Name, Class) VALUES (@Name, @Class)", conn);
                    insertcmd.Parameters.AddWithValue("@Name", name);
                    insertcmd.Parameters.AddWithValue("@Class", className);

                    int rows = insertcmd.ExecuteNonQuery();
                    Console.WriteLine($"\nInserted student. Rows affected: {rows}\n");
                }
            }

            public void GetStudentById(int studentId)
            {
                //7) Create a parameterized procedure to get student using stored procedure “GetStudentById” with input parameter(@StudentId)
                // and get students where studentid = 1 from program and print
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand getStudenCmd = new SqlCommand("GetStudentById", conn);
                    getStudenCmd.CommandType = CommandType.StoredProcedure;
                    getStudenCmd.Parameters.AddWithValue("@StudentId", studentId);

                    using (SqlDataReader reader = getStudenCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"\nFound Student: {reader["Id"]}, {reader["Name"]}, {reader["Class"]}");
                        }
                        else
                        {
                            Console.WriteLine($"Student with ID {studentId} not found.");
                        }
                    }
                }
            }

            public int InsertStudentWithOutput(string name, string className)
            {
                //8)  Create a parameterized procedure to insert a student using stored procedure “InsertStudent”
                // with input parameters (Name, Class) and output parameter last inserted student id(@LastInsertedId) then print that id.

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand insertcmd = new SqlCommand("InsertStudent", conn);
                    insertcmd.CommandType = CommandType.StoredProcedure;
                    insertcmd.Parameters.AddWithValue("@Name", name);
                    insertcmd.Parameters.AddWithValue("@Class", className);

                    SqlParameter outputIdParam = new SqlParameter();
                    outputIdParam.ParameterName = "@LastInsertedId";
                    outputIdParam.SqlDbType = SqlDbType.Int;
                    outputIdParam.Direction = ParameterDirection.Output;
                    insertcmd.Parameters.Add(outputIdParam);

                    insertcmd.ExecuteNonQuery();
                    int newId = (int)outputIdParam.Value;
                    return newId;
                }
            }

            public void DeleteStudent(int studentId)
            {
                //9)  Create a parameterized procedure to delete a student using stored procedure “DeleteStudent”
                // with input parameters (@StudentId) and print student deleted successfully or not.

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand deleteCmd = new SqlCommand("DeleteStudent", conn);
                    deleteCmd.CommandType = CommandType.StoredProcedure;
                    deleteCmd.Parameters.AddWithValue("@StudentId", studentId);
                    
                    int result = (int)deleteCmd.ExecuteScalar();

                    if (result == 1)
                    {
                        Console.WriteLine($"\nStudent {studentId} deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"\nStudent {studentId} not found, could not delete.");
                    }
                }
            }

            public void UpdateStudent(int studentId, string newName, string newClass)
            {

                //10)  Create a parameterized procedure to update a student using stored procedure “UpdateStudent”
                //with input parameters (@StudentId, @StudnetName, @Class) and print student updated successfully or not.

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand updateCmd = new SqlCommand("UpdateStudent", conn);

                    updateCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.Parameters.AddWithValue("@StudentId", studentId);
                    updateCmd.Parameters.AddWithValue("@StudentName", newName);
                    updateCmd.Parameters.AddWithValue("@Class", newClass);

                    conn.Open();
                    int result = (int)updateCmd.ExecuteScalar();

                    if (result == 1)
                    {
                        Console.WriteLine($"\nStudent {studentId} updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"\nStudent {studentId} not found, could not update.");
                    }
                }
            }

        }
    }
}




