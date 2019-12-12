using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SizeModel
    {
        public int ID { get; private set; }
        public string SizeName { get; set; }
        public float Ratio { get; set; }

        public SizeModel(DAL.Size size)
        {
            this.ID = size.ID;
            this.SizeName = size.SizeName;
            this.Ratio = size.Ratio;
        }

        public SizeModel()
        {
                
        }
    }
}
