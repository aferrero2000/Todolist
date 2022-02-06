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
using WpfTodolist.Api;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WpfTodolist
{
    /// <summary>
    /// Lógica de interacción para ViewResponsable.xaml
    /// </summary>
    public partial class ViewResponsable : Window
    {
        ApiClient api = new ApiClient();

        public ViewResponsable()
        {
            InitializeComponent();
            dgUsers.ItemsSource = api.GetResponsableAsync().Result;
        }

        private void Crear_usuari_Click(object sender, RoutedEventArgs e)
        {
            ConfiguracioResponsable form = new ConfiguracioResponsable();
            form.ShowDialog();
            dgUsers.ItemsSource = api.GetResponsableAsync().Result;
        }

        private async void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Segur que vols eliminar el responsable seleccionat (Aquesta acció no es pot desfer)?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Responsable oUser = (Responsable)dgUsers.SelectedItem;
                    List<Tasca> llista_tasques =  api.GetTasquesAsync().Result;
                    llista_tasques.FindAll(t => t.Responsable == oUser.Id);
                    foreach (Tasca tasca in llista_tasques)
                    {
                        await api.DeleteTascaAsync(tasca.Id);
                    }
                    await api.DeleteResponsableAsync(oUser.Id);
                    dgUsers.ItemsSource = await api.GetResponsableAsync();
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
            ConfiguracioResponsable form = new ConfiguracioResponsable(new string(boto.Tag.ToString()));
            form.ShowDialog();
            dgUsers.ItemsSource = api.GetResponsableAsync().Result;
        }
        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
