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
    public partial class AuthPage : ContentPage
    {
        Client client = new Client();
        
        public AuthPage()
        {
            InitializeComponent();
        }

        private async void btn_Reg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegPage());
        }

        private async void btn_Log_Clicked(object sender, EventArgs e)
        {
            var lst = App.Db.GetClients();
            bool state = false;

            foreach (var item in lst)
            {
                if (item.Login == client.Login)
                {
                    if (item.Password == client.Password && state == false)
                    {
                        state = true;
                        await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                    }
                }
            }

            if (!state)
            {
                await App.Current.MainPage.DisplayAlert("Уведомление", "Не правилный логин или пароль", "Ok");
            }
    }
    }
}