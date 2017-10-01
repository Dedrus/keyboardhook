using System.Windows;
using BeOpen.Devices.KeyboardListener;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KeyboardListener _listener;
        public MainWindow()
        {
            InitializeComponent();
            _listener = new KeyboardListener(5);
            _listener.NewText += _listener_NewText;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, System.EventArgs e)
        {
            _listener.Dispose();
        }

        private void _listener_NewText(object sender, NewStringEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                TextBox.Text = $"Keyboard event captured. Text is:{e.Text}";
            });
        }
    }
}
