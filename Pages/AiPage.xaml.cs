
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AlienAccounting.Workers.CvWorkers;


namespace AlienAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для AiPage.xaml
    /// </summary>
    public partial class AiPage : Page
    {
        public AiPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new CvWorker().RunTest();
        }

        private double SimilarityFace(Mat A, Mat B)
        {
                
                FisherFaceRecognize
                if (A.Rows > 0 && A.Rows == B.Rows && A.Cols > 0 && A.Cols == B.Cols)
                {
                    // Calculate the L2 relative error between the 2 images.
                    double errorL2 = Cv2.Norm(A, B, NormTypes.L2);
                    // Convert to a reasonable scale, since L2 error is summed across all pixels of the image.
                    double similarity = errorL2 / (double)(A.Rows * A.Cols);
                    return similarity;
                }
                else
                {
                    //cout << "WARNING: Images have a different size in 'getSimilarity()'." << endl;
                    return 100000000.0;  // Return a bad value
                }

            
        }
        private void OneReso(Mat A, Mat B)
        {
            Cv2.Resize(B, B, new Size(A.Width, A.Height), interpolation: InterpolationFlags.Cubic);
        }
        
    }
}
