using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercis01 {
    internal class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);

        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            Console.WriteLine(string.Format("{0:yyyy/MM/dd HH:mm}", dateTime));
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            Console.WriteLine(dateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒"));
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayof = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            var str = dateTime.ToString("ggy年M月d日",culture);
            Console.WriteLine($"{str}({dayof})");
        }
    }
}
