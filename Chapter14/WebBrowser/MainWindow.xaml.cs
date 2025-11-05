using Microsoft.Web.WebView2.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Wpf;

namespace WebBrowser {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            InitializeWebView();
        }
        private async void InitializeWebView() {
            await WebView.EnsureCoreWebView2Async(null);
            WebView.CoreWebView2.Navigate("https://www.example.com");
        }
        private void BackButton_Click(object sender, RoutedEventArgs e) {
            if (WebView.CoreWebView2.CanGoBack) {
                WebView.CoreWebView2.GoBack();
            }
        }
        private void FowardButton_Click(object sender, RoutedEventArgs e) {
            if (WebView.CoreWebView2.CanGoForward) {
                WebView.CoreWebView2.GoForward();
            }
        }
        private void GoButton_Click(object sender, RoutedEventArgs e) {
            string url = AddressBar.Text;
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute)) {
                WebView.CoreWebView2.Navigate(url);
            } else {
                MessageBox.Show("無効なURLです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
