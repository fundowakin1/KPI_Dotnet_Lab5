using Lab5.DispatcherServices;
using Lab5.Entities;
using Lab5.Loggers;

namespace Lab5.Builders
{
    public interface IAirportBuilder
    {
        public Airport GetAirport();
        public void BuildRunway(int quantity);
        public void BuildPlane(int quantity, Ilogger logger);
        public void BuildTerminal(int quantity);
        public void ChangeTerminalOccupation(Plane plane, Terminal terminal);
        public void ChangeRunwayOccupation(Plane plane, Runway runway);
        public void Reset();
    }
}
