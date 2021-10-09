using System;
using System.Data;
using System.Text;
namespace BusinessDates
{
    class Program
    {
        static int Main(string[] args)
        {
            int retVal = 0;
            if(args.Length > 0)
            {
                switch (args[0])
                {
                    case "DisplaySecHolidays":
                        DisplaySecHolidays();
                        retVal =  0;
                        break;
                    case "IsThisAHoliday":
                        DateTime input = Convert.ToDateTime(args[1]);
                        if (IsThisAHoliday(input))
                        {
                            Console.WriteLine($"{input.ToString("dd-MMM-yyyy")} is a holiday");
                            return 0;
                        }
                        Console.WriteLine($"{input.ToString("dd-MMM-yyyy")} is not a holiday");
                        return 1;
                    case "AddBusinesDays":
                        DateTime date = Convert.ToDateTime(args[1]);
                        int days = Convert.ToInt32(args[2]);
                        var data = AddBusinesDays(date, days);
                        Console.WriteLine($"Old Date: {date} \t\t\t New Date: {data} {data.DayOfWeek}");
                        break;
                    default:
                        Console.WriteLine(Usage);
                        retVal = 1;
                        break;
                }
            }
            else
            {
                Console.WriteLine(Usage);
                retVal =  1;
            }
            //Console.Read();
            return retVal;
            
        }
        static DateTime AddBusinesDays(DateTime _date, int businessDays)
        {
            ProcessBusinessDates busDates = new ProcessBusinessDates();
            DateTime retVal = busDates.AddBusinesDays(_date, businessDays);

            return retVal;
        }

        static bool IsThisAHoliday(DateTime value)
        {
            bool retVal = false;
            Holidays_2021 holidays = new Holidays_2021();
            retVal = holidays.IsSecHoliday(value);

            return retVal;
        }
        static void DisplaySecHolidays()
        {
            Holidays_2021 holidays = new Holidays_2021();
            foreach (DataRow h in holidays.SecHolidays().Rows)
            {
                Console.WriteLine($"{Convert.ToString(h["Holiday"]).PadRight(30)} \t\t\t {Convert.ToDateTime(h["Date"]).ToString("dd-MMM-yyyy")}");
            }
        }

        static string Usage
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Please enter an argument");
                return sb.ToString();
            }
        }
    }
}