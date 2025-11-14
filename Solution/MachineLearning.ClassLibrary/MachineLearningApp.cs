using MachineLearning.Classlibrary;
using Microsoft.ML;

namespace MachineLearning.ClassLibrary
{
    public class MachineLearningApp
    {
        public bool MachineLearningDemo()
        {
            MLContext mlContext = new MLContext();

            var trainingData = new List<SentimentData>
            {
                new SentimentData { SentimentText = "This is a great product!", Sentiment = true },
                new SentimentData { SentimentText = "I loved this movie.", Sentiment = true },
                new SentimentData { SentimentText = "Terrible service at the bar.", Sentiment = false },
                new SentimentData { SentimentText = "I am very disappointed.", Sentiment = false },
                new SentimentData { SentimentText = "Happy with the results.", Sentiment = true },
                new SentimentData { SentimentText = "What a putrid movie.", Sentiment = false },
                new SentimentData { SentimentText = "This is the worst movie I have seen.", Sentiment = false },
                new SentimentData { SentimentText = "Horrible wait staff.", Sentiment = false },
                new SentimentData { SentimentText = "My favorite movie of all time.", Sentiment = true },
                new SentimentData { SentimentText = "Loved the movie.", Sentiment = true }
            };

            IDataView dataView = mlContext.Data.LoadFromEnumerable(trainingData);

            // Define Data Processing Pipeline
            var pipeline = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            // Train the Model
            ITransformer model = pipeline.Fit(dataView);

            // Make Predictions
            var predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);

            var sample1 = new SentimentData { SentimentText = "I am so pleased with this movie." };
            var prediction1 = predictionEngine.Predict(sample1);
            Console.WriteLine($"Test 1: '{sample1.SentimentText}' | Prediction: {prediction1.Prediction} | Probability: {prediction1.Probability}");

            var sample2 = new SentimentData { SentimentText = "What a terrible movie." };
            var prediction2 = predictionEngine.Predict(sample2);
            Console.WriteLine($"Test 2: '{sample2.SentimentText}' | Prediction: {prediction2.Prediction} | Probability: {prediction2.Probability}");

            var sample3 = new SentimentData { SentimentText = "Without a doubt, a great movie to see." };
            var prediction3 = predictionEngine.Predict(sample3);
            Console.WriteLine($"Test 3: '{sample3.SentimentText}' | Prediction: {prediction3.Prediction} | Probability: {prediction3.Probability}");

            if (prediction1 != null && prediction2 != null && prediction3 != null) { return  true; } else { return false; }
        }
    }
}
