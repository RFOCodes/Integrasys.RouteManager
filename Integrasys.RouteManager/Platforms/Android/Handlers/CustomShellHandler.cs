using Google.Android.Material.AppBar;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace Integrasys.RouteManager.Handlers;

public class CustomShellHandler : ShellRenderer
{
   public CustomShellHandler(global::Android.Content.Context context) : base(context){}

   protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
   {
      return new CustomToolbarAppearanceTracker();
   }
}

public class CustomToolbarAppearanceTracker : IShellToolbarAppearanceTracker
{
   public void SetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
   {
      CenterTitle(toolbar);
   }

   public void ResetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker)
   {
      CenterTitle(toolbar);
   }

   public void Dispose() { }

   private void CenterTitle(Toolbar toolbar)
   {
      if (toolbar is MaterialToolbar materialToolbar)
      {
         materialToolbar.TitleCentered = true;
         materialToolbar.SubtitleCentered = true;
      }

      for (int i = 0; i < toolbar.ChildCount; i++)
      {
         if (toolbar.GetChildAt(i) is Android.Widget.TextView textView)
         {
            var typeFace =
               Android.Graphics.Typeface.CreateFromAsset(Android.App.Application.Context.Assets,
                  "AktivGrotesk-XBold.ttf");
            textView.Typeface = typeFace;
            break;
         }
      }
   }
}