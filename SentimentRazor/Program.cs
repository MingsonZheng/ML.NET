using Microsoft.Extensions.ML;
using SentimentRazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddPredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput>().FromFile(Tool.GetAbsolutePath("MLModel.zip"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

/*
当应用程序启动时，在文本区域中输入“Model Builder is cool!” 。 显示的预测情绪应为“Not Toxic” 。
 */