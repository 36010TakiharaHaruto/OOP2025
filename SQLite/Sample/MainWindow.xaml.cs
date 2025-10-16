using Sample.Data;
using SQLite;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window{
    private List<Person> _persons = new List<Person>();

    public MainWindow(){
        InitializeComponent();
        ReadDatabase();
        _persons.Add(new Person { Id = 1, Name = "aaaa", Phone = "123456" });
        PersonListView.ItemsSource = _persons;
    }

    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();
            _persons = connection.Table<Person>().ToList();
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        var person = new Person() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
        };

        using(var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();
            connection.Insert(person);
        }
    }

    private void ReadButton_Click(object sender, RoutedEventArgs e) {
        ReadDatabase();
        PersonListView.ItemsSource = _persons;
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = PersonListView.SelectedItem as Person;
        if(item == null) {
            MessageBox.Show("行を選択してください");
            return;
        }
        //データベース接続
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>(); //データベースから選択されているレコードの削除
            connection.Delete(item);
            ReadDatabase();
            PersonListView.ItemsSource = _persons;
        }
    }

    //リストビューのフィルタリング
    private void SerchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
        var filterList = _persons.Where(x => x.Name.ToLower().Contains(SearchTextBox.Text) ||
        x.Phone.Contains(SearchTextBox.Text));
        PersonListView.ItemsSource = filterList;
    }

    //リストビューから1レコード選択
    private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedPerson = PersonListView.SelectedItem as Person;
        if (selectedPerson == null) {
            return;
        }
        NameTextBox.Text = selectedPerson.Name;
        PhoneTextBox.Text = selectedPerson.Phone;
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e) {
        var selectedPerson = PersonListView.SelectedItem as Person;
        if (selectedPerson is null) return;

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();

            var person = new Person() {
                Id = selectedPerson.Id,
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
            };
            connection.Update(person);

            ReadDatabase();
            PersonListView.ItemsSource = _persons;
        }
    }
}