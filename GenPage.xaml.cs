using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для GenPage.xaml
    /// </summary>
    public partial class GenPage : Page
    {
        public GenPage()
        {
            InitializeComponent();
            DGridGen.ItemsSource = TexEntities1.GetContext().Invs.ToList();
        }
        //кнопка редактирования, открытие страницы для редактирования
        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddGen((sender as Button).DataContext as Inv));
        }
        //кнопка добавление техники, открытие страницы для редактирования
        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddGen(null));
        }
        //кнопка удаление выделенной техники, с проверкой и подтверждение от пользователя
        private void Delbtn_Click(object sender, RoutedEventArgs e)
        {
            var InvForRemoving = DGridGen.SelectedItems.Cast<Inv>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {InvForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TexEntities1.GetContext().Invs.RemoveRange(InvForRemoving);
                    TexEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");


                    DGridGen.ItemsSource = TexEntities1.GetContext().Invs.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        //при открытие страницы идет обновление данных
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TexEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridGen.ItemsSource = TexEntities1.GetContext().Invs.ToList();
            }
        }
        //кнопка для создания отчета в EXEL 
        private void Otbtn_Click(object sender, RoutedEventArgs e)
        {
            this.DGridGen.SelectAllCells();
            this.DGridGen.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.DGridGen);
            this.DGridGen.UnselectAllCells();
            String result = Clipboard.GetData(DataFormats.CommaSeparatedValue).ToString();
            try
            {
                StreamWriter sw = new StreamWriter(new FileStream("Отчет.csv", FileMode.OpenOrCreate), Encoding.UTF32);
                sw.WriteLine(result);
                sw.Close();
                Process.Start("Отчет.csv");
            }
            catch(Exception ex)
            {

            }
        }
    }
}
