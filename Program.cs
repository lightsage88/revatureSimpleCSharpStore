using System;
using System.Data.SqlClient;

namespace EmployeeManagementSolution
{
    class Program
    {
        static void Main(string[] args)
        {
        bool continueoptions = true;
            while(continueoptions)
            {
                System.Console.WriteLine("Welcome to Employee Management Solution");
                EmployeeOperations operationObj = new EmployeeOperations();
                System.Console.WriteLine("------------------------------ Choose from options below -------------------");
                System.Console.WriteLine("1. View Employee");
                System.Console.WriteLine("2. Add Employee");
                System.Console.WriteLine("3. Delete Employee");
                System.Console.WriteLine("4. Update Employee");
                System.Console.WriteLine("5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        string result = operationObj.GetEmployee();
                        System.Console.WriteLine(result);
                        break;
                    case 2:
                        operationObj.AddEmployee();
                        System.Console.WriteLine("Employee added successfully");
                        break;
                    case 3:
                        operationObj.DeleteEmployee();
                        System.Console.WriteLine("Employee deleted successfully");
                        break;
                    case 4:
                        operationObj.UpdateEmployee();
                        System.Console.WriteLine("Employee Updated Successfully");
                        break;
                    case 5: 
                        System.Console.WriteLine("Thank you for using my solution");
                        break;
                    default:
                        System.Console.WriteLine("Sorry, invalid option");
                        break;
                }
                // Console.ReadLine();
                System.Console.WriteLine("Do you wanna conitnue?");
                System.Console.WriteLine("1. Yes \n 2. No");
                int choose = Convert.ToInt32(Console.ReadLine());
                if(choose == 2)
                {
                    continueoptions = false;
                }
            } 
        }  
    }
}
