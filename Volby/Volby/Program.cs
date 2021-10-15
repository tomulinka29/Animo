using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Volby
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chcete editovat, volit, nebo se podivat na vysledky? [0/1/2]");
            int mode;
            int.TryParse(Console.ReadLine(), out mode);

            if (mode == 1) // voting part
            {
                var parties = LoadData("Data.json");

                if (parties == null)
                {
                    Console.WriteLine("Nebyly nacteny zadne strany");
                    return;
                }


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
            else if (mode == 0) // editation part
            {
                var parties = LoadData("Data.json");
                if (parties == null)
                    parties = new List<Party>();

                Console.WriteLine("Jakou upravu chcete provest?: ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Pridat politickou stranu - 1");
                Console.WriteLine("------------------------------");

                int operationIndex;
                int.TryParse(Console.ReadLine(), out operationIndex);

                switch (operationIndex)
                {
                    case 1:
                        Console.WriteLine("Zadejte nazev nove strany: ");
                        parties.Add(new Party(Console.ReadLine()));
                        break;
                }


                try
                {
                    SaveData(parties);
                    Console.WriteLine("Upravy probehly uspesne");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Chyba při zápisu uprav: {0}", e.Message);
                }
            }
            else if (mode == 2)
            {
                // show results    
            }
        }

        private static void ShowParties(List<Party> parties)
        {
            int index = 1; // indexing from 1
            foreach (Party strana in parties)
            {
                Console.WriteLine(index.ToString() + ": " + strana.name);
                index++;
            }
        }

        private static int ChoosePart(List<Party> parties)
        {
            Console.WriteLine("Zadejte číslo zvolené strany: ");

            int chosenID; // indexing from 1
            while (!int.TryParse(Console.ReadLine(), out chosenID) || (chosenID < 1 || chosenID > parties.Count))
            {
                Console.WriteLine("Neplatný vstup!");
            }
            chosenID--; // for indexing in array

            return chosenID;
        }

        private static List<Party> LoadData(string path)
        {
            if (File.Exists(path) && File.ReadAllText(path).Trim().Length != 0)
            {
                return JsonConvert.DeserializeObject<List<Party>>(File.ReadAllText(path));
            }
            else
            {
                File.Create(path).Close();
                
                return null;
            }
        }

        private static void SaveData(List<Party> parties)
        {
            string output = JsonConvert.SerializeObject(parties);
            File.WriteAllText("Data.json", output);
        }
    }
}
