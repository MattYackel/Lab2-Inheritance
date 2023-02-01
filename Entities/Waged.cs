using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance.Entities
{
    internal class Waged : Employee //wages inherits from employee
    {
        private double rate;
        private double hours;

        public double Rate
        {
            get { return rate; }
        }
        public double Hours
        {
            get => hours;
        }
        public override double Pay
        {
            get
            {
                double rate = this.rate;
                double hours = this.hours;
                double pay = 0;

                if (hours > 40) //calculate pay with overtime
                {
                    double overtime = 0;
                    overtime = hours - 40;
                    pay = (rate * 1.5 * overtime) + (rate * 40);
                }
                else if (hours <= 40) //calculate pay with no overtime
                {
                    pay = rate * hours;
                }
                return pay;
            }
        }

        public Waged(string id, string name, string address, string phone, long sin, string birthday, string department, double rate, double hours)
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
    }
}
