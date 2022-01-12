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
        TascaService ts = new TascaService();
        PrioritatService ps = new PrioritatService();
        ResponsableService rs = new ResponsableService();
        public Window1()
        {
            novatasca = true;
            InitializeComponent();

            data_de_creacio.SelectedDate = DateTime.Today;
            data_prevista_de_finalitzacio.SelectedDate = DateTime.Today.AddDays(+7);

            IEnumerable<Responsable> ResponsableList = rs.GetAll();
            foreach (Responsable person in ResponsableList)
            {
                if (!Responsable_Bindingg.Items.Contains(person.Id))
                {
                    Responsable_Bindingg.Items.Add(person.Nom);
                }
            }

            btn_eliminar.Visibility = Visibility.Hidden;
        }

        public Window1(ObjectId ID)
        {
            novatasca = false;
            InitializeComponent();

            Tasca tasca = ts.GetOne(ID);
            Responsable responsable = rs.GetOne(tasca.Responsable);
            nom_tasca.Text = tasca.Nom;
            descripcio.Text = tasca.Descripcio;
            data_de_creacio.SelectedDate = tasca.Data_creacio;
            data_prevista_de_finalitzacio.SelectedDate = tasca.Data_finalitzacio;
            Prioritat prioritat = ps.GetOne(tasca.Prioritat);
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
            ID_Binding.Content = ID;
            IEnumerable<Responsable> ResponsableList = rs.GetAll();
            foreach (Responsable person in ResponsableList)
            {
                if (!Responsable_Bindingg.Items.Contains(person.Id))
                {
                    Responsable_Bindingg.Items.Add(person.Nom + ' ' + person.Cognom);
                }
            }

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
                Responsable responsable = new Responsable();

                tasca.Nom = nom_tasca.Text;
                tasca.Descripcio = descripcio.Text;
                DateTime datacreacio = DateTime.ParseExact(data_de_creacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                tasca.Data_creacio = datacreacio;
                DateTime datafinal = DateTime.ParseExact(data_prevista_de_finalitzacio.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                tasca.Data_finalitzacio = datafinal;
                responsable.Nom = Responsable_Bindingg.SelectedItem.ToString();
                Prioritat prioritat;
                switch (prioritata.SelectedIndex)
                {
                    case 0:
                        prioritat = ps.GetOne("Red");
                        tasca.Prioritat = prioritat.Id;
                        break;
                    case 1:
                        prioritat = ps.GetOne("Yellow");
                        tasca.Prioritat = prioritat.Id;
                        break;
                    case 2:
                        prioritat = ps.GetOne("Green");
                        tasca.Prioritat = prioritat.Id;
                        break;
                }

                if (novatasca)
                {
                    tasca.Estat = "ToDo";
                    rs.Add(responsable);
                    Responsable temp = rs.GetOne(responsable.Id);
                    tasca.Responsable = temp.Id;
                    ts.Add(tasca);
                }
                else
                {
                    
                    tasca.Responsable = new ObjectId(Responsable_Binding.Content.ToString());
                    responsable.Id = tasca.Responsable;
                    tasca.Id = new ObjectId(ID_Binding.Content.ToString());
                    tasca.Responsable = new ObjectId(Responsable_Binding.Content.ToString());
                    rs.Update(responsable);
                    ts.Update(tasca);
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
            ts.Delete(new ObjectId(ID_Binding.Content.ToString()));
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