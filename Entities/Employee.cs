using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance.Entities
{
    internal class Employee
    {
        protected string id; //dont use private if children need to access it
        protected string name;
        protected string address;
        protected string phone;
        protected long sin;
        protected string birthday;
        protected string department;      

        public string Id 
        { 
            get { return id; } 
        }
        public string Name
        {
            get => name;
        }
        public string Address
        {
            get => address;
        }
        public string Phone
        {
            get => phone;
        }
        public long Sin
        {
            get => sin;
        }
        public string Birthday
        {
            get => birthday;
        }
        public string Department
        {
            get => department;
        }
        public virtual double Pay
        {
            get
            {
                return 0;
            }
        }


        public Employee() //no-arg constructor
        {

        }
        //public Employee(string id, string name, string address, string phone, long sin, string birthday, string department) //user-defined constructor
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.address = address;
        //    this.phone = phone;
        //    this.sin = sin;
        //    this.birthday = birthday;
        //    this.department = department;
        //}
    }
}
