#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string tempDir = Path.Combine(Path.GetTempPath(), "MyData");
    if (!Directory.Exists(tempDir))
    {
        Directory.CreateDirectory(tempDir);
    }
    string tempFile = Path.Combine(tempDir, "steps.txt");
    string result = File.ReadAllText(tempFile);

    log.LogInformation(result);

    return result != null
        ? (ActionResult)new OkObjectResult(result)
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}
