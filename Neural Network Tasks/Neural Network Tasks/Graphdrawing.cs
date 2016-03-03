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
        static public Chart draw(Chart Cht, Sample[] Y, Sample[] X, int F1, int F2)
        {
            chart = Cht;
            for (int g = 0; g < Y.Length; g++)
            {
                chart.Series["Series1"].Points.AddXY(X[g].features_values[F1, 0], Y[g].features_values[F2, 0]);
           }
            return chart;
        }

    }
}
