using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        // ���C�ɓ���ۑ��t�@�C����
        private const string FavoritesFile = "favorites.xml";

        public Form1() {
            InitializeComponent();
            DarkThemeStyler.ApplyDarkTheme(this);

            cbUrl.DisplayMember = "Key";
            cbUrl.ValueMember = "Value";

            LoadFavorites();

            // �����o�^���Ȃ���΃f�t�H���g��ǉ�
            if (cbUrl.Items.Count == 0) {
                cbUrl.Items.Add(new KeyValuePair<string, string>("����", "https://news.yahoo.co.jp/rss/categories/domestic.xml"));
                cbUrl.Items.Add(new KeyValuePair<string, string>("����", "https://news.yahoo.co.jp/rss/categories/world.xml"));
                cbUrl.Items.Add(new KeyValuePair<string, string>("�o��", "https://news.yahoo.co.jp/rss/categories/business.xml"));
                cbUrl.Items.Add(new KeyValuePair<string, string>("�G���^��", "https://news.yahoo.co.jp/rss/categories/entertainment.xml"));
                cbUrl.Items.Add(new KeyValuePair<string, string>("�X�|�[�c", "https://news.yahoo.co.jp/rss/categories/sports.xml"));
                cbUrl.Items.Add(new KeyValuePair<string, string>("IT", "https://news.yahoo.co.jp/rss/categories/it.xml"));
                cbUrl.Items.Add(new KeyValuePair<string, string>("�Ȋw", "https://news.yahoo.co.jp/rss/categories/science.xml"));
                cbUrl.Items.Add(new KeyValuePair<string, string>("���C�t", "https://news.yahoo.co.jp/rss/categories/life.xml"));
                cbUrl.Items.Add(new KeyValuePair<string, string>("�n��", "https://news.yahoo.co.jp/rss/categories/local.xml"));
            }

            //cbUrl.SelectedIndex = 0;
            //if (cbUrl.Items.Count > 0) {
            //    cbUrl.SelectedIndex = 0;
            //}

            cbUrl.SelectedIndex = -1;

            // �C�x���g�o�^
            btRegistration.Click += btRegistration_Click;
            btDelete.Click += tbDelete_Click;
        }

        private async void btRssGet_Click_1(object sender, EventArgs e) {
            if (cbUrl.SelectedItem is not KeyValuePair<string, string> selected) {
                MessageBox.Show("RSS�J�e�S����I�����Ă��������B");
                return;
            }

            using (var hc = new HttpClient()) {
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
            if (wvRssLink.CanGoBack) wvRssLink.GoBack();
        }

        //�i��
        private void btMove_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoForward) wvRssLink.GoForward();
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btReturn.Enabled = wvRssLink.CanGoBack;
            btMove.Enabled = wvRssLink.CanGoForward;
        }

        // ���C�ɓ���o�^
        private void btRegistration_Click(object sender, EventArgs e) {
            string name = tbFavorite.Text.Trim();
            string url = cbUrl.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(url)) {
                MessageBox.Show("���̂�URL�̗�������͂��Ă��������B");
                return;
            }

            bool exists = cbUrl.Items
                .OfType<KeyValuePair<string, string>>()
                .Any(kv => kv.Value == url);

            if (exists) {
                MessageBox.Show("����URL�͂��łɓo�^����Ă��܂��B");
                return;
            }

            cbUrl.Items.Add(new KeyValuePair<string, string>(name, url));
            SaveFavorites();
            MessageBox.Show("���C�ɓ���ɓo�^���܂����B");
        }

        // ���C�ɓ���폜
        private void tbDelete_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem is not KeyValuePair<string, string> selected) {
                MessageBox.Show("�폜���鍀�ڂ�I��ł��������B");
                return;
            }

            if (MessageBox.Show($"�u{selected.Key}�i{selected.Value}�j�v���폜���܂����H", "�m�F", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                cbUrl.Items.Remove(selected);
                SaveFavorites();

                if (cbUrl.Items.Count > 0)
                    cbUrl.SelectedIndex = 0;
                else
                    cbUrl.SelectedIndex = -1;
            }
        }

        // ���C�ɓ���ۑ��p�̃N���X
        public class FavoriteItem {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        // ���C�ɓ����XML�t�@�C���ɕۑ�
        private void SaveFavorites() {
            try {
                var list = cbUrl.Items
                    .OfType<KeyValuePair<string, string>>()
                    .Select(kv => new FavoriteItem { Name = kv.Key, Url = kv.Value })
                    .ToList();

                var serializer = new XmlSerializer(typeof(List<FavoriteItem>));
                using (var writer = new StreamWriter(FavoritesFile, false, Encoding.UTF8)) {
                    serializer.Serialize(writer, list);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("���C�ɓ���ۑ��G���[: " + ex.Message);
            }
        }

        // ���C�ɓ����XML�t�@�C������ǂݍ���
        private void LoadFavorites() {
            if (!File.Exists(FavoritesFile)) return;

            try {
                var serializer = new XmlSerializer(typeof(List<FavoriteItem>));
                using (var reader = new StreamReader(FavoritesFile, Encoding.UTF8)) {
                    var list = (List<FavoriteItem>)serializer.Deserialize(reader);
                    cbUrl.Items.Clear();
                    foreach (var item in list) {
                        cbUrl.Items.Add(new KeyValuePair<string, string>(item.Name, item.Url));
                    }
                }
                if (cbUrl.Items.Count > 0) cbUrl.SelectedIndex = 0;
            }
            catch (Exception ex) {
                MessageBox.Show("���C�ɓ���ǂݍ��݃G���[: " + ex.Message);
            }
        }
    }
}
