using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            CreateLoot();
        }//end SpawnLoot(sender, e)

        /// <summary>
        /// Contains all the backend stuff for SpawnLoot()
        /// </summary>
        private void CreateLoot()
        {
            //grab the number of times we need to generate loot
            int lootAmount = Convert.ToInt32(uxLootAmount.Value);
            //choose one of the categories to use
            Random r = new Random();
            for (int i = 0; i < lootAmount; i++)
            {
                int index = r.Next(0, Categories.Count);
                Categories[index].SelectItem();
            }//end looping to select item for each lootAmount

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

            //enable the group with all the output options
            uxOutputGroup.Enabled = true;
        }//end CreateLoot()

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
        /// A testing method which will create my sample categories
        /// through hardcoded commands and make them show up in the
        /// GUI.
        /// </summary>
        private void CreateCats()
        {
            Categories = new List<Category>();

            //add spices
            if (true)
            {
                Categories.Add(new Category("Spices"));
                double weight = 0.0625;
                string qs = "1d/2";
                string descAdd0 = "As a spice, this item's quantity refers" +
                    " to how many ounces there are. Weight is for one ounce," +
                    " or one sixteenth of a pound. ";
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

                Categories[0].AddItem("Allspice",150, weight, qs, descAdd0);
                Categories[0].AddItem("Anise",150, weight, qs, descAdd0);
                Categories[0].AddItem("Annatto",113, weight, qs, descAdd0);
                Categories[0].AddItem("Asafetida",75, weight, qs, descAdd0);
                Categories[0].AddItem("Cardamom",150, weight, qs, descAdd0);
                Categories[0].AddItem("Cassia",75, weight, qs, descAdd0);
                Categories[0].AddItem("Chiles",38, weight, qs, descAdd0 + descAdd1);
                Categories[0].AddItem("Cinnamon",150, weight, qs, descAdd0 + descAdd2);
                Categories[0].AddItem("Clove",150, weight, qs, descAdd0);
                Categories[0].AddItem("Coriander",150, weight, qs, descAdd0 + descAdd3);
                Categories[0].AddItem("Cumin",150, weight, qs, descAdd0);
                Categories[0].AddItem("Dwarven Savory Fungus",75, weight, qs, descAdd0 + descAdd4);
                Categories[0].AddItem("Elven Pepperbark",38, weight, qs, descAdd0);
                Categories[0].AddItem("Faerie Glimmerseed",270, weight, qs, descAdd0 + descAdd5);
                Categories[0].AddItem("Fennel",75, weight, qs, descAdd0);
                Categories[0].AddItem("Fenugreek",150, weight, qs, descAdd0);
                Categories[0].AddItem("Ginger",38, weight, qs, descAdd0 + descAdd6);
                Categories[0].AddItem("Halfling Savory",150, weight, qs, descAdd0 + descAdd4);
                Categories[0].AddItem("Huajiao (Szechuan Pepper)",150, weight, qs, descAdd0 + descAdd1);
                Categories[0].AddItem("Mace",225, weight, qs, descAdd0);
                Categories[0].AddItem("Mustard",38, weight, qs, descAdd0);
                Categories[0].AddItem("Nigella",75, weight, qs, descAdd0 + descAdd7);
                Categories[0].AddItem("Nutmeg",150, weight, qs, descAdd0);
                Categories[0].AddItem("Onion Seed",38, weight, qs, descAdd0);
                Categories[0].AddItem("Orcish Firegrain",150, weight, qs, descAdd0 + descAdd8);
                Categories[0].AddItem("Pepper, Black",150, weight, qs, descAdd0 + descAdd1);
                Categories[0].AddItem("Pepper, White",188, weight, qs, descAdd0 + descAdd1);
                Categories[0].AddItem("Poppy Seed",38, weight, qs, descAdd0);
                Categories[0].AddItem("Saffron",300, weight, qs, descAdd0);
                Categories[0].AddItem("Salt",15, weight, qs, descAdd0 + descAdd9);
                Categories[0].AddItem("Salt, Black",38, weight, qs, descAdd0 + descAdd9);
                Categories[0].AddItem("Salt, Red",38, weight, qs, descAdd0 + descAdd9);
                Categories[0].AddItem("Sumac",38, weight, qs, descAdd0);
                Categories[0].AddItem("Tamarind",15, weight, qs, descAdd0);
                Categories[0].AddItem("Tumeric",38, weight, qs, descAdd0 + descAdd10);
                Categories[0].AddItem("Zeodary",150, weight, qs, descAdd0);

                uxCategoryOptions.DataSource = Categories;
            }//end if we're doing spices
            
        }//end CreateCats()
    }//end partial class LootSpawner
}//end namespace