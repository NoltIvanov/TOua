using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TOua.Droid.Services;
using TOua.Services.Memory;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndriodMemoryService))]
namespace TOua.Droid.Services {
    public class AndriodMemoryService : IMemoryService {

        private static Context _context;

        /// <summary>
        ///     ctor().
        /// </summary>
        public AndriodMemoryService() {
            _context = MainActivity.Instance;
        }

        public MemoryInfo GetInfo() => MemoryHelper.GetMemoryInfo(_context);
    }
}