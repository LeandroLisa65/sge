#region

using System.Text.Json;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

#endregion

namespace Infrastructure.Common.Helpers;
public static class AwsSecretsHelper
{
    private static readonly IAmazonSecretsManager _secretsClient;
    private static readonly string Env = string.Empty;

    static AwsSecretsHelper()
    {
        Env = System.Environment.GetEnvironmentVariable("ENVIRONMENT") ?? "dev";
        _secretsClient = new AmazonSecretsManagerClient(RegionEndpoint.USEast1);
    }

    public static async Task<T?> GetSecrets<T>(string secretName)
    {
        var request = new GetSecretValueRequest() { SecretId = secretName };
        T? secrets;
        try
        {
            GetSecretValueResponse? response = await _secretsClient.GetSecretValueAsync(request);
            secrets = JsonSerializer.Deserialize<T>(response.SecretString);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error obtaining secret {secretName}, msg: {ex.Message}");
            throw;
        }       

        return secrets;
    }
}