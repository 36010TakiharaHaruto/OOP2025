using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CustomerApp.Data;
using Microsoft.Win32;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Media.Imaging;

namespace CustomerApp {
    public partial class App : Application {
        public static string databasePath;

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            var folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "CustomerApp");

            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            databasePath = Path.Combine(folder, "customers.db");
        }
    }

    public partial class MainWindow : Window {
        private List<Customer> _customers = new();
        private byte[] _selectedImageBytes;

        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
            PersonListView.ItemsSource = _customers;
        }

       


        private void ReadDatabase() {
            using var connection = new SQLiteConnection(App.databasePath);
            connection.CreateTable<Customer>();
            _customers = connection.Table<Customer>().ToList();
        }

        private void PictureButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenFileDialog {
                Title = "画像を選択",
                Filter = "画像ファイル (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (dialog.ShowDialog() == true) {
                _selectedImageBytes = File.ReadAllBytes(dialog.FileName);
                MessageBox.Show("画像が選択されました");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Picture = _selectedImageBytes
            };

            using var connection = new SQLiteConnection(App.databasePath);
            connection.CreateTable<Customer>();
            connection.Insert(customer);

            _selectedImageBytes = null;
            ReadDatabase();
            PersonListView.ItemsSource = _customers;
            NameTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = PersonListView.SelectedItem as Customer;
            if (selectedCustomer == null) return;

            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            if (_selectedImageBytes != null) {
                selectedCustomer.Picture = _selectedImageBytes;
            }

            using var connection = new SQLiteConnection(App.databasePath);
            connection.CreateTable<Customer>();
            connection.Update(selectedCustomer);

            _selectedImageBytes = null;
            ReadDatabase();
            PersonListView.ItemsSource = _customers;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = PersonListView.SelectedItem as Customer;
            if (selectedCustomer == null) {
                MessageBox.Show("行を選択してください");
                return;
            }

            using var connection = new SQLiteConnection(App.databasePath);
            connection.CreateTable<Customer>();
            connection.Delete(selectedCustomer);

            ReadDatabase();
            PersonListView.ItemsSource = _customers;
        }

        private void SerchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var keyword = SearchTextBox.Text.ToLower();
            var filtered = _customers.Where(x =>
                x.Name.ToLower().Contains(keyword) ||
                x.Phone.Contains(keyword) ||
                x.Address.ToLower().Contains(keyword)).ToList();

            PersonListView.ItemsSource = filtered;
        }

        private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = PersonListView.SelectedItem as Customer;
            if (selectedCustomer == null) return;

            NameTextBox.Text = selectedCustomer.Name;
            PhoneTextBox.Text = selectedCustomer.Phone;
            AddressTextBox.Text = selectedCustomer.Address;
        }
        private async void PostalCodeTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            string zipcode = PostalCodeTextBox.Text.Trim();

            zipcode = zipcode.Replace("-", "");
            if (zipcode.Length != 7 || !zipcode.All(char.IsDigit))
                return;

            await GetAddressFromZipAsync(zipcode);
        }

        private async Task GetAddressFromZipAsync(string zipcode) {
            try {
                using var client = new HttpClient();
                string url = $"https://zipcloud.ibsnet.co.jp/api/search?zipcode={zipcode}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("results", out var results) && results.ValueKind == JsonValueKind.Array && results.GetArrayLength() > 0) {
                    var result = results[0];
                    string address1 = result.GetProperty("address1").GetString();
                    string address2 = result.GetProperty("address2").GetString();
                    string address3 = result.GetProperty("address3").GetString();

                    AddressTextBox.Text = $"{address1}{address2}{address3}";
                } else {
                    AddressTextBox.Text = "住所が見つかりません";
                }
            }
            catch (Exception ex) {
                AddressTextBox.Text = $"エラー: {ex.Message}";
            }
        }
    }
}