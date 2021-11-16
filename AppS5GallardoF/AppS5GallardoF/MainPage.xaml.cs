using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppS5GallardoF
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.7/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppS5GallardoF.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<AppS5GallardoF.Datos> posts = JsonConvert.DeserializeObject<List<AppS5GallardoF.Datos>>(content);
                _post = new ObservableCollection<AppS5GallardoF.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewInsertar());

        }

        private void bntPost_Clicked(object sender, EventArgs e)
        {

        }
    }
}
