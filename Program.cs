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
            if (series.Length == 0)
                return 0;

            float sum = 0;
            foreach (float num in series)
                sum += num;
            return sum / series.Length;
        }

        /* קבל את סכום הסדרה */
        static float GetSeriesSum(float[] series)
        {
            float sum = 0;
            foreach (float num in series)
                sum += num;
            return sum;
        }

        /* בדוק האם מחרוזת תואמת לאחד מהאפשרויות בתפריט (0-9) */
        static bool IsValidMenuOption(string menuOption)
        {
            return menuOption.Length == 1 && menuOption[0] >= '0' && menuOption[0] <= '9';
        }

        /* בצע פעולה מהתפריט */
        static void HandleMenuOption(string menuOption, ref float[] series)
        {
            switch (menuOption)
            {
                case "1":
                    series = ReadSeriesFromConsole();
                    Console.WriteLine("Series updated.");
                    break;
                case "2":
                    Console.WriteLine("Series in original order:");
                    PrintSeries(series);
                    break;
                case "3":
                    Console.WriteLine("Series in reversed order:");
                    PrintSeries(series, true);
                    break;
                case "4":
                    Console.WriteLine("Series in sorted order:");
                    PrintSeries(GetSortedSeries(series));
                    break;
                case "5":
                    Console.WriteLine($"Max value: {GetMaxValue(series)}");
                    break;
                case "6":
                    Console.WriteLine($"Min value: {GetMinValue(series)}");
                    break;
                case "7":
                    Console.WriteLine($"Average: {GetAverage(series)}");
                    break;
                case "8":
                    Console.WriteLine($"Number of elements: {series.Length}");
                    break;
                case "9":
                    Console.WriteLine($"Sum: {GetSeriesSum(series)}");
                    break;
                default:
                    Console.WriteLine("Unknown option.");
                    break;
            }
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