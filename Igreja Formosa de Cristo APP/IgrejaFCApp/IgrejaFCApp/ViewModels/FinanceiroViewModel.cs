﻿using System;
using IgrejaFCApp.Services;
using Prism.Commands;
using Prism.Navigation;

namespace IgrejaFCApp.ViewModels
{
    public class FinanceiroViewModel : BaseViewModel
    {
        IAuthenticationService _authenticationService { get; }

        public FinanceiroViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            Title = "View B";
            _authenticationService = authenticationService;
            LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);
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