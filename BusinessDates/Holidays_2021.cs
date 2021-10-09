using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessDates
{
    internal class Holidays_2021
    {
        
        internal DataTable SecHolidays()
        {
            DataTable retVal = new DataTable();
            retVal.Columns.Add("Holiday", typeof(string));
            retVal.Columns.Add("Date", typeof(DateTime));

            DataRow row = retVal.NewRow();
            row.SetField("Holiday", "New Year's Day");
            row.SetField("Date", new DateTime(2021, 01, 01));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "");
            row.SetField("Date", new DateTime(2021, 01, 08));
            row = retVal.NewRow();
            row.SetField("Holiday", "Washington's Birthday");
            row.SetField("Date", new DateTime(2021, 02, 15));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "Memorial Day");
            row.SetField("Date", new DateTime(2021, 05, 31));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "Juneteenth (observed)");
            row.SetField("Date", new DateTime(2021, 06, 18));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "Independence Day (observed)");
            row.SetField("Date", new DateTime(2021, 07, 05));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "Labor Day");
            row.SetField("Date", new DateTime(2021, 09, 06));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "Columbus Day");
            row.SetField("Date", new DateTime(2021, 10, 11));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "Veterans Day");
            row.SetField("Date", new DateTime(2021, 11, 11));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "Thanksgiving Day");
            row.SetField("Date", new DateTime(2021, 11, 25));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "Christmas Day (observed)");
            row.SetField("Date", new DateTime(2021, 12, 24));
            retVal.Rows.Add(row);
            row = retVal.NewRow();
            row.SetField("Holiday", "New Year's Day");
            row.SetField("Date", new DateTime(2021, 12, 31));
            retVal.Rows.Add(row);

            return retVal;
        }

        internal bool IsSecHoliday(DateTime date)
        {
            var data = SecHolidays();
            foreach(DataRow d in data.Rows)
            {
                if(d["Date"] != DBNull.Value)
                {
                    var data1 = Convert.ToDateTime(d["Date"]);
                    if (data1 == date)
                    {
                        return true;
                    }
                }
               
            }
            return false;
        }
    }
}
