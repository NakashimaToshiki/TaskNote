using System.Windows;

namespace TaskNote.Platform.Wpf
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow(TaskListBox taskListBox)
        {
            InitializeComponent();
            _grid.Children.Add(taskListBox);
        }
    }
}
