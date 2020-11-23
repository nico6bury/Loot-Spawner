using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Current plan for getting things made
/// First: Get things working for totally easy items that don't
/// require use of the ItemOptions class
/// First and a Half: Get file input working
/// Second: Get things working for mundane items that use the
/// ItemOptions class for easy stuff like increase cost
/// Third: Get embellishments working
/// Fourth: Get enchantments working
/// 
/// Notes and TODOs:
/// 1. make sure there can't be duplicate items in different categories
/// 2. make probability property of items also affect category choice
/// 3. make probability a double instead of an integer and change item choice to remain compatible with this.
/// </summary>
namespace Loot_Spawner
{
    public partial class LootSpawner : Form
    {
        /// <summary>
        /// This List holds all the loaded categories that can
        /// have loot spawned from them. It holds basically all the
        /// information for the backend in a single list.
        /// </summary>
        private List<Category> Categories;
        public LootSpawner()
        {
            InitializeComponent();
            CreateCats();
        }//end constructor

        /// <summary>
        /// The click event for uxSpawnLoot.
        /// It uses information from uxLootAmount to spawn loot
        /// into uxResultsList which is a part of uxOutputGroup
        /// This method by itself just handles input validation,
        /// a helper method is used for actually doing things.
        /// </summary>
        /// <param name="sender">object that sent the event</param>
        /// <param name="e">event arguments</param>
        public void SpawnLoot(object sender, EventArgs e)
        {
            if (uxCategoryOptions.CheckedItems.Count > 0) CreateLoot();
            else MessageBox.Show("You have no selected categories", "",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//end SpawnLoot(sender, e)

        /// <summary>
        /// Contains all the backend stuff for SpawnLoot()
        /// </summary>
        private void CreateLoot()
        {
            //grab the number of times we need to generate loot
            int lootAmount = Convert.ToInt32(uxLootAmount.Value);
            SelectItem(lootAmount);
            DisplayActive();


            /* OBSOLETE method of choosing items
            //choose one of the categories to use
            //Random r = new Random();
            for (int i = 0; i < lootAmount; i++)
            {
                
                OBSOLETE method of generating items
                int index = r.Next(0, Categories.Count);
                Categories[index].SelectItem();
                
            }//end looping to select item for each lootAmount
            */
        }//end CreateLoot()

        /// <summary>
        /// Displays active items from all categories.
        /// A useful helper method
        /// </summary>
        private void DisplayActive()
        {
            //Grab all the items with active quantity and add them to list
            List<Item> DisplayList = new List<Item>();
            foreach (Category cat in Categories)
            {
                if (cat.ContainsActiveItems)
                {
                    //from here we need to add each item to our list
                    foreach (Item item in cat.Inventory)
                    {
                        DisplayList.Add(item);
                    }//end looping for each item in inventory
                }//end if we want to add it to our display list
            }//end looping for each category in Categories

            //Display the List in the ListBox
            uxResultsList.DataSource = null;
            uxResultsList.DataSource = DisplayList;

            //make sure we don't have empty listbox.
            if (uxResultsList.Items.Count == 0) uxOutputGroup.Enabled = false;
            //enable the group with all the output options
            else uxOutputGroup.Enabled = true;
        }//end DisplayActive

        /// <summary>
        /// The click event for uxSelectAll.
        /// Checks everything in uxCategoryOptions
        /// </summary>
        /// <param name="sender">object that sent the event</param>
        /// <param name="e">event arguments</param>
        public void SelectAllCats(object sender, EventArgs e)
        {
            for(int i = 0; i < uxCategoryOptions.Items.Count; i++)
            {
                uxCategoryOptions.SetItemCheckState(i, (true ? CheckState.Checked : CheckState.Unchecked));
            }//end looping over each item in uxCategoryOptions
        }//end SelectAllCats(sender, e)

        /// <summary>
        /// The click event for uxClearSelection.
        /// Unchecks everything in uxCategoryOptions
        /// </summary>
        /// <param name="sender">object that sent the event</param>
        /// <param name="e">event arguments</param>
        public void DeselectAllCats(object sender, EventArgs e)
        {
            for (int i = 0; i < uxCategoryOptions.Items.Count; i++)
            {
                uxCategoryOptions.SetItemCheckState(i, (false ? CheckState.Checked : CheckState.Unchecked));
            }//end looping over each item in uxCategoryOptions
        }//end DeselectAllCats(sender, e)
        
        /// <summary>
        /// Click event for uxShowDetail
        /// Shows details for selected item
        /// </summary>
        public void ShowDetails(object sender, EventArgs e)
        {
            try
            {
                Item selected = uxResultsList.SelectedItem as Item;
                //make sure the selected is an Item
                if (selected == null) throw new ArgumentException();
                StringBuilder message = new StringBuilder();
                StringBuilder caption = new StringBuilder();
                //build the caption for the message
                caption.Append(selected.Name);
                caption.Append("  x");
                caption.Append(selected.Quantity);
                //add cost and base cost to message
                message.Append("Cost: ");
                message.Append(selected.Cost);
                message.Append("\t(Base Cost: ");
                message.Append(selected.BaseCost);
                message.Append(")\n");
                //add weight to message
                message.Append("Weight: ");
                message.Append(selected.Weight);
                message.Append(selected.WeightType);
                message.Append("\n");
                //add description to message
                message.Append(selected.Description);

                MessageBox.Show(message.ToString(), caption.ToString(), 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end try
            catch
            {
                MessageBox.Show("I'm sorry, it appears that command is" +
                    " unavailable with the current conditions", "Unexpected" +
                    " Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//end catch
        }//end ShowDetails()

        /// <summary>
        /// Click event for uxAdjustQuantity
        /// Allows user to adjust quantity
        /// </summary>
        public void AdjustQuantity(object sender, EventArgs e)
        {
            try
            {
                Item selected = uxResultsList.SelectedItem as Item;

                //now we can get into asking the user what quantity they want
                bool finished = false;
                int Quant = -1;
                while (!finished)
                {
                    string nQuant = Microsoft.VisualBasic.Interaction.InputBox("" +
                    "What would you like this item's new quantity to be?", "Adjust" +
                    " Quantity");
                    try
                    {
                        if(nQuant == "") nQuant = selected.Quantity.ToString();
                        Quant = Convert.ToInt32(nQuant);
                        finished = true;
                    }//end trying to convert quant to a integer
                    catch
                    {
                        MessageBox.Show("It appears that you have entered something" +
                            " which could not be interpreted as an integer. Please" +
                            " enter an integer number with no spaces or letters.");
                    }//end catching the user's error
                }//end looping while getting input from the user

                selected.SetQuantity(Quant);

                //we still need to figure out which category this item is in, just to be efficient
                Category foundCat = null;
                for (int i = 0; i < Categories.Count && foundCat == null; i++)
                {
                    foreach (Item item in Categories[i].Inventory)
                    {
                        if (selected.Equals(item))
                        {
                            foundCat = Categories[i];
                        }//end if selected equals this item
                    }//end looping through each item of this cat's inven
                }//end looping over each active item in categories
                 //just in case something whack happens
                if (foundCat == null) throw new ArgumentException();

                //now that we've found the cat, we can update its inventory
                foundCat.UpdateInventory();

                //now we just need to display the changes that we made
                DisplayActive();

            }//end try
            catch
            {
                MessageBox.Show("I'm sorry, it appears that command is" +
                    " unavailable with the current conditions", "Unexpected" +
                    " Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//end catch

        }//end AdjustQuantity()

        /// <summary>
        /// Click event for uxClearLoot
        /// It clears the loot from uxResultsList and also from the Categories
        /// </summary>
        public void ClearLoot(object sender, EventArgs e)
        {
            for(int i = 0; i < Categories.Count; i++)
            {
                Categories[i].ClearInventory();
            }//end looping to clear each category
            DisplayActive();
        }//end ClearLoot()

        /// <summary>
        /// Click event for uxShowTotal
        /// It shows some of the total stats for everything in uxResultsList
        /// </summary>
        public void ShowStats(object sender, EventArgs e)
        {
            //basically we just need to tally up the stats shown in uxResultList
            List<Item> items = new List<Item>();
            for(int i = 0; i < uxResultsList.Items.Count; i++)
            {
                Item cur = uxResultsList.Items[i] as Item;
                if (cur != null) items.Add(cur);
            }//end looping to add resultList into items

            //now to tally up everything
            List<string> weightTypes;
            List<double> weights;
            int[] results = GetBigStats(items, out weightTypes, out weights);
            int TotalCost = results[0];
            int TotalQuantity = results[1];

            //now to build the message
            StringBuilder message = new StringBuilder();
            message.Append("Here are your totals:\nTotal Quantity: "
                + TotalQuantity + "\nTotal Value: $" + 
                TotalCost + "\nTotal \"Weight\": ");
            for(int i = 0; i < weights.Count; i++)
            {
                message.Append(weights[i] + weightTypes[i] + ", ");
            }//end looping to add all the weights in
            message.Length -= 2;
            MessageBox.Show(message.ToString(), "Total Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//end ShowStats()

        /// <summary>
        /// A useful helper method to collect all the total stats
        /// about a group of items
        /// </summary>
        /// <param name="items">The list of items to search through</param>
        /// <param name="WeightTypes">will be list of weight types</param>
        /// <param name="Weights">will be list of weights, parallel to 
        /// WeightTypes</param>
        /// <returns>returns total cost as an integer</returns>
        private int[] GetBigStats(List<Item> items, 
            out List<string> WeightTypes, out List<double> Weights)
        {
            //index 0 is total cost
            //index 1 is total quantity
            int[] ArrayResults = new int[2];
            ArrayResults[0] = 0;
            ArrayResults[1] = 0;
            WeightTypes = new List<string>();
            Weights = new List<double>();
            for (int i = 0; i < items.Count; i++)
            {
                //add the current cost to the total tally
                ArrayResults[0] += (items[i].Cost * items[i].Quantity);
                ArrayResults[1] += items[i].Quantity;
                if (!WeightTypes.Contains(items[i].WeightType))
                {
                    WeightTypes.Add(items[i].WeightType);
                    Weights.Add(items[i].Weight * items[i].Quantity);
                }//end if this is a new type of weight measurement
                else
                {
                    Weights[WeightTypes.IndexOf(items[i].WeightType)] += 
                        (items[i].Weight * items[i].Quantity);
                }//end else we should add this to the weights list
            }//end looping to count all the things
            return ArrayResults;
        }//end GetBigStats(items, WeightTypes, Weights)

        /// <summary>
        /// Click event for uxOutputToText
        /// Allows the user to output all this information to text
        /// </summary>
        public void OutputText(object sender, EventArgs e)
        {
            //TODO: Write code to open a file and put stuff there
            using (uxSaveTxtDialog)
            {
                if (uxSaveTxtDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(uxSaveTxtDialog.FileName, BuildTextOutput());
                }//end if we got an OK for the result
            }//end use of uxSaveTxtDialog
            
            //TODO: Write method to build a list of lines to write in the file

        }//end OutputText()

        /// <summary>
        /// Actually builds all of the text to put in a file.
        /// Is a helper method for OutputText().
        /// Potentially outputs the following:
        /// Total Stats of all items,
        /// Total Weights for all of each item,
        /// Total Costs for all of each item,
        /// Item name, quantity, individual weight, base cost, cost,
        /// description of each item
        /// </summary>
        /// <returns>returns a string with all the information in it</returns>
        public string BuildTextOutput()
        {
            //first we create the StringBuilder to hold everything
            StringBuilder AllText = new StringBuilder();
            //now to tally up the totals
            List<Item> items = new List<Item>();
            for (int i = 0; i < uxResultsList.Items.Count; i++)
            {
                Item cur = uxResultsList.Items[i] as Item;
                if (cur != null) items.Add(cur);
            }//end looping to add resultList into items
            List<string> weightTypes;
            List<double> weights;
            int[] results = GetBigStats(items, out weightTypes, out weights);
            int TotalCost = results[0];
            int TotalQuantity = results[1];

            //now to build the message with totals
            AllText.Append("Here are your totals:\nTotal Quantity: "
                + TotalQuantity + "\nTotal Value: $" +
                TotalCost + "\nTotal \"Weight\": ");
            for (int i = 0; i < weights.Count; i++)
            {
                AllText.Append(weights[i] + weightTypes[i] + ", ");
            }//end looping to add all the weights in
            AllText.Length -= 2;
            AllText.Append("\n");

            //now we just need to add each Item to our thing
            foreach(Item item in items){
                AllText.Append(item.BuildInfoStr());
            }//end looping to add 

            return AllText.ToString();
        }//end BuildTextOutput()

        /// <summary>
        /// This enum is used in the ReadFile method as an essential
        /// part of a state machine within a for loop which parses each line.
        /// </summary>
        enum FileState
        {
            /// <summary>
            /// idek anymore tbh
            /// </summary>
            Idle,
            /// <summary>
            /// currently finished with the current thing
            /// </summary>
            Finished,
            /// <summary>
            /// currently parsing the name
            /// </summary>
            GettingName,
            /// <summary>
            /// currently parsing the cost
            /// </summary>
            GettingCost,
            /// <summary>
            /// currently parsing the weight
            /// </summary>
            GettingWeight,
            /// <summary>
            /// currently parsing the description
            /// </summary>
            GettingDesc,
            /// <summary>
            /// currently parsing the quantity specification
            /// </summary>
            GettingQuantSpec,
            /// <summary>
            /// currently parsing the probability
            /// </summary>
            GettingProbab
        }//end enum FileState

        /// <summary>
        /// This method looks around a string in order to find the locations of new
        /// properties
        /// </summary>
        /// <param name="s">the string to search in</param>
        /// <param name="propertyShorthands">char array of all the letters that start
        /// a new property</param>
        /// <returns>list of index locations where a property starts</returns>
        private List<int> FindPropertyStarts(string s, char[] propertyShorthands)
        {
            List<int> selectedLocations = new List<int>();

            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '-' && propertyShorthands.Contains(s[i+1]) && s[i+2] == '\"' && s[i-1] != '\\')
                {
                    selectedLocations.Add(i);
                }//end if we found a new property
            }//end looping for each character in s

            return selectedLocations;
        }//end FindPropertyStarts(s, propertyShorthands)

        /// <summary>
        /// Splits a string into several strings by splicing it up at
        /// the specified locations
        /// </summary>
        /// <param name="s">the string you want to split</param>
        /// <param name="locations">the locations where you're going
        /// to split the string</param>
        /// <returns></returns>
        private List<string> SplitBasedOnIndex(string s, List<int> locations)
        {
            List<string> splits = new List<string>();
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < s.Length; i++)
            {
                if (locations.Contains(i))
                {
                    splits.Add(sb.ToString());
                    sb.Clear();
                }//end if we need to split here
                else
                {
                    sb.Append(s[i]);
                }//end else we need to just add the char to the SB
            }//end looping for each character in s

            return splits;
        }//end SplitBasedOnIndex(s, locations)

        /// <summary>
        /// Click event for uxOpenFile
        /// Opens up a specified file and tries to read
        /// it in as a category.
        /// </summary>
        public void ReadFile(object sender, EventArgs e)
        {
            using(OpenFileDialog OpenFile = new OpenFileDialog())
            {
                if(OpenFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using(StreamReader scribe = new
                            StreamReader(OpenFile.FileName))
                        {
                            //building an appropriate name for the category
                            string[] fileparts = OpenFile.FileName.Split(new char[] { '\\' });
                            StringBuilder nameBuilder = new StringBuilder();
                            nameBuilder.Append(fileparts[fileparts.Length - 1]);
                            //this gets rid of the .txt part of the name
                            nameBuilder.Length -= 4;

                            Category newCat = new Category(nameBuilder.ToString());
                            while (!scribe.EndOfStream)
                            {
                                //begin actualy file input
                                string line = scribe.ReadLine();

                                // begin start of new input method
                                // get all those string pieces set up
                                char[] acceptedTypeShorthands = { 'n', 'c', 'w', 't', 'd', 'p', 'q' };
                                List<int> locations = FindPropertyStarts(line, acceptedTypeShorthands);
                                List<string> components = SplitBasedOnIndex(line, locations);

                                //set some default values
                                string name = "Object not named";
                                int cost = -1;
                                double weight = -1;
                                string weightType = "Arbitrary Units";
                                string description = "Object defies description";
                                string quantSpec = "";
                                int probability = 100;
                                StringBuilder sb = new StringBuilder();

                                if (components[0].ToLower().Equals("s"))
                                {
                                    for (int i = 1; i < components.Count; i++)
                                    {
                                        //build some tools for the if statement to make use of
                                        string comp = components[i];
                                        StringBuilder lineBuilder = new StringBuilder();
                                        for (int j = 2; j < (comp.Length - 1); j++)
                                        {
                                            lineBuilder.Append(comp[j]);
                                        }//end looping over some letters

                                        if (comp.ToLower()[0].Equals('n'))
                                        {
                                            name = lineBuilder.ToString();
                                        }//end if (n)ame prefix detected
                                        else if (comp.ToLower()[0].Equals('c'))
                                        {
                                            try
                                            {
                                                cost = Convert.ToInt32(lineBuilder.ToString());
                                            }//end trying to convert something
                                            catch
                                            {
                                                MessageBox.Show("Something happened while trying " +
                                                    "to convert your cost into an integer.\"" +
                                                    lineBuilder.ToString() + "\" was read as the cost," +
                                                    " but this can't be converted. " +
                                                    "\". Cost for \"" + name + "\" will be set to 0."
                                                    , "Conversion Error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }//end catching conversion errors
                                        }//end else if (c)ost prefix detected
                                        else if (comp.ToLower()[0].Equals('w'))
                                        {
                                            try
                                            {
                                                weight = Convert.ToDouble(lineBuilder.ToString());
                                            }//end trying to convert something
                                            catch
                                            {
                                                MessageBox.Show("Something happened while trying to convert " +
                                                    "the weight of \"" + name + "\" to a decimal. \"" +
                                                    lineBuilder.ToString() + "\" was read for the weight of this" +
                                                    " object, but this can't be converted.", "Conversion Error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }//end catching conversion errors
                                        }//end else if (w)eight prefix detected
                                        else if (comp.ToLower()[0].Equals('t'))
                                        {
                                            weightType = lineBuilder.ToString();
                                        }//end else if weight (t)ype prefix detected
                                        else if (comp.ToLower()[0].Equals('d'))
                                        {
                                            description = lineBuilder.ToString();
                                        }//end else if (d)escription prefix detected
                                        else if (comp.ToLower()[0].Equals('p'))
                                        {
                                            try
                                            {
                                                probability = Convert.ToInt32(lineBuilder.ToString());
                                            }//end trying to convert something
                                            catch
                                            {
                                                MessageBox.Show("Something happened while trying " +
                                                    "to convert the probability of \"" + name +
                                                    "\" into an integer." + "As \"" + lineBuilder.ToString() +
                                                    "\" couldn't be converted, probability for this object will" +
                                                    " be set to 100.", "Conversion Error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                probability = 100;
                                            }//end catching conversion errors
                                        }//end else if (p)robability prefix detected
                                        else if (comp.ToLower()[0].Equals('q'))
                                        {
                                            quantSpec = lineBuilder.ToString();
                                        }//end else if (q)uantity specification prefix detected
                                        else
                                        {
                                            probability = 0;
                                        }//end else the prefix is unrecognized
                                    }//end looping over each component simple case
                                    newCat.AddItem(name, cost, weight, weightType,
                                        quantSpec, description, probability);

                                }//end if the item is simple
                                else
                                {
                                    //errorbox
                                    MessageBox.Show("Based on your line input, it appears" +
                                        " that you have an item which isn't simple. I haven't" +
                                        " even built the classes or anything for more complicated" +
                                        " items yet, so I can't really do this line. Remember that" +
                                        " to distinguish that an item is simple, put an \"S\" followed" +
                                        " immediately by a dash. If you don't do that, the program" +
                                        " can't tell what you're trying to do.","Unsupported Item Type",
                                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                                }//end else the item is more complicated
                            }//end while scribe not at end of stream
                            Categories.Add(newCat);
                        }//end use of streamreader
                        uxCategoryOptions.DataSource = null;
                        uxCategoryOptions.DataSource = Categories;
                        SelectAllCats(null, null);
                    }//end trying to get input from file.
                    catch
                    {
                        //errorbox
                        MessageBox.Show("Unfortuneately it seems that " +
                            "your attempt to import a file has failed. This" +
                            " could be due to something happening either " +
                            "while the application opened the file or while " +
                            "reading the file. Either way, the file couldn't " +
                            "be read. You might try taking a closer look at the" +
                            " readme if it exists, or just try double checking " +
                            "that your file looks right.", "File Import Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }//end catching user's file error
                }//end if user pressed OK
                
            }//end use of OpenFile
        }//end ReadFile()        

        /// <summary>
        /// This is a helper method that selects an item based on 
        /// probabiltiy from all categories
        /// <param name="time">the number of times to get an item</param>
        /// </summary>
        private void SelectItem(int times)
        {
            //I'll need a way to randomly select weighted items
            //Below is the algorith I chose to use
            /* 1. Create an array of pairs of actual items and weight
             * of each item
             * 2. When you add an item, the weight of the item needs
             * to be its own weight plus the sum of the weights of all
             * items already in the array. (Sum should be tracked 
             * separately)
             * 3. To retrieve an object, generate a random number 
             * between 0 and the sum of the weights of all items.
             * 4. Iterate the array from start to finish until you 
             * found an entry with a weight larger or equal then the
             * random number.
             */

            //find the total number of items
            int itemNum = 0;
            for(int i = 0; i < Categories.Count; i++)
            {
                //add this catgegory's inventory count
                itemNum += Categories[i].Items.Count;
            }//end looping over each Category's Inventory's Count

            //now that we know the size, we can intialize our array
            ItemPair[] ItemPairs = new ItemPair[itemNum];
            int wtSum = 0;//sum of all weights
            for(int i = 0; i < Categories.Count; i++)
            {
                int j = 0;
                foreach(Item item in Categories[i].Items)
                {
                    ItemPairs[i + j].item = item;
                    ItemPairs[i + j].wt = item.Probability + wtSum;
                    wtSum += item.Probability;
                    j++;
                }//end looping over each item in inventory
            }//end looping for each category

            //now to generate all the random indexes
            /* change wtSel array to be a BinaryTree so that 
             * it's automatically sorted, and then we'll want
             * to maybe tranfer that to a queue or stack to use
             * during the next step.
             * Note: just sort list instead of using BinaryTree
             */
            List<int> wtSel = new List<int>();
            Random r = new Random();
            for (int i = 0; i < times; i++)
            {
                wtSel.Add(r.Next(0, wtSum));
            }//end adding times number of random numbers
            //transfer wtSel to queue
            wtSel.Sort();
            int cur = 0;//current index of wtSel that we're at

            //now to pick out all the randomly gotten items
            for(int i = 0; i < ItemPairs.Length && cur < wtSel.Count; i++)
            {
                if(ItemPairs[i].wt > wtSel[cur])
                {
                    //add item to list somehow
                    ItemPairs[i].item.AddQuantity(1);
                    //perform counter maintenance
                    cur++;
                    i--;
                }//end if we found an item
            }//end looping over each item

            //in order to make sure we've kept track of the items
            //that are now active, we need to update inventories
            foreach(Category cat in Categories)
            {
                cat.UpdateInventory();
            }//end updating inventory for each category in categories
        }//end SelectItem()

        /// <summary>
        /// This struct holds an Item and a probabilitistical
        /// weight. The weight represents the relative chance
        /// for the Item to be chosen. Also, this is the first
        /// time I've ever used a struct before. Woo.
        /// </summary>
        struct ItemPair
        {
            /// <summary>
            /// This is the item part of this item pair. So,
            /// in other words, if this ItemPair is selected, 
            /// then it means that this Item object has been 
            /// chosen.
            /// </summary>
            public Item item;

            /// <summary>
            /// this is the weight of the item pair in terms 
            /// of probabilistic chances of this item being 
            /// selected. It's named wt instead of weight in
            /// order to avoid getting it confused with the 
            /// weight property of the Item class.
            /// </summary>
            public int wt;
        }//end struct ItemPair

        /// <summary>
        /// A testing method which will create my sample categories
        /// through hardcoded commands and make them show up in the
        /// GUI.
        /// </summary>
        private void CreateCats()
        {
            Categories = new List<Category>();

            //add spices
            if (false)
            {
                Categories.Add(new Category("Spices"));
                double weight = 1;
                string wt = "oz";
                string qs = "1d/2";
                string descAdd0 = "As a spice, this item's quantity refers" +
                    " to how many ounces there are. An ounce is one sixteenth" +
                    " of a pound. Spice is a lightweight trading good with relatively" +
                    " high value. Alchemists who are short on cash but have spices can" +
                    " use their value to offset half the cost of raw materials when making" +
                    " their own potions.";
                string descAdd1 = "An ounce of this, ground to a powder" +
                    " and scattered in the user’s path, will make anyone" +
                    " tracking him by scent have a fit of sneezing(see " +
                    "p.B428).Afterward, the tracker must make a HT roll " +
                    "at -3 or have to stop tracking for an hour while " +
                    "his sense of smell recovers from overload. ";
                string descAdd2 = "This spice is a well-known aphrodisiac. " +
                    "Consuming an ounce imposes -1 on any rolls to resist " +
                    "Lecherousness and seduction attempts for the next hour. ";
                string descAdd3 = "If an ounce of this is consumed within " +
                    "an hour before ingesting a poison, the user is at + 1 " +
                    "to HT rolls to resist. ";
                string descAdd4 = "This spice is useful for strengthening " +
                    "the blood and speeding healing. Consuming an ounce a " +
                    "day gives +1 to daily HT rolls to recover lost HP. ";
                string descAdd5 = "This spice is highly prized, but the " +
                    "consumer of an ounce or more is at - 1 to resist any" +
                    " mind-reading or mind-control attempts made in the " +
                    "next hour. ";
                string descAdd6 = "This spice aids digestion; an ounce " +
                    "acts as a treatment to resist nausea(see p.B428) for" +
                    " an hour. ";
                string descAdd7 = "This spice balances humors and helps " +
                    "stabilize mood. Consuming an ounce gives +1 to resist" +
                    " sudden bursts of anger and rage, including the Berserk" +
                    " and Bloodlust disadvantages, for an hour. ";
                string descAdd8 = "This is a very mild stimulant. Anyone " +
                    "who ingests an ounce is at + 1 to HT to resist poisons" +
                    " that cause unconsciousness or fatigue damage for the" +
                    " next hour. ";
                string descAdd9 = "Tossing an ounce of salt gives clerics" +
                    " +1 to cast Turn Zombie and to Will rolls for True " +
                    "Faith to turn zombies. ";
                string descAdd10 = "This spice has antiseptic properties." +
                    " Using an ounce of it while dressing wounds gives +1" +
                    " to First Aid. ";

                Categories[0].AddItem("Allspice",150, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Anise",150, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Annatto",113, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Asafetida",75, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Cardamom",150, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Cassia",75, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Chiles",38, weight, wt, qs, descAdd0 + descAdd1);
                Categories[0].AddItem("Cinnamon",150, weight, wt, qs, descAdd0 + descAdd2);
                Categories[0].AddItem("Clove",150, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Coriander",150, weight, wt, qs, descAdd0 + descAdd3);
                Categories[0].AddItem("Cumin",150, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Dwarven Savory Fungus",75, weight, wt, qs, descAdd0 + descAdd4);
                Categories[0].AddItem("Elven Pepperbark",38, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Faerie Glimmerseed",270, weight, wt, qs, descAdd0 + descAdd5);
                Categories[0].AddItem("Fennel",75, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Fenugreek",150, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Ginger",38, weight, wt, qs, descAdd0 + descAdd6);
                Categories[0].AddItem("Halfling Savory",150, weight, wt, qs, descAdd0 + descAdd4);
                Categories[0].AddItem("Huajiao (Szechuan Pepper)",150, weight, wt, qs, descAdd0 + descAdd1);
                Categories[0].AddItem("Mace",225, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Mustard",38, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Nigella",75, weight, wt, qs, descAdd0 + descAdd7);
                Categories[0].AddItem("Nutmeg",150, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Onion Seed",38, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Orcish Firegrain",150, weight, wt, qs, descAdd0 + descAdd8);
                Categories[0].AddItem("Pepper, Black",150, weight, wt, qs, descAdd0 + descAdd1);
                Categories[0].AddItem("Pepper, White",188, weight, wt, qs, descAdd0 + descAdd1);
                Categories[0].AddItem("Poppy Seed",38, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Saffron",300, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Salt",15, weight, wt, qs, descAdd0 + descAdd9);
                Categories[0].AddItem("Salt, Black",38, weight, wt, qs, descAdd0 + descAdd9);
                Categories[0].AddItem("Salt, Red",38, weight, wt, qs, descAdd0 + descAdd9);
                Categories[0].AddItem("Sumac",38, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Tamarind",15, weight, wt, qs, descAdd0);
                Categories[0].AddItem("Tumeric",38, weight, wt, qs, descAdd0 + descAdd10);
                Categories[0].AddItem("Zeodary",150, weight, wt, qs, descAdd0);

            }//end spices p11
            if (false)
            {
                Categories.Add(new Category("Other Materials"));
                //weight
                double w = 1;
                string w1 = "gallon(s)";
                string w2 = "pint(s)";
                string w3 = "oz";
                string qs = "1d+1";
                string d0 = "A miscellaneous material. ";
                string d1 = "Fermented alcoholic milk. ";
                string d2 = "Produced from an unusual substance: " +
                    "dissolved stardust, lotus nectar, fermented " +
                    "demon’s blood. The wine has no immediate " +
                    "supernatural properties like a potion, but " +
                    "might be a valuable alchemical ingredient " +
                    "or a treatment for specific magical afflictions. ";
                string d3 = "Water lightly scented with flowers. ";
                string d4 = "An alcohol solution scented with flowers," +
                    " spices, and/or resins. ";
                string d5 = "A perfumed vegetable oil or animal fat. ";
                string d6 = "An object coated with or containing perfume" +
                    " elements. ";
                string d7 = "A very expensive insect-derived red. ";
                string d8 = "A vivid-red mineral pigment. ";
                string d9 = "A deep-blue vegetable dye. ";
                string d10 = "A relatively inexpensive red vegetable dye. ";
                string d11 = "A rare purple-red derived from mollusks. ";
                string d12 = "A yellow mineral pigment. ";
                string d13 = "A pale-blue vegetable dye related to indigo. ";
                Categories[1].AddItem("Ale", 5, w, w1, qs, d0);
                Categories[1].AddItem("Distilled Liquor", 16, w, w2, qs, d0);
                Categories[1].AddItem("Flavored Ale", 7, w, w1, qs, d0);
                Categories[1].AddItem("Flavored Brandy", 20, w, w2, qs, d0);
                Categories[1].AddItem("Kumiz", 15, w, w1, qs, d1);
                Categories[1].AddItem("Mead", 11, w, w1, qs, d0);
                Categories[1].AddItem("Opium", 20, w, w3, qs, d0);
                Categories[1].AddItem("Tea, Black", 2, w, w3, qs, d0);
                Categories[1].AddItem("Tea, Green", 2, w, w3, qs, d0);
                Categories[1].AddItem("Wine, Date", 9, w, w1, qs, d0);
                Categories[1].AddItem("Wine, Grape", 9, w, w1, qs, d0);
                Categories[1].AddItem("Wine, Rice", 8, w, w1, qs, d0);
                Categories[1].AddItem("Wine, Otherworldly", 20, w, w1, qs, d2);
                Categories[1].AddItem("Sealing Wax", 1, w, w3, qs, d0);
                Categories[1].AddItem("Ambergris", 35, w, w3, qs, d0);
                Categories[1].AddItem("Cedar Resin", 10, w, w3, qs, d0);
                Categories[1].AddItem("Copal", 11, w, w3, qs, d0);
                Categories[1].AddItem("Frankincense", 16, w, w3, qs, d0);
                Categories[1].AddItem("Musk", 28, w, w3, qs, d0);
                Categories[1].AddItem("Myrrh", 15, w, w3, qs, d0);
                Categories[1].AddItem("Onycha", 20, w, w3, qs, d0);
                Categories[1].AddItem("Patchouli", 9, w, w3, qs, d0);
                Categories[1].AddItem("Sandalwood Gum", 8, w, w3, qs, d0);
                Categories[1].AddItem("Flower Water", 5, w, w3, qs, d3);
                Categories[1].AddItem("Perfumed Essence", 12, w, w3, qs, d4);
                Categories[1].AddItem("Perfumed Oil", 8, w, w3, qs, d5);
                Categories[1].AddItem("Pomander", 9, w, w3, qs, d6);
                Categories[1].AddItem("Carmine", 40, w, w3, qs, d7);
                Categories[1].AddItem("Cinnabar", 18, w, w3, qs, d8);
                Categories[1].AddItem("Ochre", 1, w, w3, qs, d0);
                Categories[1].AddItem("Henna", 1, w, w3, qs, d0);
                Categories[1].AddItem("Indigo", 32, w, w3, qs, d9);
                Categories[1].AddItem("Madder", 2, w, w3, qs, d10);
                Categories[1].AddItem("Murex", 29, w, w3, qs, d11);
                Categories[1].AddItem("Orpiment", 22, w, w3, qs, d12);
                Categories[1].AddItem("Woad", 2, w, w3, qs, d13);

            }//end other materials p13
            if (false)
            {
                Categories.Add(new Category("Cooking"));
                Categories[2].AddItem("Basin",3,4,"lbs","","A wide," +
                    " open bowl (two gallongs), appropriate for large" +
                    " quantities of soup, washing up, or drainging the" +
                    " blood of sacrificial victims. ",200);
                Categories[2].AddItem("Bowl",1,.3,"lbs","","A small " +
                    "ceramic bowl suitable for individual meals",200);
                Categories[2].AddItem("Bucket",15,4,"lbs","","With " +
                    "rope handle. Holds 1 gallon of liquid (1lb if " +
                    "water). DR1, HP2. ",200);
                Categories[2].AddItem("Cauldron",18,20,"lbs","","A " +
                    "blackened iron cooking pot with a capacity of about" +
                    " four gallons. ",200);
                Categories[2].AddItem("Chopsticks",1,0,"lbs","1d/2","" +
                    "A somewhat uncommon form of eating utensil. ",200);
                Categories[2].AddItem("Cup",1,.15,"lbs","","Useful for" +
                    " holding drinks or anything else small enough to" +
                    " fit. ",200);
                Categories[2].AddItem("Dinner Plate",2, 0.5,"lbs","1d+3"
                    ,"A large plate suitable for eating off of. ",200);
                Categories[2].AddItem("Drinking Set",7,3,"lbs", "","A" +
                    " set of drinking paraphenalia for four, such as " +
                    "snifters and a decanter for brandy or a strainer" +
                    " and wide shallow cups for unfiltered wine. ",200);
                Categories[2].AddItem("Fork, Cooking", 10,2,"lbs","",
                    "A heavy fork, about a foot long, good for holding" +
                    " roasts during carving, or piercing and lifting" +
                    " large vegetables. If used as a weapon, does " +
                    "thr-1 imp; use Knife skill at -2. ",200);
                Categories[2].AddItem("Fork, Table",3,0.4,"lbs","1d+5"
                    ,"If used as a weapon, does thr-3 imp; use Knife" +
                    " skill at -2. ",200);
                Categories[2].AddItem("Goblet",5,.5,"lbs","1d/2+2",
                    "A large (at least one-pint capactity), footed" +
                    " cup. ",200);
                Categories[2].AddItem("Knife, Table",2,.4,"lbs","1d+5"
                    ,"A dull knife, not sharp enough for cutting " +
                    "damage or pointed enough for impaling",200);
                Categories[2].AddItem("Ladle",9,2,"lbs","",
                    "An ordinary kitchen ladle.",200);
                Categories[2].AddItem("Mortar and Pestle",20,6,"lbs"
                    ,"", "Stone, about a pint capacity. ", 200);
                Categories[2].AddItem("Pitcher",2,3,"lbs",
                    "", "Ceramic, half-gallon", 200);
                Categories[2].AddItem("Place Setting",5,2,"lbs","1d"
                    ,"A set of dishes and eating utensils. " +
                    "Quanity indicates number of settings found. ",200);
                Categories[2].AddItem("Platter",1,1,"lbs","1d/3",
                    "An ordinary kitchen platter. ",200);
                Categories[2].AddItem("Pot",30,2,"lbs","1d/3",
                    "A lightweight cooking pot, holding about" +
                    "two quarts. ",200);
                Categories[2].AddItem("Skillet",50,8,"lbs","",
                    "A 12-inch pan for cooking. ",200);
                Categories[2].AddItem("Spit, Cooking",100,15,"lbs",""
                    ,"A pointed metal bar large enough to cook a whole" +
                    " goat or sheep. Does not include posts to set it" +
                    " up on. ",200);
                Categories[2].AddItem("Tea Set",6,4.5,"lbs","",
                    "A pot for brewing and four small cups. ",200);
                Categories[2].AddItem("Teapot, Iron",45,7,"lbs",""
                    ,"An iron teapot, doesn't have to just contain" +
                    " tea.",200);
                Categories[2].AddItem("Wine Glass",10,.5,"lbs","1d/3+3",
                    "A glass cup made for holding wine. ",200);
            }//end if cooking p14

            uxCategoryOptions.DataSource = Categories;
            SelectAllCats(null, null);
        }//end CreateCats()
    }//end partial class LootSpawner
}//end namespace