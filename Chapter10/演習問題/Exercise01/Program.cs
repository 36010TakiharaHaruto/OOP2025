using System;
using System.IO;
using System.Linq;
class Exercise01
    {
    static void Main() {
        Console.Write("読み込むC#ファイル名を入力してください: ");
        string filePath = Console.ReadLine();
        if (!File.Exists(filePath)) {
            Console.WriteLine("ファイルが見つかりません。");
            return;
        }
        var lines = File.ReadLines(filePath);
        int count = 0;
        foreach (var line in lines) {
            if (line.Contains("class")) {

                count++;

            }

        }
        Console.WriteLine($"'class' は {count} 回出現しました。");
    }

}
