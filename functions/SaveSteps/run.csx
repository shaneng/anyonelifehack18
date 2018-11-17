#r "Newtonsoft.Json"
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

public static async Task<IActionResult> Run(HttpRequestMessage  req, ILogger log)
{

    string tempDir = Path.Combine(Path.GetTempPath(), "MyData");
    if (!Directory.Exists(tempDir))
    {
        Directory.CreateDirectory(tempDir);
    }
    string tempFile = Path.Combine(tempDir, "steps.txt");
    string documentContents = await req.Content.ReadAsStringAsync();

    File.WriteAllText(tempFile, documentContents);
    string result = File.ReadAllText(tempFile);

    return (ActionResult)new OkObjectResult(result);
}
