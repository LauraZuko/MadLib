using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MadLib;
/*
Laura Zukoski
70-245 OOP
Assignment Madlibs
*/

/*
This program creates a madlib.  It reads an existing file and finds the placeholders
It then asks the user to enter a word for that placeholder, and prints the MadLib with the
user entered words
*/
namespace MadLib
{
    // precond - user entered a file name 
    // postcond - returns a list of the lines in the file
    class MadlibReader
    {
        // Create a list to store each line in the file
        public List<string> read(string fvar)
        {
            List<string> result = new List<string>();
            string line;
            string[] lines;
            try
            {
                // when the line is not a blank line this trims the white space for the line and 
                // adds the line to the list
                StreamReader reader = new StreamReader(@"C:\Users\Zukoskla\Desktop\MadLib.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    lines = line.Split('\n');
                    result.Add(line);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // returns the list of lines contained in the file
            return result;
        }
    }
    // precond - A list containing the madlib lines is passed
    // postcond - The list is split first at < and then at > 
    // splitting like this means we dont have to worry about punctuation and stuff.
    class MadlibAsker
    {
        public List<string> asker(List<string> result)
        {
            // creates a list to store the madLib with the users words
            List<string> asker = new List<string>();
            //
            foreach (string newLib in result)
            {
                // creates a list of words split at '<'  EX) words ="name>" 
                string[] words = newLib.Split('<');
                string results = words[0];
                // for each word this goes through the list and finds the placeholder and replaces the users word with the placeholder
                // i increments and searches for the next placeholder
                for (int i = 1; i < words.Length; i++)
                {
                    // splits the word at ending '>' so words = "name"
                    // create another list so that the phrase is always at [0]
                    string[] phrase = words[i].Split('>');
                    if (phrase[0] == ("name"))
                    {
                        Console.Write("Enter a name: ");
                    }
                    if (phrase[0] == ("snoun"))
                    {
                        Console.Write("Enter a singular noun: ");
                    }
                    if (phrase[0] == ("adv"))
                    {
                        Console.Write("Enter an ad verb: ");
                    }
                    if (phrase[0] == ("sverb"))
                    {
                        Console.Write("Enter a singular verb: ");
                    }
                    if (phrase[0] == ("adj"))
                    {
                        Console.Write("Enter an adjective: ");
                    }
                    if (phrase[0] == ("place"))
                    {
                        Console.Write("Enter a place: ");
                    }
                    // stores the user enter word and adds it to results list, along with the the remaining part of the phrase
                    string lib = Console.ReadLine();
                    results += lib;
                    results += phrase[1];                    
                }
                // adds the results to a list
                asker.Add(results);
            }
            // returns the list
            return asker;
        }
    }

    //postcond - MadlibPrinter class is called and writeLib function is passed 
    //precond - MadlibPrinter class is called and 
    class MadlibPrinter
    {
        public void writeLib(List<string> newlib)
        {
            // 
            Console.WriteLine("\nHere is your completed MadLib: ");
            Console.WriteLine();
            foreach (string lib in newlib)
            {
                Console.WriteLine(lib);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // prints intro
            Console.WriteLine("Welcome to e-madlibs");
            Console.WriteLine("\nIn this game, you will name various kinds of words," +
                "\nand I will plug them into a story. You never know" +
                "\nwhat interesting prose you'll come up with!\n");
            Console.Write("Enter the name of the story file: ");
            Console.WriteLine();
            // creates reader object to read file in MadlibReader and stores file as list of strings
            MadlibReader reader = new MadlibReader();
            string fvar = Console.ReadLine();
            List<string> lines = reader.read(fvar);
            // creates asks object and calls asker that will ask and replace the placeholders
            MadlibAsker asks = new MadlibAsker();
            List<string> askerLib = asks.asker(lines);
            // creates printLib object and calls the writeLib function to print the askerLib
            MadlibPrinter printLib = new MadlibPrinter();
            printLib.writeLib(askerLib);
        }
    }
}
/*
    Most of the improvements I would make to this code would be in the MadlibAsker class, and overall making the program in a model view controller model. I would add a class that puts together all the user entered 
    strings like userLib. I would make the class MadlibAsker have subclasses for each specific word that can be entered. The class MadlibAsker would have a function like get_word that would be passed to the 
    respective subclass, as would be the case for asking the user for a word.  I would make a function user_word and pass it for the MadlibAsker class, but the subclasses, would have code that asks for that 
    specific word and stores it. This is where the userLib function would become useful, each subclass would return the user entered name and add it to a list at position [i]. Then when the userlib class would 
    be called all that would be needed to be done is print the function in the userLib class. As the userlib class would have a function that places all the user_word in the lib at their respective positions.

*/