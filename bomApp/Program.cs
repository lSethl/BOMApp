using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BOMProject.DataAccess.Context;
using BOMProject.DataAccess.Repositories;
using BOMProject.Business.Services;
using BOMProject.Business.Contracts;

namespace bomApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string databaseFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "BomApp");

            Directory.CreateDirectory(databaseFolder);

            string databasePath = Path.Combine(
                databaseFolder, "BomApp.db");

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite($"Data Source={databasePath}")
            .Options;

            using (var context = new AppDbContext(options))
            {
                context.Database.Migrate();
            }

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={databasePath}"));

            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IImportHistoryRepository, ImportHistoryRepository>();
            services.AddScoped<IExcelImportService, ExcelImportService>();
            services.AddScoped<IImportHistoryService, ImportHistoryService>();
            services.AddScoped<BOMProject>();
            services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
            services.AddScoped<IActivityLogService, ActivityLogService>();

            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var materialService = scope.ServiceProvider.GetRequiredService<IMaterialService>();
            }

            var form = serviceProvider.GetRequiredService<BOMProject>();
            Application.Run(form);
        }
    }
}