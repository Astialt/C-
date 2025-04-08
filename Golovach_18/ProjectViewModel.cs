using System.Collections.ObjectModel;
using System.Windows.Input;
using OrderManagementDemo.Commands;

namespace OrderManagementDemo.ViewModels
{
    public class ProjectViewModel<T> : BaseViewModel where T : new()
    {
        private readonly Repositories.IRepository<T> _repo;
        public ObservableCollection<T> Items { get; } = new ObservableCollection<T>();

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ProjectViewModel(Repositories.IRepository<T> repo)
        {
            _repo = repo;
            LoadCommand = new AsyncRelayCommand(async () =>
            {
                var list = await _repo.GetAllAsync();
                Items.Clear();
                foreach (var i in list)
                    Items.Add(i);
            });
            AddCommand = new AsyncRelayCommand(async () =>
            {
                await _repo.AddAsync(new T());
                await _repo.SaveAsync();
                await ((AsyncRelayCommand)LoadCommand).ExecuteAsync(null);
            });
            DeleteCommand = new AsyncRelayCommand(async () =>
            {
                await _repo.DeleteAsync(SelectedItem);
                await _repo.SaveAsync();
                await ((AsyncRelayCommand)LoadCommand).ExecuteAsync(null);
            });
        }

        private T _selectedItem;
        public T SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
        }
    }
}
