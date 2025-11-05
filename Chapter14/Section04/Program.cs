using System.Threading.Tasks;

namespace Section04 {
    internal class Program {
        static async Task Main(string[] args) {
            HttpClient hc = new HttpClient();
            await GetHtmlExample(hc); 
        }

        static async Task GetHtmlExample(HttpClient httpClient) {
            var url = "https://www.google.com/?hl=ja";
            var text = await httpClient.GetStreamAsync(url);
            Console.WriteLine(text);
        }
    }
}
