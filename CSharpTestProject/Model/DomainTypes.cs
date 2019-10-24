using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTestProject.Model
{
    public enum PricesType { Regular, Rewards }
    public enum DayType
    {
        Semana, FimdeSemana
    }

    static class ExtenderDayType
    {
        public static DayType ConvertoDayType(this DateTime date)
        {
            if (date.IsSemana())
                return DayType.Semana;
            else
                return DayType.FimdeSemana;
        }

        public static bool IsSemana(this DateTime date )
        {
            return (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday);
        }
        public static bool EqualsDate(this DayType val, DateTime date)
        {
            return val == date.ConvertoDayType();
        }
    }

}

