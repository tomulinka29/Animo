using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Volby
{
    class Program
    {
        static void Main(string[] args)
        {

            bool endProgram = false; // flag for ending a program

            while (!endProgram)
            {
                Console.Clear();
                Console.WriteLine("Chcete volit, editovat, nebo se podivat na vysledky? [1/2/3]");
                int mode;
                int.TryParse(Console.ReadLine(), out mode);

                Console.Clear();

                switch (mode)
                {
                    case 1:
                        VotingMode();
                        break;

                    case 2:
                        EditationMode();
                        break;

                    case 3:
                        ResultsMode();
                        break;

                    default:
                        Console.WriteLine("Neplatna volba");
                    break;

                }
            }


        }


        private static void VotingMode()
        {
            var parties = LoadData("Data.json");

            if (parties == null)
            {
                Console.WriteLine("Nebyly nacteny zadne strany");
                return;
            }


         

            try
            {
                //Show parties
                ShowParties(parties);
                Console.WriteLine("----------------");


                //Choose which party do you wanna give your vote
                int chosenID = ChooseParty(parties);
                Console.WriteLine("----------------");

                //Add vote to selected party and save
                parties[chosenID].AddVote();
                SaveData(parties);

                //Some info
                Console.WriteLine("OK, zvolil/a jste {0}", parties[chosenID].name);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba při zápisu vašeho hlasu: {0}", e.Message);
                Console.ReadLine();
            }
        }

        private static void EditationMode()
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

                default:
                    Console.WriteLine("Neplatna volba");
                    Console.ReadLine();
                    return;
            }


            try
            {
                SaveData(parties);
                Console.WriteLine("Upravy probehly uspesne");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba při zápisu uprav: {0}", e.Message);
                Console.ReadLine();
            }
        }

        private static void ResultsMode()
        {
            var parties = LoadData("Data.json");

            if (parties == null)
            {
                Console.WriteLine("Nebyly nacteny zadne strany");
                return;
            }

            Console.WriteLine("--------------------------------------");
            foreach (Party party in parties)
            {
                Console.WriteLine(party.name + "".PadLeft(parties.Max(e => e.name.Length + 4) - party.name.Length) + party.voteCount);
            }
            Console.WriteLine("--------------------------------------");

            int maxVotes = parties.Max(e => e.voteCount);

            foreach (var party in parties)
            {
                if (party.voteCount == maxVotes)
                    Console.WriteLine("Nejvice hlasu ma: " + party.name);
            }


            Console.ReadLine();
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

        private static int ChooseParty(List<Party> parties)
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
                string fileContent = File.ReadAllText(path);
                List<Party> parties = JsonConvert.DeserializeObject<List<Party>>(fileContent);

                return parties;
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
