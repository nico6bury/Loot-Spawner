using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public List<Item> Items { get; private set; }
        /// <summary>
        /// This HashSet list all the items within the Items List
        /// that are active, this being decided based on whether or not
        /// they have a Quantity greater than 0. It can be getted to
        /// take a look at it, but to remove anything from anything,
        /// one must use the provided methods.
        /// </summary>
        public HashSet<Item> Inventory { get; private set; }
        
        /// <summary>
        /// don't use this constructor if you want to actually use
        /// this object
        /// </summary>
        public Category()
        {
            this.Name = "Not Initialized";
            this.Items = new List<Item>();
        }//end no-arg constructor

        /// <summary>
        /// simple constructor for just initializing the name
        /// as well as getting the Items list initialized
        /// </summary>
        /// <param name="name">the name of this category</param>
        public Category(string name)
        {
            this.Name = name;
            this.Items = new List<Item>();
        }//end 1-arg constructor

        /// <summary>
        /// This method randomly selects an Item from the Items
        /// list, increases its quantity based on QuantSpec.
        /// From there, it adds any item it increases the quantity
        /// of to the Inventory HashSet. It also returns the item
        /// object which it added to the quantity of.
        /// </summary>
        public Item SelectItem()
        {
            Random r = new Random();
            int index = r.Next(0, Items.Count);
            Item selected = Items[index];
            selected.AddQuantity(1);
            return selected;
        }//end SelectItem()

        /// <summary>
        /// Allows you to remove a single item from Inventory
        /// and reset its quantity count.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveFromInventory(Item item)
        {
            item.Quantity = 0;
            Inventory.Remove(item);
        }//end RemoveFromInventory(item)

        /// <summary>
        /// This method resets quantity of all items in category
        /// and clears the inventory hashset
        /// </summary>
        public void ClearInventory()
        {
            foreach (Item item in Inventory)
            {
                item.Quantity = 0;
            }//end looping to reset each quantity
            Inventory.Clear();
        }//end ClearInventory()
    }//end class
}//end namespace