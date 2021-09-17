using System;
using System.Diagnostics;

namespace Series
{
    
    class Program
    {
        private static SeriesStorage storage = new SeriesStorage();
        
        static void Main(string[] args)
        {
            string input = GetNextUserInput();

            while (input != "X")
            {
                switch (input)
                {
                    case "1":
                        DisplayList();
                        break;
                    case "2":
                        InsertNewSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        VisualizeSeires();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                input = GetNextUserInput();
            }
        }

        private static void VisualizeSeires()
        {
            Console.WriteLine("Printing series");
            
            Console.WriteLine("Type the series ID: ");
            int id = int.Parse(Console.ReadLine());
            
            Console.WriteLine(storage.Get(id).ToString());
        }

        private static void DeleteSeries()
        {
            Console.WriteLine("Deleting series");

            Console.WriteLine("Type the series ID: ");
            int id = int.Parse(Console.ReadLine());
            
            storage.Delete(id);
        }

        private static void UpdateSeries()
        {
            
            Console.WriteLine("Updating series");
            
            Console.WriteLine("Type the series ID: ");
            int id = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i,(Genre)i);
            }
            
            Console.WriteLine("Type one of the available genres: ");
            Genre genre = (Genre) int.Parse(Console.ReadLine());
            
            Console.WriteLine("Type the series title: ");
            string title = Console.ReadLine();
            
            Console.WriteLine("Type the series description: ");
            string description = Console.ReadLine();
            
            Console.WriteLine("Type series starting year");
            int year = int.Parse(Console.ReadLine());

            Series newSeries = new Series(
                id, 
                genre,
                title, 
                description, 
                year
            );
            
            storage.Update(id,newSeries);
        }
        

        private static void InsertNewSeries()
        {
            Console.WriteLine("Inserting new seires");

            foreach (int i in System.Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i,(Genre)i);
            }
            
            Console.WriteLine("Type one of the available genres: ");
            Genre genre = (Genre) int.Parse(Console.ReadLine());
            
            Console.WriteLine("Type the series title: ");
            string title = Console.ReadLine();
            
            Console.WriteLine("Type the series description: ");
            string description = Console.ReadLine();
            
            Console.WriteLine("Type series starting year");
            int year = int.Parse(Console.ReadLine());

            Series newSeries = new Series(
                storage.NextId(), 
                genre,
                title, 
                description, 
                year
            );
            
            storage.Insert(newSeries);
        }

        private static void DisplayList()
        {
            var list = storage.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No registered seires");
                return;
            }

            foreach (var series in list)
            {
                if (!series.Deleted)
                {
                    Console.WriteLine("ID {0}: {1}",series.ID,series.Title);
                }
            }
        }

        private static string GetNextUserInput()
        {
            Console.WriteLine();
            Console.WriteLine("Series storage initialized");
            Console.WriteLine("Choose the desired option: ");
            
            Console.WriteLine("1- Display List");
            Console.WriteLine("2- Insert");
            Console.WriteLine("3- Update");
            Console.WriteLine("4- Delete");
            Console.WriteLine("5- Visualize");
            Console.WriteLine("C- Clear");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userInput;
        }
    }
}
