namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            //インチからメートルへの変換
            for (int inch = 1; inch <= 10; inch++) {
                double meter = InchToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            }

            static double InchToMeter(int inch) {
                return inch * 0.0254;
            }
        }
    }
}
