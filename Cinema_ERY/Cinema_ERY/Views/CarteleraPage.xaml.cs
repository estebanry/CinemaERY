using Cinema_ERY.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_ERY.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarteleraPage : ContentPage
	{
		public CarteleraPage ()
		{
			InitializeComponent ();
            CargarPeliculas();
		}

        private async Task CargarPeliculas()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://misapis.azurewebsites.net");
            var request = await client.GetAsync("/api/Cartelera");

            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<Cartelera>>(responseJson);

                listPeliculas.ItemsSource = response;
            }
        }

        private void PeliculaSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new FuncionPage());
        }
    }
}