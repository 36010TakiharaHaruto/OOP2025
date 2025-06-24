using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var today = new DateTime(2025,6,24); //日付
            //var now = DateTime.Now;     //日付と時刻
            //Console.WriteLine($"Today : {today}");
            //Console.WriteLine($"Now : {now}");


            // ①自分の生年月日は何曜日かをプログラムを書いて調べる
            Console.Write("西暦:");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月:");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日:");
            var day = int.Parse(Console.ReadLine());
            var date = new DateTime(year, month, day);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(date);
            var eraName = culture.DateTimeFormat.GetEraName(era);
            var dayof = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            DayOfWeek dayofweek = date.DayOfWeek;
            Console.WriteLine($"{eraName}{month}月{day}日は{dayof}です");


            //②うるう年の判定プログラムを生成する
            Console.Write("西暦:");
            var uru = int.Parse(Console.ReadLine());
            var isLeapYear = DateTime.IsLeapYear(uru);
            if (isLeapYear) {
                Console.WriteLine($"{uru}年はうるう年です");
            } else {
                Console.WriteLine($"{uru}年は平年です");
            }

            //③生まれてから〇〇日メデス
            var now = DateTime.Now;
            var diff = now.Date - date.Date;
            Console.WriteLine($"生まれてから{diff}");

        }
    }
}
