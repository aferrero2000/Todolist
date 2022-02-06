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
using WpfTodolist.Api;

namespace WpfTodolist
{
    /// <summary>
    /// Lógica de interacción para ConfiguracioResponsable.xaml
    /// </summary>
    public partial class ConfiguracioResponsable : Window
    {
        bool nouresponsable;

        ApiClient api = new ApiClient();
        public ConfiguracioResponsable()
        {
            nouresponsable = true;
            InitializeComponent();
        }

        public ConfiguracioResponsable(string ID)
        {
            nouresponsable = false;
            InitializeComponent();

            List<Responsable> lr = api.GetResponsableAsync().Result;
            Responsable responsable = lr.Find(r => r.Id.Equals(ID));
            id_responsable.Text = responsable.Id.ToString();
            nom_responsable.Text = responsable.Nom;
            cognom_responsable.Text = responsable.Cognom;
        }


        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Responsable responsable = new Responsable();

            responsable.Nom = nom_responsable.Text;
            responsable.Cognom = cognom_responsable.Text;

            bool dadescompletades;
            dadescompletades = true;

            if (nom_responsable.Text.Length == 0)
            {
                MessageBox.Show("Has d'introduir un nom.");
                dadescompletades = false;
            }
            else if (cognom_responsable.Text.Length == 0)
            {
                MessageBox.Show("Has d'introduir el cognom.");
                dadescompletades = false;
            }

            if (dadescompletades)
            {

                if (nouresponsable)
                {
                    api.AddResponsableAsync(responsable);
                }
                else
                {
                    responsable.Id = new string(id_responsable.Text);
                    api.UpdateResponsableAsync(responsable);
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
