using System;
using System.IO;
using Newtonsoft.Json;

namespace Volby
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chcete editovat, nebo volit? [0/1]");
            int mode;
            int.TryParse(Console.ReadLine(), out mode);

            if (mode == 1) // voting part
            {
                var parties = LoadData("Data.json");

                ShowParties(parties);
                Console.WriteLine("----------------");

                int chosenID = ChoosePart(parties);
                Console.WriteLine("----------------");

                try
                {
                    SaveData(parties);
                    Console.WriteLine("OK, zvolil/a jste {0}", parties[chosenID]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Chyba při zápisu vašeho hlasu: {0}", e.Message);
                }
            }
            else // editation part
            { 
            
            }


        }

        private static void ShowParties(Party[] parties)
        {
            int index = 1; // indexing from 1
            foreach (Party strana in parties)
            {
                Console.WriteLine(index.ToString() + ": " + strana.name);
                index++;
            }
        }

        private static int ChoosePart(Party[] parties)
        {
            Console.WriteLine("Zadejte číslo zvolené strany: ");

            int chosenID; // indexing from 1
            while (!int.TryParse(Console.ReadLine(), out chosenID) || (chosenID < 1 || chosenID > parties.Length))
            {
                Console.WriteLine("Neplatný vstup!");
            }
            chosenID--; // for indexing in array

            return chosenID;
        }

        private static Party[] LoadData(string path)
        {
            if (File.Exists(path))
                return JsonConvert.DeserializeObject<Party[]>(path);
            else
                File.Create(path);
                return null;
        }

        private static void SaveData(Party[] parties)
        {
            string output = JsonConvert.SerializeObject(parties);
            File.WriteAllText("Data.json", output);
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
