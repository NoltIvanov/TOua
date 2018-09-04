using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TransportAndOwner.Services.Dialog {
    public interface IDialogService {
        Task ShowAlertAsync(string message, string title, string buttonLabel);

        Task ToastAsync(string message, string actionName, Action action);

        Task ToastAsync(string message);
    }
}
