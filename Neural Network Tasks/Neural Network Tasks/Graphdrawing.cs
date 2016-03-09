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
        static public Chart draw(Chart Cht, Sample[] Y, Sample[] X, int F1, int F2,string str)
        {
            
            for (int g = 0; g < Y.Length; g++)
            {
                Cht.Series[str].Points.AddXY(X[g].features_values[F1, 0], Y[g].features_values[F2, 0]);

           }
            return Cht;
        }
        static public Chart DrawSample(Chart Cht, Sample X, int F1, int F2, string str)
        {     Cht.Series[str].Points.AddXY(X.features_values[F1, 0], X.features_values[F2, 0]);    
            return Cht;
        }
        static public void drawline(string str,ref Chart C,double Bias,double [] W)
        {
            //double x = C.ChartAreas[1].AxisY.Maximum;
            //double min = C.ChartAreas[1].AxisY.Minimum;
            //double x1, y1 = 0, x2 = 0, y2;

            //x1 = (-Bias) / W[0];
            //y2 = (Bias) / W[1];
            //C.Series[str].Points.AddXY(x1, y1);
            //C.Series[str].Points.AddXY(x2, y2);


           
        }
    }
}
