using MachineLearning.Classlibrary;
using MachineLearning.ClassLibrary;
using Microsoft.ML;
using System.Data;

namespace MachineLearning.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatePrediction_Test()
        {
            MachineLearningApp app = new MachineLearningApp();
            app.MachineLearningDemo();
            if (app.MachineLearningDemo()) { Assert.Pass(); } else { Assert.Fail(); }
        }
    }
}