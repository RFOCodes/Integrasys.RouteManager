using CommunityToolkit.Mvvm.Input;

namespace Integrasys.RouteManager.ViewModels;

public partial class MainPageViewModel : ViewModelBase
{

   [RelayCommand]
   private async Task AdminTapAsync()
   {
      await Shell.Current.DisplayAlertAsync("Admin", "The Admin label was tapped!", "OK");
   }
   
   [RelayCommand]
   private async Task CommsTapAsync()
   {
      await Shell.Current.DisplayAlertAsync("Comms", "The Comms label was tapped!", "OK");
   }
   
}