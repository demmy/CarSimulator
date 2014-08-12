namespace Interfaces.Parts
{
    public interface IPanel
    {
        string Name { get; set; }
        string Speed { get; set; }
        string Fuel { get; set; }
        string Degree { get; set; }
        string Gear { get; set; }
        string Light { get; set; }
        string MaxSpeed { get; set; }
        string MaxGear { get; set; }
        string PedalLuft { get; set; }
        string RudderLuft { get; set; }
    }
}