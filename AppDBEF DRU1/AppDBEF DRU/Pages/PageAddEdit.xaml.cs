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
        private Pabotbl pabotbl = new Pabotbl();
        public PageAddEdit(Pabotbl pabot)
        {
            InitializeComponent();

            if (pabot != null)
                pabotbl = pabot;

            CmbDoljnostb.ItemsSource =
                uchebnayaDrugovaEntities.GetContext().Porychenia.ToList();
            CmbDoljnostb.SelectedValuePath = "ID_nomer";
            CmbDoljnostb.DisplayMemberPath = "Doljnostb";
            

            //создаём  контекст
            DataContext = pabotbl;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (pabotbl.ID_shifr == 0)
                uchebnayaDrugovaEntities.GetContext().
                    Pabotbl.Add(pabotbl);
            //добавить в контекст
            try
            {
                uchebnayaDrugovaEntities.GetContext().SaveChanges();
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
//CmbDoljnostb.ItemsSource =
//    lesuser13Entities1.GetContext().Porychenia.Select(x => x.Doljnostb).Distinct().ToList();
//CmbDoljnostb.SelectedValue = "Doljnostb";