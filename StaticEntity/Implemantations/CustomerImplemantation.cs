using StaticEntity.Interfaces;
using StaticEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticEntity.Implemantations
{
    public class CustomerImplemantation : ICustomerInterface
    {
        public static List<Customer> list= new List<Customer>();
        public bool AddCustomer(string name, string surName)
        {
            list.Add(Customer.AddCustomer(name, surName));
            return true;
        }

        public void FirstAddCustomers()
        {
            Customer c1 = Customer.AddCustomer("İpek", "Taş");
            Customer c2 = Customer.AddCustomer("Emre", "Kaya");
            Customer c3 = Customer.AddCustomer("Bilgi", "Erol");
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
        }


        public List<Customer> GetCustomers()
        {
            return list;
        }


    }
}
