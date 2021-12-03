using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfTodolist.Entity;
using WpfTodolist.Persistance;
using WpfTodolist.Service;

namespace WpfTodolist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            InitializeComponent();
            DbContext.Up();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actualitzarLlistes();
        }

        private void afegir_tasca_Click(object sender, RoutedEventArgs e)
        {
            Window1 form = new Window1();
            form.ShowDialog();
            actualitzarLlistes();
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
            Window1 form = new Window1(boto.Tag.ToString());
            form.ShowDialog();
            actualitzarLlistes();
        }

        private void todo_next_Click(object sender, RoutedEventArgs e)
        {
            Button boto = (Button)sender;
            TascaService.UpdateEstat("Doing", Convert.ToInt32(boto.Tag.ToString()));
            actualitzarLlistes();
        }

        private void doing_previous_Click(object sender, RoutedEventArgs e)
        {
            Button boto = (Button)sender;
            TascaService.UpdateEstat("ToDo", Convert.ToInt32(boto.Tag.ToString()));
            actualitzarLlistes();
        }

        private void doing_next_Click(object sender, RoutedEventArgs e)
        {
            Button boto = (Button)sender;
            TascaService.UpdateEstat("Done", Convert.ToInt32(boto.Tag.ToString()));
            actualitzarLlistes();
        }

        private void done_previous_Click(object sender, RoutedEventArgs e)
        {
            Button boto = (Button)sender;
            TascaService.UpdateEstat("Doing", Convert.ToInt32(boto.Tag.ToString()));
            actualitzarLlistes();
        }

        private void actualitzarLlistes()
        {
            List<Tasca_Responsable> itemsToDo = new List<Tasca_Responsable>();
            IEnumerable<Tasca> toDo = TascaService.GetAll("ToDo");
            foreach (Tasca tasca in toDo)
            {
                itemsToDo.Add(Tasca_ResponsableService.GetNomResponsable(tasca));
            }
            ListToDo.ItemsSource = itemsToDo;

            List<Tasca_Responsable> itemsDoing = new List<Tasca_Responsable>();
            IEnumerable<Tasca> Doing = TascaService.GetAll("Doing");
            foreach (Tasca tasca in Doing)
            {
                itemsDoing.Add(Tasca_ResponsableService.GetNomResponsable(tasca));
            }
            ListDoing.ItemsSource = itemsDoing;

            List<Tasca_Responsable> itemsDone = new List<Tasca_Responsable>();
            IEnumerable<Tasca> Done = TascaService.GetAll("Done");
            foreach (Tasca tasca in Done)
            {
                itemsDone.Add(Tasca_ResponsableService.GetNomResponsable(tasca));
            }
            ListDone.ItemsSource = itemsDone;
        }
    }
}
