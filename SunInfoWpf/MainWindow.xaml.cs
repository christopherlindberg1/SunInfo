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
using CoreLibrary.ApiClients;
using CoreLibrary.Models;

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
        //private IApiHelper _apiHelper;
        //private ISunApiClient _sunApiClient;

        public SunDataModel SunDataModel { get; set; }

        public MainWindow(
            ILatitudeValidator latValidator,
            ILongitudeValidator longValidator,
            IErrorMessageHandler errorMessageHandler)
            //IApiHelper apiHelper,
            //ISunApiClient sunApiClient)
        {
            InitializeComponent();

            _latitudeValidator = latValidator;
            _longitudeValidator = longValidator;
            _errorMessageHandler = errorMessageHandler;
            //_apiHelper = apiHelper;
            //_sunApiClient = sunApiClient;
        }

        private bool ValidateUserInput()
        {
            bool latitudeOk = ValidateLatitude();
            bool longitudeOk = ValidateLongitude();
            bool dateOk = ValidateDate();

            return latitudeOk && longitudeOk && ValidateDate();
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

        private bool ValidateDate()
        {
            // No particular validation needed atm.
            return true;
        }

        private void DisplaySunInfo(SunDataModel sunDataModel)
        {
            textBlockSunrise.Text = $"{ SunDataModel.Sunrise.ToLongTimeString() } UTC";
            textBlockSunset.Text = $"{ SunDataModel.Sunset.ToLongTimeString() } UTC";
        }

        private async void btnGetSunInfo_Click(object sender, RoutedEventArgs e)
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

            IApiHelper apiHelper = new ApiHelper();
            ISunApiClient sunApiClient = new SunApiClient(apiHelper);

            SunDataModel = await sunApiClient.GetSunInformation(
                textBoxLatitude.Text,
                textBoxLongitude.Text,
                datePickerDate.SelectedDate);

            DisplaySunInfo(SunDataModel);
        }

        private void btnGetGeoLocation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
