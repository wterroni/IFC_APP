using System;
using IgrejaFCApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using IgrejaFCApp.Entities;

namespace IgrejaFCApp.ViewModels
{
    public class ViewAViewModel : BaseViewModel
    {
        public ObservableCollection<Agenda> Agendalist { get; set; }

        IAuthenticationService _authenticationService { get; }
        public ViewAViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            CarregaListaEventos();

            _authenticationService = authenticationService;
            LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);
        }

        private void CarregaListaEventos()
        {
            Agendalist = new ObservableCollection<Agenda>
            {
                new Agenda(){ DtEvento = "07/04/2018 - 19h30", Descricao = "Aniversário de 15 anos, participação Coral Kemuel" },
                new Agenda(){ DtEvento = "08/04/2018 - 18h30", Descricao = "Aniversário de 15 anos, preleitor: Pastor João" },
                new Agenda(){ DtEvento = "11/04/2018 - 19h30", Descricao = "Campanha: Vitória" },
                new Agenda(){ DtEvento = "12/04/2018 - 15h00", Descricao = "Campanha: Libertação" },
                new Agenda(){ DtEvento = "15/04/2018 - 18h30", Descricao = "Culto da Família" },
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
