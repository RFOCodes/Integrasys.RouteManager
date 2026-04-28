namespace Integrasys.RouteManager;

public partial class AppShell : Shell
{
   public AppShell()
   {
      InitializeComponent();
      Routing.RegisterRoute("InventoryTransfer", typeof(Views.InventoryTransfer));
   }
}