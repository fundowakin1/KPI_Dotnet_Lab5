using Lab5.Enums;

namespace Lab5.Extensions
{
    public static class StackExtensions
    {
        public static Stack<PlaneState> DeepCopy(this Stack<PlaneState> flight)
        {
            var array = new PlaneState[flight.Count];
            flight.CopyTo(array, 0);
            var reversed = array.Reverse().ToArray();
            return new Stack<PlaneState>(reversed);
        }
    }
}
