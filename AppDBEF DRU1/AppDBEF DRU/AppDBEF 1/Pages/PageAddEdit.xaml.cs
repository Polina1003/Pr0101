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
    /// Логика взаимодействия для PageAddEdit.xaml
    /// </summary>
    public partial class PageAddEdit : Page
    {
        private Tovarbl tovapbl = new Tovarbl();
        public PageAddEdit()
        {
            InitializeComponent();

            //CmbTovap.ItemsSource =
            //    uchebnayaChepoytevEntities.GetContext().Tovapbl.ToList();
            //CmbTovap.SelectedValuePath = "ID";
            //CmbTovap.DisplayMemberPath = "Название товара";

            CmbPostvshik.ItemsSource =
                lesuser13Entities.GetContext().Postavchiki.ToList();
            CmbPostvshik.SelectedValue = "ID_Поставщика";
            CmbPostvshik.DisplayMemberPath = "Имя_поставщика";

            //создаем контекст

            DataContext = tovapbl;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var namepost=CmbPostvshik.SelectedItem.ToString();

            if (tovapbl.ID == 0)
                lesuser13Entities.GetContext().
                    Tovarbl.Add(tovapbl); //добавить в контекст

            try
            {
                lesuser13Entities.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены");
                ClassFrame.frmObj.Navigate(new PageListStudent());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }
    }
}
