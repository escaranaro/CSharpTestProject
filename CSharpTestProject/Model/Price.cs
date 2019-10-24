using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTestProject.Model
{
    public class Price
    {
        public PricesType PricesType { get; set; }
        public DayType DayofWeek { get; set; }
        public float Value { get; set; }
        public Hotel Hotel{ get; set; }
        internal bool ComparePriceKey(Price Item)
        {
            return this.DayofWeek == Item.DayofWeek && this.PricesType == Item.PricesType;
        }
        
    }
}
