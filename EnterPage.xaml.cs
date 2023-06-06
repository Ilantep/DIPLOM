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

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {
        public EnterPage()
        {
            InitializeComponent();
        }
        //кнопка очитки полей
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Clear();
            PasswordBox.Clear();
        }
        //кнопка входа, проверка логина и пароля
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(TextBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
            }
            using (var db = new TexEntities1())
            {
                var user = db.Logs
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == TextBox.Text && u.Password == PasswordBox.Password);

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден!");
                    return;
                }
                if (errors.Length == 0)
                {
                    Manager.MainFrame.Navigate(new GenPage());
                }
            }
        }
    }
}
