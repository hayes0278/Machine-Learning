using MachineLearning.ClassLibrary;

namespace MachineLearning.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Demo_Test()
        {
            MachineLearningApp app = new MachineLearningApp();
            app.MachineLearningDemo();
            if (app.MachineLearningDemo()) { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void CreatePredictionNegative_Test()
        {
            string testText = "This movie was horrible.";
            MachineLearningApp app = new MachineLearningApp();
            string result = app.MakePrediction(testText);
            if (result == "Negative") { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void CreatePredictionPositive_Test()
        {
            string testText = "This movie was really great.";
            MachineLearningApp app = new MachineLearningApp();
            string result = app.MakePrediction(testText);
            if (result == "Positive") { Assert.Pass(); } else { Assert.Fail(); }
        }
    }
}