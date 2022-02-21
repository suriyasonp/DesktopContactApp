using DesktopContactApp.Classes;
using System;
using System.IO;
using System.Windows;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Save contact

            Contact contact = new()
            {
                Name = nameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text,
            };

            using (SQLite.SQLiteConnection connection = new(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            };



            this.Close();
        }
    }
}
