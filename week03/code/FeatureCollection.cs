using System.Text.Json.Serialization;

/// <summary>
/// Top-level object returned by the USGS earthquake GeoJSON feed.
/// The feed's shape is: { "type": ..., "metadata": {...}, "features": [ {...}, {...} ] }
/// We only need the "features" array for this assignment.
/// </summary>
public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

/// <summary>
/// Each entry in the "features" array represents a single earthquake event.
/// It has a "properties" object (which holds place/magnitude) and a
/// "geometry" object (coordinates) which we don't need here.
/// </summary>
public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

/// <summary>
/// The properties object for a single earthquake feature.
/// The USGS feed has many more fields, but we only care about
/// "place" and "mag" for this assignment.
/// </summary>
public class Properties
{
    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
}