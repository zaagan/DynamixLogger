using DynamixLogger;
using DynamixLogger.Info;
using DynamixLogger.LogStrategy;
using DynamixLogger.Utilities;
using DynamixLogger_TestApp.Controllers;
using DynamixLogger_TestApp.NinjectUtils;
using System;
using System.IO;
using System.Windows.Forms;


namespace DynamixLogger_TestApp
{
    public partial class Master : Form
    {

        public Master()
        {
            InitializeComponent();
            InstantiateDefaultLogInfo();
            InstantiateNinject();
        }


        #region -------- LOGGING USING INHERITANCE --------

        /// <summary>
        /// Examle : Message logging using class inheritance
        /// Checkout the OneAwesomeController file to see how it is done.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoSomething_Click(object sender, EventArgs e)
        {
            OneAwesomeController someAwesomeController = new OneAwesomeController();
            string filePath = someAwesomeController.DoSomething();

            lblMessage.Text = $"A normal message was logged to the file at {filePath}";
        }


        private void btnLogException_Click(object sender, EventArgs e)
        {
            OneAwesomeController someAwesomeController = new OneAwesomeController();
            string filePath = someAwesomeController.CreateAnExceptionAndLog();

            lblMessage.Text = $"A sample exception was logged to the file at {filePath}";
        }

        #endregion




        #region -------- SAMPLE LOGGING USING DI -------

        FileLogInfo fileLogInfo = null;
        ILogStrategy<FileLogInfo> iLogStrategy = null;


        private void InstantiateDefaultLogInfo()
        {
            // YOU CAN CREATE YOUR OWN FileLogInfo
            // I AM USING A DEFAULT LOG INFO FROM THE LIBRARY HERE

            // NOTE : THE FILE LOGGER IS CONFIGURED TO AUTO CHOOSE A 
            //        DRIVE WITH MINIMUM 5 GB OF SPACE FOR LOGGING THE DATA
            fileLogInfo = DynamixDefaultController.DefaultFileLogInfo();
        }


        /// <summary>
        /// YOU MIGHT BE DOING SOMETHING LIKE THIS TO GET YOUR LOG STRATEGY
        /// </summary>
        private void InstantiateNinject()
        {

            NinjectHandler ninjectHandler = new NinjectHandler();
            iLogStrategy = ninjectHandler.Get<ILogStrategy<FileLogInfo>>();
        }


        /// <summary>
        /// Implement the dependency injection on your own way.
        /// You dont have to stick to how it has been done here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsingDependencyInjection_Click(object sender, EventArgs e)
        {
            fileLogInfo.LogType = LogType.Exception;
            fileLogInfo.LogLevel = LogLevel.EXCEPTION;
            fileLogInfo.Exception = new Exception("What the hell ? You just logged in a self invoked exception dude.");

            LogWriter<FileLogInfo>.Write(iLogStrategy, fileLogInfo);


            lblMessage.Text = $"A sample exception via dependency injection was logged to the file at {Path.Combine(fileLogInfo.FilePath, fileLogInfo.FolderName)}";
        }


        /// <summary>
        /// Logging a normal message using DI.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogMessageUsingDI_Click(object sender, EventArgs e)
        {

            fileLogInfo.LogType = LogType.Message;
            fileLogInfo.LogLevel = LogLevel.INFO;
            fileLogInfo.LogMessage = "Did i just log something stupid !!##??";

            LogWriter<FileLogInfo>.Write(iLogStrategy, fileLogInfo);


            lblMessage.Text = $"A sample message via dependency injection was logged to the file at {Path.Combine(fileLogInfo.FilePath,fileLogInfo.FolderName)}";
        }


        #endregion



        private void btnBasicLogging_Click(object sender, EventArgs e)
        {

            FileLogInfo logInfo = new FileLogInfo();
            logInfo.LogMessage = "Just a basic file logging";

            FileLogger<FileLogInfo> fileLogger = new FileLogger<FileLogInfo>();
            fileLogger.Write(logInfo);

            lblMessage.Text = $"Message logged to the root of the application due to no configuration at {logInfo.FilePath}";

        }


    }
}
