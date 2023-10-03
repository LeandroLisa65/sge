#region

using System.Text.Json.Serialization;

#endregion

namespace Contract.AWS;
public class RdsSecrets
{
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("engine")]
    public string? Engine { get; set; }

    [JsonPropertyName("host")]
    public string? Host { get; set; }

    [JsonPropertyName("port")]
    public int Port { get; set; }

    [JsonPropertyName("dbClusterIdentifier")]
    public string? DbClusterIdentifier { get; set; }

    [JsonPropertyName("Database")]
    public string? Database { get; set; }
}