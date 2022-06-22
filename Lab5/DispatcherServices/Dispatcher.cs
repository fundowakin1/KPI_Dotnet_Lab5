using Lab5.Entities;
using Lab5.Enums;
using Lab5.Loggers;

namespace Lab5.DispatcherServices
{
    public class Dispatcher : IDispatcher
    {
        
        private readonly DispatcherService _service;
        public Dispatcher(DispatcherService service)
        {
            _service = service;
        }
        public void Notify(Plane senderPlane, PlaneState nextState)
        {
            switch (nextState)
            {
                case PlaneState.InTerminal:
                case PlaneState.WaitingForTerminal:
                    _service.InTerminalRequest(senderPlane);
                    break;
                case PlaneState.UsingRunway:
                case PlaneState.WaitingForRunway:
                    _service.UsingRunwayRequest(senderPlane);
                    break;
                case PlaneState.InAir:
                    _service.InAirRequest(senderPlane);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(nextState), nextState, null);
            }
        }
    }
}
