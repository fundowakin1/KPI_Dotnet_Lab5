namespace Lab5.Entities
{
    public class Runway : IAirportArtifact
    {
        public int Id { get; set; }
        public bool IsFree { get; set; }
        public Plane Plane { get; set; }

        public Runway(int id)
        {
            Id = id;
            IsFree = true;
        }
    }
}
