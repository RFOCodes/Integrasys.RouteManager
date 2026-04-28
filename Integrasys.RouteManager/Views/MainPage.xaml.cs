namespace Integrasys.RouteManager.Views;

public partial class MainPage : ContentPage
{
   public MainPage(ViewModels.MainPageViewModel vm)
   {
      InitializeComponent();
      BindingContext = vm;
   }

   private async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
   {
      await Shell.Current.GoToAsync("InventoryTransfer");
   }
}