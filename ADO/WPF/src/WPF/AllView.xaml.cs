using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WPF
{
  /// <summary>
  /// Логика взаимодействия для AllView.xaml
  /// </summary>
  public partial class AllView : Window
  {
    public AllView()
    {
      InitializeComponent();

      var connectionStringBuilder = new SqlConnectionStringBuilder()
      {
        DataSource = @"(localdb)\MSSQLLocalDB",
        InitialCatalog = "Demo",
        IntegratedSecurity = true,
        Pooling = !false
      };

      var con = new SqlConnection(connectionStringBuilder.ConnectionString);
      var dt = new DataTable();
      var da = new SqlDataAdapter();

      var sqlSelect = @"
SELECT *
FROM Workers
";

      da.SelectCommand = new SqlCommand(sqlSelect, con);
      da.Fill(dt);
      gridAllView.DataContext = dt.DefaultView;
    }
  }
}
