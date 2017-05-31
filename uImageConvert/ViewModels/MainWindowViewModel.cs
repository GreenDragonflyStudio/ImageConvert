using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace uImageConvert.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
       
        private string _title = "uImageConverter";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool isMenuOpen;
        public bool IsMenuOpen
        {
            get { return isMenuOpen; }
            set { SetProperty(ref isMenuOpen, value); }
        }

        private DelegateCommand exitAppCommand;
        private DelegateCommand<string> switchViewCommand;
        public IRegionManager _regionManager;

        public DelegateCommand<string> SwitchViewCommand =>
            switchViewCommand ?? (switchViewCommand = new DelegateCommand<string>(ShowMenu));

        internal void ShowMenu(string uri)
        {
            _regionManager.RequestNavigate("ContentRegion", uri);
            IsMenuOpen = false;
        }

        public DelegateCommand ExitAppCommand =>
            exitAppCommand ?? (exitAppCommand = new DelegateCommand(() => App.Current.Shutdown() /*ExitApp*/ , () => true));

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ShowMenu("converter");
        }
    }
}
