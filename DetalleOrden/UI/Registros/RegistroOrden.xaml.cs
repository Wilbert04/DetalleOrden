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
            ClienteIdTextbox.Text = "0";
            MontoTextbox.Text = " ";
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
            orden.ClienteId = Convert.ToInt32(ClienteIdTextbox.Text);
            orden.Monto = Convert.ToDecimal(MontoTextbox.Text);
            orden.Fecha = Convert.ToDateTime(FechaPicker.SelectedDate);
            orden.Ordenes = this.Detalles;

            return orden;
        }

        private void LlenaCampo(Orden orden)
        {
            IdTextbox.Text = Convert.ToString(orden.OrdenId);
            ClienteIdTextbox.Text = Convert.ToString(orden.ClienteId);
            MontoTextbox.Text = Convert.ToString(orden.Monto);
            FechaPicker.SelectedDate = orden.Fecha;
            this.Detalles = orden.Ordenes;
        }



        private bool ExisteEnLaBaseDatos()
        {
            Orden orden = OrdenBLL.Buscar((int)Convert.ToInt32(ClienteIdTextbox.Text));
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
        /*
                private bool validar()
                {
                    bool paso = true;

                    if (string.IsNullOrWhiteSpace(MontoTextbox.Text))
                    {
                        MessageBox.Show("No puede dejar campos vacios");
                        MontoTextbox.Focus();
                        paso = false;
                    }

                    if (string.IsNullOrWhiteSpace(ProductoIdTextbox.Text))
                    {
                        MessageBox.Show("No puede dejar campos vacios");
                        ProductoIdTextbox.Focus();
                        paso = false;
                    }


                    return paso;

                }
        */
        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            
            Orden orden = new Orden();
            bool paso = false;

           // if (!validar())
               // return;

            orden = LlenaClase();

            if (IdTextbox.Text == "0")
            {
                paso = OrdenBLL.Guardar(orden);
            }
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

            //Producto pro = ProductoBLL.Buscar(Convert.ToInt32(ProductoIdTextbox.Text));
            Producto producto = new Producto();
            this.Detalles.Add(

                new OrdenDetalle(
                    id: 0,
                    ordenId: Convert.ToInt32(IdTextbox.Text),
                    productoId:Convert.ToInt32( ProductoIdTextbox.Text),
                    cantidad:Convert.ToInt32(CantidadTextbox.Text),
                    precio: producto.Precio 
                  
                    ));

            CargarGrid();
            ProductoIdTextbox.Clear();
            CantidadTextbox.Clear();
        }
    }
}
