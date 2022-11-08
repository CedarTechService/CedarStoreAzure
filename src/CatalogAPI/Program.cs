using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(lb => { lb.ClearProviders(); lb.AddConsole(); });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, PostgresProductRepository>();

var connStringBuilder = new NpgsqlConnectionStringBuilder();
connStringBuilder.ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
connStringBuilder.Username = builder.Configuration["UserID"];
connStringBuilder.Password = builder.Configuration["Password"];
builder.Services.AddDbContext<ProductContext>(opt => opt.UseNpgsql(connStringBuilder.ConnectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Audience = builder.Configuration["ResourceId"];
        opt.Authority = $"{builder.Configuration["Instance"]}{builder.Configuration["TenantId"]}";
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductContext>();
    db.Database.Migrate();
    //test
}

// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseAuthentication();
app.UseAuthorization();

// app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
