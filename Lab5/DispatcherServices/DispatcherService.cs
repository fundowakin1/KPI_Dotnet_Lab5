using Lab5.Entities;
using Lab5.Loggers;

namespace Lab5.DispatcherServices
{
    public class DispatcherService
    {
        public Airport Airport { get; }
        private readonly Ilogger _logger;
        public DispatcherService(Airport airport, Ilogger logger)
        {
            Airport = airport;
            _logger = logger;
        }
        public void InTerminalRequest(Plane senderPlane)
        {
            var terminal = Airport.Terminals.FirstOrDefault(x => x.IsFree);
            if (terminal != null)
            {
                terminal.Plane = senderPlane;
                terminal.IsFree = false;
                _logger.Info($"DISPATCHER --- Found a TERMINAL-{terminal.Id} for PLANE [{senderPlane.Id}]");
                senderPlane.GetPermissionForTerminal(terminal);

                var runway = GetAppropriate(senderPlane, Airport.Runways);
                if (runway == null) return;

                runway!.IsFree = true;
                runway.Plane = null;
                _logger.Info($"DISPATCHER --- RUNWAY-{runway.Id} is free now");
            }
            else
            {
                senderPlane.GetDenialForTerminal();
                _logger.Info($"DISPATCHER --- there is no available Terminals for PLANE [{senderPlane.Id}]");
            }
        }
        public void UsingRunwayRequest(Plane senderPlane)
        {
            var runway = Airport.Runways.FirstOrDefault(x => x.IsFree);
            if (runway != null)
            {
                runway.Plane = senderPlane;
                runway.IsFree = false;
                _logger.Info($"DISPATCHER --- Found a RUNWAY-{runway.Id} for PLANE [{senderPlane.Id}]");
                senderPlane.GetPermissionForRunway(runway);

                var terminal = GetAppropriate(senderPlane, Airport.Terminals);
                if (terminal == null) return;

                terminal!.IsFree = true;
                terminal.Plane = null;
                _logger.Info($"DISPATCHER --- TERMINAL-{terminal.Id} is free now");

            }

            else
                senderPlane.GetDenialForRunway();
        }

        public void InAirRequest(Plane senderPlane)
        {
            var runway = GetAppropriate(senderPlane, Airport.Runways);
            runway!.IsFree = true;
            runway.Plane = null;
        }

        private IAirportArtifact? GetAppropriate(Plane plane, IEnumerable<IAirportArtifact> list)
        {
            return list.Where(item => item.Plane != null).FirstOrDefault(item => item.Plane.Id == plane.Id);
        }
    }
}
