using Interfaces.Parts;

namespace BMW.Parts
{
    public class Panel : IPanel
    {
        public string Name { get; set; }
        public string Speed { get; set; }
        public string Fuel { get; set; }
        public string Degree { get; set; }
        public string Gear { get; set; }
        public string Light { get; set; }
        public string MaxSpeed { get; set; }
        public string MaxGear { get; set; }
        public string PedalLuft { get; set; }
        public string RudderLuft { get; set; }
    }
}