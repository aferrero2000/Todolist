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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTodolist.Persistance;
using WpfTodolist.Service;
using WpfTodolist.Entity;
using System.Diagnostics;

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
            DbContext.Up(); //Si la base de dades no existeix, no executarà el codi posterior. (ara si funciona però no sé com ho he solucionat)
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actualitzarLlistes();
        }





        private void Button_ex1_Click(object sender, RoutedEventArgs e)
        {
            Window1 form = new Window1();
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
            IEnumerable<Prioritat> prioritats = PrioritatService.GetAll();
            ListToDo.ItemsSource = TascaService.GetAll("ToDo");
            foreach (Tasca item in ListToDo.ItemsSource)
            { 
                item.
                MessageBox.Show(item.Prioritat.ToString());
            } 
            ListDoing.ItemsSource = TascaService.GetAll("Doing");
            ListDone.ItemsSource = TascaService.GetAll("Done");
        }
    }
}
