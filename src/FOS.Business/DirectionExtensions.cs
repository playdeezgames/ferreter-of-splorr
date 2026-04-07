using FOS.Data;

namespace FOS.Business
{
    public static class DirectionExtensions
    {
        public static string GetName(this Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => "North",
                Direction.SOUTH => "South",
                Direction.EAST => "East",
                Direction.WEST => "West",
                _ => throw new NotImplementedException(),
            };
        }
    }
}
