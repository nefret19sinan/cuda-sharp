using CudaSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CudaSharpStreamTest
{
    
    
    /// <summary>
    ///This is a test class for CudaAlgebraTest and is intended
    ///to contain all CudaAlgebraTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CudaAlgebraTest
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
        public void ScalarMultiplicationTest()
        {
            using (CudaSharpStream stream = new CudaSharpStream())
            {
                CudaAlgebra target = stream.Algebra;
                using (CudaHostVector hostVector = new CudaHostVector(50000))
                {
                    using (CudaDeviceVector deviceVector = new CudaDeviceVector(50000))
                    {
                        using (CudaHostScalar hostScalar = new CudaHostScalar(3))
                        {
                            hostVector[2] = 3;

                            stream.MemoryManagement.Copy(hostVector, deviceVector);
                            target.ScalarMultiplication(deviceVector, hostScalar);
                            stream.MemoryManagement.Copy(deviceVector, hostVector);
                            stream.Synchronize();

                            Assert.AreEqual(9, hostVector[2]);
                        }
                    }
                }
            }
        }
    }
}
