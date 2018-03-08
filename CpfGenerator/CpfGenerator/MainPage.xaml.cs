using CpfGenerator.Database;
using CpfGenerator.Entities;
using System;
using Xamarin.Forms;
using Plugin.Clipboard;
using CpfGenerator.Utils;

namespace CpfGenerator
{
    public partial class MainPage : ContentPage
    {
        static DatabaseAccess db;

        public static DatabaseAccess Db
        {
            get
            {
                if (db == null)
                {
                    db = new DatabaseAccess();
                }
                return db;
            }
        }

        public MainPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CpfList.ItemsSource = await Db.GetAll();
        }

        protected async void GenerateCpf(object sender, EventArgs e)
        {
            var cpf = new Cpf
            {
                GeneratedNumber = CpfUtil.GenerateCpf(),
            };

            CrossClipboard.Current.SetText(cpf.GeneratedNumber);

            await DisplayAlert("Alert", "Copied to Clipboard!", "OK");

            await Db.Save(cpf);
            CpfList.ItemsSource = await Db.GetAll();
        }

        protected async void DeleteAll(object sender, EventArgs e)
        {
            await Db.DeleteAll();
            CpfList.ItemsSource = await Db.GetAll();

            await DisplayAlert("Alert", "Success!", "OK");
        }

        protected void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            CrossClipboard.Current.SetText(e.SelectedItem.ToString());

            DisplayAlert("Alert", "Copied to Clipboard!", "OK");
        }

    }
}
