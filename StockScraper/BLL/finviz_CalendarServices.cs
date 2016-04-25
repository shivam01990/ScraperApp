using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class finviz_CalendarServices
    {
        #region--Instance--
        public static finviz_CalendarServices Instance = new finviz_CalendarServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_finviz_Calendar(finviz_Calendar rr)
        {
            long finviz_calendar_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.finviz_calendar_id == 0)
                {
                    int count = db.finviz_Calendar.Where(f => f.calendar_dd == rr.calendar_dd
                         && (f.calendar_yyyy == rr.calendar_yyyy) && (f.calendar_mm == rr.calendar_mm)).Count();
                    if (count > 0)
                    {
                        return 0;
                    }
                }

                if (rr.finviz_calendar_id > 0)
                {
                    finviz_Calendar temp = db.finviz_Calendar.Where(u => u.finviz_calendar_id == rr.finviz_calendar_id).FirstOrDefault();

                    if (temp != null)
                    {

                        temp.job_run_id = rr.job_run_id;
                        temp.calendar_date_text = rr.calendar_date_text;
                        temp.calendar_yyyy = rr.calendar_yyyy;
                        temp.calendar_mm = rr.calendar_mm;
                        temp.calendar_dd = rr.calendar_dd;
                        temp.calendar_day = rr.calendar_day;
                        temp.banner_date = rr.banner_date;
                        temp.time_zone = rr.time_zone;
                        temp.calendar_date = rr.calendar_day;
                        temp.market_closed = rr.market_closed;
                        temp.official_market_closure = rr.official_market_closure;
                        temp.market_closure_notes = rr.market_closure_notes;
                    }
                }
                else
                {
                    db.finviz_Calendar.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    finviz_calendar_id = rr.finviz_calendar_id;
                }
            }

            return finviz_calendar_id;
        }
        #endregion

        public bool IsEffectiveDateExist(string dd, string mm, string yyyy)
        {
            int count = 0;
            using (DBEntities db = new DBEntities())
            {
                count = db.finviz_Calendar.Where(f => f.calendar_dd == dd
                      && (f.calendar_yyyy == yyyy) && (f.calendar_mm == mm)).Count();

            }
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
