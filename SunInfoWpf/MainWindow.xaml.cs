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
using System.Text.RegularExpressions;
using CoreLibrary;

namespace SunInfoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILatitudeValidator _latitudeValidator;
        private ILongitudeValidator _longitudeValidator;

        public MainWindow(ILatitudeValidator latValidator, ILongitudeValidator longValidator)
        {
            InitializeComponent();

            _latitudeValidator = latValidator;
            _longitudeValidator = longValidator;
        }

        private bool ValidateUserInput()
        {


            return true;
        }

        private bool ValidateLongitude()
        {


            return true;
        }

        private void btnGetSunInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
