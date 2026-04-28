using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Integrasys.RouteManager.Models;

namespace Integrasys.RouteManager.ViewModels;

public partial class InventoryTransferViewModel : ViewModelBase
{
   private readonly ObservableCollection<Item> _itemsDB;
   [ObservableProperty] private ObservableCollection<InventoryTransferItemViewModel> _items;
   [ObservableProperty] private string _searchText = string.Empty;
   [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LargeButtonCommand))] private int _total = 0;

   public InventoryTransferViewModel()
   {
      _itemsDB =
      [
         new Item()
         {
            Id = 4826, Title = "Salami - Genoa with red wine and pepper", Uc = 12, Upc = "602652170081", Stock = -212,
            Cases = 5
         },
         new Item()
         {
            Id = 2156, Title = "Family Pack of Bacon Egg and Cheese Bage", Uc = 8, Upc = "043695062000", Stock = -897,
            Cases = 5
         },
         new Item()
         {
            Id = 2698, Title = "Cooked Ham and with smokey and savory mo", Uc = 8, Upc = "043695062010", Stock = -475,
            Cases = 5
         },
         new Item()
         {
            Id = 95466, Title = "Extra Sweet Orange Juice", Uc = 6, Upc = "00000000000", Stock = -2953, Cases = 5
         },
         new Item()
         {
            Id = 1205, Title = "Peanut Butter Ice Cream with Crunchy Pea", Uc = 3, Upc = "00000000000", Stock = -2003,
            Cases = 5
         }
      ];
      Items = new ObservableCollection<InventoryTransferItemViewModel>(_itemsDB.Select(x => CreateInventoryTransferItemViewModel(x.ToDto())));
   }

   private InventoryTransferItemViewModel CreateInventoryTransferItemViewModel(ItemToViewModelDto item)
   {
      var itemViewModel = new InventoryTransferItemViewModel(item);
      itemViewModel.CasesChanged += UpdateTotal;
      return itemViewModel;
   }

   private void UpdateTotal(object? sender, EventArgs e)
   {
      ProcessTotal();
   }

   partial void OnSearchTextChanged(string value)
   {
      Items = new ObservableCollection<InventoryTransferItemViewModel>(
         _itemsDB.Where(x => 
            x.Title.Contains(value, StringComparison.OrdinalIgnoreCase)
            ||
            x.Id.ToString().Contains(value, StringComparison.OrdinalIgnoreCase)
            ||
            x.Upc.ToString().Contains(value, StringComparison.OrdinalIgnoreCase)
         ).Select(x => CreateInventoryTransferItemViewModel(x.ToDto())));
   }

   partial void OnItemsChanged(ObservableCollection<InventoryTransferItemViewModel> value)
   {
      ProcessTotal();
   }

   private void ProcessTotal()
   {
      Total = Items.Sum(x => x.Cases);
   }
   
   [RelayCommand]
   private async Task GoBackAsync()
   {
      await Shell.Current.GoToAsync("..");
   }

   [RelayCommand]
   private async Task ShareAsync()
   {
      await Shell.Current.DisplayAlertAsync("Share", "The Share button was clicked.", "OK");
   }
   
   [RelayCommand]
   private async Task BarcodeScanAsync()
   {
      await Shell.Current.DisplayAlertAsync("Barcode", "The Barcode button was clicked.", "OK");
   }
   
   [RelayCommand]
   private async Task AddItemAsync()
   {
      await Shell.Current.DisplayAlertAsync("Add", "The Add button was clicked.", "OK");
   }
   
   [RelayCommand(CanExecute = nameof(HasCases))]
   private async Task LargeButtonAsync()
   {
      await Shell.Current.DisplayAlertAsync("Cases", $"Total of Cases: {Total}", "OK");
   }

   private bool HasCases() => Total > 0;
}