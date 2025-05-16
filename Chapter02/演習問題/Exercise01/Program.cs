using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //歌データを入れるリストオブジェクトを生成


            while (title == "end") {
                Console.WriteLine("*****曲の登録*****");
                Console.WriteLine("曲名：");
                var title = Console.ReadLine();
                Console.WriteLine("アーティスト名");
                var artistname = Console.ReadLine();
                Console.WriteLine("演奏時間（秒）");
                int length = Console.ReadLine();
            }
        }
        //2.1.4
        private static void printSong(Song[] songs) {
#if false
            foreach(var song in songs){
                var minutes = song.Length / 60;
                var seconds = song.Length % 60;
                Console.WriteLine($"{song.Title},{song.ArtistName},{minutes}: {seconds:00}");
            }
#else
            //TimeSpan構造体を使った場合
            foreach(var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title},{song.ArtistName},{timespan.Minutes}: {timespan.Seconds:00}");
            }

            //以下でも可
            foreach (var song in songs) {
                Console.WriteLine(@"{0}, {1} {2:m\:es}",
                    song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }
#endif
            Console.WriteLine();
        }
    }
}
