using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    //問題15.1
    internal class LineToHalfNumberService : TextFileService{
        private int _count;

        public void Initialize(string fname) {
        }

        public void Execute(string line) {
            Console.WriteLine(line.Normalize(NormalizationForm.FormKD));
        }

        public void Terminate() {
            Console.WriteLine("変換終了");
        }
    }
}
