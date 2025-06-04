
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;

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

            Console.WriteLine("6.3.99");
            Exercise6(text);
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
            var sb = new StringBuilder();
            foreach(var word in text.Split(' ')) {
                sb.Append(word + " ");
            }
            var t = sb.ToString();
            Console.WriteLine(t);
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

        private static void Exercise6(string text) {
            //var nexttext = text.ToLower();
            //Console.WriteLine("a:" + nexttext.Where(c => c == 'a').Count());
            //Console.WriteLine("b:" + nexttext.Where(c => c == 'b').Count());
            //Console.WriteLine("c:" + nexttext.Where(c => c == 'c').Count());
            //Console.WriteLine("d:" + nexttext.Where(c => c == 'd').Count());
            //Console.WriteLine("e:" + nexttext.Where(c => c == 'e').Count());
            //Console.WriteLine("f:" + nexttext.Where(c => c == 'f').Count());
            //Console.WriteLine("g:" + nexttext.Where(c => c == 'g').Count());
            //Console.WriteLine("h:" + nexttext.Where(c => c == 'h').Count());
            //Console.WriteLine("i:" + nexttext.Where(c => c == 'i').Count());
            //Console.WriteLine("j:" + nexttext.Where(c => c == 'g').Count());
            //Console.WriteLine("k:" + nexttext.Where(c => c == 'k').Count());
            //Console.WriteLine("l:" + nexttext.Where(c => c == 'l').Count());
            //Console.WriteLine("m:" + nexttext.Where(c => c == 'm').Count());
            //Console.WriteLine("n:" + nexttext.Where(c => c == 'n').Count());
            //Console.WriteLine("o:" + nexttext.Where(c => c == 'o').Count());
            //Console.WriteLine("p:" + nexttext.Where(c => c == 'p').Count());
            //Console.WriteLine("q:" + nexttext.Where(c => c == 'q').Count());
            //Console.WriteLine("r:" + nexttext.Where(c => c == 'r').Count());
            //Console.WriteLine("s:" + nexttext.Where(c => c == 's').Count());
            //Console.WriteLine("t:" + nexttext.Where(c => c == 't').Count());
            //Console.WriteLine("u:" + nexttext.Where(c => c == 'u').Count());
            //Console.WriteLine("v:" + nexttext.Where(c => c == 'v').Count());
            //Console.WriteLine("w:" + nexttext.Where(c => c == 'w').Count());
            //Console.WriteLine("x:" + nexttext.Where(c => c == 'x').Count());
            //Console.WriteLine("y:" + nexttext.Where(c => c == 'y').Count());
            //Console.WriteLine("z:" + nexttext.Where(c => c == 'z').Count());


            //var str = text.ToLower().Replace(" ","");
            //var alphDicCount = Enumerable.Range('a', 26)
            //    .ToDictionary(num => ((char)num).ToString(), num => 0);
            //foreach (var alph in str) {
            //    alphDicCount[alph.ToString()]++;
            //}
            //foreach (var item in alphDicCount) {
            //    Console.WriteLine($"{item.Key}:{item.Value}");
            //}



            //var str = text.ToLower().Replace(" ", "");
            //var array = Enumerable.Repeat(0, 26).ToArray();
            //foreach (var alph in str) {
            //    array[alph - 'a']++;
            //}
            //for (char ch = 'a'; ch <= 'z'; ch++) {
            //    Console.WriteLine($"{ch}:{text.Count(tc => tc == ch)}");
            //}



                var nexttext = text.ToLower();
            for (var c = 'a'; c <= 'z'; c++) {
                Console.WriteLine(c + ":" + nexttext.Count(ct => ct == c));
            }

        }


    }
}
