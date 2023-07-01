
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventarioBodegaContext>();

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(ITblInvCoDespachadasNRepository), typeof(TblInvCoDespachadasNRepository));
builder.Services.AddScoped(typeof(ITblInvNpComprometidasNRepository), typeof(TblInvNpComprometidasNRepository));
builder.Services.AddScoped(typeof(ITblInvUbicacionesNRepository), typeof(TblInvUbicacionesNRepository));

builder.Services.AddScoped(typeof(ITblInvNpComprometidasNService), typeof(TblInvNpComprometidasNService));
builder.Services.AddScoped(typeof(ITblInvCoDespachadasNService), typeof(TblInvCoDespachadasNService));
builder.Services.AddScoped(typeof(ITblInvUbicacionesNService), typeof(TblInvUbicacionesNService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
