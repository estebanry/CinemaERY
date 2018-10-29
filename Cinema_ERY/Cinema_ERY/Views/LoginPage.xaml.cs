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
    public partial class LoginPage : ContentPage
    {
        
            public LoginPage()
            {
                InitializeComponent();
            }
            private async void siguiente(object sender, EventArgs e)
             {
                 HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");

                var content = new StringContent("User:" + usuario.Text + "Password:" + contrasenaa.Text, Encoding.UTF8, "application/json");

                var response = cliente.PostAsync("/api/Seguridad", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var respuestaJson = await response.Content.ReadAsStringAsync();
                    var verificacion = JsonConvert.DeserializeObject<Login>(respuestaJson);
                    if (verificacion.Access == true)
                    {
                        await DisplayAlert("Resultado", verificacion.Delivered, "Continue");
                        await Navigation.PushAsync(new CarteleraPage());
                    }
                    else
                    {
                        await DisplayAlert("Incorrecto", verificacion.Delivered, "Intente de nuevo");
                    }
                }
            }

       
    }
    }