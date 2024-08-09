namespace SpaceResume2024.Models.PlanetModels;

public class Rootobject
{
    public string swagger { get; set; }
    public Info info { get; set; }
    public string host { get; set; }
    public string basePath { get; set; }
    public string[] schemes { get; set; }
    public string[] consumes { get; set; }
    public string[] produces { get; set; }
    public Tag[] tags { get; set; }
    public Paths paths { get; set; }
}