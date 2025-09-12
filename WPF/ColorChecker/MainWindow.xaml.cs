using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using System;

namespace ColorChecker {
    public partial class MainWindow : Window {
        private List<MyColor> predefinedColors;  
        private List<MyColor> colorHistory;      
        private bool isDarkMode = false;         

        public MainWindow() {
            InitializeComponent();
            predefinedColors = new List<MyColor>();  
            colorHistory = new List<MyColor>();      

            // Colorsクラスからすべての静的な色を取得
            var colorProperties = typeof(Colors).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            foreach (var prop in colorProperties) {
                var color = (Color)prop.GetValue(null);
                var name = prop.Name;
                predefinedColors.Add(new MyColor { Name = name, Color = color });
            }

            // コンボボックスに色リストをセット
            colorSelectComboBox.ItemsSource = predefinedColors;

            // 初期選択
            int blackIndex = predefinedColors.FindIndex(c => c.Name == "Black");
            colorSelectComboBox.SelectedIndex = blackIndex >= 0 ? blackIndex : 0;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColorArea();  
        }

        // ラベルの背景色を更新する
        private void UpdateColorArea() {
            byte r = (byte)rSlider.Value;  
            byte g = (byte)gSlider.Value;  
            byte b = (byte)bSlider.Value;  
            Color newColor = Color.FromRgb(r, g, b);  
            colorArea.Background = new SolidColorBrush(newColor);  
        }

        private void ColorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var comboSelectMyColor = (MyColor)((ComboBox)sender).SelectedItem; 
            SetSliderValue(comboSelectMyColor.Color); 
        }

        // スライダーに色を設定する
        private void SetSliderValue(Color color) {
            rSlider.Value = color.R;  
            gSlider.Value = color.G;  
            bSlider.Value = color.B;  
        }
        // STOCKボタンがクリック
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var currentColor = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            string name;

            // 選択されている色と一致するか
            if (colorSelectComboBox.SelectedItem is MyColor selectedColor && selectedColor.Color == currentColor) {
                name = selectedColor.Name;
            } else {
                name = "Custom";
            }

            // 同じ色が保存されているか
            var duplicateColor = colorHistory.FirstOrDefault(c => c.Color.Equals(currentColor));

            if (duplicateColor.Equals(default(MyColor))) 
            {
                var myColor = new MyColor { Name = name, Color = currentColor };
                stockList.Items.Add(myColor);
                colorHistory.Add(myColor); 
            } else {

                MessageBox.Show("同じ色があります！", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        // ストックリスト
        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor)  
            {
                SetSliderValue(selectedColor.Color); 
                colorArea.Background = new SolidColorBrush(selectedColor.Color);  
            }
        }

        // リセットボタン
        private void ResetButton_Click(object sender, RoutedEventArgs e) {
            rSlider.Value = 0;
            gSlider.Value = 0;
            bSlider.Value = 0;

            colorArea.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            stockList.Items.Clear();
            colorHistory.Clear();  
        }

        // ダークモードの切り替え
        private void DarkModeButton_Click(object sender, RoutedEventArgs e) {
            isDarkMode = !isDarkMode;
            if (isDarkMode) {
                this.Background = new SolidColorBrush(Color.FromRgb(30, 30, 30));
                colorArea.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
                stockList.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
                stockList.Foreground = Brushes.White;
                stockButton.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
                stockButton.Foreground = Brushes.White;
                rText.Foreground = Brushes.White;
                gText.Foreground = Brushes.White;
                bText.Foreground = Brushes.White;
            } else {
                this.Background = Brushes.White;
                colorArea.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                stockList.Background = Brushes.White;
                stockList.Foreground = Brushes.Black;
                stockButton.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
                stockButton.Foreground = Brushes.Black;
                rText.Foreground = Brushes.Black;
                gText.Foreground = Brushes.Black;
                bText.Foreground = Brushes.Black;
            }
        }


        private void ClearAllButton_Click(object sender, RoutedEventArgs e) {
            stockList.Items.Clear();  
            colorHistory.Clear();  
        }

        private void SaveColorButton_Click(object sender, RoutedEventArgs e) {
            var currentColor = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            var myColor = new MyColor { Name = "Saved", Color = currentColor };

            stockList.Items.Add(myColor);
            colorHistory.Add(myColor);  
        }

        private void RandomColorButton_Click(object sender, RoutedEventArgs e) {
            Random rnd = new Random();
            rSlider.Value = rnd.Next(256);
            gSlider.Value = rnd.Next(256);
            bSlider.Value = rnd.Next(256);
        }
    }
}
