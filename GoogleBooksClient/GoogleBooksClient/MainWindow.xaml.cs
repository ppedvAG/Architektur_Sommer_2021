using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Windows;

namespace GoogleBooksClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchBooks(object sender, RoutedEventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={suchTb.Text}";
            var http = new HttpClient();
            var json = await http.GetStringAsync(url);
            jsonTb.Text = json;

            BooksResult result = JsonConvert.DeserializeObject<BooksResult>(json);
            booksGrid.ItemsSource = result.items.Select(x => x.volumeInfo).ToList();
        }
    }
}
