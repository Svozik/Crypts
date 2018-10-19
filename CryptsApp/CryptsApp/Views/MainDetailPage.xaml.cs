using CryptsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainDetailPage : ContentPage
	{
        public MainDetailPage(Data crypts)
        {
            if (crypts == null)
                throw new ArgumentNullException();

            BindingContext = crypts;

            InitializeComponent();
        }
    }
}