namespace Section01 {
    internal class Program {

        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            //var exists = cities.Exists(s => s[0] == 'A');
            //Console.WriteLine(exists);

            //var name = cities.Find(s => s.Length == 6);
            //Console.WriteLine(name);

            //var index = cities.FindIndex(s => s == "Berlin");
            //Console.WriteLine(index);

            //var names = cities.FindAll(s => s.Length <= 5);
            //cities.ForEach(Console.WriteLine);

            //var lowerList = cities.ConvertAll(s => s.ToLower());
            //lowerList.ForEach(Console.WriteLine);

            var upperList = cities.ConvertAll(s => s.ToUpper());
            upperList.ForEach(Console.WriteLine);


        }
    }
}
