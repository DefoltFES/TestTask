using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using TestTask.Api.Domain;

namespace TestTask.AdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient client = new HttpClient();

        public List<Payment> Payments { get; set; }

        private Dictionary<string, string> ImagesPayment = new Dictionary<string, string>()
        {
            {"Магнит","https://s.rbk.ru/v1_companies_s3/resized/140xH/media/trademarks/a0ea2f08-06ce-4668-a0f9-a7c79070fd93.jpg" },
            {"Райфайзен","https://papik.pro/uploads/posts/2021-11/thumbs/1636211000_3-papik-pro-p-raiffaizenbank-logotip-foto-3.png" },
            {"Летай","https://static.tildacdn.com/tild3735-6636-4930-b532-613838636335/1102.png" },
            {"Uber","https://w7.pngwing.com/pngs/609/614/png-transparent-computer-icons-uber-taxi-logos-miscellaneous-rectangle-black.png" }

        };
        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:44348/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
            GetData();

        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            GenerateData();
            
            MessageBox.Show("Данные сгенерированы","Сообщение");
        }
    
        public async void GetData()
        {
            var response = await client.GetStringAsync("favorites");
            var favorites = JsonConvert.DeserializeObject<List<Favorite>>(response);
            var responsePay = await client.GetStringAsync("payments");
            var payments = JsonConvert.DeserializeObject<List<Payment>>(responsePay).Where(x => x.CanBeFavorite == true);
            ListFavorites.ItemsSource = null;
            ListFavorites.ItemsSource = favorites;
            TypePayments.ItemsSource = payments;
            TypePayments.SelectedIndex = 0;
        }


        public async void GenFavorite()
        {
            var response = await client.GetStringAsync("payments");
            var payments = JsonConvert.DeserializeObject<List<Payment>>(response).Where(x=>x.CanBeFavorite==true);
            if (payments != null)
            {
                var favorite = new Favorite()
                {
                    Name = "Тестовое название",
                    PaymentId= payments.First().Id
                };
                await client.PostAsJsonAsync("favorites", favorite);
            }
            GetData();
        }

        public async void GenerateData()
        {
            var rnd = new Random();
            List<Payment> genPayments = new List<Payment>();
            foreach (var payment in ImagesPayment)
            {
                genPayments.Add(new Payment()
                {
                    Name = payment.Key,
                    Image = payment.Value,
                    CanBeFavorite = true
                });
            }           
            List<Account> accounts = new List<Account>();
            for (int i = 0; i < 10; i++)
            {
                
                var account = new Account()
                {
                    NumberAccount = GenerateNumber(20)
                };               
                for (int j = 0; j < 2; j++)
                {
                    var card = new Card()
                    {
                        Id=Guid.NewGuid(),
                        Number= GenerateNumber(16),
                        Balance=rnd.Next(10,10000)
                    };
                    for (int o = 0; o < 3; o++)
                    {
                        card.Operations.Add(new Operation()
                        {
                            Id = Guid.NewGuid(),
                            Payment = genPayments[rnd.Next(0, genPayments.Count)],
                            TimeOperation = DateTime.Now,
                            SumOperation = rnd.Next(-100, 100)
                        });
                    }
                    account.Cards.Add(card);                   
                }
                accounts.Add(account);
            }
            await client.PostAsJsonAsync("accounts/addmany",accounts);
            GenFavorite();
        }

        public string GenerateNumber(int x)
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < x; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }

        private async void DelFavorite(Favorite fav)
        {
            await client.DeleteAsync("favorites/"+fav.Id);
            MessageBox.Show("Избранное удаленно", "Сообщение");
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
          var favorite= (sender as Button).DataContext as Favorite;
            if (favorite != null)
            {
                DelFavorite(favorite);
            }
            GetData();
        }


        private async void  SaveFavorite(Favorite fav)
        {
            await client.PostAsJsonAsync("favorites", fav);
        }

        private async void UpdateFavorite(Favorite fav)
        {
            await client.PutAsJsonAsync("favorites", fav);
        }

        private void CreateOrEditFavorite_Click(object sender, RoutedEventArgs e)
        {
            var fav = new Favorite()
            {
                Name = NameFav.Text,
                PaymentId = (TypePayments.SelectedItem as Payment).Id
            };
            if (fav.Id == Guid.Empty)
            {
                SaveFavorite(fav);
                MessageBox.Show("Избранное сохранено", "Сообщение");
            }
            else
            {
                UpdateFavorite(fav);
                MessageBox.Show("Избранное изменнено", "Сообщение");
                CreateOrEditFavorite.Content = "Добавить в избранное";
            }
            NameFav.Text = String.Empty;
            IdFav.Text = String.Empty;
            GetData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var favorite = (sender as Button).DataContext as Favorite;
            if (favorite != null)
            {
                NameFav.Text = favorite.Name;
                IdFav.Text = favorite.Id.ToString();
                TypePayments.SelectedItem = favorite.Payment;
                CreateOrEditFavorite.Content = "Сохранить изменение";
            }           
        }
    }
}
