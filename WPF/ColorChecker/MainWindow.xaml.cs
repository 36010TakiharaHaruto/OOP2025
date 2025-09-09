using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorChecker {
    public partial class MainWindow : Window {

        private List<MyColor> predefinedColors;

        public MainWindow() {
            InitializeComponent();

            // Colorsクラスの全ての静的パブリックプロパティを取得
            predefinedColors = new List<MyColor>();
            var colorProperties = typeof(Colors).GetProperties(BindingFlags.Static | BindingFlags.Public);

            foreach (var prop in colorProperties) {
                var color = (Color)prop.GetValue(null);
                var name = prop.Name;
                predefinedColors.Add(new MyColor { Name = name, Color = color });
            }

            // ComboBoxに色リストをセット
            colorSelectComboBox.ItemsSource = predefinedColors;

            // 初期選択
            int blackIndex = predefinedColors.FindIndex(c => c.Name == "Black");
            colorSelectComboBox.SelectedIndex = blackIndex >= 0 ? blackIndex : 0;
        }

        // スライダーの値が変わった時の処理
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColorArea(); // 背景色を更新
        }

        // ComboBoxで色が選択された時の処理
        private void ColorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorSelectComboBox.SelectedItem is MyColor selected) {
                UpdateSlidersFromColor(selected.Color); // スライダーを更新
            }
        }

        // ラベルの背景色を更新
        private void UpdateColorArea() {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            Color newColor = Color.FromRgb(r, g, b);
            colorArea.Background = new SolidColorBrush(newColor);
        }

        // スライダーに色のRGB値をセット
        private void UpdateSlidersFromColor(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        // STOCKボタンの処理
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var currentColor = Color.FromRgb(
                (byte)rSlider.Value,
                (byte)gSlider.Value,
                (byte)bSlider.Value);

            string name = "Custom";
            if (colorSelectComboBox.SelectedItem is MyColor selectedColor) {
                name = selectedColor.Name; // コンボボックスの色名を取得
            }

            var myColor = new MyColor {
                Name = name,
                Color = currentColor
            };

            stockList.Items.Add(myColor);
        }
    }
}
