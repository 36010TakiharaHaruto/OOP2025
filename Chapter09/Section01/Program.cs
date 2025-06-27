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
            var dayof = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            var era = culture.DateTimeFormat.Calendar.GetEra(date);
            var eraName = culture.DateTimeFormat.GetEraName(era);
            DayOfWeek dayofweek = date.DayOfWeek;
            Console.WriteLine($"{eraName}{month}月{day}日は{dayof}です");

            //③生まれてから〇〇日メデス
            var now = DateTime.Now;
            var diff = now.Date - date.Date;
            Console.WriteLine($"生まれてから{diff}");
            //TimeSpan diff;
            //while (true) {
            //    diff = DateTime.Now - date;
            //    Console.Write($"\r{diff.TotalSeconds}秒");//生まれてからの経過秒数 
            //}

            //④あなたは〇〇歳です
            static int GetAge(DateTime birthday, DateTime targetDay) {
                var age = targetDay.Year - birthday.Year;
                if (targetDay < birthday.AddYears(age)) {
                    age--;
                }
                return age;
            }
            var birthday = new DateTime(year, month, day);
            var today = DateTime.Today;
            int age = GetAge(date, today);
            Console.WriteLine($"{age}歳です");

            //⑤1月1日から何日目か
            int dayOfYear = today.DayOfYear;
            Console.WriteLine($"1月1日から{dayOfYear}日目");

            //②うるう年の判定プログラムを生成する
            Console.Write("西暦:");
            var uru = int.Parse(Console.ReadLine());
            var isLeapYear = DateTime.IsLeapYear(uru);
            if (isLeapYear) {
                Console.WriteLine($"{uru}年はうるう年です");
            } else {
                Console.WriteLine($"{uru}年は平年です");
            }
        }
    }
}
