using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot_Spawner
{
    /// <summary>
    /// This class represents a single item. For advanced uses, it
    /// must be combined with the ItemOptions class. Not sure how that
    /// will work out quite yet, but I'll get there.
    /// 
    /// In terms of storing that there are multiple of one item, this 
    /// will be handled inside of the class, using a quantity property.
    /// This allows the class to format its output string by itself to
    /// simplify displaying several items in the end result.
    /// </summary>
    class Item
    {
        /// <summary>
        /// the name of this particular item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// a description of what this item is and/or
        /// what it does, its effects, etc. This is
        /// optional, but if not used should be set
        /// to an empty string
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// this is the net cost of the item while taking into
        /// consideration all the modifiers that the item has
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// this is the original base cost of the item without
        /// taking into account any of the modifiers. Useful for
        /// calculating multiple cost factors
        /// </summary>
        public int BaseCost { get; set; }
        /// <summary>
        /// this is the weight of the item. This takes into account
        /// all modifiers. There is no base weight, so be careful
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// The unit of measurement for the weight of this item.
        /// So for instance if the weight is in pounds, then this
        /// should be "lbs"
        /// </summary>
        public string WeightType { get; set; }
        /// <summary>
        /// this represents how many of this particular item exist in
        /// our inventory at the moment. This doesn't affect anything
        /// within this class other than displaying in the ToString and
        /// any other display formatting method.
        /// Make sure that you use the AddQuantity method to change
        /// this if you have a QuantSpec
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// for items like spices in which you roll for quantity.
        /// If this item requires you to roll for an amount, then
        /// this string should have the dice plus or minus modifiers
        /// with no spaces. Otherwise leave it as an empty string.
        /// </summary>
        public string QuantSpec { get; set; }
        /// <summary>
        /// This number, which by default is one, multiplies the chance
        /// for this item to be chosen by the number that it is. So if
        /// this is 2, then this item is twice as likely to be chosen
        /// Changed after a time to allow decimals, but only to a certain
        /// degree of precision. Basically 100 is 100% of the time, and 
        /// you get decimals that way. Nifty, right?
        /// </summary>
        public int Probability { get; set; }

        //potential lists for storing additional data?
        //public List<Enchantment> Enchants { get; set; }
        //public Lists<Embellishment> Embellishments { get; set; }

        /// <summary>
        /// Don't use this constructor if you want to use this
        /// object to actually represent an item.
        /// </summary>
        public Item()
        {
            this.Name = null;
            this.Description = null;
            this.Cost = 0;
            this.Quantity = 0;
            this.QuantSpec = "";
            this.Probability = 0;
        }//end no-arg constructor

        /// <summary>
        /// This is the preferred constructor to use for mundane
        /// items which do not require the use of the ItemOptions
        /// class.
        /// </summary>
        /// <param name="name">The name of this particular item</param>
        /// <param name="description">the description of ths item</param>
        /// <param name="baseCost">the base cost of this item</param>
        /// <param name="weight">the weight of this item in pounds</param>
        public Item(string name, string description, int baseCost, double weight)
        {
            this.Name = name;
            this.Description = description;
            this.BaseCost = baseCost;
            this.Cost = baseCost;
            this.Weight = weight;
            this.Quantity = 0;
            this.QuantSpec = "";
            this.Probability = 100;
        }//end 4-arg recommended constructor

        /// <summary>
        /// same as 4-arg recommended constructor, but this one allows you to
        /// specify QuantSpec
        /// </summary>
        /// <param name="name">the name of this particular item</param>
        /// <param name="description">the description of this item</param>
        /// <param name="baseCost">the base cost of this item</param>
        /// <param name="weight">the weight of this item</param>
        /// <param name="quantSpec">the QuantSpec of this item</param>
        public Item(string name, string description, int baseCost, double weight,
            string weightType, string quantSpec)
        {
            this.Name = name;
            this.Description = description;
            this.BaseCost = baseCost;
            this.Cost = baseCost;
            this.Weight = weight;
            this.WeightType = weightType;
            this.Quantity = 0;
            this.QuantSpec = quantSpec;
            this.Probability = 100;
        }//end 5-arg constructor for nondefault QuantSpec

        /// <summary>
        /// method used to test if two items are equal. Method
        /// contains commented out code for testing enchantments
        /// and embellishments as well, but due to those classes
        /// not existing yet, they can be phased into the code
        /// sometime in the future. For two items to be equal, they
        /// need only have the same name, description, base cost,
        /// and weight.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Equals(Item item)
        {
            return this.Name.Equals(item.Name)
                && this.Description.Equals(item.Description)
                && this.BaseCost.Equals(item.BaseCost)
                && this.Weight.Equals(item.Weight)
                && this.WeightType.Equals(item.WeightType)
                //&& this.Embellishments.Equals(item.Embellishments)
                //&& this.Enchants.Equals(item.Enchants)
                ;
        }//end Equals(item)

        /// <summary>
        /// The ToString method in this case returns a one-line string
        /// representation of this object in the way it should appear
        /// when displaying to the user.
        /// </summary>
        /// <returns>Returns a display-ready string representation
        /// of this object, complete with name, quantity, cost, 
        /// and also weight.</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(Name);
            output.Append(" x");
            output.Append(Quantity);
            output.Append("; ");
            output.Append("$");
            output.Append(Cost);
            output.Append("; ");
            output.Append(string.Format("{0:0.####}", Weight));
            output.Append(WeightType);

            return output.ToString();
        }//end ToString()

        /// <summary>
        /// A way to build all the information about this object
        /// into a single string. Nifty!
        /// </summary>
        /// <returns>Returns string with information on
        /// everything this object stores</returns>
        public string BuildInfoStr()
        {
            StringBuilder info = new StringBuilder();
            info.Append(Name);

            if(Quantity < 2)
            {
                info.Append(BaseCost);
                info.Append("->");
                info.Append(Cost + " ");
                info.Append(Weight + WeightType + "\n\t");
            }//end if we have a single item
            else
            {
                info.Append("x" + Quantity + " ");
                info.Append(BaseCost + "/");
                info.Append(BaseCost * Quantity);
                info.Append("->");
                info.Append(Cost + "/");
                info.Append(Cost * Quantity);
                info.Append(" ");
                info.Append(Weight + WeightType + "\n\t");
            }//end else we have several items

            //now for the description
            for (int i = 0; i < Description.Length; i++)
            {
                info.Append(Description[i]);

                //TODO: Make it so that this if statement 
                //doesn't separate words, somehow...
                if (i != 0 && i % 75 == 0)
                {
                    info.Append("\n\t");
                }//end if we've reaches the next 20th line
            }//end looping over each character in Description
            info.Append("\n");
            return info.ToString();
        }//end BuildInfoStr()

        /// <summary>
        /// simply adds amount to quantity, taking QuantSpec into
        /// account. If you add amount more than 1 with a valid
        /// QuantSpec, then the method will loop to add evaluated
        /// QuantSpec to Quantity amount times. This method will
        /// never descrease Quantity.
        /// </summary>
        /// <param name="amount">the amount of times to increase
        /// Quantity. This should be at least 1</param>
        public void AddQuantity(int amount)
        {
            if(amount < 1)
            {
                throw new InvalidOperationException();
            }//end if amount is less than 1

            if(QuantSpec == "")
            {
                Quantity += amount;
            }//end if there is no QuantSpec
            else
            {
                for(int i = 0; i < amount; i++)
                {
                    Quantity += ParseQuantity(QuantSpec);
                }//end looping amount times
            }//end else we must observe QuantSpec
        }//end AddQuantity(amount)

        /// <summary>
        /// Allows you to set this items quantity to a specific number
        /// If you want Inventory to be updated, then use the method
        /// from Category
        /// </summary>
        /// <param name="nQuant">new quantity for this item</param>
        public void SetQuantity(int nQuant)
        {
            Quantity = nQuant;
            if(Quantity < 1) Quantity = 0;
        }//end SetQuantity(nQuant)

        /// <summary>
        /// this method parses QuantSpec, using random numbers.
        /// input must contain a number followed by the letter d.
        /// Modifiers are accepted but not required.
        /// Also the dice part needs to be first.
        /// Also no parenthesis are allowed.
        /// Also it only works with integers.
        /// </summary>
        /// <param name="quantityStr">the QuantSpec we're working with</param>
        /// <returns>returns evaluated QuantSpec</returns>
        private int ParseQuantity(string quantityStr)
        {
            if(quantityStr.Length < 2 || !Char.IsDigit(quantityStr[0]) 
                || !quantityStr.Contains('d'))
            {
                throw new ArgumentException();
            }//end if the input is clearly invalid

            int runningTotal = 0;
            /// <summary>
            /// -1 represents needing dice roll first
            /// 0 represents no operator
            /// 1 represents addition
            /// 2 represents subtraction
            /// 3 represents multiplication
            /// 4 represents division
            /// </summary>
            int operatorMode = -1;
            bool finishedDice = false;
            StringBuilder diceNum = new StringBuilder();
            StringBuilder modNum = new StringBuilder();
            for(int i = 0; i < quantityStr.Length; i++)
            {
                if (!finishedDice)
                {
                    if (quantityStr[i].Equals('d'))
                    {
                        int diceNumber = Convert.ToInt32(diceNum.ToString());
                        runningTotal += RollDice(diceNumber);

                        //prepare the loop to start processing operators
                        finishedDice = true;
                        operatorMode = 0;
                    }//end if we have the number and now need to roll dice
                    else
                    {
                        diceNum.Append(quantityStr[i]);
                    }//end else we're still making out the number of dice
                }//end if we're still trying to roll dice
                else
                {
                    if(i == quantityStr.Length - 1)
                    {
                        //we need to go ahead and wrap this up
                        //if we can process an operator mode and
                        //anything in the sb, do that, otherwise just
                        //move on without doing anything

                        //if things are processable, then our last character should be
                        //a digit
                        if (Char.IsDigit(quantityStr[i]))
                        {
                            //section below will cause a crash if modnum if empty at this point
                            modNum.Append(quantityStr[i]);
                            //code below is copied and pasted from section if current is operator
                            if (operatorMode == 1)
                            {
                                runningTotal += Convert.ToInt32(modNum.ToString());
                            }//end if operator is addition
                            else if (operatorMode == 2)
                            {
                                runningTotal -= Convert.ToInt32(modNum.ToString());
                            }//end else if operator is subtraction
                            else if (operatorMode == 3)
                            {
                                runningTotal *= Convert.ToInt32(modNum.ToString());
                            }//end else if operator is multiplication
                            else if (operatorMode == 4)
                            {
                                runningTotal++;
                                runningTotal /= Convert.ToInt32(modNum.ToString());
                            }//end else if operator is division
                        }//end if last thing processable
                    }//end if we're on the last one
                    else if (Char.IsDigit(quantityStr[i]))
                    {
                        //if there's an active operator mode, add this
                        //number to the SB. Otherwise, ignore it
                        if(operatorMode  <= 0)
                        {
                            //do nothing
                        }//end if there's no active operator mode
                        else
                        {
                            modNum.Append(quantityStr[i]);
                        }//end else there's an active operator mode
                    }//end if this character is a digit
                    else
                    {
                        //if we already had an operator mode and also some
                        //numbers in the SB, process them. Otherwise, 
                        //set the operator mode
                        if(operatorMode <= 0)
                        {
                            if(quantityStr[i] == '+')
                            {
                                operatorMode = 1;
                            }//end if the operator is addition
                            else if (quantityStr[i] == '-')
                            {
                                operatorMode = 2;
                            }//end else the operator is subtraction
                            else if (quantityStr[i] == '*')
                            {
                                operatorMode = 3;
                            }//end else the operator is multiplication
                            else if (quantityStr[i] == '/')
                            {
                                operatorMode = 4;
                            }//end else the operator is division
                            else
                            {
                                operatorMode = 0;
                            }//end else the operator is invalid
                        }//end if we need to set operator mode
                        else
                        {
                            if(operatorMode == 1)
                            {
                                runningTotal += Convert.ToInt32(modNum.ToString());
                            }//end if operator is addition
                            else if (operatorMode == 2)
                            {
                                runningTotal -= Convert.ToInt32(modNum.ToString());
                            }//end else if operator is subtraction
                            else if (operatorMode == 3)
                            {
                                runningTotal *= Convert.ToInt32(modNum.ToString());
                            }//end else if operator is multiplication
                            else if (operatorMode == 4)
                            {
                                runningTotal /= Convert.ToInt32(modNum.ToString());
                            }//end else if operator is division

                            //reset certain variables
                            operatorMode = 0;
                            modNum.Length = 0;
                        }//end else we should process what we have here already
                    }//end else we'll just assume this is an operator
                }//end else we've moved on to the operators
            }//end looping over each character in quantityStr
            if (runningTotal < 1) runningTotal = 1;
            return runningTotal;
        }//end ParseQuantity

        /// <summary>
        /// this is just a simple utility method for simulating the
        /// rolling of some number of dice
        /// </summary>
        /// <param name="times">the number of times to roll dice</param>
        /// <returns>returns the total result of all the dice</returns>
        private int RollDice(int times)
        {
            Random r = new Random();
            int total = 0;
            for(int i = 0; i < times; i++)
            {
                total += r.Next(1, 7);//rolls from 1 to 6
            }//end looping times times
            return total;
        }//end RollDice
    }//end class
}//end namespace