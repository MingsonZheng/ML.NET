using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.ML;

namespace SentimentRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> _predictionEnginePool;

        public IndexModel(ILogger<IndexModel> logger, PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> predictionEnginePool)
        {
            _logger = logger;
            _predictionEnginePool = predictionEnginePool;
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetAnalyzeSentiment([FromQuery] string text)
        {
            if (String.IsNullOrEmpty(text)) return Content("Neutral");
            var input = new MLModel.ModelInput { SentimentText = text, LoggedIn = true};
            var prediction = _predictionEnginePool.Predict(input);
            var sentiment = Convert.ToBoolean(prediction.Prediction) ? "Toxic" : "Not Toxic";
            return Content(sentiment);
        }
    }
}