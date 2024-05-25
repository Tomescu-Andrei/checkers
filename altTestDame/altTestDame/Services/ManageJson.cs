using System;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using altTestDame.Models;
using Formatting = Newtonsoft.Json.Formatting;
using System.Windows;
using System.Linq;

namespace altTestDame.Services
{
    internal class ManageJson
    {
        public static ObservableCollection<ObservableCollection<Piece>> ReadBoardFromJson()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Board.json");
            ObservableCollection<ObservableCollection<Piece>> board;
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    board = JsonConvert.DeserializeObject<ObservableCollection<ObservableCollection<Piece>>>(json);
                }
                else
                {
                    board = new ObservableCollection<ObservableCollection<Piece>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading JSON file: " + ex.Message);
                board = new ObservableCollection<ObservableCollection<Piece>>();
            }
            return board;
        }

  

 

        public static (int redScore, int maxRed, int blackScore, int maxBlack) ReadStatisticsFromJson()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Integers.json");
            (int redScore, int maxRed, int blackScore, int maxBlack) result = (0, 0, 0, 0);
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    var statistics = JsonConvert.DeserializeObject<dynamic>(json);
                    result = (
                        redScore: (int)statistics.RedScore,
                        maxRed: (int)statistics.MaxRed,
                        blackScore: (int)statistics.BlackScore,
                        maxBlack: (int)statistics.MaxBlack
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading JSON file: " + ex.Message);
            }
            return result;
        }


        public static void WriteStatisticsToJson((int redScore, int maxRed, int blackScore, int maxBlack) numbers)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Integers.json");
            try
            {
                var statistics = new
                {
                    RedScore = numbers.redScore,
                    MaxRed = numbers.maxRed,
                    BlackScore = numbers.blackScore,
                    MaxBlack = numbers.maxBlack
                };

                string updatedJson = JsonConvert.SerializeObject(statistics, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to JSON file: " + ex.Message);
            }
        }


        public static void EnterInFile(bool parameter)
        {
            string continut = parameter.ToString();

            string numeFisier = "mutiple.txt";

            using (StreamWriter sw = new StreamWriter(numeFisier))
            {
                sw.Write(continut);
            }

            Console.WriteLine("Șirul a fost salvat în fișierul " + numeFisier);
        }

        public static bool ReadFromFileAndConvertToBool(string numeFisier)
        {
            bool rezultat = false;

            try
            {
                if (File.Exists(numeFisier))
                {
                    using (StreamReader sr = new StreamReader(numeFisier))
                    {
                        string continut = sr.ReadToEnd();

                        rezultat = bool.Parse(continut);
                    }
                }
                else
                {
                    Console.WriteLine("Fișierul nu există.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la citirea din fișier: " + ex.Message);
            }

            return rezultat;
        }



    }
}
