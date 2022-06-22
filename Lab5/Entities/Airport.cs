using System.Text;
using Lab5.DispatcherServices;

namespace Lab5.Entities
{
    public class Airport
    {
        public List<Terminal> Terminals { get; set; } = new List<Terminal>();
        public List<Runway> Runways { get; set; } = new List<Runway>();
        public List<Plane> Planes { get; set; } = new List<Plane>();

        public void SetDispatcher(IDispatcher dispatcher)
        {
            Planes.ForEach(plane => plane.SetDispatcher(dispatcher));
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendLine($"Terminals:");
            foreach (var terminal in Terminals)
            {
                str.AppendLine($"\tTerminal-{terminal.Id} is Free = {terminal.IsFree}");
            }
            str.AppendLine();

            str.AppendLine($"Runways:");
            foreach (var runway in Runways)
            {
                str.AppendLine($"\tRunway-{runway.Id} is Free = {runway.IsFree}");
            }
            str.AppendLine();

            str.AppendLine("Planes:");
            foreach (var plane in Planes)
            {
                str.AppendLine(plane.ToString());
            }

            return str.ToString();
        }
    }
}
