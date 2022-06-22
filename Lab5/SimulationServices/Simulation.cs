using Lab5.Entities;
using Lab5.Loggers;

namespace Lab5.SimulationServices
{
    public class Simulation
    {
        private readonly Airport _airport;
        private readonly EventGenerator _eventGenerator;
        private readonly Ilogger _logger;
        public Simulation(Airport airport, Ilogger logger)
        {
            _airport = airport;
            _eventGenerator = new EventGenerator(airport);
            _logger = logger;
        }

        public void Run(int times)
        {
            var i = 0;
            while (i < times)
            {
                _logger.Info("\n----------------------------------------------------\n");
                var nextPlane = _eventGenerator.GetNextPlane();
                _eventGenerator.GenerateEvent(nextPlane);
                i++;
            }
            _logger.Info("\n----------------------------------------------------\n");
            _logger.Info(_airport.ToString());
        }
    }
}
