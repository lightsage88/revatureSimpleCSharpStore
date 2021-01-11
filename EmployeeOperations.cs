using System;
using System.Data.SqlClient;
public class EmployeeOperations
{
    SqlConnection con = new SqlConnection("server=DESKTOP-K5838CB\\NYKSERVER;database=EmployeeManagementDB;integrated security=true");

    public int AddEmployee()
    {
        System.Console.WriteLine("Employee Management");
            //SqlCommand cmdObj = new SqlCommand("insert into EmployeeInformation values(106, 'Richard', 'HR', 'Portland', 0, 3500)", con);
            SqlCommand cmdObj = new SqlCommand("insert into EmployeeInformation values(@newEmpNo, @newEmpName, @newEmpDesignation, @newEmpCity, @newEmpIsPermanent, @newEmpSalary)", con);

            System.Console.WriteLine("Enter new Employee number");
            int newEmpNo = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter new Employee name");
            string newEmpName = Console.ReadLine();
            System.Console.WriteLine("Enter new Employee designation");
            string newEmpDesignation = Console.ReadLine();
            System.Console.WriteLine("Enter new Employee city");
            string newEmpCity = Console.ReadLine();
            System.Console.WriteLine("Enter new Employee permanent?");
            bool newEmpIsPermanent = Convert.ToBoolean(Console.ReadLine());
            System.Console.WriteLine("Enter new Employee salary");
            int newEmpSalary = Convert.ToInt32(Console.ReadLine());

            cmdObj.Parameters.AddWithValue("@newEmpNo", newEmpNo);
            cmdObj.Parameters.AddWithValue("@newEmpName", newEmpName);
            cmdObj.Parameters.AddWithValue("@newEmpDesignation", newEmpDesignation);
            cmdObj.Parameters.AddWithValue("@newEmpCity", newEmpCity);
            cmdObj.Parameters.AddWithValue("@newEmpIsPermanent", newEmpIsPermanent);
            cmdObj.Parameters.AddWithValue("@newEmpSalary", newEmpSalary);

            con.Open();
                int result = cmdObj.ExecuteNonQuery();
            con.Close();

            System.Console.WriteLine("Employee Added to System succesfully");
            return result;
    }


    public int DeleteEmployee()
    {
        SqlCommand cmd = new SqlCommand("delete from EmployeeInformation where empId=@eNo", con);
        System.Console.WriteLine("Enter Employee Number");
        int empNo = Convert.ToInt32(Console.ReadLine());

        cmd.Parameters.AddWithValue("@eNo", empNo);

        con.Open();
            int result = cmd.ExecuteNonQuery();
        con.Close();

        return result;
    }

    public int UpdateEmployee()
    {
        SqlCommand cmd = new SqlCommand("update EmployeeInformatoin set empSalary =@newsal where empId=@eNo", con);

        System.Console.WriteLine("Enter Employee No.");
        int no = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Enter new Salary");
        int sal = Convert.ToInt32(Console.ReadLine());

        cmd.Parameters.AddWithValue("@newsal", sal);
        cmd.Parameters.AddWithValue("@eNo", no);

        con.Open();
            int result = cmd.ExecuteNonQuery();
        con.Close();

        return result;
    }

    public string GetEmployee()
    {
        SqlCommand cmd = new SqlCommand("select * from EmployeeInformation where empId=@eNo", con);
        SqlDataReader read = null;
        string result = "";

        System.Console.WriteLine("Enter Employee Number");
        int no = Convert.ToInt32(Console.ReadLine());
        cmd.Parameters.AddWithValue("@eNo", no);

        try{
        con.Open();
             read = cmd.ExecuteReader();

            //sqldataReader is a collection type that can read all columns
                if(read.Read())
                {
                    //
                    result = "Employee No: " + read[0] + 
                    "\n Employee Name: " + read[1] +
                    "\n Employee Designation: " + read[2] +
                    "\n Employee City: " + read[3] +
                    "\n Employee Permanent?: " + read[4] +
                    "\n Employee Salary: " + read[5];

                } else {
                    result = "Employee does not exist";
                }
        } 
        catch(SqlException sqlexp)
        {
            throw new Exception(sqlexp.Message);
        }
        finally 
        {
            read.Close();
        con.Close();
        }
        return result;
    }
}