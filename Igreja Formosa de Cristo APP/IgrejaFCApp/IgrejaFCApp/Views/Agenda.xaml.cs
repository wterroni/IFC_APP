using Xamarin.Forms;
using IgrejaFCApp.ViewModels;

namespace IgrejaFCApp.Views
{
    public partial class ViewAgenda : ContentPage
    {
        public ViewAgenda()
        {
            InitializeComponent();
            BindingContext = new AgendaViewModel(null, null);
        }
    }
}
