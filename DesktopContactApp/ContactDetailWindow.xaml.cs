using DesktopContactApp.Classes;
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
using System.Windows.Shapes;

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
