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

            Tasca tasco = TascaService.GetOne(Convert.ToInt32(ID));
            Responsable responsablo = ResponsableService.GetOne(Convert.ToInt32(tasco.Responsable));
            nom_tasca.Text = tasco.Nom;
            descripcio.Text = tasco.Descripcio;
            data_de_creacio.SelectedDate = tasco.Data_creacio;
            data_prevista_de_finalitzacío.SelectedDate = tasco.Data_finalitzacio;
            responsablee.Text = responsablo.Nom;
            prioritata.SelectedIndex = tasco.Prioritat - 1;
            ID_Binding.Content = ID;

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
            responsable.Nom = responsablee.Text;

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
            
            responsable.Nom = responsablee.Text;

        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close(); //NOSE
        }


    }
}
