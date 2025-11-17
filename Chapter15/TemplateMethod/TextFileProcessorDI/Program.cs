using System;
using System.IO;

namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            //var service = new LineOutputService();
            var service = new LineToHalfNumberService();
            var processor = new TextFileProcessor(service);
            Console.Write("パスの入力 : ");

            string path = Console.ReadLine();
            path = path.Trim().Trim('"');
            processor.Run(path);
        }
    }
}

