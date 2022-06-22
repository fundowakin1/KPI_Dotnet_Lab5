using Lab5.Entities;
using Lab5.Enums;

namespace Lab5.DispatcherServices
{
    public interface IDispatcher
    {
        public void Notify(Plane senderPlane, PlaneState nextState);
    }
}
