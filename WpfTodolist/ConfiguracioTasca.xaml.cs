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
        bool novatasca;
        public Window1()
        {
            novatasca = true;
            InitializeComponent();
            btn_eliminar.Visibility = System.Windows.Visibility.Hidden;
        }

        public Window1(String ID)
        {
            novatasca = false;
            InitializeComponent();

            Tasca tasca = TascaService.GetOne(Convert.ToInt32(ID));
            Responsable responsable = ResponsableService.GetOne(Convert.ToInt32(tasca.Id));
            nom_tasca.Text = tasca.Nom;
            descripcio.Text = tasca.Descripcio;
            data_de_creacio.SelectedDate = tasca.Data_creacio;
            data_prevista_de_finalitzacio.SelectedDate = tasca.Data_finalitzacio;
            nom_responsable.Text = responsable.Nom;
            prioritata.SelectedIndex = tasca.Prioritat - 1;
            ID_Binding.Content = ID;

        }
        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = new Tasca();
            Responsable responsable = new Responsable();

            tasca.Nom = nom_tasca.Text;
            tasca.Descripcio = descripcio.Text;
            tasca.Prioritat = 1;
            DateTime datacreacio = DateTime.ParseExact(data_de_creacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
            tasca.Data_creacio = datacreacio;
            DateTime datafinal = DateTime.ParseExact(data_prevista_de_finalitzacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
            tasca.Data_finalitzacio = datafinal;
            responsable.Nom = nom_responsable.Text;

            if (novatasca)
            {
                tasca.Estat = "ToDo";
                TascaService.SetOne(tasca);
                ResponsableService.SetOne(responsable);
            }
            else
            {
                tasca.Id = Convert.ToInt32(ID_Binding.Content);
                TascaService.UpdateNoEstat(tasca);
                ResponsableService.Update(responsable);
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close(); //NOSE
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            TascaService.Delete(TascaService.GetOne(Convert.ToInt32(ID_Binding.Content)).Id);
            Close();
        }
    }
}
