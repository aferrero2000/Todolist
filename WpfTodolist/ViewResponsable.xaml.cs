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
    /// Lógica de interacción para ViewResponsable.xaml
    /// </summary>
    public partial class ViewResponsable : Window
    {
        public ViewResponsable()
        {
            InitializeComponent();
            dgUsers.ItemsSource = ResponsableService.GetAll();
        }

    }
}
