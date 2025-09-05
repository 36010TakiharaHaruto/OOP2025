using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();



            // スライダーの値が変わった時にイベントを登録
            // ValueChanged →　スライダーの「値が変わったとき」に発生するイベント
            //Slider_ValueChanged →　値が変わったときに呼ばれる関数
            rSlider.ValueChanged += Slider_ValueChanged;
            gSlider.ValueChanged += Slider_ValueChanged;
            bSlider.ValueChanged += Slider_ValueChanged;

            // 初期色セット
            UpdateColor();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColor();
        }


        private void UpdateColor() {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            // RGBの色を作成して、colorAreaの背景にセット
            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }


        private void stockButton_Click(object sender, RoutedEventArgs e) {
            // RGBの値を取得
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            // MyColor にまとめる
            MyColor color = new MyColor {
                Color = Color.FromRgb(r, g, b),
              };

            // ListBox に追加
            stockList.Items.Add(color);
        }



        //入力中
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
            var color = mycolor.Color;
            var name = mycolor.Name;
        }
    }
}
