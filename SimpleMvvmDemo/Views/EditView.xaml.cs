using SimpleMvvmDemo.ViewModels;
using System.Windows;

namespace SimpleMvvmDemo.Views
{
    /// <summary>
    /// EditView.xaml 的交互逻辑
    /// </summary>
    public partial class EditView : Window
    {
        public EditView()
        {
            InitializeComponent();
            this.DataContext = new EditViewModel();
        }
    }
}
