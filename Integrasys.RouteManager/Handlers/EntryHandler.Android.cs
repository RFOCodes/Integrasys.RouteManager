using Microsoft.Maui.Platform;

namespace Integrasys.RouteManager.Handlers;

public partial class EntryHandler
{
   private static void NoBorder()
   {
      Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorder", (handler, entry) =>
      {
         handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
         handler.PlatformView.BackgroundTintList =
            Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
      });
   }
}