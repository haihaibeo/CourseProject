using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public CustomerModel(Customer cust)
        {
            this.ID = cust.ID;
            this.Name = cust.Name;
            this.Address = cust.Address;
            this.Phone = cust.Phone;
        }
        public CustomerModel()
        {

        }
    }
}
