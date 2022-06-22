using System.Text;
using Lab5.DispatcherServices;
using Lab5.Enums;
using Lab5.Loggers;

namespace Lab5.Entities
{
    public class Plane
    {
        private readonly ILogger _logger;
        private IDispatcher _dispatcher;
        public int Id { get; set; }
        public PlaneState State { get; set; }
        public Stack<PlaneState> PlaneFlight { get; set; }
        public Plane(int id, ILogger logger)
        {
            _logger = logger;
            Id = id;
            PlaneFlight = new Stack<PlaneState>();
            State = PlaneState.InAir;
            PlaneFlight.Push(State);
        }
        public void PrepareToUseRunway()
        {
            _logger.Info($"PLANE [{Id}] --- \tneeds a Runway");
            _dispatcher.Notify(this, PlaneState.UsingRunway);
            
        }

        public void PrepareToTerminal()
        {
            _logger.Info($"PLANE [{Id}] --- \tneeds a Terminal");
            _dispatcher.Notify(this, PlaneState.InTerminal);
        }

        public void GetPermissionForRunway(Runway runway)
        {
            State = PlaneState.UsingRunway;
            PlaneFlight.Push(State);
            _logger.Info($"PLANE [{Id}] --- \tis using a RUNWAY-{runway.Id}");
        }

        public void GetPermissionForTerminal(Terminal terminal)
        {
            State = PlaneState.InTerminal;
            PlaneFlight.Push(State);
            _logger.Info($"PLANE [{Id}] --- \tis using a TERMINAL-{terminal.Id}");
        }

        public void GetDenialForTerminal()
        {
            State = PlaneState.WaitingForTerminal;
            PlaneFlight.Push(State);
            _logger.Info($"PLANE [{Id}] --- \tis waiting for a Terminal");
        }

        public void GetDenialForRunway()
        {
            State = PlaneState.WaitingForRunway;
            PlaneFlight.Push(State);
            _logger.Info($"PLANE [{Id}] --- \tis waiting for a Runway");
        }
        public void FlyOut()
        {
            State = PlaneState.InAir;
            PlaneFlight.Push(State);
            _dispatcher.Notify(this, State);
            _logger.Info($"PLANE [{Id}] --- \tis departed");
        }

        public void SetDispatcher(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendLine($"\tPLANE [{Id + 1}] --- Currently: {State}");
            foreach (var state in PlaneFlight)
            {
                str.Append($" {state} <-- ");
            }

            str.AppendLine();
            return str.ToString();
        }
    }
}
