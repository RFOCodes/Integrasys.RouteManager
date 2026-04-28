namespace Integrasys.RouteManager.Views;

public partial class InventoryTransfer : ContentPage
{
   public InventoryTransfer(ViewModels.InventoryTransferViewModel vm)
   {
      InitializeComponent();
      BindingContext = vm;
   }

   private void Cases_OnTextChanged(object? sender, TextChangedEventArgs e)
   {
      if (sender is Entry entry)
      {
         var isValid = System.Text.RegularExpressions.Regex.IsMatch(e.NewTextValue, "^[0-9]*$");
         if (!isValid)
            entry.Text = e.OldTextValue;
      }
   }
}