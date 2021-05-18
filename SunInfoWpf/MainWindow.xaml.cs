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
        private IErrorMessageHandler _errorMessageHandler;

        public MainWindow(
            ILatitudeValidator latValidator,
            ILongitudeValidator longValidator,
            IErrorMessageHandler errorMessageHandler)
        {
            InitializeComponent();

            _latitudeValidator = latValidator;
            _longitudeValidator = longValidator;
            _errorMessageHandler = errorMessageHandler;
        }

        private bool ValidateUserInput()
        {
            bool latitudeOk = ValidateLatitude();
            bool longitudeOk = ValidateLongitude();

            return latitudeOk && longitudeOk;
        }

        private bool ValidateLatitude()
        {
            bool isValid = _latitudeValidator.IsValidLatitude(textBoxLatitude.Text);

            if (isValid == false)
            {
                _errorMessageHandler.AddMessage("Invalid latitude.");
            }

            return isValid;
        }

        private bool ValidateLongitude()
        {
            bool isValid = _longitudeValidator.IsValidLongitude(textBoxLongitude.Text);

            if (isValid == false)
            {
                _errorMessageHandler.AddMessage("Invalid longitude.");
            }

            return isValid;
        }

        private void btnGetSunInfo_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateUserInput() == false)
            {
                MessageBox.Show(
                    _errorMessageHandler.GetMessages(),
                    "Info",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }
        }
    }
}
