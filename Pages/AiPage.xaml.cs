using OpenCvSharp;
using OpenCvSharp.Face;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Emgu.Util.Platform;


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
            new FaceDetection().RunTest();
        }
    }
    class FaceDetection
    {
        public  void RunTest()
        {
            // Load the cascades
            const string FileName = "D:\\haarcascade_frontalface_alt2.xml";
            const string Files = "D:\\lbpcascade_frontalface.xml";
            var haarCascade = new CascadeClassifier(fileName: FileName);

            var src2 = new Mat("D:\\testPhoto.jpg", ImreadModes.Color);
            var src = new Mat("D:\\test3.jpg", ImreadModes.Color);
            OneReso(src, src2);
          
            // Detect faces
            Mat haarResult = DetectFace(haarCascade,src2);
            Mat haarResult2 = DetectFace(haarCascade,src);
            Debug.WriteLine(SimilarityFace(haarResult, haarResult2));



            Cv2.ImShow("Faces by Haar", haarResult);
            Cv2.ImShow("Faces by Haasr", haarResult2);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cascade"></param>
        /// <returns></returns>
        private Mat DetectFace(CascadeClassifier cascade ,Mat src)
        {
            Mat result;
            
            using (var gray = new Mat())
            {
                result = src.Clone();
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
               

                // Detect faces
                Rect[] faces = cascade.DetectMultiScale(gray, 1.08, 2, HaarDetectionTypes.ScaleImage, new Size(30, 30));


                // Render all detected faces
                foreach (Rect face in faces)
                {

                    var center = new Point
                    {
                        X = (int)(face.X + face.Width * 0.5),
                        Y = (int)(face.Y + face.Height * 0.5)
                    };
                    var axes = new Size
                    {
                        Width = (int)(face.Width * 0.5),
                        Height = (int)(face.Height * 0.5)
                    };
                    Cv2.Ellipse(result, center, axes, 0, 0, 360, new Scalar(255, 0, 255), 4);
                   
                }
            }
            return result;
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
