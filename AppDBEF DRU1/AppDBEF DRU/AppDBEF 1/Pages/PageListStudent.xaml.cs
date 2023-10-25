using AppDBEF.Classes;
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

namespace AppDBEF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageListStudent.xaml
    /// </summary>
    public partial class PageListStudent : Page
    {
        public PageListStudent()
        {
            InitializeComponent();

            DtgListStudent.ItemsSource =
                lesuser13Entities.GetContext().Tovarbl.ToList();

             var listDisc = lesuser13Entities.GetContext().Tovarbl.
                 Select(x => x.Название_товара).Distinct().ToList();


           
            CmbDiscipline.ItemsSource = lesuser13Entities.GetContext().
                 Tovarbl.ToList();
            CmbDiscipline.SelectedValue = "ID";
            CmbDiscipline.DisplayMemberPath = "Название_товара";


            
        }

        private void CmbDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             string discipline = CmbDiscipline.SelectedValue.ToString();

             if (discipline == "Все поставщики")
                 DtgListStudent.ItemsSource =
                lesuser13Entities.GetContext().Tovarbl.ToList();
             else
            DtgListStudent.ItemsSource =
                 lesuser13Entities.GetContext().Postavchiki.
                 Where(x=>x.Имя_поставщика ==  discipline).ToList();
            int idDisc = CmbDiscipline.SelectedIndex + 1;
            DtgListStudent.ItemsSource =
                lesuser13Entities.GetContext().Tovarbl.
                Where(x => x.ID == idDisc).ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxtSearch.Text;
            DtgListStudent.ItemsSource =
                lesuser13Entities.GetContext().Tovarbl.
                Where(x=>x.Описание_товара.Contains(search)).ToList();
        }

        private void RbtnAsc_Click(object sender, RoutedEventArgs e)
        {
            //сортировка по возрастанию
            DtgListStudent.ItemsSource =
                lesuser13Entities.GetContext().Tovarbl.
                OrderBy(x => x.Колво_на_складе).ToList();
        }

        private void RbtnDesc_Click(object sender, RoutedEventArgs e)
        {
            //сортировка по убыванию
            DtgListStudent.ItemsSource =
                lesuser13Entities.GetContext().Tovarbl.
                OrderByDescending(x => x.Колво_на_складе).ToList();
        }

       

        private void BtnResults_Click(object sender, RoutedEventArgs e)
        {
            LstResults.Items.Clear();
            //подсчет агрегатных функций

            int count = lesuser13Entities.GetContext().
                Tovarbl.Count();
            
          double averagemark = (double)lesuser13Entities.GetContext().
           Tovarbl.Select(x=>x.Колво_на_складе).Average();

          double minmark = (double)lesuser13Entities.GetContext().
             Tovarbl.Select(x => x.Колво_на_складе).Min();

           double maxmark = (double)lesuser13Entities.GetContext().
              Tovarbl.Select(x => x.Колво_на_складе).Max();

           double summark = (double)lesuser13Entities.GetContext().
               Tovarbl.Select(x => x.Колво_на_складе).Sum();

           LstResults.Items.Add($"количество записей {count}");
           LstResults.Items.Add($"Средний Кол-во на складе {averagemark}");
            LstResults.Items.Add($"Минимальный Кол-во на складе {minmark}");
            LstResults.Items.Add($"Максимальный Кол-во на складе {maxmark}");
            LstResults.Items.Add($"Общая сумма Кол-ва на складе {summark}");

            string minMarkFIO = lesuser13Entities.GetContext().
                Tovarbl.First(x=>x.Колво_на_складе == minmark).Название_товара.ToString();
            MessageBox.Show(minMarkFIO);


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.
                Navigate(new PageAddEdit());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление нескольких строк
            var studentsForRemoving = 
                DtgListStudent.SelectedItems.
                Cast<Tovarbl>().ToList();

            if (MessageBox.Show
                ($"Удалить {studentsForRemoving.Count()} " +
                $"товары?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    lesuser13Entities.GetContext().
                        Tovarbl.RemoveRange(studentsForRemoving);

                    lesuser13Entities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены");
                    DtgListStudent.ItemsSource =
                        lesuser13Entities.GetContext().
                        Tovarbl.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

        }
    }
}
