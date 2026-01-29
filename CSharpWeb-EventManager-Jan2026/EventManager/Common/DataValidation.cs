namespace EventManager.Common
{
    public static class DataValidation
    {
        public static class Event
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 100;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 1000;

            public const int MinParticipantsValue = 1;
            public const int MaxParticipantsValue = 500;
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class Registration
        {
            public const int ParticipantNameMinLength = 2;
            public const int ParticipantNameMaxLength = 60;

            public const int EmailMinLength = 5;
            public const int EmailMaxLength = 254;
        }
    }
}
