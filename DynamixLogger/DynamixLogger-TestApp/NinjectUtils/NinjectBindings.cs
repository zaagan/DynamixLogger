using DynamixLogger;
using DynamixLogger.Info;
using DynamixLogger.LogStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamixLogger_TestApp.NinjectUtils
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            //Bind<IBaseLogInfo>().To<FileLogInfo>();
            Bind(typeof(ILogStrategy<>)).To(typeof(FileLogger<>));
            //Bind<ILogStrategy<FileLogInfo>>().To<FileLogger<FileLogInfo>>();

        }
    }
}
