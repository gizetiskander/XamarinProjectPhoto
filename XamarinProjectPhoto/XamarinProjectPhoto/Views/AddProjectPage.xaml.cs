using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProjectPhoto.Models;

namespace XamarinProjectPhoto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProjectPage : ContentPage
    {
        Project Project = new Project();
        public AddProjectPage()
        {
            InitializeComponent();
        }

        private async void AddImageGalBtn_Clicked(object sender, EventArgs e)
        {
            try
            {

                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);


                Project.ImagePath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void AddImageCamBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });


                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                Project.ImagePath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void AddBtn_Clicked(object sender, EventArgs e)
        {
            try
            {

                App.db.SaveItem(new Project(Project.Name, Project.Description, Project.TelephoneNumber1, Project.Email, Project.Address, Project.ImagePath));
                await Navigation.PopAsync();
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Error", "Загрузка в базу данных неуспешно", "Ok");
            }
        }
    }
}