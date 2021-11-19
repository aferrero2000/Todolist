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
using WpfTodolist.Persistance;
using WpfTodolist.Service;
using WpfTodolist.Entity;
using System.Diagnostics;
using System.Globalization;

namespace WpfTodolist
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {
            string caption = "Informació";
            MessageBox.Show(nom_tasca.Text + descripcio.Text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
            Tasca tasca = new Tasca();
            Responsable responsable = new Responsable();

            tasca.Nom = nom_tasca.Text;
            tasca.Descripcio = descripcio.Text;
            tasca.Prioritat = 1;
            DateTime datacreacio = DateTime.ParseExact(data_de_creacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
            tasca.Data_creacio = datacreacio;
            DateTime datafinal = DateTime.ParseExact(data_prevista_de_finalitzacío.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
            tasca.Data_finalitzacio = datafinal;
            tasca.Estat = "ToDo";

            responsable.Nom = responsablee.Text;


            TascaService.SetOne(tasca);
            ResponsableService.SetOne(responsable);
        }
    }


}
