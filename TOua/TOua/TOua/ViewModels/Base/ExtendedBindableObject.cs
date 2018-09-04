﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TransportAndOwner.ViewModels.Base {
    public class ExtendedBindableObject : BindableObject {
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
