using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab2
{
    public partial class ChartForm : Form
    {
        int[,] matrix;

        public ChartForm(int[,] matrix1)
        {
            this.matrix = matrix1;
            InitializeComponent();
        }
        /// <summary>
        /// При загрузці форми з діаграмою дає їй назву
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartForm_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            AddSeries(matrix, "Matrix");
            chart1.Titles.Add("Percentage of positive elements by rows");
            chart1.ChartAreas[0].AxisX.Title = "Row index";
        }
        /// <summary>
        /// Створює екземпляр класу Series типу Pie,
        /// далі проходиться по матриці і рахує додатні елементи, заносить їх кількість в масив,
        /// далі вираховує відсоток додатніх чисел в рядку і додає їх в діаграму
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="name"></param>
        void AddSeries(int[,] matrix, string name)
        {
            var series = new Series { ChartType = SeriesChartType.Pie, Name = name };
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            int positiveCounter, percentComplete, rowCounter = 0;
            int[] positiveCounterArray = new int[m];
            for (int i = 0; i < m; i++)
            {
                positiveCounter = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > 0) positiveCounter++;
                }
                positiveCounterArray[rowCounter] = positiveCounter;
                rowCounter++;
                
            }
            for(int i = 0; i < positiveCounterArray.GetLength(0); i++)
            {
                percentComplete = (int)(0.5f + ((100f * positiveCounterArray[i]) / n));
                series.Points.AddXY($"Row #{i + 1} is {percentComplete}%", percentComplete);
                
            }
            chart1.Series.Add(series);
            
        }

    }
}
