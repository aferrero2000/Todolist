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
using WpfTodolist.Entity;
using WpfTodolist.Persistance;
using WpfTodolist.Service;

namespace WpfTodolist
{
    /// <summary>
    /// Lógica de interacción para ConfiguracioResponsable.xaml
    /// </summary>
    public partial class ConfiguracioResponsable : Window
    {
        bool novatasca;
        public ConfiguracioResponsable()
        {
            novatasca = true;
            InitializeComponent();

            btn_eliminar.Visibility = System.Windows.Visibility.Hidden;
        }

        public ConfiguracioResponsable(String ID)
        {
            novatasca = false;
            InitializeComponent();

            Responsable responsable = ResponsableService.GetOne(Convert.ToInt32(ID));
            nom_rresponsable.Text = responsable.Nom;
            cognom_responsable.Text = responsable.Id.ToString();
        }


        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Responsable responsable = new Responsable();

            responsable.Nom = nom_rresponsable.Text;
            //responsable.Id = cognom_responsable.Text;

            bool dadescompletades;
            dadescompletades = true;

            if (nom_rresponsable.Text.Length == 0)
            {
                MessageBox.Show("Has d'introduir un nom.");
                dadescompletades = false;
            }
 /*           else if (cognom_responsable.Text.Length == 0)
            {
                MessageBox.Show("Has d'introduir la descripció.");
                dadescompletades = false;
            }*/

            if (dadescompletades)
            {

                if (novatasca)
                {
                    ResponsableService.SetOne(responsable);
                }
                else
                {
                    responsable.Id = Convert.ToInt32(cognom_responsable.Text);
                    ResponsableService.Update(responsable);
                }

                Close();
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
