using CSharpTestProject.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CSharpTestProject
{
    public class SampleUnitTest
    {
        [Fact]
        public void ShouldFail()
        {
            var lakewood = new Hotel()
            {
                Id = 1,
                Name = "Lakewood",
                Stars = 3
            };
            lakewood.Add(new Price()
            {
                DayofWeek = DayType.Semana,
                PricesType = PricesType.Regular,
                Value = 110
            });

            lakewood.Add(new Price()
            {
                DayofWeek = DayType.Semana,
                PricesType = PricesType.Rewards,
                Value = 80
            });

            lakewood.Add(new Price()
            {
                DayofWeek = DayType.FimdeSemana,
                PricesType = PricesType.Regular,
                Value = 90
            });

            lakewood.Add(new Price()
            {
                DayofWeek = DayType.FimdeSemana,
                PricesType = PricesType.Rewards,
                Value = 80
            });

            var bridgewood = new Hotel()
            {
                Id = 2,
                Name = "Bridgewood",
                Stars = 4
            };

            bridgewood.Add(new Price()
            {
                DayofWeek = DayType.Semana,
                PricesType = PricesType.Regular,
                Value = 160
            });

            bridgewood.Add(new Price()
            {
                DayofWeek = DayType.Semana,
                PricesType = PricesType.Rewards,
                Value = 110
            });

            bridgewood.Add(new Price()
            {
                DayofWeek = DayType.FimdeSemana,
                PricesType = PricesType.Regular,
                Value = 60
            });

            bridgewood.Add(new Price()
            {
                DayofWeek = DayType.FimdeSemana,
                PricesType = PricesType.Rewards,
                Value = 50
            });

            var ridgewood = new Hotel()
            {
                Id = 3,
                Name = "Ridgewood",
                Stars = 5
            };

            ridgewood.Add(new Price()
            {
                DayofWeek = DayType.Semana,
                PricesType = PricesType.Regular,
                Value = 220
            });

            ridgewood.Add(new Price()
            {
                DayofWeek = DayType.Semana,
                PricesType = PricesType.Rewards,
                Value = 110
            });

            ridgewood.Add(new Price()
            {
                DayofWeek = DayType.FimdeSemana,
                PricesType = PricesType.Regular,
                Value = 150
            });

            ridgewood.Add(new Price()
            {
                DayofWeek = DayType.FimdeSemana,
                PricesType = PricesType.Rewards,
                Value = 40
            });

            List<string> entradas = new List<string>{
                "Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)",
                "Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)",
                "Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)"
            };

            Control.Control.Instance().Binding(new List<Hotel> { lakewood,ridgewood,bridgewood } );

            List<string> saidas = new List<string>{"Lakewood", "Bridgewood","Ridgewood"};
            for (int i = 0; i < entradas.Count; i++)
            {
                Control.Control.Instance().Input(entradas[i]);
                var result = Control.Control.Instance().Search();
                Assert.Equal(saidas[i], result.Name);
            }
            Assert.True(true);
        }
    }
}
