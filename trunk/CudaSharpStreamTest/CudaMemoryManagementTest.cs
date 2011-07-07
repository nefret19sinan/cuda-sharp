using CudaSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CudaSharpStreamTest
{
    
    
    /// <summary>
    ///This is a test class for CudaMemoryManagementTest and is intended
    ///to contain all CudaMemoryManagementTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CudaMemoryManagementTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void CopyVectorTest()
        {
            using (CudaSharpStream str = new CudaSharpStream())
            {
                CudaMemoryManagement target = str.MemoryManagement;
                using (CudaDeviceVector deviceVector = new CudaDeviceVector(5))
                {
                    using (CudaHostVector hostVector = new CudaHostVector(5))
                    {
                        hostVector[2] = 3;
                        using (CudaHostVector hostVector2 = new CudaHostVector(5))
                        {
                            target.Copy(hostVector, deviceVector);
                            target.Copy(deviceVector, hostVector2);
                            str.Synchronize();
                            Assert.AreEqual(3, hostVector2[2]);
                        }
                    }
                }
            }
        }
    }
}
