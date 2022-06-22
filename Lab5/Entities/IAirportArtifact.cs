namespace Lab5.Entities
{
    public interface IAirportArtifact
    {
        public int Id { get; set; }
        public bool IsFree { get; set; }
        public Plane Plane { get; set; }
    }
}
