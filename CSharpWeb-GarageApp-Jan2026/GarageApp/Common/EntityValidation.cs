namespace GarageApp.Common
{
    public static class EntityValidation
    {
        //Car
        public const int CarMakeMinLength = 2;
        public const int CarMakeMaxLength = 70;
        public const int CarModelMinLength = 1;
        public const int CarModelMaxLength = 100;

        //Garage
        public const int GarageNameMinLength = 3;
        public const int GarageNameMaxLength = 50;
        public const int GarageLocationMinLength = 3;
        public const int GarageLocationMaxLength = 150;

    }
}