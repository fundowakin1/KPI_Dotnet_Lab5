using Lab5.Entities;
using Lab5.Enums;
using Lab5.Extensions;

namespace Lab5.SimulationServices
{
    public class EventGenerator
    {
        private readonly Random _random = new Random();
        private readonly Airport _airport;

        public EventGenerator(Airport airport)
        {
            _airport = airport;
        }
        public Plane GetNextPlane()
        {
            return _airport.Planes[_random.Next(_airport.Planes.Count)];
        }

        public void GenerateEvent(Plane plane)
        {
            switch (plane.State)
            {
                case PlaneState.InTerminal:
                    plane.PrepareToUseRunway();
                    break;
                case PlaneState.WaitingForTerminal:
                    plane.PrepareToTerminal();
                    break;
                case PlaneState.UsingRunway:
                    UsingRunwayEvent(plane);
                    break;
                case PlaneState.WaitingForRunway:
                    plane.PrepareToUseRunway();
                    break;
                case PlaneState.InAir:
                    plane.PrepareToUseRunway();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UsingRunwayEvent(Plane plane)
        {
            var planeFlight = plane.PlaneFlight.DeepCopy();
            var previousState = planeFlight.Pop();
            while (planeFlight.Any())
            {
                previousState = planeFlight.Pop();
                if (previousState != PlaneState.WaitingForRunway)
                    break;
            }
            if (previousState == PlaneState.InAir)
                plane.PrepareToTerminal();
            else
                plane.FlyOut();
        }
    }
}
