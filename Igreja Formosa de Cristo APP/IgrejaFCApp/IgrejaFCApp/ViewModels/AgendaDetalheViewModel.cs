using IgrejaFCApp.Models;
using IgrejaFCApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace IgrejaFCApp.ViewModels
{
    public class AgendaDetalheViewModel : BaseViewModel
    {
        public ObservableCollection<AgendaModel> agendaModel { get; set; }

        public AgendaDetalheViewModel(INavigationService navigationService, IAuthenticationService authenticationService, AgendaModel objAgenda)
            : base(navigationService)
        {
            this.agendaModel = new ObservableCollection<AgendaModel>();
            this.agendaModel.Add(objAgenda);            
        }
    }
}
