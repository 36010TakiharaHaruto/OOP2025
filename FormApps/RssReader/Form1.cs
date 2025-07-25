using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();

            cbUrl.DisplayMember = "Key";
            cbUrl.ValueMember = "Value";

            cbUrl.Items.Add(new KeyValuePair<string, string>("国内", "https://news.yahoo.co.jp/rss/categories/domestic.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("国際", "https://news.yahoo.co.jp/rss/categories/world.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("経済", "https://news.yahoo.co.jp/rss/categories/business.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("エンタメ", "https://news.yahoo.co.jp/rss/categories/entertainment.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("スポーツ", "https://news.yahoo.co.jp/rss/categories/sports.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("IT", "https://news.yahoo.co.jp/rss/categories/it.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("科学", "https://news.yahoo.co.jp/rss/categories/science.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("ライフ", "https://news.yahoo.co.jp/rss/categories/life.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("地域", "https://news.yahoo.co.jp/rss/categories/local.xml"));

            cbUrl.SelectedIndex = 0;
            if (cbUrl.Items.Count > 0) {
                cbUrl.SelectedIndex = 0;
            }

            // イベント登録
            btRegistration.Click += btRegistration_Click;
            btDelete.Click += tbDelete_Click;
        }

        private async void btRssGet_Click_1(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                var selected = (KeyValuePair<string, string>)cbUrl.SelectedItem;
                string xml = await hc.GetStringAsync(selected.Value);
                XDocument xdoc = XDocument.Parse(xml);

                //var url = hc.OpenRead(tbUrl.Text);
                //XDocument xdoc = XDocument.Load(url); //RSSの取得

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link")
                    }).ToList();

                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "データなし"));
                //foreach (var item in items) {
                //    lbTitles.Items.Add(item.Title);
                //}
            }
        }

        //タイトルを検索（クリック）したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            //var link = items.ElementAtOrDefault(lbTitles.SelectedIndex)?.Link;
            //wvRssLink.Source = string.IsNullOrEmpty(link) ? wvRssLink.Source : new Uri(link);

            if (lbTitles.SelectedIndex < 0 || lbTitles.SelectedIndex >= items.Count) return;
            string link = items[lbTitles.SelectedIndex].Link;
            if (!string.IsNullOrEmpty(link)) {
                wvRssLink.Source = new Uri(link);
            }
        }

        //戻る
        private void btReturn_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }

        //進む
        private void btMove_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btReturn.Enabled = wvRssLink.CanGoBack;
            btMove.Enabled = wvRssLink.CanGoForward;
        }

        private void btRegistration_Click(object sender, EventArgs e) {
            string name = tbFavorite.Text.Trim();
            string url = cbUrl.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(url)) {
                MessageBox.Show("名称とURLの両方を入力してください。");
                return;
            }
            bool exists = cbUrl.Items
                .OfType<KeyValuePair<string, string>>()
                .Any(kv => kv.Value == url);

            if (exists) {
                MessageBox.Show("このURLはすでに登録されています。");
                return;
            }

            // キー(名称)と値(URL)のペアで登録
            cbUrl.Items.Add(new KeyValuePair<string, string>(name, url));
            MessageBox.Show("お気に入りに登録しました。");
        }

        //お気に入り削除
        private void tbDelete_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem is not KeyValuePair<string, string> selected) {
                MessageBox.Show("削除する項目を選んでください。");
                return;
            }

            if (MessageBox.Show($"「{selected.Key}（{selected.Value}）」を削除しますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                cbUrl.Items.Remove(selected);
                if (cbUrl.Items.Count > 0)
                    cbUrl.SelectedIndex = 0;
            }
        }

  
    }
}
