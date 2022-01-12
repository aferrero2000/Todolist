using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfTodolist.Entity;
using WpfTodolist.Persistance;
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
        TascaService ts = new TascaService();
        ResponsableService rs = new ResponsableService();
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

        private void afegir_tasca_Click(object sender, RoutedEventArgs e)
        {
            var llista_responsables = rs.GetAll();
            if (llista_responsables.Count != 0)
            {
                Window1 form = new Window1();
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


        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            Button boto = (Button)sender;
            Window1 form = new Window1(new ObjectId(boto.Tag.ToString()));
            form.ShowDialog();
            actualitzarLlistes();
        }

        private void todo_next_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = ts.Refactor((Tasca_Responsable)((Button)sender).DataContext);
            tasca.Estat = "Doing";

            ts.Update(tasca);
            actualitzarLlistes();
        }

        private void doing_previous_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = ts.Refactor((Tasca_Responsable)((Button)sender).DataContext);
            tasca.Estat = "ToDo";

            ts.Update(tasca);
            actualitzarLlistes();
        }

        private void doing_next_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = ts.Refactor((Tasca_Responsable)((Button)sender).DataContext);
            tasca.Estat = "Done";

            ts.Update(tasca);
            actualitzarLlistes();
        }

        private void done_previous_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = ts.Refactor((Tasca_Responsable)((Button)sender).DataContext);
            tasca.Estat = "Doing";

            ts.Update(tasca);
            actualitzarLlistes();
        }

        private void actualitzarLlistes()
        {
            List<Tasca_Responsable> itemsToDo = new List<Tasca_Responsable>();
            IEnumerable<Tasca> toDo = ts.GetAll("ToDo");
            foreach (Tasca tasca in toDo)
            {
                itemsToDo.Add(trs.GetNomResponsable(tasca));
            }
            ListToDo.ItemsSource = itemsToDo;


            List<Tasca_Responsable> itemsDoing = new List<Tasca_Responsable>();
            IEnumerable<Tasca> doing = ts.GetAll("Doing");
            foreach (Tasca tasca in doing)
            {
                itemsDoing.Add(trs.GetNomResponsable(tasca));
            }
            ListDoing.ItemsSource = itemsDoing;

            List<Tasca_Responsable> itemsDone = new List<Tasca_Responsable>();
            IEnumerable<Tasca> done = ts.GetAll("Done");
            foreach (Tasca tasca in done)
            {
                itemsDone.Add(trs.GetNomResponsable(tasca));
            }
            ListDone.ItemsSource = itemsDone;
        }
    }
}
