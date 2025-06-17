namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要：科目別点数を求める
        private static IEnumerable<Student> ReadScore(string filePath) {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Student stu in _score) {
                if (dict.ContainsKey(stu.Name))
                    dict[stu.Name] += stu.Score;
                else
                    dict[stu.Name] = stu.Score;
            }
            return (IEnumerable<Student>)dict;
        }

        //メソッドの概要： 集計結果を出力する
        public IDictionary<string, int> GetPerStudentScore() {
              public static IEnumerable<Student> ReadSales(string filePath) {
            var score = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                string[] items = line.Split(',');
                var sco = new Student() {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2]),
                };
                Student.Add(Student);
            }
            return Student;
        }
    }
}
