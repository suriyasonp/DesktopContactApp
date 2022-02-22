using DesktopContactApp.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactsUserControl.xaml
    /// </summary>
    public partial class ContactsUserControl : UserControl
    {


        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactsUserControl), new PropertyMetadata(new Contact() { Name = "Name Lastname", Phone = "(123) 456 7890", Email = "example@domain.com"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactsUserControl? control = d as ContactsUserControl;

            control.nameTextBlock.Text = ((Contact)e.NewValue).FullName;
            control.emailTextBlock.Text = ((Contact)e.NewValue).Email;
            control.phoneTextBlock.Text = ((Contact)e.NewValue).Phone;

        }

        public ContactsUserControl()
        {
            InitializeComponent();
        }
    }
}
