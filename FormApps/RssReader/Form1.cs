using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click_1(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                string xml = await hc.GetStringAsync(tbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);



                //var url = hc.OpenRead(tbUrl.Text);
                //XDocument xdoc = XDocument.Load(url); //RSSの取得

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title")
                                                ,
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
            int index = lbTitles.SelectedIndex;
            if (index >= 0 && index < items.Count) {
                string? link = items[index].Link;
                if (!string.IsNullOrEmpty(link)) {
                    webView21.Source = new Uri(link);
                }
            }
        }

        private void btReturn_Click(object sender, EventArgs e) {
            if (webView21.CanGoBack) {
                webView21.GoBack();
            }
        }

        private void btMove_Click(object sender, EventArgs e) {
            if (webView21.CanGoForward) {
                webView21.GoForward();
            }
        }
    }
}
