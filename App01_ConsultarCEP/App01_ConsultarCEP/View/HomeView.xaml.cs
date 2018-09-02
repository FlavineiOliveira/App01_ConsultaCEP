using App01_ConsultarCEP.Interface;
using App01_ConsultarCEP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ConsultarCEP.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage, IMessage
	{
        HomeViewModel homeViewModel;

        public HomeView()
		{
			InitializeComponent ();

            homeViewModel = new HomeViewModel()
            {
                Message = this,
            };
            BindingContext = homeViewModel;

        }
	}
}