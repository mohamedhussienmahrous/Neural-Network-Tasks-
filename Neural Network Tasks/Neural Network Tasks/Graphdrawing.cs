using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Neural_Network_Tasks
{
    static class Graphdrawing
    {
        static public Chart chart;
        static public Chart draw(Chart Cht, double[,] Y, double[,] X)
        {
            chart = Cht;
            //chart.Series.;
            for (int g = 0; g < Y.Length; g++)
            {
                chart.Series["Series1"].Points.AddXY(X[g,0], Y[g,0]);
            }

            chart.Series["Series1"].ChartType = SeriesChartType.Point;
            chart.Series["Series1"].Color = Color.Red;


            return chart;
        }

    }
}
