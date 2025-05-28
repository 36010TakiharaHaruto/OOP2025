namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var books = Books.GetBooks();

            //本の平均金額を表示
            Console.WriteLine((int)books.Average(b => b.Price));

            //本のページ合計を表示
            Console.WriteLine(books.Sum(b => b.Pages));

            //金額の安い書籍名と金額を表示
            foreach (var book in books.Where(b => b.Price == books.Min(b => b.Price))) {
                Console.WriteLine(book.Title + "金額:" + book.Price + "円");
            }
            //ページが多い書籍名とページを表示
            // Console.WriteLine(books.Max(b => b.Pages + "ページ:" + b.Title));
            foreach (var book in books.Where(b => b.Pages == books.Max(b => b.Pages))) {
                Console.WriteLine(book.Title + ":" + book.Pages + "ページ");
            }

            //タイトルに「物語」が含まれている書籍名をすべて表示
            foreach (var book in books.Where(b => b.Title.Contains("物語"))) {
                Console.WriteLine(book.Title);
            }
        }
    }
}
