using DetalleOrden.BLL;
using DetalleOrden.Entidades;
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

namespace DetalleOrden.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroProducto.xaml
    /// </summary>
    public partial class RegistroProducto : Window
    {
        public RegistroProducto()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextbox.Text = "0";
            DescripcionTextbox.Text = string.Empty;
            PrecioTextbox.Text = string.Empty;
            InventarioTextbox.Text = string.Empty;
        }

        private void Button_Nuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Producto LlenaClase()
        {
            Producto producto = new Producto();
            producto.ProductoId = Convert.ToInt32(IdTextbox.Text);
            producto.Descripcion = string.Empty;
            producto.Precio = Convert.ToDecimal(PrecioTextbox.Text);
            producto.Inventario = Convert.ToDecimal(InventarioTextbox.Text);
            return producto;
        }

        private void LlenaCampo(Producto producto)
        {
            
            IdTextbox.Text = Convert.ToString(producto.ProductoId);
            DescripcionTextbox.Text = string.Empty;
            PrecioTextbox.Text = Convert.ToString(producto.Descripcion);
            InventarioTextbox.Text = Convert.ToString(producto.Inventario);

        }

        private bool ExisteEnLaBaseDeDatos() 
        {
            Producto producto= ProductoBLL.Buscar(Convert.ToInt32(IdTextbox.Text));
            return (producto != null);
        }

        private bool validar()
        {
            bool paso = true;
         
            if (string.IsNullOrWhiteSpace(DescripcionTextbox.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
                DescripcionTextbox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(PrecioTextbox.Text))
            {
                MessageBox.Show("No puede dejar campos vacios","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                
                paso = false;
            }

            if (InventarioTextbox.Text == "  ")
            {
                MessageBox.Show("No puede dejar campos vacios");
                DescripcionTextbox.Focus();
                paso = false;
            }

            return paso;

        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            Producto producto;
            bool paso = false;

            producto = LlenaClase();

            if (IdTextbox.Text == "0")
                paso = ProductoBLL.Guardar(producto);

            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("Personas No Existe!!");
                }
                MessageBox.Show("Persona Modificada!!");
                paso = ProductoBLL.Modificar(producto);
            }

            if (paso)
            {
                MessageBox.Show("¡¡Guardado!!");
            }
            else
            {
                MessageBox.Show("No se Guardo!!");
            }
        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextbox.Text, out id);


            if (ProductoBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!");
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar!!");
            }
        }

        private void Button_Buscar(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextbox.Text, out id);
            Producto producto = new Producto();

            producto = ProductoBLL.Buscar(id);

            if (producto != null)
            {
                MessageBox.Show("Persona Encontrada!!");
                LlenaCampo(producto);
            }
            else
            {
                MessageBox.Show("Persona No Encontrada!!");
            }
        }
    }
}
