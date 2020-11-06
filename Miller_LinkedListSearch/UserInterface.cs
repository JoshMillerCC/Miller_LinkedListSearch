using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miller_LinkedListSearch
{
    class UserInterface
    {
        public static void Menu()
        {
            Console.WriteLine("Pick your poison:");
            Console.WriteLine("1. Search for a name.");
            Console.WriteLine("2. See count of all nodes.");
            Console.WriteLine("3. See count of all female names.");
            Console.WriteLine("4. See count of all male names.");
            Console.WriteLine("5. Add a name. (needs 3 arguements)");
            Console.WriteLine("6. See data for most popular female name.");
            Console.WriteLine("7. See data for most popular male name.");
            Console.WriteLine("8. Exit.");
        }

        public static void MenuOptions(string choice, LinkedList LL)
        {
            Console.Clear();
            switch (choice)
            {
                case "1":
                    // search for a name

                    Stopwatch sw = new Stopwatch();
                    Console.WriteLine("What name are you looking for?");
                    string name = Console.ReadLine().ToLower();
                    sw.Start();
                    if (LL.Search(name) != null)
                    {
                        sw.Stop();
                        Console.WriteLine(name + " is in the list.\n");
                    }
                    else
                    {
                        sw.Stop();
                        Console.WriteLine(name + " is not in the list.\n");
                    }
                    TimeSpan ts = sw.Elapsed;
                    Console.Write(string.Format("It took {0:00} hours, {1:00} minutes, {2:00} seconds, {3:00} milliseconds to check the list.\n", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10));

                    break;

                case "2":
                    // see count of all nodes

                    Console.WriteLine(LL.getHead().Data.getAllCount() + " nodes are in the list.\n");
                    break;

                case "3":
                    // see count of all female names

                    Console.WriteLine(LL.getHead().Data.getFCount() + " nodes with a female gender are in the list.\n");
                    break;

                case "4":
                    // see count of all male names

                    Console.WriteLine(LL.getHead().Data.getMCount() + " nodes with a male gender are in the list.\n");
                    break;

                case "5":
                    // add a name (3 arguements required)
                    // Some names work with this and some don't. I can't figure out why.

                    Console.WriteLine("What name do you want to add?");
                    string newName = Console.ReadLine();

                    while(string.IsNullOrEmpty(newName))
                    {
                        Console.WriteLine("Name cannot be empty, plese type again");
                        newName = Console.ReadLine();
                    }

                    // check for good user input
                    bool loop = true;
                    while (loop)
                    {
                        foreach (char c in newName)
                        {
                            if (!Char.IsLetter(c))
                            { 
                                Console.WriteLine("Please enter a valid name. (letters only)");
                                loop = true;
                                newName = Console.ReadLine();
                                break;
                            }
                            else
                            {
                                loop = false;
                            }
                            
                        }
                       
                    }

                    Console.WriteLine("What is the gender? M/F");
                    string newGender = Console.ReadLine().ToUpper();

                    while (string.IsNullOrEmpty(newGender))
                    {
                        Console.WriteLine("Gender cannot be empty, plese type again");
                        newGender = Console.ReadLine().ToUpper();
                    }

                    while (newGender != "M" && newGender != "F")
                    {
                        Console.WriteLine("Please enter a valid gender. (M/F only)");
                        newGender = Console.ReadLine().ToUpper();
                    }
                    char charGender = Convert.ToChar(newGender);


                    Console.WriteLine("What is the rank?");
                    string newRank = Console.ReadLine();
                    Int32.TryParse(newRank, out int numRank);
                    // need to check for legit rank here. numbers only.

                    MetaData newdata;
                    Node searchedNode = LL.Search(newName);

                    if (searchedNode == null)
                    {
                        newdata = new MetaData(charGender, newName, numRank);
                        LL.Add(newdata);
                        break;
                    }
                    else if(searchedNode.Data.getName().ToLower().Equals(newName.ToLower()) && searchedNode.Data.getGender() != charGender)
                    {
                        newdata = new MetaData(charGender, newName, numRank);
                        LL.Add(newdata);
                        break;
                    }
                    else
                    {
                        if (searchedNode.Data.getName().ToLower().Equals(newName.ToLower()) && searchedNode.Data.getGender() == charGender)
                        {
                            Console.WriteLine("This name already exists in the list with this gender.");
                            Console.WriteLine("Do you want to add an \"_1\"? (y/n)");
                            string result = Console.ReadLine().ToLower();
                            while(result != "y" && result != "n")
                            {
                                Console.WriteLine("Please enter a valid option.");
                                result = Console.ReadLine().ToLower();
                            }
                            if (result.Equals("y"))
                            {
                                newName = newName + "_1";
                                newdata = new MetaData(charGender, newName, numRank);
                                LL.Add(newdata);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("nothing added");
                                break;
                            }
                        }

                        if (searchedNode.Next.Data.getName().ToLower().Equals(newName.ToLower()) && searchedNode.Next.Data.getGender() == charGender)
                        {
                            Console.WriteLine("This name already exists in the list with this gender.");
                            Console.WriteLine("Do you want to add an \"_1\"? (y/n)");
                            string result = Console.ReadLine().ToLower();
                            while (result != "y" && result != "n")
                            {
                                Console.WriteLine("Please enter a valid option.");
                                result = Console.ReadLine().ToLower();
                            }
                            
                            if (result.Equals("y"))
                            {
                                newName = newName + "_1";
                                newdata = new MetaData(charGender, newName, numRank);
                                LL.Add(newdata);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("nothing added");
                                break;
                            }
                        }

                        if (searchedNode.Previous.Data.getName().ToLower().Equals(newName.ToLower()) && searchedNode.Previous.Data.getGender() == charGender)
                        {
                            Console.WriteLine("This name already exists in the list with this gender.");
                            Console.WriteLine("Do you want to add an \"_1\"? (y/n)");
                            string result = Console.ReadLine().ToLower();
                            while (result != "y" && result != "n")
                            {
                                Console.WriteLine("Please enter a valid option.");
                                result = Console.ReadLine().ToLower();
                            }
                            
                            if (result.Equals("y"))
                            {
                                newName = newName + "_1";
                                newdata = new MetaData(charGender, newName, numRank);
                                LL.Add(newdata);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("nothing added");
                                break;
                            }
                        }
                    }


                    break;

                case "6":
                    // see data for most popular female name

                    Console.WriteLine("Most popular female name: " + LL.FemalePopularity().Data.getName() + ", Rank: " + LL.FemalePopularity().Data.getRank());
                    break;

                case "7":
                    // see data for most popular male name

                    Console.WriteLine("Most popular male name: " + LL.MalePopularity().Data.getName() + ", Rank: " + LL.MalePopularity().Data.getRank());
                    break;

                case "8":
                    // exit the program

                    Environment.Exit(0);
                    break;

                default:
                    // this is what shows up if they don't choose 1-8

                    Console.WriteLine("Pick a valid option please and thank you!");
                    break;
            }
        }
    }
}
