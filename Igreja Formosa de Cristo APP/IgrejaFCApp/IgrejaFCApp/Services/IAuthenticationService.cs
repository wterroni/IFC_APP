using System;
namespace IgrejaFCApp.Services
{
    public interface IAuthenticationService
    {
        bool Login(string username, string password);

        void Logout();
    }
}
