namespace Tote.Contracts;

public class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class EventRoutes
    {
        public const string GetEventById = Base + "/events/{EventId}";
        public const string CreateEvent = Base + "/events";
        public const string UpdateEvent = Base + "/events";
        public const string DeleteEvent = Base + "/events/{EventId}";
    }

    public static class SportTypes
    {
        public const string GetSportTypeById = Base + "/sportTypes/{SportTypeId}";
        public const string CreatesportType = Base + "/sportTypes";
        public const string UpdateSportType = Base + "/sportTypes";
        public const string DeleteSportType = Base + "/sportTypes/{SportTypeId}";
    }

    public static class OutcomeBlocks
    {
        public const string GetOutcomeBlockById = Base + "/outcomeBlocks/{OutcomeBlockId}";
        public const string CreateOutcomeBlock = Base + "/outcomeBlocks";
        public const string UpdateOutcomeBlock = Base + "/outcomeBlocks";
        public const string DeleteOutcomeBlock = Base + "/outcomeBlocks/{OutcomeBlockId}";
        public const string GetOutcomeBlockMarkets = Base + "/outcomeBlocks/{OutcomeBlockId}/markets";
    }

    public static class Markets
    {
        public const string GetMarketById = Base + "/markets/{MarketId}";
        public const string CreateMarket = Base + "/markets";
        public const string UpdateMarket = Base + "/markets";
        public const string DeleteMarket = Base + "/markets/{MarketId}";
        public const string GetMarketOutcomes = Base + "/markets/{MarketId}";
    }

    public static class Outcomes
    {
        public const string GetOutcomeById = Base + "/outcomes/{OutcomeId}";
        public const string CreateOutcome = Base + "/outcomes";
        public const string UpdateOutcome = Base + "/outcomes";
        public const string DeleteOutcome = Base + "/outcomes/{OutcomeId}";
    }

    public static class Bets
    {
        public const string GetBetById = Base + "/bets/{BetId}";
        public const string CreateBet = Base + "/bets";
        public const string UpdateBetStatus = Base + "/bets";
        public const string DeleteBet = Base + "/bets/{BetId}";
    }
}
