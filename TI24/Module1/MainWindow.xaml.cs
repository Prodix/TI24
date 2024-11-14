using System;
using System.Collections.Generic;
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

namespace Module1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            FrameElement.NavigationService.Navigate(new Module1Page());
        }

        private void ButtonBase_OnClickTwo(object sender, RoutedEventArgs e)
        {
            FrameElement.NavigationService.Navigate(new Module2Page());
        }

        private void ButtonBase_OnClickThree(object sender, RoutedEventArgs e)
        {
            FrameElement.NavigationService.Navigate(new Module3Page());
        }
    }
}