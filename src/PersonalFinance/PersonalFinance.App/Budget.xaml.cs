using PersonalFinance.App.Data;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace PersonalFinance.App
{
    /// <summary>
    /// Interaction logic for Budget.xaml
    /// </summary>
    public partial class Budget : Page
    {
        public Budget()
        {
            InitializeComponent();

            DataAccess.GetSqlConnection();
            string query = "SELECT * FROM Budgets";
            DataTable data = DataAccess.Get_DataTable(query);
            budgetTable.ItemsSource = data.DefaultView;
        }
       
    }
}
