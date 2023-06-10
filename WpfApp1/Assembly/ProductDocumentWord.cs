using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WpfApp1.Assembly;
using Word = Microsoft.Office.Interop.Word;
namespace WpfApp1
{
    class ProductDocumentWord
    {
        private FileInfo _fileInfo;

        public ProductDocumentWord(string path)
        {
            if (File.Exists(path))
            {
                _fileInfo = new FileInfo(path);
                Console.WriteLine("OK1");
            }
            else
            {
                throw new ArgumentException("File not found");
            }
        }

        internal void Process(ObservableCollection<Product> products)
        {
            string originalFile = @"C:\Users\master\source\repos\WpfApp1\WpfApp1\Assembly\ШаблонКомерчПредлложение.docx";
            string newFile = _fileInfo.FullName;
            File.Copy(originalFile, newFile, true);




            var app = new Word.Application();
            Object file = _fileInfo.FullName;

            var wordDoc = app.Documents.Open(file);


            Word.Range range = wordDoc.Content; 
            range.Collapse(WdCollapseDirection.wdCollapseEnd);
            Word.Table wordTable = wordDoc.Tables.Add(range, products.Count + 2, 4);

            wordTable.Cell(1, 1).Range.Text = "Наименование";
            wordTable.Cell(1, 2).Range.Text = "Кол-во";
            wordTable.Cell(1, 3).Range.Text = "Цена за ед.";
            wordTable.Cell(1, 4).Range.Text = "Сумма, руб";

            for (int i = 1; i <= 4; i++)
            {
                wordTable.Cell(1, i).Range.Font.Bold = 1;
                wordTable.Cell(1, i).Range.Font.Bold = 1;
                wordTable.Cell(1, i).Range.Font.Name = "Times New Roman";
            }


            for (int i = 0; i < products.Count; i++)
            {

                wordTable.Cell(2 + i, 1).Range.Text = products[i].Name;
                wordTable.Cell(2 + i, 2).Range.Text = products[i].Count.ToString();
                wordTable.Cell(2 + i, 3).Range.Text = products[i].PriceUnit.ToString();
                wordTable.Cell(2 + i, 4).Range.Text = products[i].TotalPrice.ToString();

                wordTable.Cell(2 + i, 1).Range.Font.Name = "Times New Roman";
                wordTable.Cell(2 + i, 2).Range.Font.Name = "Times New Roman";
                wordTable.Cell(2 + i, 3).Range.Font.Name = "Times New Roman";
                wordTable.Cell(2 + i, 4).Range.Font.Name = "Times New Roman";
            }


            wordTable.Cell(products.Count + 2, 1).Merge(wordTable.Cell(products.Count + 2, 3));
            wordTable.Cell(products.Count + 2, 1).Range.Text = "ИТОГО";

            ulong sum = 0;
            foreach (var p in products)            
                sum += (ulong)p.TotalPrice;
            

            wordTable.Cell(products.Count + 2, 2).Range.Text = sum.ToString();


            wordTable.Borders.Enable = 1;

            app.ActiveDocument.Save();
            app.ActiveDocument.Close();
            app.Quit();

        }
    }
}
