using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XIVApp.Classes
{
    /// <summary>
    /// A sorted list of a fixed size.  
    /// </summary>
    public class FixedSortedList<K, V> : SortedList<K, List<V>>
    {
        /// <summary>
        /// Maximum capacity of the list. 
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Create a new fixed size list with a limit. 
        /// </summary>
        /// <param name="limit"></param>
        public FixedSortedList(int limit)
        {
            this.Limit = limit;
        }

        /// <summary>
        /// Gets the number of elements contains in the FixedSortedList. 
        /// </summary>
        public int CountItems
        {
            get { return this.Sum(x => x.Value.Count); }
        }

        /// <summary>
        /// Adds a value but removes the oldest or 
        /// minimum value in the list. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddItem(K key, V value)
        {
            // Does not contain the key, create one. 
            if (!this.ContainsKey(key))
                this[key] = new List<V>();

            // Add a value to the key / values pairing. 
            this[key].Add(value);

            // Remove one chatline from the oldest list of chatlines. 
            if (this.CountItems > Limit && this.CountItems > 0)
            {
                // remove a single list item. 
                this.First().Value.Remove(this.First().Value.First());

                // List no longer contains items, remove it. 
                if (this.First().Value.Count == 0)
                {
                    this.Remove(this.First().Key);
                }
            }
        }
    }
}
