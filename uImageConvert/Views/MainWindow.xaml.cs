using System.Windows;

namespace uImageConvert.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mw = (this.DataContext as ViewModels.MainWindowViewModel);
            mw.ShowMenu("converter");
        }
         
    }
}
