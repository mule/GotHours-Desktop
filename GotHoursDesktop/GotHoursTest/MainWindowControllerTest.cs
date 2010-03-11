using GotHoursDesktop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GotHoursDAL.Entities;
using System;


namespace GotHoursTest
{
    
    
    /// <summary>
    ///This is a test class for MainWindowControllerTest and is intended
    ///to contain all MainWindowControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainWindowControllerTest
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


        /// <summary>
        ///A test for LogTime
        ///</summary>
        [TestMethod()]
        public void LogTimeTest()
        {
            MainWindowController target = new MainWindowController(); // TODO: Initialize to an appropriate value
            string pTaskName = string.Empty; // TODO: Initialize to an appropriate value
            DateTime pStartTime = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime pEndTime = new DateTime(); // TODO: Initialize to an appropriate value
            target.LogTime(pTaskName, pStartTime, pEndTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for loadUser
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GotHoursDesktop.exe")]
        public void loadUserTest()
        {
            MainWindowController_Accessor target = new MainWindowController_Accessor(); // TODO: Initialize to an appropriate value

            target.loadUser();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for loadTasks
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GotHoursDesktop.exe")]
        public void loadTasksTest()
        {
            MainWindowController_Accessor target = new MainWindowController_Accessor(); // TODO: Initialize to an appropriate value
            target.loadTasks();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for getTask
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GotHoursDesktop.exe")]
        public void getTaskTest()
        {
            MainWindowController_Accessor target = new MainWindowController_Accessor(); // TODO: Initialize to an appropriate value
            string pTaskName = string.Empty; // TODO: Initialize to an appropriate value
            Task expected = null; // TODO: Initialize to an appropriate value
            Task actual;
            actual = target.getTask(pTaskName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MainWindowController Constructor
        ///</summary>
        [TestMethod()]
        public void MainWindowControllerConstructorTest()
        {
            MainWindowController target = new MainWindowController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
