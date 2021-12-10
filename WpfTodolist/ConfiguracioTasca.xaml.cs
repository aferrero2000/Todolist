﻿using System;
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

            IEnumerable<Responsable> hola = ResponsableService.GetAll();
            foreach (Responsable person in hola)
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

            IEnumerable<Responsable> hola = ResponsableService.GetAll();
            foreach (Responsable person in hola)
            {
                if (!Responsable_Bindingg.Items.Contains(person.Id))
                {
                    Responsable_Bindingg.Items.Add(person.Nom);
                }
            }
            

            Responsable_Bindingg.SelectedItem = responsable.Nom;
            switch (tasca.Prioritat)
            {
                case "Red":
                    prioritata.Foreground = Brushes.Red;
                    prioritata.SelectedIndex = 0;
                    break;
                case "Yellow":
                    prioritata.Foreground = Brushes.Yellow;
                    prioritata.SelectedIndex = 1;
                    break;
                case "Green":
                    prioritata.Foreground = Brushes.Green;
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
            responsable.Nom = Responsable_Bindingg.SelectedItem.ToString();
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



            bool dadescompletades;
            dadescompletades = true;

            if (nom_tasca.Text.Length == 0)
            {
                MessageBox.Show("Has d'introduir un nom.");
                dadescompletades = false;
            }
            else if (descripcio.Text.Length == 0)
            {
                MessageBox.Show("Has d'introduir la descripció.");
                dadescompletades = false;
            }
            /*else if (data_de_creacio.SelectedDate == null) //No funciona, una solució temporal és afegir l'atribut "Focusable" a "False" en l'etiqueta "DatePicker"
            {
                data_de_creacio.SelectedDate = DateTime.Today;
                MessageBox.Show("Has d'introduir data de creació.");
                dadescompletades = false;
            }*/

            if (dadescompletades)
            {

                if (novatasca)
                {
                    tasca.Estat = "ToDo";
                    Responsable temp = ResponsableService.GetOne(responsable.Nom);
                    tasca.Responsable = temp.Id;
                    TascaService.SetOne(tasca);
                }
                else
                {
                    Responsable temp = ResponsableService.GetOne(responsable.Nom);
                    tasca.Responsable = temp.Id;
                    tasca.Id = Convert.ToInt32(ID_Binding.Content);
                    TascaService.UpdateNoEstat(tasca);
                }

                Close();
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