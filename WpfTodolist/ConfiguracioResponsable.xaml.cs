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

namespace WpfTodolist
{
    /// <summary>
    /// Lógica de interacción para ConfiguracioResponsable.xaml
    /// </summary>
    public partial class ConfiguracioResponsable : Window
    {

        public ConfiguracioResponsable()
        {
            InitializeComponent();
        }
        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
