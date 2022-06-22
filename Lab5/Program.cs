using Lab5.Builders;
using Lab5.DirectorServices;
using Lab5.DispatcherServices;
using Lab5.Loggers;
using Lab5.SimulationServices;

var builder = new AirportBuilder();
var director = new Director(builder);
director.BuildDefaultAirport();
var airport = director.GetAirport();
var dispatcherService = new DispatcherService(airport, new ConsoleLogger());
var dispatcher = new Dispatcher(dispatcherService);
airport.SetDispatcher(dispatcher);

var simulation = new Simulation(airport, new ConsoleLogger());
simulation.Run(10);

Console.ReadKey();