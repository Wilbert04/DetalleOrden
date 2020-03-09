using DetalleOrden.UI;
using DetalleOrden.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DetalleOrden
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindows_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrarProductos_Click(object sender, RoutedEventArgs e)
        {
            RegistroProducto rProductos = new RegistroProducto();
            rProductos.Show();
        }

        private void RegistrarOrden_Click(object sender, RoutedEventArgs e)
        {
            RegistroOrden rOrden = new RegistroOrden();
            rOrden.Show();
        }

        private void RegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            RegistroCliente rCliente = new RegistroCliente();
            rCliente.Show();
        }
    }
}
