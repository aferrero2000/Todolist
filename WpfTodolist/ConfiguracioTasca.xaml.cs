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

            data_de_creacio.SelectedDate = DateTime.Today;
            data_prevista_de_finalitzacio.SelectedDate = DateTime.Today.AddDays(+7);

            IEnumerable<Responsable> ResponsableList = ResponsableService.GetAll();
            foreach (Responsable person in ResponsableList)
            {
                if (!Responsable_Bindingg.Items.Contains(person.Id))
                {
                    Responsable_Bindingg.Items.Add(person.Nom);
                }
            }

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

            IEnumerable<Responsable> ResponsableList = ResponsableService.GetAll();
            List<int> ResponsableListId = new List<int>();
            foreach (Responsable person in ResponsableList)
            {
                if (!Responsable_Bindingg.Items.Contains(person.Id))
                {
                    Responsable_Bindingg.Items.Add(person.Nom);
                    ResponsableListId.Add(person.Id);
                }
            }

            int i = 0;
            while (Responsable_Bindingg.SelectedIndex != i && i != ResponsableListId.Count)
            {
                if (ResponsableListId[i] == tasca.Responsable)
                {
                    Responsable_Bindingg.SelectedIndex = i;
                }
                else
                {
                    i++;
                }
            }



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

            string dadesperdeterminar;
            dadesperdeterminar = "Has de determinar:";
            
            if (nom_tasca.Text.Length == 0)
            {
                dadesperdeterminar = dadesperdeterminar + " Nom -";
            }
            if (descripcio.Text.Length == 0)
            {
                dadesperdeterminar = dadesperdeterminar + " Descripció -";
            }
            if (Responsable_Bindingg.Text.Length == 0)
            {
                dadesperdeterminar = dadesperdeterminar + " Responsable -";
            }
            if (prioritata.Text.Length == 0)
            {
                dadesperdeterminar = dadesperdeterminar + " Prioritat -";
            }


            if (dadesperdeterminar == "Has de determinar:")
            {
                Tasca tasca = new Tasca();

                IEnumerable<Responsable> ResponsableList = ResponsableService.GetAll();
                List<int> ResponsableListId = new List<int>();
                foreach (Responsable person in ResponsableList)
                {
                    ResponsableListId.Add(person.Id);
                }

                tasca.Nom = nom_tasca.Text;
                tasca.Descripcio = descripcio.Text;
                DateTime datacreacio = DateTime.ParseExact(data_de_creacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                tasca.Data_creacio = datacreacio;
                DateTime datafinal = DateTime.ParseExact(data_prevista_de_finalitzacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                tasca.Data_finalitzacio = datafinal;

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
                    tasca.Responsable = ResponsableListId[Responsable_Bindingg.SelectedIndex];
                    TascaService.SetOne(tasca);
                }
                else
                {
                    tasca.Responsable = ResponsableListId[Responsable_Bindingg.SelectedIndex];
                    tasca.Id = Convert.ToInt32(ID_Binding.Content);
                    TascaService.UpdateNoEstat(tasca);
                }

                Close();
            }
            else
            {
                dadesperdeterminar = dadesperdeterminar.Remove(dadesperdeterminar.Length - 2);
                MessageBox.Show(dadesperdeterminar);
            }
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

        private void prioritata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem comboBoxItem = (ComboBoxItem)comboBox.SelectedItem;

            switch (comboBoxItem.Content)
            { 
                case "Alta":
                    prioritata.Foreground = Brushes.Red;
                    break;
                case "Mitja":
                    prioritata.Foreground = Brushes.DarkGoldenrod;
                    break;
                case "Baix":
                    prioritata.Foreground = Brushes.Green;
                    break;
            }

        }
    }
}