using CSharpTestProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpTestProject.Control
{
    public class Control
    {
        static Regex regular =
                        new Regex(@"(Regular|Rewards)\:\s(\d{2}\w{3}\d{4})\D{5,6}\,\s(\d{2}\w{3}\d{4})\D{5,6}\,\s(\d{2}\w{3}\d{4})\D{5,6}",
                                        RegexOptions.Singleline|RegexOptions.Compiled);
        static private volatile  Control objInstace = null;
        List<Hotel> Hotels = new List<Hotel>();
        List<Price> PricesHotels = new List<Price>();

        KeyValuePair<PricesType, List<DateTime>> Filters = new KeyValuePair<PricesType, List<DateTime>>();
        private Control()
        { 
        }

         
        public static Control Instance()
        {
            object objectControl;
            lock (objectControl = new object())
            {
                if (objInstace == null) objInstace = new Control();
            }

            return objInstace;
        }

        internal void Input(string item)
        {
            Match matches = regular.Match(item);
            var dates = new List<DateTime>{
                      DateTime.Parse(matches.Groups[2].Value.Trim()),
                      DateTime.Parse(matches.Groups[3].Value.Trim()),
                      DateTime.Parse(matches.Groups[4].Value.Trim())
                };
            Filters = new KeyValuePair<PricesType, List<DateTime>>(Enum.Parse<PricesType>(matches.Groups[1].Value.Trim()), dates );

        }

        internal Hotel Search()
        {
            List<Price> values = new List<Price>();

            foreach (var item in Filters.Value)
            {
                var filter = PricesHotels.Where(x => x.PricesType == Filters.Key && x.DayofWeek.EqualsDate(item))
                    .OrderBy(x => x.Value).ThenBy(x => x.Hotel.Stars);
                if(filter.Any())
                    values.Add(filter.FirstOrDefault());                
            }

            return values.OrderBy(x => x.Value).ThenBy(x => x.Hotel.Stars).First().Hotel;

        }

        internal void Binding(List<Hotel> list)
        {
            this.Hotels = list;
            foreach (var item in list)
            {
                PricesHotels.AddRange(item.Prices);
            }
        }
    }
}
