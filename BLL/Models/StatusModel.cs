using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StatusModel
    {
        public int ID { get; set; }
        public string Status { get; set; }

        public StatusModel() { }

        public StatusModel(DAL.Status status)
        {
            this.ID = status.ID;
            this.Status = status.Status1;
        }
    }
}
