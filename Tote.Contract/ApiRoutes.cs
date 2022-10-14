namespace Tote.Contracts;

public class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class EventRoutes
    {
        public const string GetEventById = Base + "/events/{id}";
        public const string CreateEvent = Base + "/events";
        public const string UpdateEvent = Base + "/events";
        public const string DeleteEvent = Base + "/events/{id}";
    }

    public static class SportTypes
    {
        public const string GetSportTypeById = Base + "/sportTypes/{id}";
        public const string CreatesportType = Base + "/sportTypes";
        public const string UpdateSportType = Base + "/sportTypes";
        public const string DeleteSportType = Base + "/sportTypes/{id}";
    }

    public static class OutcomeBlocks
    {
        public const string GetOutcomeBlockById = Base + "/outcomeBlocks/{id}";
        public const string CreateOutcomeBlock = Base + "/outcomeBlocks";
        public const string UpdateOutcomeBlock = Base + "/outcomeBlocks";
        public const string DeleteOutcomeBlock = Base + "/outcomeBlocks/{id}";
        public const string GetOutcomeBlockMarkets = Base + "/outcomeBlocks/{id}/markets";
    }

    public static class Markets
    {
        public const string GetMarketById = Base + "/markets/{id}";
        public const string CreateMarket = Base + "/markets";
        public const string UpdateMarket = Base + "/markets";
        public const string DeleteMarket = Base + "/markets/{id}";
        public const string GetMarketOutcomes = Base + "/markets/{id}/outcomes";
    }

    public static class Outcomes
    {
        public const string GetOutcomeById = Base + "/outcomes/{id}";
        public const string CreateOutcome = Base + "/outcomes";
        public const string UpdateOutcome = Base + "/outcomes";
        public const string DeleteOutcome = Base + "/outcomes/{id}";
    }

    public static class Bets
    {
        public const string GetBetById = Base + "/bets/{id}";
        public const string CreateBet = Base + "/bets";
        public const string UpdateBetStatus = Base + "/bets";
        public const string DeleteBet = Base + "/bets/{id}";
    }
}
