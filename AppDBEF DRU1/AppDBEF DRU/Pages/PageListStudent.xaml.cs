using AppDBEF.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace AppDBEF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageListStudent.xaml
    /// </summary>
    public partial class PageListStudent : Page
    {
        public PageListStudent()
        {
            //InitializeComponent();
            //DtgListStudent.ItemsSource =
            //    uchebnayaDrugovaEntities.GetContext().Pabotbl.ToList();
            // var listDisc = uchebnayaDrugovaEntities.GetContext().Pabotbl.
            //     Select(x => x.Nazvanie).Distinct().ToList();
            //CmbDiscipline.ItemsSource = uchebnayaDrugovaEntities.GetContext().
            //     Porychenia.Select(x => x.Trudoemkostb).Distinct().ToList();

            InitializeComponent();

            DtgListStudent.ItemsSource =
                uchebnayaDrugovaEntities.GetContext().Pabotbl.ToList();

            var listDisc = uchebnayaDrugovaEntities.GetContext().Pabotbl.
                Select(x => x.Nazvanie).Distinct().ToList();



            CmbDiscipline.ItemsSource = uchebnayaDrugovaEntities.GetContext().
                 Pabotbl.ToList();
            CmbDiscipline.SelectedValue = "ID_shifr";
            CmbDiscipline.DisplayMemberPath = "Nazvanie";
        }

        private void CmbDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string discipline = CmbDiscipline.SelectedValue.ToString();

            if (discipline == "Все должности")
                DtgListStudent.ItemsSource =
               uchebnayaDrugovaEntities.GetContext().Pabotbl.ToList();
            else
                DtgListStudent.ItemsSource =
                     uchebnayaDrugovaEntities.GetContext().Porychenia.
                     Where(x => x.Doljnostb == discipline).ToList();
            int idDisc = CmbDiscipline.SelectedIndex + 1;
            DtgListStudent.ItemsSource =
                uchebnayaDrugovaEntities.GetContext().Pabotbl.
                Where(x => x.ID_shifr == idDisc).ToList();

            //var trud = (int)CmbDiscipline.SelectedValue;

            //DtgListStudent.ItemsSource = uchebnayaDrugovaEntities.GetContext().Porychenia.
            //    Where(x => x.Trudoemkostb == trud).ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxtSearch.Text;
            DtgListStudent.ItemsSource =
                uchebnayaDrugovaEntities.GetContext().Pabotbl.
                Where(x => x.Nazvanie.Contains(search)).ToList();
        }

        private void RbtnAsc_Click(object sender, RoutedEventArgs e)
        {
            //сортировка по возрастанию
            DtgListStudent.ItemsSource =
                 uchebnayaDrugovaEntities.GetContext().Pabotbl.
                 OrderBy(x => x.Data_okonchania).ToList();
        }

        private void RbtnDesc_Click(object sender, RoutedEventArgs e)
        {
            //сортировка по убыванию
            DtgListStudent.ItemsSource =
                uchebnayaDrugovaEntities.GetContext().Pabotbl.
                OrderByDescending(x => x.Data_okonchania).ToList();
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageAddEdit(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление нескольких строк
            var studentsForRemoving = 
                DtgListStudent.SelectedItems.
                Cast<Pabotbl>().ToList();

            if (MessageBox.Show
                ($"Удалить {studentsForRemoving.Count()} " +
                $"договора?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    uchebnayaDrugovaEntities.GetContext().
                        Pabotbl.RemoveRange(studentsForRemoving);

                    uchebnayaDrugovaEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены");
                    DtgListStudent.ItemsSource =
                        uchebnayaDrugovaEntities.GetContext().
                        Pabotbl.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(
                new Pages.PageAddEdit((sender as Button).DataContext as Pabotbl));
        }

        private void BtnPerLV_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageLV());
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet ws = app.Worksheets.Item[1];

            int indexRows = 1;

            ws.Cells[1][indexRows] = "Шифр работы";
            ws.Cells[2][indexRows] = "Название";
            ws.Cells[3][indexRows] = "ФИО сотрудника";
            ws.Cells[4][indexRows] = "Дата выдачи поручения на работу";
            ws.Cells[5][indexRows] = "Дата окончания работы";
            ws.Cells[6][indexRows] = "Должность";
            ws.Cells[7][indexRows] = "Трудоёмкость";

            var listReps = uchebnayaDrugovaEntities.GetContext().Pabotbl.ToList();
            foreach (var reps in listReps)
            {
                indexRows++;
                ws.Cells[1][indexRows] = indexRows - 1;
                ws.Cells[2][indexRows] = reps.Nazvanie;
                ws.Cells[3][indexRows] = reps.FIO;
                ws.Cells[4][indexRows] = reps.Data_vbIdachi;
                ws.Cells[5][indexRows] = reps.Data_okonchania;
                ws.Cells[6][indexRows] = reps.Porychenia.Doljnostb;
                ws.Cells[7][indexRows] = reps.Porychenia.Trudoemkostb;
            }

            app.Visible = true;

        }

        private void BtnShablon_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();

            Excel.Workbook wb = app.Workbooks.Open($"" + $"{Directory.GetCurrentDirectory()}" + $"\\Лист2.xlsx");
            Excel.Worksheet worksheet = (Excel.Worksheet)wb.Worksheets[1];

            int indexRows = 2;
            worksheet.Cells[1][indexRows] = "Шифр работы";
            worksheet.Cells[2][indexRows] = "Название";
            worksheet.Cells[3][indexRows] = "ФИО сотрудника";
            worksheet.Cells[4][indexRows] = "Дата выдачи поручения на работу";
            worksheet.Cells[5][indexRows] = "Дата окончания работы";
            worksheet.Cells[6][indexRows] = "Должность";
            worksheet.Cells[7][indexRows] = "Трудоёмкость";

            var listReps = uchebnayaDrugovaEntities.GetContext().Pabotbl.ToList();

            foreach (var reps in listReps)
            {
                indexRows++;
                worksheet.Cells[1][indexRows] = indexRows - 2;
                worksheet.Cells[2][indexRows] = reps.Nazvanie;
                worksheet.Cells[3][indexRows] = reps.FIO;
                worksheet.Cells[4][indexRows] = reps.Data_vbIdachi;
                worksheet.Cells[5][indexRows] = reps.Data_okonchania;
                worksheet.Cells[6][indexRows] = reps.Porychenia.Doljnostb;
                worksheet.Cells[7][indexRows] = reps.Porychenia.Trudoemkostb;
            }
            app.Visible = true;

        }

        private void BtnWord_Click(object sender, RoutedEventArgs e)
        {
            var app = new Word.Application();
            Word.Document doc = app.Documents.Add();
            var listReps = uchebnayaDrugovaEntities.GetContext().Pabotbl.ToList();

            foreach (var reps in listReps)
            {
                Word.Paragraph parHazv = doc.Paragraphs.Add();
                Word.Range rangeHazv = parHazv.Range;
                rangeHazv.Text = $"Название: {reps.Nazvanie}";
                rangeHazv.InsertParagraphAfter();

                Word.Paragraph parFIO = doc.Paragraphs.Add();
                Word.Range rangeFIO = parFIO.Range;
                rangeFIO.Text = $"ФИО сотрудника: {reps.FIO}";
                rangeFIO.InsertParagraphAfter();

                Word.Paragraph parVbldch = doc.Paragraphs.Add();
                Word.Range rangeVbldch = parVbldch.Range;
                rangeVbldch.Text = $"Дата выдачи поручения на работу: {reps.Data_vbIdachi}";
                rangeVbldch.InsertParagraphAfter();

                Word.Paragraph parOconch = doc.Paragraphs.Add();
                Word.Range rangeOconch = parOconch.Range;
                rangeOconch.Text = $"Дата окончания работы: {reps.Data_okonchania}";
                rangeOconch.InsertParagraphAfter();

                Word.Paragraph parDolj = doc.Paragraphs.Add();
                Word.Range rangeDolj = parDolj.Range;
                rangeDolj.Text = $"Должность: {reps.Porychenia.Doljnostb}";
                rangeDolj.InsertParagraphAfter();

                Word.Paragraph parTrud = doc.Paragraphs.Add();
                Word.Range rangeTrud = parTrud.Range;
                rangeTrud.Text = $"Трудоёмкость: {reps.Porychenia.Trudoemkostb}";
                rangeTrud.InsertParagraphAfter();

                if (reps != listReps.LastOrDefault())
                {
                    doc.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                }
            }

            app.Visible = true;

        }
    }
}