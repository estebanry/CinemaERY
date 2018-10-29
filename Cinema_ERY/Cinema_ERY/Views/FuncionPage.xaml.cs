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
	public partial class FuncionPage : ContentPage
	{
		public FuncionPage (Cartelera cartelera)
		{
			InitializeComponent ();
            BindingContext = cartelera;
            listar.ItemsSource = cartelera.Funciones;
        }

        private async void sleccionf(object sender, SelectedItemChangedEventArgs e)
        {
            var sel = e.SelectedItem as Cartelera;
            await Navigation.PushAsync(new FuncionPage(sel));
        }

        
    }
}
