using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.BusinessLayer.Concrete;
using ECommerceSimulationApp.DataAccessLayer.Abstract;
using ECommerceSimulationApp.DataAccessLayer.Concrete;
using ECommerceSimulationApp.DataAccessLayer.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ECommerceSimulationApp.DesktopUI.Forms;
using ECommerceSimulationApp.DesktopUI;
using ECommerceSimulationApp.DataAccessLayer.UnitOfWork;
using ECommerceSimulationApp.EntityLayer.Dto.CategoryDto;
using ECommerceSimulationApp.BusinessLayer.FluentValidation.CategoryValidation;

namespace ECommerceSimulationApp.UI
{
    static class Program
    {
       

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                });
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // DbContext registration
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(@"Data Source=MSý\SQLEXPRESS;Initial Catalog=ECommerceSimulationAppDesktopDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            });

            // Form Kayýtlarý 
            services.AddScoped<MainForm>();
            services.AddScoped<ProductForm>();
            services.AddScoped<CategoryForm>();
            services.AddScoped<OrderForm>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            // Services
            services.AddScoped<ICategoryService, CategoryManager>();

            // Validators
            services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryValidator>();

            // AutoMapper 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}