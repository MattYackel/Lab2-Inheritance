using System;
using System.IO; //Need for using files (input output)
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2_Inheritance.Entities;

namespace Lab2_Inheritance
{
    /// <summary>
    /// Lab 2: Inheritance
    /// </summary>
    /// <remarks>Author: Matt Yackel</remarks>
    /// <remarks>Date: Jan 30 2023</remarks>
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Employees.txt"; //use relative path not absolute. @ to use \.
            string[] linesArray; //[] after datatype to create an array 
            linesArray = File.ReadAllLines(path); //fill the array with lines in the file
            List<Employee> employees = new List<Employee>(); //create a list that holds the parent objects (Employees)

            foreach (string line in linesArray)
            {
                string[] parts = line.Split(":"); //split line into an array
                string id = parts[0];
                string name = parts[1];
                string address = parts[2];
                string phone = parts[3];
                long sin = long.Parse(parts[4]); //convert string to long
                string birthday = parts[5];
                string department = parts[6];
                //[7] can be rate salary
                //[8] is hours worked if not salaried

                string firstDigit; //get first digit in id# (0-9)
                firstDigit = id.Substring(0, 1); //get a string from a string. (startindex, endindex);
                int firstNum = int.Parse(firstDigit); //convert string to int

                if (firstNum >= 0 && firstNum <= 4)
                {
                    //Salary
                    double salary = double.Parse(parts[7]); //convert string to double
                    Salaried salaried = new Salaried(id, name, address, phone, sin, birthday, department, salary); //create new salary object
                    employees.Add(salaried);
                }
                else if (firstNum >= 5 && firstNum <= 7)
                {
                    //Waged                   
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    Waged waged = new Waged(id, name, address, phone, sin, birthday, department, rate, hours);
                    employees.Add(waged); //add to the list
                }
                else if (firstNum >= 8 && firstNum <= 9)
                {
                    //PartTime
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    PartTime partTime = new PartTime(id, name, address, phone, sin, birthday, department, rate, hours);
                    employees.Add(partTime);
                }
            }

            //Outputs

            //average employee pay
            double averageWeeklyPay = CalcAverage(employees);
            //call CalcAverage and pass the employees list
            Console.WriteLine(string.Format("Average weekly pay: {0:C2}", averageWeeklyPay));

            //highest waged employee 
            Employee highestWaged = Highest(employees);
            Console.WriteLine(string.Format("Employee with the highest wage is {0} with {1:C2}", highestWaged.Name, highestWaged.Pay));

            //lowest salaried employee 
            Employee lowestSalaried = Lowest(employees);
            Console.WriteLine(string.Format("Employee with the lowest salary is {0} with {1:C2}", lowestSalaried.Name, lowestSalaried.Pay));

            //% in each employee category
            Percent(employees);
        }

        //Methods
        private static double CalcAverage(List<Employee> employees)
        {
            //Calculate the average pay of all employees
            double total = 0;
            foreach (Employee employee in employees)
            {
                if (employee is PartTime partTime) //2nd partTime is a new variable
                {
                    double pay = partTime.Pay;
                    total += pay;
                }
                else if (employee is Waged waged)
                {
                    double pay = waged.Pay;
                    total += pay;
                }
                else if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay; //salaried.Salary has the same get return
                    total += pay;
                }
            }
            //double average = total / employees.Count;
            //return average;
            return total / employees.Count; //Count: # of elements in the list
        }



        private static Waged Highest(List<Employee> employees)
        {
            //find the employee with the highest waged pay
            double highest = 0;
            Waged highestWagedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Waged waged)
                {
                    double pay = waged.Pay;

                    if (pay > highest)
                    {
                        highest = pay;
                        highestWagedEmployee = waged;
                    }
                }
            }
            return highestWagedEmployee;
        }



        public static Salaried Lowest(List<Employee> employees)
        {
            //find the lowest paid salaried employee
            double lowest = double.MaxValue; //max value for double
            Salaried lowestSalariedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    double pay = salaried.Salary;

                    if (pay < lowest)
                    {
                        lowest = pay;
                        lowestSalariedEmployee = salaried;
                    }
                }
            }
            return lowestSalariedEmployee;
        }



        private static void Percent(List<Employee> employees)
        {
            //calculate what % of employees each category has
            double counterPartTime = 0;
            double counterSalaried = 0;
            double counterWaged = 0;

            foreach (Employee employee in employees)
            {
                if (employee is PartTime)
                {
                    counterPartTime += 1;
                }
                else if (employee is Waged)
                {
                    counterWaged += 1;
                }
                else if (employee is Salaried)
                {
                    counterSalaried += 1;
                }                
            }
            double percentPartTime = counterPartTime / employees.Count; //use :P2 so we dont need to * by 100
            double percentWaged = counterWaged / employees.Count;
            double percentSalaried = counterSalaried / employees.Count;

            //output percentages
            Console.WriteLine($"Part Time: {percentPartTime:P2}\nWaged: {percentWaged:P2}\nSalaried: {percentSalaried:P2}");
        }

    }
}