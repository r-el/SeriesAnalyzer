using System;
using System.Text;

namespace TheSeriesAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] series = ParseSeriesFromArg(args);
            // if (series.Length < 3)
            //     series = ReadSeriesFromConsole();
            
            // PrintMenu();
        }

        /* לסדרה של מספרים שלמים args הפוך את 
         * (כולל טיפול בקלט לא תקין) */
        static int[] ParseSeriesFromArg(string[] args)
        {
            int[] series = new int[args.Length];

            for (int i = 0; i < args.Length; i++)
                if (!int.TryParse(args[i], out series[i]))
                    series[i] = ReadIntFromConsole($"arg #{i + 1} is invalid. Please enter a new integer: ");
                    
            return series;
        }

        /* קבל סדרה של של מספרים שלמים (לפחות 3) */
        static int[] ReadSeriesFromConsole()
        {
            // ...
            return [];
        }
        
        /* קבל מספר שלם מהקונסול (כולל ולידציה) */
        static int ReadIntFromConsole(string msgForUser = "Enter an integer: ")
        {
            int num;
            Console.Write(msgForUser);
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.Write("Invalid input. Please enter a valid integer: ");

            return num;
        }

        /* הדפס סדרה ישר/הפוך */
        static void PrintSeries(int[] series, bool revered = false)
        {
            // ...
        }

        /* קבל העתק ממוין של הסדרה */
        static int[] GetSortedSeries(int[] series)
        {
            // return copy ...
            return [];
        }

        /* קבל את המספר הגדול ביותר בסדרה */
        static int GetMaxValue(int[] series)
        {
            // ...
            return 0;
        }

        /* קבל את המספר הקטן ביותר הסדרה */
        static int GetMinValue(int[] series)
        {
            // ...
            return 0;
        }

        /* קבל את המספר ממוצע של הסדרה */
        static int GetAverage(int[] series)
        {
            // ...
            return 0;
        }

        /* קבל את גודל הסדרה */
        // פונקציה אולי מיותרת
        static int GetSeriesLength(int[] series)
        {
            return 0;
        }

        /* קבל את סכום הסדרה */
        static int GetSeriesSum(int[] series)
        {
            // ...
            return 0;
        }

        /* בדוק האם מחרוזת תואמת לאחד מהאפשרויות בתפריט */
        static bool IsValidMenuOption(string menuOption)
        // The answer should be displayed. 
        {
            // ...
            return false;
        }

        /* בצע פעולה מהתפריט */
        static int[] HandleMenuOption(string menuOption)
        {
            // ...
            return [];
        }

        /* הדפס תפריט */
        static void PrintMenu()
        {
            StringBuilder sb = new();
            sb.AppendLine("1) Input a Series. (Replace the current series)");
            sb.AppendLine("2) Display the series in the order it was entered.");
            sb.AppendLine("3) Display the series in the reversed order it was entered.");
            sb.AppendLine("4) Display the series in sorted order (from low to high).");
            sb.AppendLine("5) Display the Max value of the series.");
            sb.AppendLine("6) Display the Min value of the series.");
            sb.AppendLine("7) Display the Average of the series.");
            sb.AppendLine("8) Display the Number of elements in the series.");
            sb.AppendLine("9) Display the Sum of the series.");
            sb.AppendLine("0) Exit.");

            string menu = sb.ToString();

            Console.WriteLine(menu);
        }
    }
}