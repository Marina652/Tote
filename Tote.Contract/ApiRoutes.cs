namespace Tote.Contracts;

public class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class EventRoutes
    {
        public const string GetEventById = Base + "/event/{EventId}";
        public const string CreateEvent = Base + "/event";
        public const string UpdateEvent = Base + "/event";
        public const string DeleteEvent = Base + "/event/{EventId}";
    }

    public static class SportType
    {
        public const string GetSportTypeById = Base + "/sportType/{SportTypeId}";
        public const string CreatesportType = Base + "/sportType";
        public const string UpdateSportType = Base + "/sportType";
        public const string DeleteSportType = Base + "/sportType/{SportTypeId}";
    }

    public static class OutcomeBlock
    {
        public const string GetOutcomeBlockById = Base + "/outcomeBlock/{OutcomeBlockId}";
        public const string CreateOutcomeBlock = Base + "/outcomeBlock";
        public const string UpdateOutcomeBlock = Base + "/outcomeBlock";
        public const string DeleteOutcomeBlock = Base + "/outcomeBlock/{OutcomeBlockId}";
    }

    public static class Market
    {
        public const string GetMarketById = Base + "/market/{MarketId}";
        public const string CreateMarket = Base + "/market";
        public const string UpdateMarket = Base + "/market";
        public const string DeleteMarket = Base + "/market/{MarketId}";
    }
}
