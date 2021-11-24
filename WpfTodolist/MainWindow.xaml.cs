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
            ListToDo.ItemsSource = TascaService.GetAll("ToDo");
            ListDoing.ItemsSource = TascaService.GetAll("Doing");
            ListDone.ItemsSource = TascaService.GetAll("Done");
        }





        private void Button_ex1_Click(object sender, RoutedEventArgs e)
        {
            Window1 form = new Window1();
            form.ShowDialog();
            ListToDo.ItemsSource = TascaService.GetAll();
        }


    }
}
