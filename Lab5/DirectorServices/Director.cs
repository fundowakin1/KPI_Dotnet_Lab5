using Lab5.Builders;
using Lab5.DispatcherServices;
using Lab5.Entities;
using Lab5.Loggers;

namespace Lab5.DirectorServices
{
    public class Director
    {
        private readonly IAirportBuilder _builder;
        public Director(IAirportBuilder builder)
        {
            _builder = builder;
        }

        public void BuildDefaultAirport()
        {
            _builder.BuildPlane(5, new ConsoleLogger());
            _builder.BuildRunway(4);
            _builder.BuildTerminal(4);
            _builder.ChangeTerminalOccupation(_builder.GetAirport().Planes[0], _builder.GetAirport().Terminals[0]);
            _builder.ChangeTerminalOccupation(_builder.GetAirport().Planes[1], _builder.GetAirport().Terminals[1]);
        }

        public Airport GetAirport()
        {
            var result = _builder.GetAirport();
            _builder.Reset();
            return result;
        }
    }
}
