using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FoodTruck.ViewModel
{
    public class BaseViewModel:INotifyPropertyChanged
    {
       

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetValue<T>(ref T backfield,T value)
        {
            if( EqualityComparer<T>.Default.Equals(backfield,value))
                               return;
            backfield = value;
            OnPropertyChanged();
        }
    }
}
