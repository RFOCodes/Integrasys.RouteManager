using CommunityToolkit.Maui;
using Integrasys.RouteManager.Handlers;
using Microsoft.Extensions.Logging;

namespace Integrasys.RouteManager;

public static class MauiProgram
{
   public static MauiApp CreateMauiApp()
   {
      var builder = MauiApp.CreateBuilder();
      builder
         .UseMauiApp<App>()
         .UseMauiCommunityToolkit()
         .ConfigureFonts(fonts =>
         {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("AktivGrotesk-Bold.ttf", "Bold");
            fonts.AddFont("AktivGrotesk-Medium.ttf", "Medium");
            fonts.AddFont("AktivGrotesk-MediumItalic.ttf", "MediumItalic");
            fonts.AddFont("AktivGrotesk-Regular.ttf", "Regular");
            fonts.AddFont("AktivGrotesk-XBold.ttf", "XBold");
            fonts.AddFont("material-symbols-filled.ttf", "MSFilled");
            fonts.AddFont("material-symbols-regular.ttf", "MSRegular");
         })
         .AddServices()
         .ConfigureMauiHandlers(handlers =>
         {
#if ANDROID
            handlers.AddHandler(typeof(Shell), typeof(CustomShellHandler));
#endif
         });

      Handlers.EntryHandler.Apply();
      
#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
   }

   extension(MauiAppBuilder builder)
   {
      private MauiAppBuilder AddServices()
      {
         builder.AddViewModels();
         builder.AddViews();
         return builder;
      }

      private void AddViewModels()
      {
         builder.Services.AddTransient<ViewModels.InventoryTransferViewModel>();
         builder.Services.AddTransient<ViewModels.InventoryTransferItemViewModel>();
         builder.Services.AddTransient<ViewModels.MainPageViewModel>();
      }
      
      private void AddViews()
      {
         builder.Services.AddTransient<Views.MainPage>();
         builder.Services.AddTransient<Views.InventoryTransfer>();
      }
   }
}