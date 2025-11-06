using Microsoft.Web.WebView2.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Wpf;

namespace WebBrowser {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            InitializeAsync();
            //InitializeWebView();
        }
        //private async void InitializeWebView() {
        //    await WebView.EnsureCoreWebView2Async(null);
        //    WebView.CoreWebView2.Navigate("https://www.example.com");
        //}
        private async void InitializeAsync() {
            await WebView.EnsureCoreWebView2Async();

            WebView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            WebView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
        }

        // 読み込み開始したらプログレスバーを表示
        private void CoreWebView2_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e) {
            LoadingBar.Visibility = Visibility.Visible;
            LoadingBar.IsIndeterminate = true;
        }

        // 読み込み完了したらプログレスバーを非表示
        private void CoreWebView2_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e) {
            LoadingBar.Visibility = Visibility.Collapsed;
            LoadingBar.IsIndeterminate = true;
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
            //string url = AddressBar.Text;
            //if (Uri.IsWellFormedUriString(url, UriKind.Absolute)) {
            //    WebView.CoreWebView2.Navigate(url);
            //} else {
            //    MessageBox.Show("無効なURLです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            var url = AddressBar.Text.Trim();
            if (string.IsNullOrWhiteSpace(url)) return;
        }
    }
}
