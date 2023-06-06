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
    /// Логика взаимодействия для AddGen.xaml
    /// </summary>
    public partial class AddGen : Page
    {
        private Inv _currentInv = new Inv();
        public AddGen(Inv selectedInv)
        {
            if(selectedInv != null)
                _currentInv= selectedInv;

            DataContext = _currentInv;

            InitializeComponent();
        }
        //кнопка сохранения данных, с вводом ошибок при незаполнении полей
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentInv.Name == null)
                errors.AppendLine("Введите название");
            if (_currentInv.Number == null)
                errors.AppendLine("Введите номер");
            if (_currentInv.Percent == null)
                errors.AppendLine("Введите процент амортизации");
            if (_currentInv.Sum == null)
                errors.AppendLine("Введите сумму техники");
            if (_currentInv.Sum_percent == null)
                errors.AppendLine("Введите сумму амортизации");
            if (_currentInv.Office == null)
                errors.AppendLine("Введите кабинет");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentInv.Id==0)
                TexEntities1.GetContext().Invs.Add(_currentInv);

            try
            {
                TexEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
