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
            Responsable responsable = ResponsableService.GetOne(Convert.ToInt32(tasca.Responsable));
            nom_tasca.Text = tasca.Nom;
            descripcio.Text = tasca.Descripcio;
            data_de_creacio.SelectedDate = tasca.Data_creacio;
            data_prevista_de_finalitzacio.SelectedDate = tasca.Data_finalitzacio;
            nom_responsable.Text = responsable.Nom;
            switch (tasca.Prioritat)
            {
                case "Red":
                    prioritata.SelectedIndex = 0;
                    break;
                case "Yellow":
                    prioritata.SelectedIndex = 1;
                    break;
                case "Green":
                    prioritata.SelectedIndex = 2;
                    break;
            }
            ID_Binding.Content = ID;
            Responsable_Binding.Content = tasca.Responsable.ToString();

        }
        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Tasca tasca = new Tasca();
            Responsable responsable = new Responsable();
            
            tasca.Nom = nom_tasca.Text;
            tasca.Descripcio = descripcio.Text;
            DateTime datacreacio = DateTime.ParseExact(data_de_creacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
            tasca.Data_creacio = datacreacio;
            DateTime datafinal = DateTime.ParseExact(data_prevista_de_finalitzacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
            tasca.Data_finalitzacio = datafinal;
            responsable.Nom = nom_responsable.Text;
            tasca.Responsable = Convert.ToInt32(Responsable_Binding.Content.ToString());
            responsable.Id = tasca.Responsable;
            switch (prioritata.SelectedIndex)
            {
                case 0:
                    tasca.Prioritat = "Red";
                    break;
                case 1:
                    tasca.Prioritat = "Yellow";
                    break;
                case 2:
                    tasca.Prioritat = "Green";
                    break;
            }

            if (novatasca)
            {
                tasca.Estat = "ToDo";
                ResponsableService.SetOne(responsable);
                Responsable temp = ResponsableService.GetOne(responsable.Nom);
                tasca.Responsable = temp.Id;
                TascaService.SetOne(tasca);
            }
            else
            {
                tasca.Id = Convert.ToInt32(ID_Binding.Content);
                tasca.Responsable = Convert.ToInt32(Responsable_Binding.Content);
                ResponsableService.Update(responsable);
                TascaService.UpdateNoEstat(tasca);
            }
            Close();
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            TascaService.Delete(TascaService.GetOne(Convert.ToInt32(ID_Binding.Content)).Id);
            Close();
        }
    }
}