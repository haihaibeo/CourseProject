using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class PizzaDetailModel
    {
        public List<BLL.PizzaModel> Pizzas { get; set; }
        public List<BLL.SizeModel> Sizes { get; set; }

        public BLL.PizzaModel pizza { get; set; }
        public BLL.SizeModel size { get; set; }
        public int quant { get; set; }
    }
}
