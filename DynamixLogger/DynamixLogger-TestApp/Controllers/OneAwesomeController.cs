using System;
using DynamixLogger;
using System.IO;

namespace DynamixLogger_TestApp.Controllers
{
    public class OneAwesomeController : DynamixDefaultController
    {

        //
        // NOTE : YOU CAN CREATE YOUR OWN LOGGING CONTROLLER OR CUSTOMIZE THE ABOVE ONE
        //

        /// <summary>
        /// Here we have inherited a default log controller from the dyanmix logger library
        /// The below sample logs a normal message to the file defined in the controller
        /// </summary>
        public string DoSomething()
        {
            LogMessage("Did you just logged what i did Dude !! ??");

            return Path.Combine(fileLogInfo.FilePath, fileLogInfo.FolderName);
        }


        /// <summary>
        /// Here we have inherited a default log controller from the dyanmix logger library
        /// This is just a sample of logging an exception.
        /// </summary>
        public string CreateAnExceptionAndLog()
        {
            try
            {
                throw new Exception("Oops !!! I did it again.");
            }
            catch (Exception ex)
            {
                LogMessage(ex);
                return Path.Combine(fileLogInfo.FilePath, fileLogInfo.FolderName);

            }
        }





    }
}
