using System.Net.Http.Json;

namespace WeatherApp {
    internal class Program {
        // 例：東京（緯度 35.0, 経度 139.0）の現在の気温などを取得
        //群馬（緯度 36.0, 経度 139.0）
        private const string Url =
            "https://api.open-meteo.com/v1/forecast?latitude=36.0&longitude=139.0&current=temperature_2m,wind_speed_10m,relative_humidity_2m,wind_direction_10m";

        static async Task Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Open-Meteo API サンプル ===");

            using var http = new HttpClient();

            try {
                // JSON デシリアライズ
                var weather = await http.GetFromJsonAsync<WeatherResponse>(Url);

                if (weather?.current != null) {
                    Console.WriteLine($"取得時刻：{weather.current.time}");
                    Console.WriteLine($"気温：{weather.current.temperature_2m} ℃");
                    Console.WriteLine($"風速：{weather.current.wind_speed_10m} m/s");
                    Console.WriteLine($"湿度：{weather.current.relative_humidity_2m} %");
                    Console.WriteLine($"風向：{weather.current.wind_direction_10m} m/s");
                } else {
                    Console.WriteLine("データが取得できませんでした。");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"エラー：{ex.Message}");
            }
        }
    }
}
