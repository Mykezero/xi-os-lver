using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XIVApp.Classes
{
    /// <summary>
    /// A list with a fixed limit that can return values within a 
    /// certain window of time. 
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public class TimeSortedList<V> : FixedSortedList<DateTime, V>
    {
        /// <summary>
        /// The window limit in terms of seconds. 
        /// </summary>
        public int Window { get; set; }

        /// <summary>
        /// Sets the max list size and window length. 
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="window"></param>
        public TimeSortedList(int limit, int window) : base(limit) 
        {
            this.Window = window;
        }

        /// <summary>
        /// Return all values within the window. 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<V> GetValuesInWindow()
        { 
            // Prevous: 1m
            // Prevous 1m 10s
            // Current: 1m 40s
            // We want chatlines that are within between 
            // 1m 30s and 1m 40s

            return this.Where(x=> x.Key.AddSeconds(Window) >= DateTime.Now)
                .SelectMany(x => x.Value);
        }
    }
}
