using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();

            cbUrl.DisplayMember = "Key";
            cbUrl.ValueMember = "Value";

            cbUrl.Items.Add(new KeyValuePair<string, string>("����", "https://news.yahoo.co.jp/rss/categories/domestic.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("����", "https://news.yahoo.co.jp/rss/categories/world.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("�o��", "https://news.yahoo.co.jp/rss/categories/business.xml"));

            cbUrl.SelectedIndex = 0;
            if (cbUrl.Items.Count > 0) {
                cbUrl.SelectedIndex = 0;
            }

            // �C�x���g�o�^
            btRegistration.Click += btRegistration_Click;
            btDelete.Click += tbDelete_Click;
        }

        private async void btRssGet_Click_1(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                var selected = (KeyValuePair<string, string>)cbUrl.SelectedItem;
                string xml = await hc.GetStringAsync(selected.Value);
                XDocument xdoc = XDocument.Parse(xml);

                //var url = hc.OpenRead(tbUrl.Text);
                //XDocument xdoc = XDocument.Load(url); //RSS�̎擾

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
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

            if (lbTitles.SelectedIndex < 0 || lbTitles.SelectedIndex >= items.Count) return;
            string link = items[lbTitles.SelectedIndex].Link;
            if (!string.IsNullOrEmpty(link)) {
                wvRssLink.Source = new Uri(link);
            }
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

        // ���C�ɓ���o�^
        private void btRegistration_Click(object sender, EventArgs e) {
            string url = tbFavorite.Text.Trim();
            if (string.IsNullOrEmpty(url)) {
                MessageBox.Show("�o�^����URL����͂��Ă��������B");
                return;
            }

            if (!cbUrl.Items.Contains(url)) {
                cbUrl.Items.Add(url);
                MessageBox.Show("���C�ɓ���ɓo�^���܂����B");
            } else {
                MessageBox.Show("���łɓo�^����Ă��܂��B");
            }
        }

        //���C�ɓ���폜
        private void tbDelete_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem == null) {
                MessageBox.Show("�폜����URL��I�����Ă��������B");
                return;
            }

            string url = cbUrl.SelectedItem.ToString();
            if (MessageBox.Show($"�u{url}�v���폜���܂����H", "�m�F", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                cbUrl.Items.Remove(url);
                if (cbUrl.Items.Count > 0) {
                    cbUrl.SelectedIndex = 0;
                }
            }
        }
    }
}
