using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;
        private string _keyword = "";

        protected override void Initialize(string fname) {
            Console.Write("単語を入力: ");
            _keyword = Console.ReadLine();
            _count = 0;
        }

        protected override void Execute(string line) {
            int index = 0;
            while ((index = line.IndexOf(_keyword, index)) != -1) {
                _count++;
                index += _keyword.Length;
            }
        }

        protected override void Terminate() => Console.WriteLine("\"{0}\" の出現回数: {1} 個", _keyword, _count);
    }
}
