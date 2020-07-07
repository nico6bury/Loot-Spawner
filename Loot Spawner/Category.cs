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
        /// this variable is updated within a couple methods and
        /// tells you if there are any items with a quantity greater
        /// than zero
        /// </summary>
        public bool ContainsActiveItems { get; private set; }

        /// <summary>
        /// don't use this constructor if you want to actually use
        /// this object
        /// </summary>
        public Category()
        {
            this.Name = "Not Initialized";
            this.Items = new List<Item>();
            ContainsActiveItems = false;
            Inventory = new HashSet<Item>();
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
            ContainsActiveItems = false;
            Inventory = new HashSet<Item>();
        }//end 1-arg constructor

        /// <summary>
        /// Returns a string representation of this object, and by
        /// that I mean it returns the name.
        /// </summary>
        /// <returns>returns String of this object</returns>
        public override string ToString()
        {
            return Name;
        }//end ToString()

        /// <summary>
        /// Method to add an Item to this Category
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="cost">base cost of the item</param>
        /// <param name="weight">weight of the item in pounds</param>
        /// <param name="quantSpec">Quantity Specification of this
        /// item. Leave as empty string if none</param>
        /// <param name="description">description of the item</param>
        public void AddItem(string name, int cost, double weight, 
            string quantSpec, string description)
        {
            Items.Add(new Item(name, description, cost, weight, quantSpec));
        }//end AddItem(name, cost, weight, description)

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
            Inventory.Add(selected);
            ContainsActiveItems = true;
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
            if(Inventory.Count == 0) ContainsActiveItems = false;
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
            ContainsActiveItems = false;
        }//end ClearInventory()
    }//end class
}//end namespace