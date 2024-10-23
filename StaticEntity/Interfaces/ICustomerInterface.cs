using StaticEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticEntity.Interfaces
{
    public interface ICustomerInterface
    {
        public List<Customer> GetCustomers();
        public void FirstAddCustomers();
        public bool AddCustomer(string name, string surName);
    }
}
