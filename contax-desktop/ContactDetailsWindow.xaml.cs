using contax_desktop.Classes;
using SQLite;
using System.Runtime.InteropServices;
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

namespace contax_desktop
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {

        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;

            Deactivated += ContactDetailsWindow_Deactivated;
        }

        private void ContactDetailsWindow_Deactivated(object sender, System.EventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;

            using (SQLiteConnection connection = new(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            Close();

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

            using (SQLiteConnection connection = new(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            Close();

        }


    }
}
