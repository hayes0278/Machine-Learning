using MachineLearning.ClassLibrary;
using Microsoft.ML;

string appName = "Machine Learning";

Console.WriteLine($"=== Welcome to {appName} ===");
Console.WriteLine("I will now train with the provided data and then make some preditions.");
Console.WriteLine("");

MachineLearningApp app = new MachineLearningApp();
app.MachineLearningDemo();

Console.WriteLine("");
Console.WriteLine($"Thank you for using the {appName} app. Goodbuy.");