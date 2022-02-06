using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfTodolist.Entity;
using WpfTodolist.Api;
using WpfTodolist.Service;
using System.Diagnostics;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WpfTodolist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApiClient api = new ApiClient();
        Tasca_ResponsableService trs = new Tasca_ResponsableService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actualitzarLlistes();
        }

        private async void afegir_tasca_Click(object sender, RoutedEventArgs e)
        {
            List<Responsable> llista_responsables = await api.GetResponsableAsync();
            if (llista_responsables.Count != 0)
            {
                Window1 form = new Window1(llista_responsables);
                form.ShowDialog();
                actualitzarLlistes(); 
            }
            else
            {
                MessageBox.Show("Has de crear un responsable primer", "Falta Responsable", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void llista_responsabe_Click(object sender, RoutedEventArgs e)
        {
            ViewResponsable form = new ViewResponsable();

            form.ShowDialog();
            actualitzarLlistes();
        }


        private async void Modificar_Click(object sender, RoutedEventArgs e)
        {
            Button boto = (Button)sender;
            List<Responsable> llista_responsables = await api.GetResponsableAsync();
            List<Tasca> llista_tasques = await api.GetTasquesAsync();
            List<Prioritat> llista_prioritats = await api.GetPrioritatsAsync();
            Window1 form = new Window1(llista_responsables, llista_tasques.Find(t => t.Id.Equals(boto.Tag.ToString())), llista_prioritats);
            form.ShowDialog();
            actualitzarLlistes();
        }

        private void todo_next_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = new Tasca((Tasca_Responsable)((Button)sender).DataContext);
            tasca.Estat = "Doing";

            api.UpdateTascaAsync(tasca);
            actualitzarLlistes();
        }

        private void doing_previous_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = (Tasca)((Button)sender).DataContext;
            tasca.Estat = "ToDo";

            api.UpdateTascaAsync(tasca);
            actualitzarLlistes();
        }

        private void doing_next_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = new Tasca((Tasca_Responsable)((Button)sender).DataContext);
            tasca.Estat = "Done";

            api.UpdateTascaAsync(tasca);
            actualitzarLlistes();
        }

        private void done_previous_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = new Tasca((Tasca_Responsable)((Button)sender).DataContext);
            tasca.Estat = "Doing";

            api.UpdateTascaAsync(tasca);
            actualitzarLlistes();
        }

        private async void actualitzarLlistes()
        {
            ListToDo.ItemsSource = await api.GetTasquesEstatAsync("ToDo");
            ListDoing.ItemsSource = await api.GetTasquesEstatAsync("Doing");
            ListDone.ItemsSource = await api.GetTasquesEstatAsync("Done");
        }
    }
}
