using System;
using System.Text;

namespace TheSeriesAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // ...
        }

        /* args-קבל סדרה של מספרים שלמים מ */
        static int[] GetSeriesFromArgs(string args)
        {
            // ...
            return [];
        }

        /* בודק האם ארגומנט תקין (ניתן להמיר אותו למספר שלם) */
        static bool IsValidArg(string arg)
        {
            // ...
            return false;
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
            // ...
            return 0;
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
            // ...
        }
    }
}