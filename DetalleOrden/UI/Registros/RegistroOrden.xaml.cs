using DetalleOrden.BLL;
using DetalleOrden.DAL;
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
    /// Interaction logic for RegistroOrden.xaml
    /// </summary>
    public partial class RegistroOrden : Window
    {
        public List<OrdenDetalle> Detalles { get; set; }

        public RegistroOrden()
        {
            InitializeComponent();
            this.Detalles = new List<OrdenDetalle>();
        }

        private void Limpiar()
        {
            FechaPicker.SelectedDate = DateTime.Now;
            CantidadTextbox.Text = string.Empty;
            ProductoIdTextbox.Text = string.Empty;

            this.Detalles = new List<OrdenDetalle>();
            CargarGrid();
        }

        private Orden LlenaClase()
        {
            Orden orden = new Orden();
            orden.OrdenId = Convert.ToInt32(IdTextbox.Text);
            orden.Fecha = Convert.ToDateTime(FechaPicker.SelectedDate);
            orden.Ordenes = this.Detalles;

            return orden;
        }

        private void LlenaCampo(Orden orden)
        {
            IdTextbox.Text = Convert.ToString(orden.OrdenId);
            FechaPicker.SelectedDate = orden.Fecha;
            this.Detalles = orden.Ordenes;
        }

        private bool ExisteEnLaBaseDatos()
        {
            Orden orden = OrdenBLL.Buscar((int)Convert.ToInt32(IdTextbox.Text));
            return (orden != null);
        }

        private void CargarGrid()
        {
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = this.Detalles;
        }

        private void ButtonNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            Orden orden;
            bool paso = false;

            orden = LlenaClase();


            if (IdTextbox.Text == "0")
                paso = OrdenBLL.Guardar(orden);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("Personas No Existe!!");
                }
                MessageBox.Show("Persona Modificada!!");
                paso = OrdenBLL.Modificar(orden);
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

        private void Button_Buscar(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextbox.Text, out id);
            Orden orden = new Orden();

            orden = OrdenBLL.Buscar(id);

            if (orden != null)
            {
                MessageBox.Show("Persona Encontrada!!");
                LlenaCampo(orden);
            }
            else
            {
                MessageBox.Show("Persona No Encontrada!!");
            }

        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextbox.Text, out id);


            if (OrdenBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!");
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar!!");
            }
        }

        private void Button_Remover(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0 && DataGrid.SelectedCells != null)

                Detalles.RemoveAt(DataGrid.SelectedIndex);

            CargarGrid();
        }

        private void Button_Agregar(object sender, RoutedEventArgs e)
        {
            Contexto db = new Contexto();
            if (DataGrid.SelectedItem != null)
                this.Detalles = (List<OrdenDetalle>)DataGrid.ItemsSource;

            Producto pro = ProductoBLL.Buscar(Convert.ToInt32(ProductoIdTextbox.Text));

            this.Detalles.Add(

                new OrdenDetalle(
                    id: 0,
                    ordenId: Convert.ToInt32(IdTextbox.Text),
                    productoId:Convert.ToInt32( ProductoIdTextbox.Text),
                    cantidad:Convert.ToInt32(CantidadTextbox.Text)
                  
                    ));

            CargarGrid();
            ProductoIdTextbox.Clear();
            CantidadTextbox.Clear();
        }
    }
}
