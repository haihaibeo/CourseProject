using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryModel
    {
        public int ID { get; private set; }
        public string Name { get; set; }

        public CategoryModel(DAL.Category cat)
        {
            this.ID = cat.ID;
            this.Name = cat.Name;
        }
        public CategoryModel()
        {

        }
    }
}
