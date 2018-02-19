using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BLupoUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string tint;
        string date;
        double width, height, woodLength, glassArea, quantity;
        const double MAX_WIDTH = 5.0;
        const double MIN_WIDTH = 0.5;
        const double MAX_HEIGHT = 3.0;
        const double MIN_HEIGHT = 0.75;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);
        }

        private void Width_Text_Change(object sender, TextChangedEventArgs e)
        {
            double parsedValue;
            if (double.TryParse(tb_width1.Text, out parsedValue))
            {
                if (parsedValue <= MAX_WIDTH && parsedValue >= MIN_WIDTH)
                {
                    tb_widthError.Text = "";
                }
                else
                {
                    var error = "Invalid Input";
                    tb_widthError.Text = error;
                }

            }
            else
            {
                var error = "Invalid Input";
                tb_widthError.Text = error;
                return;

            }
                

        }

        private void Height_Text_Changed(object sender, TextChangedEventArgs e)
        {
            double parsedValue;
            if (double.TryParse(tb_height.Text, out parsedValue))
            {
                if (parsedValue <= MAX_HEIGHT && parsedValue >= MIN_HEIGHT)
                {
                    tb_heightError.Text = "";
                }
                else
                {
                    var error = "Invalid Range";
                    tb_heightError.Text = error;
                }
                return;

            }
            else
            {
                var error = "Invalid Input";
                tb_heightError.Text = error;
                

            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            tint = cb_color.SelectedItem.ToString();
            double.TryParse(tb_height.Text, out height);
            double.TryParse(tb_width1.Text, out width);
            double.TryParse(txtResult.Text, out quantity);
            date = DateTime.Now.ToString("MM/dd/yyyy");

            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);
            double totalwood = woodLength * quantity;
            double totalGlass = glassArea * quantity;

            var msg = "Width: " + width + "\n" + "Height: "+ height + "\n" + "Tint: "+ tint + "\n" +"Quantity: " + quantity + "\n" +
                "Wood per window:  " + woodLength + " \n Total wood length:   " + totalwood +" feet." +"\n" +
                "Glass Area per window: " + glassArea + "\n Total glass area: "+ totalGlass +" square metres. \n" +
                "Order date: " + date;
            var messageDialog = new MessageDialog(msg);
            await messageDialog.ShowAsync();
        }

        private void slider1_valueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
             quantity = e.NewValue;
            //txtResult.Text = string.Format("Current value : {0}", quantity);
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tint = e.ToString();
        }


    }
}
