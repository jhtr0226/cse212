using System.Collections.Generic;

/// <summary>
/// This is the main class that matches the top-level object in the JSON.
/// The "features" key in the JSON maps to this property.
/// It's a list of "Feature" objects.
/// </summary>
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

/// <summary>
/// Each item in the "features" list is a Feature object.
/// Inside each Feature is another object called "properties".
/// </summary>
public class Feature
{
    public Properties Properties { get; set; }
}

/// <summary>
/// This is the object that contains the real data we care about:
/// - Place: where the earthquake happened
/// - Mag: the magnitude (might be missing sometimes, so we use a nullable type)
/// </summary>
public class Properties
{
    public string Place { get; set; }     // Example: "58km N of XYZ"
    public double? Mag { get; set; }      // Magnitude (ex: 4.5), may be null, so we use "double?"
}
