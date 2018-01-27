using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingUpdatedAnimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _someText = "Original text";
        public string SomeText
        {
            get { return _someText; }
            set
            {
                if (value != _someText)
                {
                    _someText = value;
                    RaisePropChanged("SomeText");
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private int nextNum = 1;
        private void btnDoSomething_Click(object sender, RoutedEventArgs e)
        {
            SomeText = string.Format("Change to {0}", nextNum++);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropChanged(string propname)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }
}
