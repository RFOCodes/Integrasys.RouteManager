using UIKit;

namespace Integrasys.RouteManager.Handlers;

public partial class EntryHandler
{
   private static void NoBorder()
   {
      Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorder", (handler, entry) =>
      {
         handler.PlatformView.BorderStyle = UITextBorderStyle.None;
      });
   }
}