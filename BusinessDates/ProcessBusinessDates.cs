using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDates
{
    /// <summary>
    /// Test Scenarios
    /// 12/24/2021  =>  01/03/2021  4 days
    /// 09/03/2021  ->  09/09/2021  3 days
    /// 09/06/2021  ->  09/09/2021  3 days
    /// 10/08/2021  ->  10/14/2021  3 days
    /// </summary>
    /// <returns></returns>
    internal class ProcessBusinessDates
    {
        private Holidays_2021 secHolidays;

        public ProcessBusinessDates()
        {
            secHolidays = new Holidays_2021();
        }
        internal DateTime AddBusinesDays(DateTime _date, int businessDays)
        {
            DateTime retVal = new DateTime();
            DateTime tmpBusDate = _date;

            do
            {
                tmpBusDate = SkipToMonday(tmpBusDate);
                tmpBusDate = tmpBusDate.AddDays(businessDays);
                tmpBusDate = SkipHolidays(tmpBusDate);
            } while (IsWeekend(ref tmpBusDate));

            retVal = tmpBusDate;

            return retVal;
        }

        internal DateTime SkipToMonday(DateTime _date)
        {
            switch (_date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    _date = _date.AddDays(3);
                    break;
                case DayOfWeek.Saturday:
                    _date = _date.AddDays(2);
                    break;

                case DayOfWeek.Sunday:
                    _date = _date.AddDays(1);
                    break;
            }
            return _date;
        }
        /// <summary>
        /// Assumption  You cant have 2 holidays in a row.
        /// </summary>
        /// <param name="_date"></param>
        /// <returns></returns>
        internal DateTime SkipHolidays(DateTime _date)
        {
            if (secHolidays.IsSecHoliday(_date))
            {
                _date = _date.AddDays(1);
                _date = SkipToMonday(_date);
            }
            return _date;
        }

        internal bool IsWeekend(ref DateTime _date)
        {
            if (_date.DayOfWeek == DayOfWeek.Saturday || _date.DayOfWeek == DayOfWeek.Sunday)
            {
                _date = SkipToMonday(_date);
                return true;
            }
            return false;
        }
    }
}
