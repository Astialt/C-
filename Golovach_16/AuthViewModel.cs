using OrderManagement.Commands;
using OrderManagement.Models;
using OrderManagement.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OrderManagement.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
        private readonly UserService _userService;
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public AuthViewModel()
        {
            _userService = new UserService();
            LoginCommand = new RelayCommand(async p => await LoginAsync());
            RegisterCommand = new RelayCommand(async p => await RegisterAsync());
        }

        private async Task LoginAsync()
        {
            var user = await _userService.AuthenticateUserAsync(Username, Password);
            MessageBox.Show(user != null ? "Вход выполнен успешно" : "Неверное имя пользователя или пароль");
        }

        private async Task RegisterAsync()
        {
            var newUser = new UserModel { Username = Username, Password = Password };
            bool success = await _userService.RegisterUserAsync(newUser);
            MessageBox.Show(success ? "Регистрация успешна" : "Пользователь с таким именем уже существует");
        }
    }
}
