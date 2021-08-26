using System;
using System.Collections.Generic;
using System.Text;
namespace RegisterApp
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        ExcludeSeries();
                        break;
                    case "5":
                        VisualizeSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you for using our services.");
            Console.ReadLine();
        }

        private static void ListSeries()
        {
            
            
           Console.WriteLine("List Series: ");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("There's no registered series :c");
                return;
            }
            foreach(var serie in list)
            {
                var excluded =  serie.returnExcluded();

                if (!excluded)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.returnId(), serie.returnTitle());
                }
            }
        }

        private static void InsertSeries()
        {
            Console.WriteLine("Insert a new series: ");

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Gender), i));
            }

            Console.Write("Inform the gender between the option above: ");
            int enterGender = int.Parse(Console.ReadLine());

            Console.Write("Inform the Title of the series: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Inform the year of the series: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Inform the description od the series: ");
            string enterDescription = Console.ReadLine();

            Series newSerie = new Series(id: repository.NextId(),
                                        gender: (Gender)enterGender,
                                        title: enterTitle,
                                        year: enterYear,
                                        description: enterDescription);

            repository.Insert(newSerie);
        }

        private static void ExcludeSeries()
        {
            Console.Write("Informe the series ID that you want to exclude: ");
            int seriesId = int.Parse(Console.ReadLine());

            repository.Exclude(seriesId);
        }
        private static void UpdateSeries()
        {
            Console.Write("Inform the series ID to update: ");
            int seriesId = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender),i));
            }

            Console.Write("Inform the gender between the option above: ");
            int enterGender = int.Parse(Console.ReadLine());

            Console.Write("Inform the Title of the series: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Inform the year of the series: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Inform the description od the series: ");
            string enterDescription = Console.ReadLine();

            Series updateSeries = new Series(id: seriesId,
                                        gender: (Gender)enterGender,
                                        title: enterTitle,
                                        year: enterYear,
                                        description: enterDescription);

            repository.Update(seriesId, updateSeries);
        }

        private static void VisualizeSeries()
        {
            Console.Write("Inform the series ID that you want to visualize: ");
            int seriesId = int.Parse(Console.ReadLine());

            var series = repository.ReturnById(seriesId);

            Console.WriteLine(series);
        }
        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series at your service!");
            Console.WriteLine("Inform the disered option:");

            Console.WriteLine("1 - List Series");
            Console.WriteLine("2 - Insert a new Serie");
            Console.WriteLine("3 - Update Serie");
            Console.WriteLine("4 - Exclude Serie");
            Console.WriteLine("5 - Visualize Serie");
            Console.WriteLine("C - Clean Screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
