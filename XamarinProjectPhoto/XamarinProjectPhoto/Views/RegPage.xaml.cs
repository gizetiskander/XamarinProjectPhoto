using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProjectPhoto.Models;

namespace XamarinProjectPhoto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPage : ContentPage
    {
        Client client = new Client();
        public RegPage()
        {
            InitializeComponent();
        }

        private async void btn_Reg_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (client.Password == entry_Password.Text)
                { 
                  App.Db.SaveClient(client);
                 }
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Уведомление", "Не удалось зарегистрироваться", "Ok");
            }
        }
    }
}