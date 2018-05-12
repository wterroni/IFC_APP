﻿using Xamarin.Forms;
using IgrejaFCApp.ViewModels;
using IgrejaFCApp.Models;

namespace IgrejaFCApp.Views
{
    public partial class ViewAgenda : ContentPage
    {
        public ViewAgenda()
        {
            InitializeComponent();
            BindingContext = new AgendaViewModel(null, null);
        }

        private async void lstEventos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AgendaDetalhe((AgendaModel)e.SelectedItem));
        }
    }
}
