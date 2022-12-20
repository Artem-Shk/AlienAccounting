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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlienAccounting.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для loadingElem.xaml
    /// </summary>
    public partial class loadingElem : UserControl
    {   
        public loadingElem()
        {
            InitializeComponent();
            Storyboard myStoryBoard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(30)),
                From = 0,
                To = 255,
                AutoReverse = true
            };


            myStoryBoard.Children.Add(doubleAnimation);
            Storyboard.SetTargetName(doubleAnimation, this.lightPolygon.Name);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Polygon.FillProperty));
            




        }
        void polygon()
        {

        }
    }
}
