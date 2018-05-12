using System;
using IgrejaFCApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using IgrejaFCApp.Models;

namespace IgrejaFCApp.ViewModels
{
    public class AgendaViewModel : BaseViewModel
    {
        public ObservableCollection<AgendaModel> Agendalist { get; set; }

        IAuthenticationService _authenticationService { get; }
        public AgendaViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            CarregaListaEventos();

            _authenticationService = authenticationService;
            LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);
        }

        private void CarregaListaEventos()
        {
            Agendalist = new ObservableCollection<AgendaModel>
            {
                new AgendaModel(){ DtEvento = "07/04/2018 - 19h30", Descricao = "Aniversário de 15 anos, participação Coral Kemuel", Nome = "Aniversário de 15 anos", Banner = "Niver15.jpg"},
                new AgendaModel(){ DtEvento = "08/04/2018 - 18h30", Descricao = "Aniversário de 15 anos, preleitor: Pastor João" },
                new AgendaModel(){ DtEvento = "11/04/2018 - 19h30", Descricao = "Campanha: Vitória" },
                new AgendaModel(){ DtEvento = "12/04/2018 - 15h00", Descricao = "Campanha: Libertação" },
                new AgendaModel(){ DtEvento = "15/04/2018 - 18h30", Descricao = "Culto da Família" },
            };
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand LogoutCommand { get; }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }

        public void OnLogoutCommandExecuted() =>
            _authenticationService.Logout();
    }
}
