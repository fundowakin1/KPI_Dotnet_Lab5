using Lab5.DispatcherServices;
using Lab5.Entities;
using Lab5.Enums;
using Lab5.Loggers;

namespace Lab5.Builders
{
    public class AirportBuilder : IAirportBuilder
    {
        private Airport _airport = new Airport();

        public void Reset()
        {
            _airport = new Airport();
        }
        public Airport GetAirport()
        {
            return _airport;
        }

        public void BuildRunway(int quantity)
        {
            for (var i = 0; i < quantity; i++)
                _airport.Runways.Add(new Runway(i));
        }

        public void BuildPlane(int quantity, ILogger logger)
        {
            for (var i = 0; i < quantity; i++)
                _airport.Planes.Add(new Plane(i, logger));
        }

        public void BuildTerminal(int quantity)
        {
            for (var i = 0; i < quantity; i++)
                _airport.Terminals.Add(new Terminal(i));
        }

        public void ChangeTerminalOccupation(Plane plane, Terminal terminal)
        {
            plane.PlaneFlight.Pop();
            if (terminal.IsFree)
            {
                terminal.Plane = plane;
                plane.State = PlaneState.InTerminal;
            }
            else
            {
                terminal.Plane = null;
                plane.State = PlaneState.InAir;
            }
            plane.PlaneFlight.Push(plane.State);
            terminal.IsFree = !terminal.IsFree;
        }

        public void ChangeRunwayOccupation(Plane plane, Runway runway)
        {
            if (runway.IsFree)
            {
                runway.Plane = plane;
                plane.State = PlaneState.UsingRunway;
            }
            else
            {
                runway.Plane = null;
                plane.State = PlaneState.InAir;
            }
            plane.PlaneFlight.Push(plane.State);
            runway.IsFree = !runway.IsFree;
        }
    }
}
