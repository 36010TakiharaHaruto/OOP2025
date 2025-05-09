namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            
            SalesCounter sales = new SalesCounter(@"data\sales.csv");
           
           IDictionary<string,int> amountsPerStore = sales.GetPerSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }
    }
}
