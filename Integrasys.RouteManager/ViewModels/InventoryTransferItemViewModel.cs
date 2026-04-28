using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Integrasys.RouteManager.Models;

namespace Integrasys.RouteManager.ViewModels;

public partial class InventoryTransferItemViewModel : ViewModelBase
{
   private readonly ItemToViewModelDto _inventoryTransferItem;
   
   public event EventHandler? CasesChanged;

   [ObservableProperty] private int _id;
   [ObservableProperty] private string _title;
   [ObservableProperty] private int _uc;
   [ObservableProperty] private string _upc;
   [ObservableProperty] private int _stock;
   [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(ItemActionCommand))] private int _cases;

   public InventoryTransferItemViewModel(ItemToViewModelDto item)
   {
      _inventoryTransferItem = item;
      
      Id = item.Id;
      Title = item.Title;
      Uc = item.Uc;
      Upc = item.Upc;
      Stock = item.Stock;
      Cases = item.Cases;
   }

   partial void OnCasesChanged(int value)
   {
      CasesChanged?.Invoke(this, EventArgs.Empty);
   }

   [RelayCommand(CanExecute = nameof(HasCases))]
   private async Task ItemActionAsync()
   {
      await Shell.Current.DisplayAlertAsync(Title, $"Cases: {Cases}", "OK");
   }

   private bool HasCases() => Cases > 0;
}