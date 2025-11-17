using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class TextFileProcessor {
        private TextFileService _service;

        //コンストラクター
        public TextFileProcessor(TextFileService service) {
            _service = service;
        }

        public void Run(string fileName) {
            _service.Initialize(fileName);

            var lines = File.ReadLines(fileName);
            foreach (var line in lines) {
                _service.Execute(line);
            }
            _service.Terminate();
        }
    }
}
