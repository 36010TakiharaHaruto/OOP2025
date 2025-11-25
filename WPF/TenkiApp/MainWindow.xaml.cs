using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TenkiApp {
    public partial class MainWindow : Window {
        private const string UrlTemplate =
            "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current_weather=true&daily=temperature_2m_max,temperature_2m_min,weathercode&timezone=Asia/Tokyo";

        public class Prefecture {
            public string Name { get; set; }
            public double Lat { get; set; }
            public double Lon { get; set; }
        }

        private List<Prefecture> Prefectures = new List<Prefecture>
        {
    new Prefecture{Name="北海道",Lat=43.0618,Lon=141.3545}, 
    new Prefecture{Name="青森",Lat=40.82444,Lon=140.74},
    new Prefecture{Name="岩手",Lat=39.70361,Lon=141.1525},
    new Prefecture{Name="宮城",Lat=38.26889,Lon=140.87194},
    new Prefecture{Name="秋田",Lat=39.71861,Lon=140.1025},
    new Prefecture{Name="山形",Lat=38.24056,Lon=140.36333},
    new Prefecture{Name="福島",Lat=37.75,Lon=140.46778},
    new Prefecture{Name="茨城",Lat=36.34139,Lon=140.44667},
    new Prefecture{Name="栃木",Lat=36.56583,Lon=139.88361},
    new Prefecture{Name="群馬",Lat=36.3907,Lon=139.0603},
    new Prefecture{Name="埼玉",Lat=35.85694,Lon=139.64889},
    new Prefecture{Name="千葉",Lat=35.60472,Lon=140.12333},
    new Prefecture{Name="東京",Lat=35.6895,Lon=139.6917},
    new Prefecture{Name="神奈川",Lat=35.44778,Lon=139.6425},
    new Prefecture{Name="新潟",Lat=37.90222,Lon=139.02361},
    new Prefecture{Name="富山",Lat=36.69528,Lon=137.21139},
    new Prefecture{Name="石川",Lat=36.59444,Lon=136.62556},
    new Prefecture{Name="福井",Lat=36.06528,Lon=136.22194},
    new Prefecture{Name="山梨",Lat=35.66389,Lon=138.56833},
    new Prefecture{Name="長野",Lat=36.65139,Lon=138.18111},
    new Prefecture{Name="岐阜",Lat=35.39111,Lon=136.72222},
    new Prefecture{Name="静岡",Lat=34.97694,Lon=138.38306},
    new Prefecture{Name="愛知",Lat=35.18028,Lon=136.90667},
    new Prefecture{Name="三重",Lat=34.73028,Lon=136.50861},
    new Prefecture{Name="滋賀",Lat=35.00444,Lon=135.86833},
    new Prefecture{Name="京都",Lat=35.02139,Lon=135.75556},
    new Prefecture{Name="大阪",Lat=34.6937,Lon=135.5023},
    new Prefecture{Name="兵庫",Lat=34.69139,Lon=135.18306},
    new Prefecture{Name="奈良",Lat=34.68528,Lon=135.83278},
    new Prefecture{Name="和歌山",Lat=34.22611,Lon=135.1675},
    new Prefecture{Name="鳥取",Lat=35.50361,Lon=134.23833},
    new Prefecture{Name="島根",Lat=35.47222,Lon=133.05056},
    new Prefecture{Name="岡山",Lat=34.66167,Lon=133.935},
    new Prefecture{Name="広島",Lat=34.39639,Lon=132.45944},
    new Prefecture{Name="山口",Lat=34.18583,Lon=131.47139},
    new Prefecture{Name="徳島",Lat=34.06583,Lon=134.55944},
    new Prefecture{Name="香川",Lat=34.34028,Lon=134.04333},
    new Prefecture{Name="愛媛",Lat=33.84167,Lon=132.76556},
    new Prefecture{Name="高知",Lat=33.55972,Lon=133.53111},
    new Prefecture{Name="福岡",Lat=33.5902,Lon=130.4017},
    new Prefecture{Name="佐賀",Lat=33.24944,Lon=130.29889},
    new Prefecture{Name="長崎",Lat=32.74472,Lon=129.87361},
    new Prefecture{Name="熊本",Lat=32.78972,Lon=130.74167},
    new Prefecture{Name="大分",Lat=33.23806,Lon=131.6125},
    new Prefecture{Name="宮崎",Lat=31.91111,Lon=131.42389},
    new Prefecture{Name="鹿児島",Lat=31.56028,Lon=130.55806},
    new Prefecture{Name="沖縄",Lat=26.2125,Lon=127.68111},
};


        public MainWindow() {
            InitializeComponent();
            PrefCombo.ItemsSource = Prefectures;
            SetCurrentLocationPrefecture(); // 起動時に現在地
            PrefCombo.SelectionChanged += PrefCombo_SelectionChanged;
        }

        // 起動時にIPから現在地を推定して都道府県選択
        private async void SetCurrentLocationPrefecture() {
            try {
                using var http = new HttpClient();
                var loc = await http.GetFromJsonAsync<IpApiResponse>("http://ip-api.com/json");
                if (loc != null) {
                    double lat = loc.lat;
                    double lon = loc.lon;

                    Prefecture nearest = null;
                    double minDistance = double.MaxValue;
                    foreach (var p in Prefectures) {
                        double d = GetDistance(lat, lon, p.Lat, p.Lon);
                        if (d < minDistance) { minDistance = d; nearest = p; }
                    }
                    if (nearest != null) PrefCombo.SelectedItem = nearest;
                }
            }
            catch {
                PrefCombo.SelectedIndex = 0; // 失敗時は北海道
            }
        }

        private double GetDistance(double lat1, double lon1, double lat2, double lon2) {
            double dLat = (lat2 - lat1) * Math.PI / 180.0;
            double dLon = (lon2 - lon1) * Math.PI / 180.0;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1 * Math.PI / 180.0) * Math.Cos(lat2 * Math.PI / 180.0) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return 6371 * c;
        }

        public class IpApiResponse { public double lat { get; set; } public double lon { get; set; } }

        private async void PrefCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (PrefCombo.SelectedItem == null) return;
            Prefecture selected = (Prefecture)PrefCombo.SelectedItem;

            AreaTitle.Text = selected.Name;
            AreaTitle.Foreground = Brushes.MediumPurple;
            TimeText.Foreground = Brushes.MediumPurple;
            TempText.Foreground = Brushes.MediumPurple;
            WindText.Foreground = Brushes.MediumPurple;
            WindDirText.Foreground = Brushes.MediumPurple;
            StatusText.Foreground = new SolidColorBrush(Color.FromArgb(200, 180, 162, 255));

            string url = string.Format(UrlTemplate, selected.Lat, selected.Lon);
            using var http = new HttpClient();
            try {
                var weather = await http.GetFromJsonAsync<WeatherResponse>(url);
                if (weather?.current_weather != null) {
                    TimeText.Text = $"取得時刻: {weather.current_weather.time}";
                    TempText.Text = $"気温: {weather.current_weather.temperature} ℃";
                    WindText.Text = $"風速: {weather.current_weather.windspeed} m/s";
                    WindDirText.Text = $"風向: {weather.current_weather.winddirection} °";

                    WeatherIcon.Text = GetWeatherEmoji(weather.current_weather.weathercode);
                    WeatherIcon.Foreground = Brushes.Orchid;

                    DrawGraph(weather);
                    ShowWeeklyForecast(weather, selected.Name);

                    UpdateMiniSummary(weather.current_weather);
                    UpdateAdvice(weather.current_weather);

                }
            }
            catch (Exception ex) {
                StatusText.Text = $"エラー: {ex.Message}";
            }
        }

        private string GetWeatherEmoji(int code) {
            if (code == 0) return "☀️";
            if (code >= 1 && code <= 3) return "⛅";
            if (code >= 45 && code <= 48) return "🌫";
            if ((code >= 51 && code <= 67) || (code >= 80 && code <= 82)) return "🌧️";
            if (code >= 71 && code <= 77) return "❄️";
            if (code >= 95 && code <= 99) return "⛈️";
            return "☁️";
        }

        private string GetDayOfWeek(string date) {
            if (DateTime.TryParse(date, out DateTime dt))
                return dt.ToString("ddd");
            return "";
        }

        private readonly Random rnd = new Random();
        private void UpdateMiniSummary(CurrentWeather cw) {
            var summaries = new List<string>
{
    "今日はポカポカあったかいよ☀️気持ちいいね！",
    "ぽかぽか陽気♪お散歩日和だよ🚶‍♂️🌼",
    "少し肌寒いかも…上着があると安心だよ🧥",
    "風が強い1日になりそう。飛ばされないようにね🍃",
    "湿気高め…髪がうねりやすそう💧",
    "しっとりした空気。落ち着いた雰囲気の1日だね😌",
    "過ごしやすい気温、快適な1日になりそうだよ🌈",
    "ちょっとムシムシするかも💦水分補給忘れずに！",
    "爽やかな涼しい風が気持ちいいよ🍃",
    "空気が乾燥気味。お肌ケア大事だよ✨",
    "雲が多めだけど過ごしやすい天気だよ☁️",
    "急に天気が変わりそう…注意してね🌦️",
    "外は結構寒いよ❄️あったかくしてね🧣",
    "太陽がしっかり出てるよ☀️日差しがやや強め",
    "夕方から冷え込みそう…気をつけて🥶",
    "外はしっとり静かな雰囲気🌫 落ち着くね",
    "全体的に穏やかな気候だよ。リラックスして過ごせる日😌",
    "ちょっと蒸し暑いね💦こまめに水分補給しよ！",
    "爽やかで心地よい1日になりそう🌿",
    "風がひんやりして気持ちいいね🍃",
    "今日は青空が広がって気分も晴れやか🌤️",
    "曇りがちだけど気温は快適☁️",
    "雨は少なめだけど湿度は高め💧",
    "夕方から夕焼けがきれいになりそう🌇",
    "朝は少し冷え込むけど昼間は暖かいよ🌞",
    "夜はひんやりするかも❄️",
    "午前中は晴れ、午後は少し雲が出そう☀️☁️",
    "風が強めなので帽子注意👒",
    "太陽が優しく降り注ぐ1日☀️",
    "湿度がちょうどよく快適だよ😌",
    "曇りだけど散歩には良い天気🚶‍♀️",
    "ちょっと肌寒いけど日差しはあるよ🌤️",
    "午後から雲が多くなるかも☁️",
    "外でリフレッシュするのに良い日🌿",
    "今日は涼しく過ごしやすいね🍃",
    "日差しが柔らかくて気持ちいい☀️",
    "夕方から少し風が強くなる予報🍃",
    "快適な気温でお出かけ日和🌈",
    "少し蒸し暑いかも。水分補給忘れずに💦",
    "朝晩は冷え込むので上着があると安心🧥",
    "今日は穏やかな天気でリラックス日😌",
    "午後から晴れる予報☀️",
    "気温差があるので服装注意👚",
    "爽やかな空気で心もリフレッシュ🌿",
    "少し風が冷たいので手袋もあると快適🧤",
    "湿度が低めでカラッとしているよ🌬️",
    "雨はほとんど降らなそう☂️",
    "午前は曇り、午後は晴れる予報🌤️",
    "今日も穏やかで快適な1日になりそう😎",
    "夕方は涼しくなりそう。気温調整してね🧥"
};


            string randomSummary = summaries[rnd.Next(summaries.Count)];

            StatusText.Text = randomSummary;

            MiniTempText.Text = $"{cw.temperature} ℃";
            MiniWindText.Text = $"{cw.windspeed} m/s";
            MiniHumidityText.Text = $"湿度: - %";
            MiniWeatherIcon.Text = GetWeatherEmoji(cw.weathercode);
        }

        private void UpdateAdvice(CurrentWeather cw) {
            var advices = new List<string>
    {
    "水分補給をこまめにね🥤",
    "日焼け止め塗ると安心だよ🌞",
    "風が強いので帽子が飛ばされないように注意👒",
    "帰りが遅いなら上着持っていこう🧥",
    "雨がポツポツ来るかも…傘あると安心☂️",
    "体調崩しやすい時期…無理しないでね😌",
    "湿度高めだから髪がうねりやすいよ💧",
    "乾燥気味…保湿大事だよ✨",
    "散歩したらリフレッシュできそう🚶‍♂️🌿",
    "気温差があるから服装調整をしっかり！👚",
    "空気が冷たいよ。マフラーおすすめ🧣",
    "夜になると冷えるかも。帰り道気をつけて🌙",
    "外出時は歩きやすい靴がいいかも👟",
    "暑い日は無理せず休憩して動こう😵‍💫",
    "風邪ひきやすい日。温かいもの飲んでね☕",
    "汗ばむ1日になりそう。タオルあると便利🧻",
    "空気が澄んでるよ。遠くまでよく見えるかも👀",
    "今日はのんびり過ごすと良い日だよ😴",
    "喉乾きやすいよ。ドリンク持っていって🥤",
    "紫外線ちょっと強め。気をつけてね🌞",
    "夜は雨になるかも。帰りのために準備しよ☂️",
    "熱中症対策大事！こまめに休憩してね🌡️",
    "風が冷たい。手袋あると快適だよ🧤",
    "外は過ごしやすいよ。気分転換に最高🌈",
    "汗かきやすい日。着替えあると安心👕",
    "外に出るなら軽く運動すると気分爽快💪",
    "曇りだけど気温は快適☁️",
    "雨は少なめだけど湿度は高め💧",
    "今日の夜は涼しいので温かい飲み物おすすめ☕",
    "午後から雲が多くなるかも☁️",
    "朝は少し冷えるので羽織り物あると安心🧥",
    "今日は洗濯日和！お天気味方だよ☀️",
    "気温が上がるので水分補給忘れずに💦",
    "風が強いので帽子や髪型注意👒",
    "夜は星が見えそう✨天体観測日和かも🌙",
    "外でリフレッシュするのに良い日🌿",
    "体調管理に気をつけて無理せず😌",
    "湿度が低めで快適。布団も干しやすいね🌞",
    "小雨が降るかも。傘を忘れずに☂️",
    "外出の際は温度差に注意👚",
    "今日は快晴！お出かけ日和☀️",
    "空気がひんやり。軽くストレッチすると気持ちいい🧘",
    "夜は少し冷えるので毛布あると安心🛏️",
    "室内も涼しいかも。軽く暖房つけてもOK🔥",
    "午前中は日差し強め。帽子やサングラスおすすめ🕶️",
    "午後は曇る予報。天気チェックしてね☁️",
    "散歩や運動に最適な天気🌈",
    "雨が降る前に洗濯物取り込もう☂️",
    "今日も穏やかで快適な1日になりそう😎",
    "外は少し蒸し暑いかも。水分補給しっかり💦"
};


            AdviceText.Text = advices[rnd.Next(advices.Count)];
        }


        private void DrawGraph(WeatherResponse weather) {
            GraphCanvas.Children.Clear();
            if (weather.daily == null || weather.daily.temperature_2m_max.Count == 0) return;

            double width = GraphCanvas.ActualWidth > 0 ? GraphCanvas.ActualWidth : 400;
            double height = GraphCanvas.ActualHeight > 0 ? GraphCanvas.ActualHeight : 200;
            double yMargin = 30;

            double maxTemp = double.MinValue;
            double minTemp = double.MaxValue;
            foreach (var t in weather.daily.temperature_2m_max) maxTemp = Math.Max(maxTemp, t);
            foreach (var t in weather.daily.temperature_2m_min) minTemp = Math.Min(minTemp, t);

            int days = weather.daily.temperature_2m_max.Count;
            double xStep = width / (days - 1);

            TextBlock maxLegend = new TextBlock { Text = "最高気温", Foreground = Brushes.MediumPurple, FontWeight = FontWeights.Bold };
            Canvas.SetLeft(maxLegend, 10); Canvas.SetTop(maxLegend, 0);
            GraphCanvas.Children.Add(maxLegend);

            TextBlock minLegend = new TextBlock { Text = "最低気温", Foreground = Brushes.Orchid, FontWeight = FontWeights.Bold };
            Canvas.SetLeft(minLegend, 120); Canvas.SetTop(minLegend, 0);
            GraphCanvas.Children.Add(minLegend);

            for (int i = 0; i < days; i++) {
                double x = i * xStep;
                double yMax = height - ((weather.daily.temperature_2m_max[i] - minTemp) / (maxTemp - minTemp) * (height - 2 * yMargin)) - yMargin;
                double yMin = height - ((weather.daily.temperature_2m_min[i] - minTemp) / (maxTemp - minTemp) * (height - 2 * yMargin)) - yMargin;

                Ellipse eMax = new Ellipse { Width = 10, Height = 10, Fill = Brushes.MediumPurple };
                Canvas.SetLeft(eMax, x - 5); Canvas.SetTop(eMax, yMax - 5);
                GraphCanvas.Children.Add(eMax);

                Ellipse eMin = new Ellipse { Width = 10, Height = 10, Fill = Brushes.Orchid };
                Canvas.SetLeft(eMin, x - 5); Canvas.SetTop(eMin, yMin - 5);
                GraphCanvas.Children.Add(eMin);

                if (i > 0) {
                    Line lMax = new Line {
                        X1 = (i - 1) * xStep,
                        Y1 = height - ((weather.daily.temperature_2m_max[i - 1] - minTemp) / (maxTemp - minTemp) * (height - 2 * yMargin)) - yMargin,
                        X2 = x,
                        Y2 = yMax,
                        Stroke = Brushes.MediumPurple,
                        StrokeThickness = 3
                    };
                    GraphCanvas.Children.Add(lMax);

                    Line lMin = new Line {
                        X1 = (i - 1) * xStep,
                        Y1 = height - ((weather.daily.temperature_2m_min[i - 1] - minTemp) / (maxTemp - minTemp) * (height - 2 * yMargin)) - yMargin,
                        X2 = x,
                        Y2 = yMin,
                        Stroke = Brushes.Orchid,
                        StrokeThickness = 3
                    };
                    GraphCanvas.Children.Add(lMin);
                }

                string dateStr = weather.daily.time[i].Substring(5).Replace("-", "/");
                TextBlock dateLabel = new TextBlock {
                    Text = dateStr,
                    Foreground = Brushes.MediumPurple,
                    FontSize = 12
                };
                Canvas.SetLeft(dateLabel, x - 15);
                Canvas.SetTop(dateLabel, height - 15);
                GraphCanvas.Children.Add(dateLabel);
            }
        }

        private void ShowWeeklyForecast(WeatherResponse weather, string prefName) {
            WeeklyPanel.Children.Clear();
            if (weather.daily != null) {
                for (int i = 0; i < weather.daily.time.Count; i++) {
                    double max = weather.daily.temperature_2m_max[i];
                    double min = weather.daily.temperature_2m_min[i];
                    string emoji = GetWeatherEmoji(weather.daily.weathercode[i]);
                    string dayOfWeek = GetDayOfWeek(weather.daily.time[i]);
                    string dateStr = weather.daily.time[i].Substring(5).Replace("-", "/");

                    TextBlock dayBlock = new TextBlock {
                        Text = $"{prefName}\n{dayOfWeek} {dateStr}\n{emoji}\nMax: {max}℃\nMin: {min}℃",
                        Foreground = Brushes.MediumPurple,
                        FontSize = 16,
                        Margin = new Thickness(5),
                        Padding = new Thickness(10),
                        Background = new SolidColorBrush(Color.FromArgb(150, 230, 220, 255)), // 薄ラベンダー
                        TextAlignment = TextAlignment.Center,
                        Width = 100
                    };
                    WeeklyPanel.Children.Add(dayBlock);
                }
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e) {
            PrefCombo_SelectionChanged(null, null);
        }
    }

    public class WeatherResponse {
        public CurrentWeather? current_weather { get; set; }
        public DailyWeather? daily { get; set; }
    }

    public class CurrentWeather {
        public string? time { get; set; }
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public double winddirection { get; set; }
        public int weathercode { get; set; }
    }

    public class DailyWeather {
        public List<string> time { get; set; } = new List<string>();
        public List<double> temperature_2m_max { get; set; } = new List<double>();
        public List<double> temperature_2m_min { get; set; } = new List<double>();
        public List<int> weathercode { get; set; } = new List<int>();
    }
}
