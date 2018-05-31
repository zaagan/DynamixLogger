using Ninject;
using System.Reflection;


namespace DynamixLogger_TestApp.NinjectUtils
{
    public class NinjectHandler
    {
        IKernel _Kernal = null;
        public T Get<T>()
        {
            if (_Kernal == null)
            {
                _Kernal = new StandardKernel();
                _Kernal.Load(Assembly.GetExecutingAssembly());
            }
            T _handler = _Kernal.Get<T>();
            return _handler;
        }

    }
}
