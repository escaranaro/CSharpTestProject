using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTestProject.Model
{
    public class Hotel
    {
         public int Id { get; set; }         
         public int Stars { get; set; }
         public string Name { get; set; }
         public List<Price> Prices{ get;  set; }

        public void Add(Price item)
        {
            if (this.Prices == null) this.Prices = new List<Price>();

            if (this.Prices.Where(x => x.ComparePriceKey(item)).Any())
                throw new System.ArgumentException("Item duplicado");

            item.Hotel = this;
            this.Prices.Add(item);
        }
        
    }
}
