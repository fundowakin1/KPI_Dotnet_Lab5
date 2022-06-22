namespace Lab5.Entities
{
    public class Terminal : IAirportArtifact
    {
        public int Id { get; set; }
        public bool IsFree { get; set; }
        public Plane Plane { get; set; }

        public Terminal(int id)
        {
            Id = id;
            IsFree = true;
        }
    }
}
