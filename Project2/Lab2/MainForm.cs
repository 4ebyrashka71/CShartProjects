/*************************************************************************************************************
 *  Виділити кольором фон тих стовпців цілочислової матриці, усі елементи яких є попарно взаємно
 *  простими. Зобразити кругову діаграму, сектори якої відповідають рядкам матриці, а значення рівні
 *  відсотку, який складають додатні елементи серед усіх елементів рядка.
 **************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Створення лісту для рядків, відкриття файлу з допомогою файлових діалогів
        /// Далі зчитування рядків і стовбців з файлу, при виявлені не валідних даних зявляється повідомлення
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private (List<string[]>, bool) GetRows(string fileName = "")
        {
            var rows = new List<string[]>();
            bool isValidData = false;
            //openFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.InitialDirectory = @"c:\Users\krasn\OneDrive\Рабочий стол";
            openFileDialog.FileName = fileName;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                isValidData = true;
                using (var reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var row = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (rows.Count > 0 && row.Length != rows[0].Length)
                        {
                            MessageBox.Show($"Invalid data in {openFileDialog.FileName}, line {rows.Count + 1}", "Error");
                            isValidData = false;
                            break;
                        }
                        rows.Add(row);
                    }
                }
            }
            return (rows, isValidData);
        }
        /// <summary>
        /// Заповнюється таблиця з елементами матриці
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="grid"></param>
        private void FillGrid(List<string[]> rows, DataGridView grid)
        {
            grid.Rows.Clear();
            grid.ColumnCount = rows[0].Length;
            foreach (var row in rows)
            {
                grid.Rows.Add(row);
            }
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        /// <summary>
        /// При нажатті на клавішу загрузки зявляється повідомлення і відкриття файлу та зчитування даних
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select file with matrix", "Information", MessageBoxButtons.OK);
            var (rows1, isValid1) = GetRows("Test.txt");
            if (isValid1 && rows1.Count > 0)
            {
                FillGrid(rows1, matrix1Grid);
            }
            task1Button.Enabled = chartButton.Enabled = true;
            saveFirstButton.Enabled = true;
        }
        /// <summary>
        /// Створюється масив і заповнюється даними
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private bool TryParseGrid(DataGridView grid, out int[,] matrix)
        {
            matrix = new int[grid.RowCount, grid.ColumnCount];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    try
                    {
                        matrix[i, j] = Convert.ToInt32(grid[j, i].Value);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Invalid value in cell ({i}, {j})");
                        grid[j, i].Selected = true;
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Метод який шукає найбільше спільне кратне (НСД)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int GCD(int a, int b)
        {
            if (a < 0) a *= -1;
            if (b < 0) b *= -1;
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
        /// <summary>
        /// Зчитується довжина рядків і стовбців, а далі вичисляється які стобці є попарно взаємно простими
        /// Виділяє попарно взаємно прості стовбці зеленим кольором
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void task1Button_Click(object sender, EventArgs e)
        {
            if (TryParseGrid(matrix1Grid, out var matrix1))
            {
                var m = matrix1.GetLength(0);
                var n = matrix1.GetLength(1);
                for (int j = 0; j < n; j++)
                {
                    var selectionRequired = true;
                    for (int i = 0; i < m; i++)
                    {
                        if(matrix1[i, j] == 1 || matrix1[i, j] == -1)
                        {
                            selectionRequired = false;
                            break;
                        }
                        for (int k = i+1; k < m; k++)
                        {
                            if (GCD(matrix1[i, j], matrix1[k, j]) != 1)
                            {
                                selectionRequired = false;
                                break;
                            }
                        }
                        if (!selectionRequired) break;
                    }
                    if (selectionRequired)
                        matrix1Grid.Columns[j].DefaultCellStyle.BackColor = Color.Chartreuse;
                    else
                        matrix1Grid.Columns[j].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        /// <summary>
        /// При нажатті на кнопку викликається метод збереження матриці
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFirstButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
                SaveGrid(matrix1Grid);
        }

        /// <summary>
        /// Викликає діалогове вікно для збереження файлу
        /// </summary>
        /// <param name="grid"></param>
        private void SaveGrid(DataGridView grid)
        {
            //saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.InitialDirectory = @"c:\Users\krasn\OneDrive\Рабочий стол";
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            writer.Write(cell.Value.ToString() + "\t");
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        /// <summary>
        /// При нажатті на клавішу "Show Chart" викликає нову форму з діаграмою і передає туди матрицю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartButton_Click(object sender, EventArgs e)
        {
            if (TryParseGrid(matrix1Grid, out var matrix1))
            {
                var chartForm = new ChartForm(matrix1);
                chartForm.Show();
            }
        }
    }
}
