using System;
using IgrejaFCApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace IgrejaFCApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        IAuthenticationService _authenticationService { get; }
        IPageDialogService _pageDialogService { get; }

        public LoginPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _authenticationService = authenticationService;
            _pageDialogService = pageDialogService;

            Title = "Login";

            LoginCommand = new DelegateCommand(OnLoginCommandExecuted, LoginCommandCanExecute)
                .ObservesProperty(() => UserName)
                .ObservesProperty(() => Password);
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand LoginCommand { get; }

        private async void OnLoginCommandExecuted()
        {
            IsBusy = true;
            if(_authenticationService.Login(UserName, Password))
            {
                await _navigationService.NavigateAsync("/Index/Navigation/ViewAgenda?message=Glad%20you%20read%20the%20code");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Erro", "Senha inválida.", "OK");
            }
            IsBusy = false;
        }

        private bool LoginCommandCanExecute() =>
            !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password) && IsNotBusy;
    }
}
