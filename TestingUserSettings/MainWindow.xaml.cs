using System;
using System.Windows;

namespace TestingUserSettings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.UpdatedNeeded)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdatedNeeded = false;
                Properties.Settings.Default.Save();
            }

            firstNameTBox.Text = Properties.Settings.Default.FirstName;
            lastNameTBox.Text = Properties.Settings.Default.LastName;
            updateNeededTBlock2.Text = Properties.Settings.Default.UpdatedNeeded.ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.FirstName = firstNameTBox.Text;
            Properties.Settings.Default.LastName = lastNameTBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
