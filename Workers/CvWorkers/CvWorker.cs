using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Face;
namespace AlienAccounting.Workers.CvWorkers
{

    class SonOfRecognize : LBPHFaceRecognizer
    {

    }
    public class CvWorker
    {
        private static LBPHFaceRecognizer reco = LBPHFaceRecognizer.Create();
        private static Mat src = new Mat("C:\\Users/ALBATROS/Source/Repos/Artem-Shk/AlienAccounting/images/Jn3rijvly4Y.jpg", ImreadModes.Color);
        private static CascadeClassifier haar_classifier = new CascadeClassifier("D:\\haarcascade_frontalface_alt2.xml");
        public void RunTest()
        {
            // Load the cascades

            //const string Files = "D:\\lbpcascade_frontalface.xml";

            Mat src2 = new Mat("C:\\Users/ALBATROS/Source/Repos/Artem-Shk/AlienAccounting/images/Selfi.jpg", ImreadModes.Color);

            if (src.Size().Width < 3)
            {
                Debug.WriteLine("size is empty");
            }
            else
            {
                OneReso(src, src2);
            }
            Rect[] faces_one = DetectFace(src),
                    faces_two = DetectFace(src2);


            // Detect faces
            Mat haarResult = RenderRectangle(faces_one, src);
            Mat haarResult2 = RenderRectangle(faces_two, src2);

            Debug.WriteLine(SimilarityFace(haarResult, haarResult2));
            TestTrain_RewriteIT();
            Checkrecog();


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
        public static Rect[] DetectFace(Mat src, CascadeClassifier cascade = null)
        {

            cascade = haar_classifier;
            Rect[] faces;

            using (var gray = new Mat())
            {
                src.Clone();
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);


                // Detect faces
                faces = cascade.DetectMultiScale(gray, 1.08, 2, HaarDetectionTypes.ScaleImage, new Size(30, 30));

            }

            return faces;
        }

        public Mat RenderRectangle(Rect[] faces, Mat img)
        {

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
                Cv2.Ellipse(img, center, axes, 0, 0, 360, new Scalar(255, 0, 255), 4);

            }
            return img;
        }

        private double SimilarityFace(Mat A, Mat B)
        {

            //FisherFaceRecognize
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

        // set folder with files
        public void TestTrain_RewriteIT(string path = "D:\\photoForTrain")
        {

            List<Mat> images = new List<Mat>();
            List<string> paths = Directory.GetFiles(path).ToList();
            List<int> id = new List<int>();
            Dictionary<Mat, int> result = new Dictionary<Mat, int>();
            int counter = -1;
            foreach (string p in paths)
            {
                id.Add(counter++);
                images.Add(Cv2.ImRead(p, ImreadModes.Grayscale));
            }
            reco.Train(images, id);

        }
        public void Checkrecog()
        {

            var Grayimage = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            var animal = DetectFace(src);
            reco.Predict(Grayimage, out int label, out double confidence);
            Debug.WriteLine($"{label}   {confidence}");
        }
    }


} 

