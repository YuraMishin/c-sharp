using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private SqlConnection con;
    private SqlDataAdapter da;
    private DataTable dt;
    private DataRowView row;

    public MainWindow()
    {
      InitializeComponent();
      Preparing();
    }

    private void Preparing()
    {
      var connectionStringBuilder = new SqlConnectionStringBuilder()
      {
        DataSource = @"(localdb)\MSSQLLocalDB",
        InitialCatalog = "Demo",
        IntegratedSecurity = true,
        Pooling = !false
      };
      var con = new SqlConnection(connectionStringBuilder.ConnectionString);
      dt = new DataTable();
      da = new SqlDataAdapter();

      var sqlSelect = @"
SELECT *
FROM Workers
";
      da.SelectCommand = new SqlCommand(sqlSelect, con);

      var sqlInsert = @"INSERT INTO Workers (Name) VALUES (@Name); SET @Id=@@IDENTITY;";
      da.InsertCommand = new SqlCommand(sqlInsert, con);
      da.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
      da.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 20, "Name");

      var sqlUpdate = @"UPDATE Workers SET Name = @Name WHERE Id = @Id";
      da.UpdateCommand = new SqlCommand(sqlUpdate, con);
      da.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").SourceVersion = DataRowVersion.Original;
      da.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 20, "Name");

      var sqlDelete = @"DELETE FROM Workers WHERE Id = @Id";
      da.DeleteCommand = new SqlCommand(sqlDelete, con);
      da.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");

      da.Fill(dt);
      gridView.DataContext = dt.DefaultView;
    }

    private void AllViewShow(object sender, RoutedEventArgs e)
    {
      new AllView().ShowDialog();
    }

    private void GVCurrentCellChanged(object? sender, EventArgs e)
    {
      if (row == null) return;
      row.EndEdit();
      da.Update(dt);
    }

    private void GVCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
    {
      row = (DataRowView)gridView.SelectedItem;
      row.BeginEdit();
    }

    private void MenuItemAddClick(object sender, RoutedEventArgs e)
    {
      var r = dt.NewRow();
      var add = new AddWindow(r);
      add.ShowDialog();

      if (add.DialogResult.Value)
      {
        dt.Rows.Add(r);
        da.Update(dt);
      }

    }

    private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
    {
      row = (DataRowView)gridView.SelectedItem;
      row.Row.Delete();
      da.Update(dt);
    }
  }
}
