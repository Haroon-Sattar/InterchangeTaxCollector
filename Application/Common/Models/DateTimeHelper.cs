using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace Common
{

	public static class DateTimeHelper
	{

        /// <summary>
        /// Common DateTime Methods.
        /// </summary>
        /// 
        public enum Quarter
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4
        }

        public enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public static bool IsWeekEnd(DateTime date)
        {
            return ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday));
            
        }
    }
}
