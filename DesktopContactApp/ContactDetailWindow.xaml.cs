using DesktopContactApp.Classes;
using System.Windows;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for ContactDetailWindow.xaml
    /// </summary>
    public partial class ContactDetailWindow : Window
    {
        Contact _contact;
        public ContactDetailWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this._contact = contact;

            nameTextBox.Text = contact.Name;
            lastNameTextBox.Text = contact.LastName;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            _contact.Name = nameTextBox.Text;
            _contact.LastName = lastNameTextBox.Text;
            _contact.Email = emailTextBox.Text;
            _contact.Phone = phoneTextBox.Text;
            
            using (SQLite.SQLiteConnection connection = new(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);
            };

            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(_contact);
            };

            this.Close();
        }
    }
}
