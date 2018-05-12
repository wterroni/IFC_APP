using Xamarin.Forms;
using IgrejaFCApp.Models;
using IgrejaFCApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace IgrejaFCApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendaDetalhe : ContentPage
	{
		public AgendaDetalhe (AgendaModel agendaModel)
		{
			InitializeComponent();
            BindingContext = new AgendaDetalheViewModel(null, null, agendaModel);
		}
	}
}