using Xamarin.Forms;
using IgrejaFCApp.ViewModels;

namespace IgrejaFCApp.Views
{
    public partial class ViewA : ContentPage
    {
        public ViewA()
        {
            InitializeComponent();
            BindingContext = new ViewAViewModel(null, null);
        }
    }
}
