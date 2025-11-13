using System;
using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            string path;
            if (args.Length > 0) {
                path = args[0];
            }
            else {
                Console.Write("パスを入力: ");
                path = Console.ReadLine();
            }
            path = path.Trim().Trim('"');
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) {
                Console.WriteLine("パスを指定してください");
                return;
            }
            TextProcessor.Run<LineCounterProcessor>(path);
        }
    }
}
