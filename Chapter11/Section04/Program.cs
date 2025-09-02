using System.Text.RegularExpressions;

namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var text = "C#の学習をすこしずつ進めていこう。";
            var pattern = @"少しづつ|すこしづつ|すこしずつ";
            var replaced = Regex.Replace(text, pattern, "少しずつ");
            Console.WriteLine(replaced);
        }
    }
}
