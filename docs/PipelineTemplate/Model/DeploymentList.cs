using System.Collections.Generic;
using System.Text.Json.Serialization;

internal class DeploymentList
{
    [JsonPropertyName("applications")]
    public List<ApplicationDeployment> Applications { get; set; }
}