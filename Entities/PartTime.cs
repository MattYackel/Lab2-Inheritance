using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance.Entities
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;

        public double Rate
        {
            get { return rate; }
        }
        public double Hours
        {
            get { return hours; }
        }
        public override double Pay
        {
            get 
            {
                double pay = rate * hours;
                return pay;
            }
        }
        public PartTime(string id, string name, string address, string phone, long sin, string birthday, string department, double rate, double hours)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthday = birthday;
            this.department = department;
            this.rate = rate;
            this.hours = hours;
        }
        public double CalcPay()
        {
            double rate = this.rate;
            double hours = this.hours;

            double pay = rate * hours;
            return pay;

        }
    }
}
