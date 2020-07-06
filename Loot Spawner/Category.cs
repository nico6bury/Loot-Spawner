using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot_Spawner
{
    class Category
    {
        /// <summary>
        /// This is the name of this category, it holds the information for a
        /// single text file.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// the list of all possible items for this category. For items with higher
        /// than normal chances to be selected, simply add duplicates.
        /// TO DO: Potentially set something up with both a List and a HashSet so that
        /// when you add an item it adds to both, and when you just want the non-duplicates
        /// then you get the hashset, and that would certainly be nifty.
        /// </summary>
        public List<Item> Items { get; set; }
    }//end class
}//end namespace