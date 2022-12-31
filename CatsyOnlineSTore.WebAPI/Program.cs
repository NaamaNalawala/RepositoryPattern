using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.DataAccess.Repositories;
using CatsyOnlineStore.Model.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CatsyOnlineStore.BAL.Repositories;
using CatsyOnlineStore.BAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDbProvider, DbProvider> (e =>
{
    var connection = new SqlConnection(builder.Configuration.GetConnectionString("catsyStoreDb"));
    return new DbProvider(connection);
});
builder.Services.AddScoped(typeof(IGenericBAL<>), typeof(GenericBAL<>));
builder.Services.AddScoped<ICustomerBAL, CustomerBAL>();
builder.Services.AddScoped<IProductBAL, ProductBAL>();
builder.Services.AddScoped<IOrderBAL, OrderBAL>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

JWTTokenEntity objSitekey = builder.Configuration.GetSection("jwtTokenConfig").Get<JWTTokenEntity>();
var key = Encoding.ASCII.GetBytes(objSitekey.Secret);

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
             .AddJwtBearer(token =>
             {
                 token.RequireHttpsMetadata = false;
                 token.SaveToken = true;
                 token.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = true,
                     ValidIssuer = objSitekey.Issuer,
                     ValidateAudience = true,
                     ValidAudience = objSitekey.Issuer,
                     RequireExpirationTime = true,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.FromMinutes(15)
                 };
             });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
