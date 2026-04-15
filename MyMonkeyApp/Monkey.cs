namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species or individual with comprehensive information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species or individual.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the geographic location where the monkey is found.
    /// </summary>
    public required string Location { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the monkey species.
    /// </summary>
    public required string Details { get; set; }

    /// <summary>
    /// Gets or sets the URL to an image of the monkey.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the population count of the monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets the latitude coordinate of the monkey's primary location.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude coordinate of the monkey's primary location.
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Returns a string representation of the monkey with key information.
    /// </summary>
    /// <returns>A formatted string containing the monkey's name and location.</returns>
    public override string ToString()
    {
        return $"{Name} - {Location}";
    }
}
