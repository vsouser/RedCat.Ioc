using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RedCat.Ioc
{ 
    public abstract class BaseContainer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void ChangeProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(storage, value))
            {
                storage = value;
                ChangeProperty(propertyName);
            }
        }

        protected virtual void ChangeProperty(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
