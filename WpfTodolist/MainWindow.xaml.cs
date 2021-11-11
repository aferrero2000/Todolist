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
            DbContext.Up();

            foreach (var prioritat in PrioritatService.GetAll())
            {
                Trace.WriteLine(
                    string.Format("#{0}: - {1}, {2}", prioritat.Id, prioritat.Nom, prioritat.Color)
                );
            }
        }

        private void Button_ex1_Click(object sender, RoutedEventArgs e)
        {
            Window1 form = new Window1();
            form.ShowDialog();
        }
    }
}
