﻿using System;
using UIKit;

namespace TOua.iOS {
    public class Application {
        // This is the main entry point of the application.
        static void Main(string[] args) {
            try {
                UIApplication.Main(args, null, "AppDelegate");
            } catch (Exception ex) {
                throw;
            }
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
        }
    }
}
