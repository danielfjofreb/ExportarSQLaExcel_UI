using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using OfficeOpenXml;

namespace ExportarSQLaExcel_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Conexion conexion;
        string connectionString;
        string query = "";
        string excelFilePath;
        string NombreHoja;
        string usuario;
        string contraseña;
        string servidor;
        string db;
        string Select;
        string From;
        string Where;
        public MainWindow()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Declaracion de variables
            conexion = new Conexion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Select != "" && From != "" && !servidor.Equals("") && !db.Equals("") && !usuario.Equals("") && !contraseña.Equals(""))
            {
                query = "SELECT " + Select + " FROM " + From + " WHERE " + Where;
                connectionString = "Data Source=" + servidor + ";Initial Catalog=" + db + ";User ID=" + usuario + ";Password=" + contraseña + ";";

            }
        }

        private void txtWhere_TextChanged(object sender, TextChangedEventArgs e)
        {
            Where = txtWhere.Text.Trim();
        }

        private void txtFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            From = txtFrom.Text.Trim();
        }

        private void txtSelect_TextChanged(object sender, TextChangedEventArgs e)
        {
            Select = txtSelect.Text.Trim();
        }


        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            usuario = txtUsuario.Text.Trim();
        }

        private void txtDB_TextChanged(object sender, TextChangedEventArgs e)
        {
            db = txtDB.Text.Trim();
        }

        private void txtServidor_TextChanged(object sender, TextChangedEventArgs e)
        {
            servidor = txtServidor.Text.Trim();
        }

        private void txtContraseña_PasswordChanged(object sender, RoutedEventArgs e)
        {
            contraseña = txtContraseña.Password;
        }

        private void txtSelect_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSelect.Text = txtSelect.Text.Trim();
            Select = txtSelect.Text.Trim(); 
        }

        private void txtFrom_LostFocus(object sender, RoutedEventArgs e)
        {
            txtFrom.Text = txtFrom.Text.Trim();
            From = txtFrom.Text.Trim();
        }

        private void txtWhere_LostFocus(object sender, RoutedEventArgs e)
        {
            txtWhere.Text = txtWhere.Text.Trim();
            Where = txtWhere.Text.Trim();
        }

        private void txtUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = txtUsuario.Text.Trim();
            usuario = txtUsuario.Text.Trim();
        }

        private void txtDB_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDB.Text = txtDB.Text.Trim();
            db = txtDB.Text.Trim();
        }

        private void txtServidor_LostFocus(object sender, RoutedEventArgs e)
        {
            txtServidor.Text = txtServidor.Text.Trim();
            servidor = txtServidor.Text.Trim();
        }
    }
}