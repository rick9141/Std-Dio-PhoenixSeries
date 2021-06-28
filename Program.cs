using System;
using Phoenix.Series.Classes;

namespace Phoenix.Series
{
    class Program
    {
        static readonly SeriesRepository repository = new();
        static void Main(string[] args)
        {
            string optionUser = UserMenu();

            while (optionUser.ToUpper() != "X")
            {
                switch (optionUser)
                {
                    case "1":
                        ListSeries();
                        break;

                    case "2":
                        InsertSerie();
                        break;

                    case "3":
                        UpdateSerie();
                        break;

                    case "4":
                        DeleteSerie();
                        break;

                    case "5":
                        ViewSerie();
                        break;

                    case "6":
                        Console.Clear();
                        break;
                }
                optionUser = UserMenu();
            }
            Console.WriteLine("Thank you for using our services.");
            Console.ReadLine();
        }

        private static string UserMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Series Management - PhoenixSeries");
            Console.WriteLine();
            Console.Write("=========Menu=========\n" +
                "(1) - Series List\n" +
                "(2) - Add New Serie\n" +
                "(3) - Serie Update\n" +
                "(4) - Serie Remove\n" +
                "(5) - Serie View\n" +
                "(6) - Clean Display\n" +
                "Enter the desired option: ");

            string optionUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return optionUser;
        }

        private static void ListSeries()
        {
            Console.WriteLine("Series List");
            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No series found.");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.ReturnDeleted();
                Console.WriteLine("#ID {0}: - {1}", serie.ReturnId(), serie.ReturnTitle());
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Insert a new series");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.WriteLine("Enter the gender from the options above: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter a series title: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Enter a Serie release date: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Enter a Serie Description: ");
            string enterDescription = Console.ReadLine();

            Serie newSerie = new(id: repository.NextId(),
                                       genre: (Genre)enterGenre,
                                       title: enterTitle,
                                       description: enterDescription,
                                       year: enterYear);

            repository.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Enter the Series Id: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.WriteLine("Enter the gender from the options above: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter a series title: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Enter a Serie release date: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Enter a Serie Description: ");
            string enterDescription = Console.ReadLine();

            Serie updateSerie = new(id: indiceSerie,
                                       genre: (Genre)enterGenre,
                                       title: enterTitle,
                                       description: enterDescription,
                                       year: enterYear);

            repository.Update(indiceSerie, updateSerie);
        }

        private static void DeleteSerie()
        {
            Console.Write("Enter the Series Id: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.Write("Are you sure you want to delete the Series? Type Y for yes or N for no: ");
            string confirmation = Console.ReadLine().ToUpper();

            if (confirmation == "Y")
            {
                repository.Delete(indiceSerie);
                Console.WriteLine("Deleted Series");
            }
            else if (confirmation == "N")
            {
                Console.WriteLine("Ok, returning to the main menu...");
            }
            else if (confirmation != "Y" || confirmation != "N")
            {
                Console.WriteLine("Just type Y or N, please try again!");
                DeleteSerie();
            }

        }

        private static void ViewSerie()
        {
            Console.Write("Enter the Series Id: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(indiceSerie);

            Console.WriteLine(serie);
        }
    }
}
