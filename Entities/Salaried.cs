using Lab2_Inheritance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance.Entities
{
    internal class Salaried : Employee
    {
        private double salary;

        public double Salary
        {
            get
            {
                return salary;
            }
        }
        public override double Pay
        {
            get
            {
                return salary;
            }
        }

        public Salaried(string id, string name, string address, string phone, long sin, string birthday, string department, double salary)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthday = birthday;
            this.department = department;
            this.salary = salary;
        }
        public double CalcPay()
        {
            double pay = this.salary;
            double total = 0;
            total += pay;
            return total;
        }
    }
}
