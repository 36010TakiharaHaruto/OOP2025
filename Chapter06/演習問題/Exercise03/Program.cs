
namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);
        }

        private static void Exercise1(string text) {
            //var cnt = text.Count(char.IsWhiteSpace)でも可
            var cnt = text.Count(c => c == ' ');
            Console.WriteLine(cnt);
        }

        private static void Exercise2(string text) {
            var replaced = text.Replace("big","small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {

        }

        private static void Exercise4(string text) {
            var word = text.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine(word);
        }

        private static void Exercise5(string text) {
            foreach (var word in text
            //空白で区切った単語だけを取り出す
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(word => word.Length <= 4)) {
                Console.WriteLine(word);
            }
        }
    }
}
