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
	public partial class RCompraPage : ContentPage
	{
        
            public RCompraPage(Cartelera cartelera)
            {
                InitializeComponent();
                BindingContext = cartelera;
                Rcompra.ItemsSource = cartelera.Funciones;
            }


        }
    }