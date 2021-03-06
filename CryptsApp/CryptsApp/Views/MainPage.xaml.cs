﻿using CryptsApp.Models;
using CryptsApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptsApp
{
    public partial class MainPage : ContentPage
    {
        private const string url = "https://api.coinmarketcap.com/v1/ticker/";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Data> _data;

        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            var content = await _Client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<List<Data>>(content);
            _data = new ObservableCollection<Data>(data);
            Post_List.ItemsSource = _data;
            base.OnAppearing();
        }


        private void Post_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var crypts = e.SelectedItem as Data;
            Navigation.PushAsync(new MainDetailPage(crypts));
            Post_List.SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
