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
using WpfTodolist.Api;
using WpfTodolist.Service;
using WpfTodolist.Entity;
using System.Diagnostics;
using System.Globalization;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WpfTodolist
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        bool novatasca;
        ApiClient api = new ApiClient();
        public Window1(List<Responsable> lr)
        {
            novatasca = true;
            InitializeComponent();

            data_de_creacio.SelectedDate = DateTime.Today;
            data_prevista_de_finalitzacio.SelectedDate = DateTime.Today.AddDays(+7);

            foreach (Responsable person in lr)
            {
                if (!Responsable_Bindingg.Items.Contains(person.Id))
                {
                    Responsable_Bindingg.Items.Add(person.Nom);
                }
            }

            btn_eliminar.Visibility = Visibility.Hidden;
        }

        public Window1(List<Responsable> lr, Tasca tasca, List<Prioritat> lp)
        {
            novatasca = false;
            InitializeComponent();

            Responsable responsable = lr.Find(r => r.Id.Equals(tasca.Responsable));
            nom_tasca.Text = tasca.Nom;
            descripcio.Text = tasca.Descripcio;
            data_de_creacio.SelectedDate = tasca.Data_creacio;
            data_prevista_de_finalitzacio.SelectedDate = tasca.Data_finalitzacio;
            Prioritat prioritat = lp.Find(p=> p.Id.Equals(tasca.Prioritat));
            switch (prioritat.Color)
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
            ID_Binding.Content = tasca.Id;
            foreach (Responsable person in lr)
            {
                if (!Responsable_Bindingg.Items.Contains(person.Id))
                {
                    Responsable_Bindingg.Items.Add(person.Nom + ' ' + person.Cognom);
                }
            }

        }
        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {

            string dadesperdeterminar = "Has de determinar:";
            
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
                Responsable responsable = new Responsable();

                tasca.Nom = nom_tasca.Text;
                tasca.Descripcio = descripcio.Text;
                DateTime datacreacio = DateTime.ParseExact(data_de_creacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                tasca.Data_creacio = datacreacio;
                DateTime datafinal = DateTime.ParseExact(data_prevista_de_finalitzacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                tasca.Data_finalitzacio = datafinal;
                responsable.Nom = Responsable_Bindingg.SelectedItem.ToString();
                List<Prioritat> prioritats = api.GetPrioritatsAsync().Result;
                switch (prioritata.SelectedIndex)
                {
                    case 0:
                        tasca.Prioritat = prioritats.Find(p => p.Color.Equals("Red")).Id;
                        break;
                    case 1:
                        tasca.Prioritat = prioritats.Find(p => p.Color.Equals("Yellow")).Id;
                        break;
                    case 2:
                        tasca.Prioritat = prioritats.Find(p => p.Color.Equals("Green")).Id;
                        break;
                }

                if (novatasca)
                {
                    tasca.Estat = "ToDo";
                    List<Responsable> responsables = api.GetResponsableAsync().Result;
                    Responsable temp = responsables.Find(r => r.Id.Equals(responsable.Id));
                    tasca.Responsable = temp.Id;
                    api.AddTascaAsync(tasca);
                }
                else
                {
                    
                    tasca.Responsable = Responsable_Binding.Content.ToString();
                    tasca.Id = ID_Binding.Content.ToString();
                    api.UpdateTascaAsync(tasca);
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

        private async void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            await api.DeleteTascaAsync(ID_Binding.Content.ToString());
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