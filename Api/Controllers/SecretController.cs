using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretController : ControllerBase
{
    private readonly IAmazonSecretsManager _secretsManager;

    public SecretController(IAmazonSecretsManager secretsManager)
    {
        _secretsManager = secretsManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetSecret()
    {
        GetSecretValueRequest request = new GetSecretValueRequest();
        request.SecretId = "test-secret";
        request.VersionStage = "AWSCURRENT";
        GetSecretValueResponse response = await  _secretsManager.GetSecretValueAsync(request);
        return Ok(new { Secret = response.SecretString });
    }
}
