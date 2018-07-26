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

namespace _00.InversionTheFlowOfProgram
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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var firstName = FirstName.Text;
            var lastName = LastName.Text;
            SaveToDB(firstName, lastName);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
        }

        private void SaveToDB(string firstName, string lastName)
        {
            //在這裡需要將輸入的姓、名，寫入到資料庫內
            Message.Text = $"{lastName} {firstName} 已經寫入到資料庫內了";
        }
    }
}
