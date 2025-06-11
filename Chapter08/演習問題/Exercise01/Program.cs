
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var dic = new Dictionary<char, int>();
            foreach (var ch in text.ToUpper()) {
                if ('A' <= ch && ch <= 'Z') {
                    if (dic.ContainsKey(ch)) {
                        dic[ch]++;
                    } else {
                        dic[ch] = 1;
                    }
                }
            }
            foreach (var a in dic.OrderBy(b => b.Key)) {
                Console.WriteLine($"{a.Key}:{a.Value} ");
            }
        }

        private static void Exercise2(string text) {
        }
    }
}
