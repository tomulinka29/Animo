using System;
using System.IO;
using Newtonsoft.Json;

namespace Volby
{
    class Program
    {
        static void Main(string[] args)
        {

            // var data = LoadParties("Data.json");

            string[] parties = LoadParties("Parties.txt", ';');
            int[] votes = LoadVotes("Votes.txt", ';');

            if (votes.Length != parties.Length)
            {
                Console.WriteLine("Poslední výsledky jsou špatné, vytvářím novou tabulku :D");
                Console.WriteLine("----------------");
                votes = new int[parties.Length];
            }

            ShowParties(parties);
            Console.WriteLine("----------------");


            int chosenID = ChoosePart(parties);
            Console.WriteLine("----------------");

            try
            {
                votes[chosenID]++;
                SaveVotes("Votes.txt", ';', votes);
                Console.WriteLine("OK, zvolil/a jste {0}", parties[chosenID]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba při zápisu vašeho hlasu: {0}", e.Message);
            }



        }

        private static void ShowParties(string[] parts)
        {
            int index = 1; // indexing from 1
            foreach (string strana in parts)
            {
                Console.WriteLine(index.ToString() + ": " + strana);
                index++;
            }
        }

        private static int ChoosePart(string[] parts)
        {
            Console.WriteLine("Zadejte číslo zvolené strany: ");

            int chosenID; // indexing from 1
            while (!int.TryParse(Console.ReadLine(), out chosenID) || (chosenID < 1 || chosenID > parts.Length))
            {
                Console.WriteLine("Neplatný vstup!");
            }
            chosenID--; // for indexing in array

            return chosenID;
        }

        private static string[] LoadParties(string path, char delimiter)
        {
            return File.ReadAllText(path).Split(delimiter); ;
        }

        private static Party[] LoadParties(string path)
        {
            return JsonConvert.DeserializeObject<Party[]>(path);
        }

        private static int[] LoadVotes(string path, char delimiter)
        {
            string[] textValues = File.ReadAllText(path).Split(delimiter);
            int[] votes = new int[textValues.Length];

            if (textValues.Length > 1) // empty file
            {
                for (int i = 0; i < textValues.Length; i++)
                {
                    if (!int.TryParse(textValues[i], out votes[i]))
                        Console.WriteLine("Nepodařilo se načíst soubor s hlasy: {0}", i);
                }
            }

            return votes;
        }

        private static bool SaveVotes(string path, char delimiter, int[] votes)
        {
            string newDelimiter = delimiter.ToString(); //change type and save to variable

            try
            {
                string output = "";
                for (int i = 0; i < votes.Length; i++)
                {
                    
                    if (i < votes.Length-1) // remove last delimiter, causes problems with split
                        output += votes[i] + newDelimiter;
                    else
                        output += votes[i];
                }

                File.WriteAllText(path, output);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Chyba při ukladani vysledku do souboru: {0}", e.Message);
                return false;
            }
        }
    }
}
