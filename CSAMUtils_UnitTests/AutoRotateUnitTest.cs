using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSAMUtils;
using System.IO;
using System.Collections.Generic;

namespace CSAMUtils_UnitTests
{
    [TestClass]
    public class AutoRotateUnitTest
    {
        [TestInitialize]
        public void Initialize()
        {
            // Put init stuff here. 


        }

        [TestMethod]
        public void RotateTestImages()
        {

            string filePath = @"..\..\RawPanelImages\";
            string outputFilePath = @"..\..\AutoRotatedImages\";

            DirectoryInfo d = new DirectoryInfo(filePath);

            Assert.IsTrue(d.GetFiles("*.jpg").Length > 5, "There are not more than 5 files to test against.");
            Assert.IsFalse(d.GetFiles("*.jpg").Length < 5, "There are more than 5 files to test against.");


            List<Double> elapsedTimes = new List<double>();
            foreach (var file in d.GetFiles("*.jpg"))
            {
                double mSecElapsedFirstRotation = 0;
                string outputFilename = string.Format("Rotated_{0}_{1}", DateTime.Now.ToString("yyyyMMdd_hhmmss"), file.Name);
                double? rotation = AutoRotate.AutoRotateImage(filePath, file.Name, false, null, null, outputFilePath, outputFilename, out mSecElapsedFirstRotation);

                Assert.IsNotNull(rotation);

                double mSecElapsedSecondRotation = 0;
                double? secondRotation = AutoRotate.GetRotationAngle(outputFilePath, outputFilename, false, null, null, out mSecElapsedSecondRotation);
          

                Assert.IsTrue(Math.Abs((double)secondRotation) < 1, "Second rotation > 1 degrees for " + file.Name);

            }



        }
    }
}
