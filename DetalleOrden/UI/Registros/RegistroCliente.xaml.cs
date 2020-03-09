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

namespace DetalleOrden.UI
{
    /// <summary>
    /// Interaction logic for RegistroCliente.xaml
    /// </summary>
    public partial class RegistroCliente : Window
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextbox.Text = "0";
            NombreTextbox.Text = string.Empty; 
            DireccionTextbox.Text = string.Empty;
            
        }

        private Cliente LlenaClase()
        {
            Cliente cliente = new Cliente();
            cliente.ClienteId = Convert.ToInt32(IdTextbox.Text);
            cliente.Direccion = string.Empty;
            cliente.Nombre = string.Empty;
            
            return cliente;

        }

        private void LlenaCampo(Cliente cliente)
        {

            IdTextbox.Text = Convert.ToString(cliente.ClienteId);
            DireccionTextbox.Text = string.Empty;
            NombreTextbox.Text = string.Empty;

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Cliente cliente = ClienteBLL.Buscar(Convert.ToInt32(IdTextbox.Text));
            return (cliente != null);
        }

        private void Button_Nuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        

        private bool validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(DireccionTextbox.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
                DireccionTextbox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(NombreTextbox.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
                NombreTextbox.Focus();
                paso = false;
            }
                       
            return paso;

        }

        

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            Cliente cliente;
            bool paso = false;

            cliente = LlenaClase();

            if (IdTextbox.Text == "0")
                paso = ClienteBLL.Guardar(cliente);

            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("Personas No Existe!!");
                }
                MessageBox.Show("Persona Modificada!!");
                paso = ClienteBLL.Modificar(cliente);
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
            Cliente cliente = new Cliente();

            cliente = ClienteBLL.Buscar(id);

            if (cliente != null)
            {
                MessageBox.Show("Persona Encontrada!!");
                LlenaCampo(cliente);
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


            if (ClienteBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!");
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar!!");
            }
        }
    }
}
