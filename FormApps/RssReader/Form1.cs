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
                //XDocument xdoc = XDocument.Load(url); //RSS�̎擾

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title")
                                                ,
                        Link = (string?)x.Element("link")
                    }).ToList();


                //���X�g�{�b�N�X�փ^�C�g����\��
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));
                //foreach (var item in items) {
                //    lbTitles.Items.Add(item.Title);
                //}
            }
        }

        //�^�C�g���������i�N���b�N�j�����Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
            //var link = items.ElementAtOrDefault(lbTitles.SelectedIndex)?.Link;
            //wvRssLink.Source = string.IsNullOrEmpty(link) ? wvRssLink.Source : new Uri(link);
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
        }

        //�߂�
        private void btReturn_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoBack) {
                wvRssLink.GoBack();
                UpdateNavigationButtons();
            }
        }
        //�i��
        private void btMove_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoForward) {
                wvRssLink.GoForward();
                UpdateNavigationButtons();
            }
        }

        private void UpdateNavigationButtons() {
            btReturn.Enabled = wvRssLink.CanGoBack;
            btMove.Enabled = wvRssLink.CanGoForward;
        }
    }
}
