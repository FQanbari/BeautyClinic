using BeautyClinic.API.Endpoints.Internal;
using BeautyClinic.API.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeautyClinicDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
// Add services to the container.

// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints<Program>(builder.Configuration);

// add validator


var app = builder.Build();

app.UseMiddleware<ApiResponseMiddleware>();
// Configure the HTTP request pipeline.
// add swagger
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
app.UseEndpoints<Program>();

app.Run();
