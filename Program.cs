using System;
using System.Globalization;
using System.Text;

namespace TheSeriesAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] series = ParseSeriesFromArg(args);
            if (series.Length < 3)
                series = ReadSeriesFromConsole();

            
            PrintSeries(GetSortedSeries(series));
            Console.WriteLine(GetMaxValue(series));
            Console.WriteLine(GetMinValue(series));
            // PrintMenu();
        }

        /* לסדרה של מספרים חיוביים args הפוך את
         * (כולל טיפול בקלט לא תקין) */
        static float[] ParseSeriesFromArg(string[] args)
        {
            float[] series = new float[args.Length];

            for (int i = 0; i < args.Length; i++)
                if (!float.TryParse(args[i], out series[i]) || series[i] < 0)
                    series[i] = ReadPositiveFloatFromConsole($"arg #{i + 1} is invalid. Please enter a new positive number: ");

            return series;
        }

        /* קבל סדרה של של מספרים חיוביים (לפחות 3) */
        static float[] ReadSeriesFromConsole()
        {
            List<float> positiveNumbers = []; // C# 12+
            Console.WriteLine("Enter at least 3 positive numbers.");

            while (true)
            {
                float number = ReadFloatFromConsole($"#{positiveNumbers.Count + 1} Enter a positive number (or -1 to end): ");

                if (number == -1.0f)
                {
                    if (positiveNumbers.Count >= 3)
                        break;
                    Console.WriteLine("You must enter at least 3 positive numbers before ending.");
                    continue;
                }

                if (number > 0)
                    positiveNumbers.Add(number);
                else
                    Console.WriteLine("Only positive numbers are allowed. Please try again.");
            }

            return [.. positiveNumbers];
        }

        /* קבל מספר חיובי מהקונסול (כולל ולידציה) */

        static float ReadPositiveFloatFromConsole(string msgForUser = "Enter a positive number: ")
        {
            float num = ReadFloatFromConsole(msgForUser);
            while (num < 0)
                num = ReadFloatFromConsole("Invalid input. Please enter a valid positive number: ", "");

            return num;
        }

        /* קבל מספר מהקונסול (כולל ולידציה) */
        static float ReadFloatFromConsole(string msgForUser = "Enter a number: ", string errMsg = "Invalid input. Please enter a valid number: ")
        {
            float num;
            Console.Write(msgForUser);
            while (
                !float.TryParse(
                    Console.ReadLine(),
                    NumberStyles.Float, // For Ubuntu he-IL
                    CultureInfo.InvariantCulture, // For Ubuntu he-IL
                    out num
                )
            )
                Console.Write(errMsg);

            return num;
        }

        /* הדפס סדרה ישר/הפוך */
        static void PrintSeries(float[] series, bool revered = false)
        {
            if (!revered)
            {
                for (int i = 0; i < series.Length; i++)
                    Console.Write(series[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = series.Length - 1; i >= 0; i--)
                    Console.Write(series[i] + " ");
                Console.WriteLine();
            }
        }

        /* קבל העתק ממוין של הסדרה */
        static float[] GetSortedSeries(float[] series)
        {
            float[] sortedSeries = series[..];
            for (int i = 0; i < sortedSeries.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < sortedSeries.Length - i - 1; j++)
                    if (sortedSeries[j] > sortedSeries[j + 1]) {
                        (sortedSeries[j], sortedSeries[j + 1]) = (sortedSeries[j + 1], sortedSeries[j]);
                        swapped = true;
                    }
                if (!swapped) break;
            }
            return sortedSeries;
        }

        /* קבל את המספר הגדול ביותר בסדרה */
        static float GetMaxValue(float[] series)
        {
            if (series.Length == 0)
                return -1;

            float max = series[0];
            for (int i = 0; i < series.Length; i++)
                if (series[i] > max)
                    max = series[i];

            return max;
        }

        /* קבל את המספר הקטן ביותר הסדרה */
        static float GetMinValue(float[] series)
        {
            if (series.Length == 0)
                return -1;

            float min = series[0];
            for (int i = 0; i < series.Length; i++)
                if (series[i] < min)
                    min = series[i];

            return min;
        }

        /* קבל את המספר ממוצע של הסדרה */
        static float GetAverage(float[] series)
        {
            // ...
            return 0;
        }

        /* קבל את גודל הסדרה */
        // פונקציה אולי מיותרת
        static float GetSeriesLength(float[] series)
        {
            return 0;
        }

        /* קבל את סכום הסדרה */
        static float GetSeriesSum(float[] series)
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
        static float[] HandleMenuOption(string menuOption)
        {
            // ...
            return new float[0];
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