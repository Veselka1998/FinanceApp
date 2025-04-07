using FinanceApp.Components.Data;
using FinanceApp.Components.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton<MarketService>();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "financeAppDatabase2.db");

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Filename={dbPath}"));
        builder.Services.AddSingleton<PortfolioService>();
        builder.Services.AddSingleton<NoteService>();
        builder.Services.AddSingleton<FinanceProductService>();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        MauiApp mauiApp = builder.Build();

        var db = mauiApp.Services.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
        return mauiApp;
    }
}
