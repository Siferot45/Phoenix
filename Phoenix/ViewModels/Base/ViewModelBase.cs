using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Phoenix.ViewModels.Base
{
    internal class ViewModelBase : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handlers = PropertyChanged;
            if (handlers is null)
                return;

            var invocationList = handlers.GetInvocationList();

            var arg = new PropertyChangedEventArgs(propertyName);
            foreach ( var invocation in invocationList)
            {
                if(invocation.Target is DispatcherObject dispatcherObject)
                    dispatcherObject.Dispatcher.Invoke(invocation, this, arg);
                else
                    invocation.DynamicInvoke(this, arg);
            }
        }
        protected virtual bool Set<T>(ref T filed, T value, [CallerMemberName] string propertyName = null)
        {
            if(Equals(filed, value)) 
                return false;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
