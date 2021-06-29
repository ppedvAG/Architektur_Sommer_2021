using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank
{
    public class OpeningHours
    {

        private Dictionary<DayOfWeek, Times> days = new Dictionary<DayOfWeek, Times>();

        public OpeningHours()
        {
            #region create TimeData
            days.Add(DayOfWeek.Monday, new Times()
            {
                Start = new TimeSpan(10, 30, 0),
                End = new TimeSpan(19, 0, 0)
            });

            days.Add(DayOfWeek.Tuesday, new Times()
            {
                Start = new TimeSpan(10, 30, 0),
                End = new TimeSpan(19, 0, 0)
            });

            days.Add(DayOfWeek.Wednesday, new Times()
            {
                Start = new TimeSpan(10, 30, 0),
                End = new TimeSpan(19, 0, 0)
            });
            days.Add(DayOfWeek.Thursday, new Times()
            {
                Start = new TimeSpan(10, 30, 0),
                End = new TimeSpan(19, 0, 0)
            });
            days.Add(DayOfWeek.Friday, new Times()
            {
                Start = new TimeSpan(10, 30, 0),
                End = new TimeSpan(19, 0, 0)
            });
            days.Add(DayOfWeek.Saturday, new Times()
            {
                Start = new TimeSpan(10, 30, 0),
                End = new TimeSpan(14, 0, 0)
            });
            #endregion
        }



        public bool IsOpen(DateTime time)
        {
            return
                   days.ContainsKey(time.DayOfWeek) &&
                   days[time.DayOfWeek].Start <= time.TimeOfDay &&
                   days[time.DayOfWeek].End > time.TimeOfDay;
        }


    }

    public struct Times
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

    }
}
