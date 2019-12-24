using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetailModel
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int Size_ID { get; set; }

        public DetailModel(DAL.Detail detail)
        {
            this.ID = detail.ID;
            this.Quantity = detail.Quantity;
            this.Size_ID = detail.Size_ID;
        }

        public DetailModel()
        {
                
        }

    }
}
