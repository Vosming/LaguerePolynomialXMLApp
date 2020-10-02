using System;
using System.IO;
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
using OxyPlot;

namespace Zad1Tablicowaniefunkcji
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using System.Collections.Generic;

    using OxyPlot;
    public partial class MainWindow : Window
    {


        //Declaration of the object
        private OxyPlotModel oxyPlotModel;

       
        
        public MainWindow()
        {
            InitializeComponent();
            //In the constructor
            oxyPlotModel = new OxyPlotModel();
            DataContext = oxyPlotModel;
            // This allows you to combine controls with OxyPlotModel classes

            
        }
        




        private void txtDegree_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
