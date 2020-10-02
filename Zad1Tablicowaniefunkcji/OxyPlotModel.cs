using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.IO;

namespace Zad1Tablicowaniefunkcji
{
    using System;

    using OxyPlot;
    using OxyPlot.Series;
    using Prism.Mvvm;
    using Prism.Commands;
    using System.Text;
    using MathNet.Numerics.Integration;

    public class OxyPlotModel : BindableBase
    {
        const int steps = 1000000;
        const double min = 0;
        const double max = 100;
        private OxyPlot.PlotModel plotModel;
        private int degree;
        private int alpha = 0;
        private string polmes;
        private double ortho;
        private int firstDegree;
        private int secondDegree;
        public int Degree
        {
            get
            {
                return degree;
            }
            set 
            {
                SetProperty(ref degree, value); 
            }
        }

        public int Alpha
        {
            get
            {
                return alpha;
            }

            set 
            {
                SetProperty(ref alpha, value);
            }

        }
        public double Orthogonal
        {
            get
            {
                return ortho;
            }
            set
            {
                SetProperty(ref ortho, value);
            }
        }
        
        public int FirstDegree
        {
            get
            {
                return firstDegree;
            }
            set
            {
                SetProperty(ref firstDegree, value);
            }
        }
        public int SecondDegree
        {
            get
            {
                return secondDegree;
            }
            set
            {
                SetProperty(ref secondDegree, value);
            }
        }


        public OxyPlotModel()
        {
            PlotModel = new PlotModel();
            GenerateChartCommand = new DelegateCommand(GenerateChart);
            GeneratePromptCommand = new DelegateCommand(GeneratePrompt);
            GenerateOrthogonalityCommand = new DelegateCommand(GenerateOrthogonality);
            GenerateOrthogonalityCommand2 = new DelegateCommand(GenerateOrthogonality2);

            GenerateSaveFileCommand = new DelegateCommand(GenerateSaveFile);
        }

       
        private void GeneratePrompt()
        {
            var lg = new Laguerre(degree);
            MessageBox.Show(lg.Polynomial.ToString());
            Polmes = lg.Polynomial.ToString();
        }
        //polmes polynomial message, Polynomial in Textbox
        public string Polmes
        {
            get
            {
                return polmes;
            }
            set
            {
                SetProperty(ref polmes, value);
            }
        }
        private void GenerateChart()
        {
            PlotModel.Series.Clear();
            var lg = new Laguerre(Degree);
            //var lg1 = new Laguerre(FirstDegree);
            //var lg2 = new Laguerre(SecondDegree);
            //AddChart(lg.Polynomial);

            alpha = 0;

            //PlotModel.Series.Add(new FunctionSeries(x=> lg1.Polynomial.FunctionValueInPoint(x)* lg2.Polynomial.FunctionValueInPoint(x), min,max,steps));
            //PlotModel.Series.Add(new FunctionSeries(x => lg1.Polynomial.FunctionValueInPoint(x) * lg2.Polynomial.FunctionValueInPoint(x)*Math.Pow(x,alpha)*Math.Exp(-x), min, max, steps));
            PlotModel.Series.Add(new FunctionSeries(x => alglib.laguerrecalculate(degree,x), min, max, steps));
            PlotModel.InvalidatePlot(true);

          
        }

        public DelegateCommand GeneratePromptCommand { get; private set; }
        public DelegateCommand GenerateChartCommand { get; private set; }
        public DelegateCommand GenerateOrthogonalityCommand { get; private set; }
        public DelegateCommand GenerateOrthogonalityCommand2 { get; private set; }
        public DelegateCommand GenerateSaveFileCommand { get; private set; }




        public OxyPlot.PlotModel PlotModel
        {
            get
            {
                return plotModel;
            }
            set
            {
                SetProperty(ref plotModel, value);
            }
        }

        private void SetUpLegend()
        {
            plotModel.LegendTitle = "Legenda";
            plotModel.LegendOrientation = OxyPlot.LegendOrientation.Horizontal;

            //Horizontal orientation
            plotModel.LegendPlacement = OxyPlot.LegendPlacement.Outside; //In addition to the chart plot
            plotModel.LegendPosition = OxyPlot.LegendPosition.TopRight; //Position: up, right
            plotModel.LegendBackground = OxyPlot.OxyColor.FromAColor(200, OxyPlot.OxyColors.White);//White background
            plotModel.LegendBorder = OxyPlot.OxyColors.Black; //Window frame black
        }
        private void GenerateOrthogonality()
        {
            double a=0.01;
            double b=10e4;
            var lg = new Laguerre(FirstDegree);
            var lg2 = new Laguerre(SecondDegree);
            double dx = (b-a) / (steps-1);
            double x;
            double integral=0.0;
            alpha = 0;
            double fx1;
            if (alpha != 0) integral = NewtonCotesTrapeziumRule.IntegrateTwoPoint(z => (lg.Polynomial.FunctionValueInPoint(z) * lg2.Polynomial.FunctionValueInPoint(z) *Math.Pow(z,-alpha)*Math.Exp(-z)), 0.0, 100);
            else
            {

                for (int i = 0; i < steps; i++)
                {
                    //x = Convert.ToDouble(i);
                    x = Convert.ToDouble(i) * dx + a;
                    fx1 = lg.Polynomial.FunctionValueInPoint(x) * lg2.Polynomial.FunctionValueInPoint(x) * (Math.Pow(x, alpha) * Math.Exp(-x));
                    //x += dx;
                    //double fx2 = lg.Polynomial.FunctionValueInPoint(x) * lg2.Polynomial.FunctionValueInPoint(x) * (Math.Pow(x, alpha) * Math.Exp(-x));
                    //integral += 0.5 * dx * (fx1 + fx2);
                    integral += fx1 * dx;
                }
            }

            Orthogonal = integral;

        }
        private void GenerateOrthogonality2()
        {
            double a = 0;
            double b = 10e10;
            double dx = (b - a) / steps;
            double x;
            double integral = 0.0;
            alpha = 0;
            for (int i = 0; i < steps; i++)
            {
                x = Convert.ToDouble(i);
                x = x * dx + a;
                double fx1 = alglib.laguerrecalculate(FirstDegree, x)* alglib.laguerrecalculate(SecondDegree, x) * (Math.Pow(x, alpha) * Math.Exp(-x));
                x += dx;
                double fx2 = alglib.laguerrecalculate(FirstDegree, x)* alglib.laguerrecalculate(SecondDegree, x) * (Math.Pow(x, alpha) * Math.Exp(-x));
                integral += 0.5 * dx * (fx1 + fx2);
            }
            double adaptive = NewtonCotesTrapeziumRule.IntegrateTwoPoint(z => (alglib.laguerrecalculate(degree, z) * alglib.laguerrecalculate(degree , z) * Math.Exp(-z)), 0.0, 10e10);
            //Orthogonal = integral.ToString();

        }
        private void GenerateSaveFile()
        {
            //here please enter correct path of file you want to generate
            var lg = new Laguerre(Degree);
            string path = $@"C:\Users\Vosming\source\repos\Zad1Tablicowaniefunkcji\Ortho.txt";
            //using (FileStream fs = File.Create(path))
            //{
            //    byte[] info = new UTF8Encoding(true).GetBytes("This is some testing text in the file.");
            //    fs.Write(info, 0, info.Length);
            //}
            string[] lines = new string[1];
            lines[0] = Convert.ToString(Orthogonal);
            //string[] lines = new string[steps + 1];
            //lines[0] = $"x;y_myfunction;y_fromLibrary";
            //var dx = (max - min) / steps;
            //var x = min;
            //double y1 = 0;
            //double y2 = 0;
            //for(int i=1;i<steps+1;i++)
            //{
            //    y1 = lg.Polynomial.FunctionValueInPoint(x);
            //    y2 = alglib.laguerrecalculate(degree, x);
            //    lines[i] = $"{x};{y1};{y2}";
            //    x += dx; 


            //}
            System.IO.File.WriteAllLines(path,lines);

        }

    }
}
