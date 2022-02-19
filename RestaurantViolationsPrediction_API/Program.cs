﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;
using RestaurantViolationsPrediction_API;

// Configure app
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPredictionEnginePool<RestaurantViolationsPrediction.ModelInput, RestaurantViolationsPrediction.ModelOutput>()
    .FromFile("RestaurantViolationsPrediction.zip");
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Description = "Docs for my API", Version = "v1" });
});
var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

// Define prediction route & handler
app.MapPost("/predict",
    async (PredictionEnginePool<RestaurantViolationsPrediction.ModelInput, RestaurantViolationsPrediction.ModelOutput> predictionEnginePool, RestaurantViolationsPrediction.ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(input)));

// Run app
app.Run();

/*
打开 PowerShell，并输入以下代码（其中，PORT 是应用程序正在侦听的端口）。
$body = @{
    InspectionType="Reinspection/Followup"
    ViolationDescription="Inadequately cleaned or sanitized food contact surfaces"
}

Invoke-RestMethod "https://localhost:<PORT>/predict" -Method Post -Body ($body | ConvertTo-Json) -ContentType "application/json"
 */

/*
如果成功，输出文本应如下所示：
prediction    score
----------    -----
Moderate Risk {0.055566575, 0.058012854, 0.88642055}
 */