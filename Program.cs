using IOptionsPattern.Settings;

var builder = WebApplication.CreateBuilder(args);

//Bind IOptions

builder.Services.Configure<NewsletterSettings>(
    builder.Configuration.GetSection(nameof(NewsletterSettings)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
