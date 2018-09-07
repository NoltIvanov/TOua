using System;

namespace TOua.Exceptions {
    internal class ConnectivityException : Exception {

        public ConnectivityException(string error) : base(error) {
        }
    }
}
