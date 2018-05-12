using Xamarin.Forms;
using IgrejaFCApp.Helpers;

namespace IgrejaFCApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            

        }

        private void EventoCPF()
        {
            if (ValidaCPF())
                txtSenha.Focus();
            else
            {
                DisplayAlert("Erro", "CPF inválido.", "OK");
                txtCPF.Focus();
            }
        }

        private bool ValidaCPF()
        {
            return Util.ValidaCPF.IsCpf(txtCPF.Text);
        }

    }
}

