
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xaml;

namespace Phoenix.ViewModels.EntityViewModel.Base
{
    internal abstract class ViewModelBase : MarkupExtension, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handlers = PropertyChanged;
            if (handlers is null)
                return;

            var invocationList = handlers.GetInvocationList();

            var arg = new PropertyChangedEventArgs(propertyName);
            foreach (var action in invocationList)
                if (action.Target is DispatcherObject disp_object)
                    disp_object.Dispatcher.Invoke(action, this, arg);
                else
                    action.DynamicInvoke(this, arg);
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public override object ProvideValue(IServiceProvider sp)
        {
            var valueTargetService = sp.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var rootObjectService = sp.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;

            OnInitialized(
                valueTargetService?.TargetObject,
                valueTargetService?.TargetProperty,
                rootObjectService?.RootObject);

            return this;
        }

        private WeakReference _targetRef;
        private WeakReference _rootRef;

        public object TargetObject => _targetRef.Target;

        public object RootObject => _rootRef.Target;

        protected virtual void OnInitialized(object target, object property, object root)
        {
            _targetRef = new WeakReference(target);
            _rootRef = new WeakReference(root);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _disposed;

        // Освобождение управляемых ресурсов
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _disposed) return;
            _disposed = true;

        }
    }
}
