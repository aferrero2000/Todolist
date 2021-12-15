using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfTodolist.Entity;
using WpfTodolist.Persistance;
using WpfTodolist.Service;

namespace WpfTodolist
{
    /// <summary>
    /// Lógica de interacción para ViewResponsable.xaml
    /// </summary>
    public partial class ViewResponsable : Window
    {
        public ViewResponsable()
        {
            InitializeComponent();
            dgUsers.ItemsSource = ResponsableService.GetAll();
        }

        private void Crear_usuari_Click(object sender, RoutedEventArgs e)
        {
            ConfiguracioResponsable form = new ConfiguracioResponsable();
            form.ShowDialog();
            dgUsers.ItemsSource = ResponsableService.GetAll();
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Segur que vols eliminar el responsable seleccionat (Aquesta acció no es pot desfer)?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Responsable oUser = (Responsable)dgUsers.SelectedItem;
                    ResponsableService.Delete(oUser.Id);
                    dgUsers.ItemsSource = ResponsableService.GetAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            Button boto = (Button)sender;
            ConfiguracioResponsable form = new ConfiguracioResponsable(boto.Tag.ToString());
            form.ShowDialog();
            dgUsers.ItemsSource = ResponsableService.GetAll();
        }
        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
