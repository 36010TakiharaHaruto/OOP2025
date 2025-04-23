using System.Diagnostics.Metrics;
using System.Threading;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            //    Console.WriteLine("1:インチからメートルに変換");
            //    Console.WriteLine("2:メートルからインチに変換");
            //    int conversion = int.Parse(Console.ReadLine());

            //    if (conversion == 1) {
            //      Console.Write("はじめ:");
            //    int start = int.Parse(Console.ReadLine());
            //    Console.Write("おわり:");
            //    int end = int.Parse(Console.ReadLine());
            //        //メソッドの呼び出し
            //        PrintinchToMeterList(start, end);

            //    } else if (conversion == 2) {
            //      Console.Write("はじめ:");
            //    int start = int.Parse(Console.ReadLine());
            //    Console.Write("おわり:");
            //    int end = int.Parse(Console.ReadLine());
            //        //メソッドの呼び出し
            //        PrintMeterToInchList(start, end);

            //    } else {
            //        Console.WriteLine("エラー");
            //    }
            //}

            ////インチからメートルへの変換
            //static void PrintinchToMeterList(int start, int end) {
            //    for (int inch = start; inch <= end; inch++) {
            //        double meter = InchToMeter(inch);
            //        Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            //    }
            //}

            ////メートルからインチへの変換
            //static void PrintMeterToInchList(int start, int end) {
            //    for (int meter = start; meter <= end; meter++) {
            //        double inch = MeterToInch(meter);
            //        Console.WriteLine($"{meter}m = {inch:0.0000}inch");
            //    }
            //}
            //static double InchToMeter(int inch) {
            //    return inch * 0.0254;
            //}

            //static double MeterToInch(int meter) {
            //    return meter / 0.0254;
            //}

            Console.WriteLine("***　変換アプリ　***");
            Console.WriteLine("１：ヤードからメートル");
            Console.WriteLine("２：メートルからヤード");
            Console.Write(">");
            int conversion = int.Parse(Console.ReadLine());

            if (conversion == 1) {
                Console.Write("変換前（ヤード)");
                int yard = int.Parse(Console.ReadLine());
                //メソッドの呼び出し
                PrintYardToMeterList(yard);

            } else if (conversion == 2) {
                Console.Write("変換前（メートル)");
                int meter = int.Parse(Console.ReadLine());
                //メソッドの呼び出し
                PrintMeterToYardList(meter);

            } else {
                Console.WriteLine("エラー");
            }
        }

        //ヤードからメートルへの変換
        static void PrintYardToMeterList(int yard) {
            double meter = YardToMeter(yard);
            Console.WriteLine($"変換後（メートル）:{meter}");
        }

        //メートルからヤードへの変換
        static void PrintMeterToYardList(int meter) {
            double yard = MeterToYard(meter);
            Console.WriteLine($"変換後（ヤード）{yard}");
            }

            static double YardToMeter(int yard) {
            return yard * 0.9144;
        }

        static double MeterToYard(int meter) {
            return meter / 0.9144;
        }
    }
}