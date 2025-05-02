using BeautyClinic.API.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeautyClinicDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
// Add services to the container.

// add swagger
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(x =>
{
    x.EnableAnnotations();
});
builder.Services.AddEndpoints<Program>(builder.Configuration);


//builder.Services.AddSingleton<AppointmentQueueService>();


var app = builder.Build();


app.UseCustomExceptionHandler();
// Configure the HTTP request pipeline.
// add swagger
app.UseSwagger(c =>
{
    c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0; 
});
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseEndpoints<Program>();

app.Run();
