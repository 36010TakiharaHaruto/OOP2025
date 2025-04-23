namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {


            Console.WriteLine("1:インチからメートルに変換");
            Console.WriteLine("2:メートルからインチに変換");
            int conversion = int.Parse(Console.ReadLine());

            if (conversion == 1) {
              Console.Write("はじめ:");
            int start = int.Parse(Console.ReadLine());
            Console.Write("おわり:");
            int end = int.Parse(Console.ReadLine());
                //メソッドの呼び出し
                PrintinchToMeterList(start, end);

            } else if (conversion == 2) {
              Console.Write("はじめ:");
            int start = int.Parse(Console.ReadLine());
            Console.Write("おわり:");
            int end = int.Parse(Console.ReadLine());
                //メソッドの呼び出し
                PrintMeterToInchList(start, end);

            } else {
                Console.WriteLine("エラー");
            }
        }

        //インチからメートルへの変換
        static void PrintinchToMeterList(int start, int end) {
            for (int inch = start; inch <= end; inch++) {
                double meter = InchToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            }
        }

        //メートルからインチへの変換
        static void PrintMeterToInchList(int start, int end) {
            for (int meter = start; meter <= end; meter++) {
                double inch = MeterToInch(meter);
                Console.WriteLine($"{meter}m = {inch:0.0000}inch");
            }
        }
        static double InchToMeter(int inch) {
            return inch * 0.0254;
        }

        static double MeterToInch(int meter) {
            return meter / 0.0254;
        }
    }
}
