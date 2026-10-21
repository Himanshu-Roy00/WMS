using Microsoft.EntityFrameworkCore;
using WMS.BAL;
using WMS.DAL;
using WMS.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

// Category
builder.Services.AddScoped<CategoryDAL>();
builder.Services.AddScoped<CategoryBAL>();

// Account
builder.Services.AddScoped<AccountDAL>();
builder.Services.AddScoped<AccountBAL>();

// Product -- YEH ADD KARO
builder.Services.AddScoped<ProductDAL>();
builder.Services.AddScoped<ProductBAL>();

builder.Services.AddScoped<UOMDAL>();
builder.Services.AddScoped<UOMBAL>();

builder.Services.AddScoped<SupplierDAL>();
builder.Services.AddScoped<SupplierBAL>();

builder.Services.AddScoped<WarehouseDAL>();
builder.Services.AddScoped<WarehouseBAL>();

builder.Services.AddScoped<StockInDAL>();
builder.Services.AddScoped<StockInBAL>();

builder.Services.AddScoped<ProductStockDAL>();
builder.Services.AddScoped<ProductStockBAL>();

builder.Services.AddScoped<StockOutDAL>();
builder.Services.AddScoped<StockOutBAL>();

builder.Services.AddScoped<ProductTransferDAL>();
builder.Services.AddScoped<ProductTransferBAL>();

builder.Services.AddScoped<ReportDAL>();
builder.Services.AddScoped<ReportBAL>();

builder.Services.AddScoped<DashboardDAL>();
builder.Services.AddScoped<DashboardBAL>();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection")
	));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();