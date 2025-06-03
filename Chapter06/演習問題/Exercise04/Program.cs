using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born1886";

            foreach (var pair in line.Split(";")) {
                var word = pair.Split('=');
                Console.WriteLine($"{ToJapanese(word[0])}:{word[1]}");
            }
        }


 
            static string ToJapanese(string key) {
                return key switch {
                    "Novelist" => "作家",
                    "BestWork" => "代表作",
                    "Born" => "誕生年",
                    _ => "引数keyは、正しい値ではありません"
                };
            }
    }
}
