using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportAndOwner.ViewModels.Base;

namespace TransportAndOwner.Services.Navigation {
    public interface INavigationService {

        bool IsBackButtonAvailable { get; }

        ViewModelBase PreviousPageViewModel { get; }

        ViewModelBase LastPageViewModel { get; }

        IReadOnlyCollection<ViewModelBase> CurrentViewModelsNavigationStack { get; }

        void Initialize();

        Task NavigateToAsync(Type navigateTo);

        Task NavigateToAsync(Type navigateTo, object parameter);

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();

        Task GoBackAsync();
    }
}
