using System;
using System.ComponentModel.DataAnnotations;
using FantasyCritic.Lib.Domain;
using FantasyCritic.Lib.Domain.Requests;
using FantasyCritic.Lib.Domain.ScoringSystems;
using FantasyCritic.Lib.Enums;

namespace FantasyCritic.Web.Models.RoundTrip
{
    public class LeagueYearSettingsViewModel
    {
        public LeagueYearSettingsViewModel()
        {

        }

        public LeagueYearSettingsViewModel(LeagueYear leagueYear)
        {
            LeagueID = leagueYear.League.LeagueID;
            Year = leagueYear.Year;
            LeagueName = leagueYear.League.LeagueName;
            StandardGames = leagueYear.Options.StandardGames;
            GamesToDraft = leagueYear.Options.GamesToDraft;
            CounterPicks = leagueYear.Options.CounterPicks;
            MaximumEligibilityLevel = leagueYear.Options.AllowedEligibilitySettings.EligibilityLevel.Level;
            AllowYearlyInstallments = leagueYear.Options.AllowedEligibilitySettings.YearlyInstallment;
            AllowEarlyAccess = leagueYear.Options.AllowedEligibilitySettings.EarlyAccess;
            AllowFreeToPlay = leagueYear.Options.AllowedEligibilitySettings.FreeToPlay;
            AllowReleasedInternationally = leagueYear.Options.AllowedEligibilitySettings.ReleasedInternationally;
            AllowExpansions = leagueYear.Options.AllowedEligibilitySettings.ExpansionPack;
            DraftSystem = leagueYear.Options.DraftSystem.Value;
            PickupSystem = leagueYear.Options.PickupSystem.Value;
            ScoringSystem = leagueYear.Options.ScoringSystem.Name;
        }

        [Required]
        public Guid LeagueID { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string LeagueName { get; set; }
        [Required]
        public int StandardGames { get; set; }
        [Required]
        public int GamesToDraft { get; set; }
        [Required]
        public int CounterPicks { get; set; }
        [Required]
        public int MaximumEligibilityLevel { get; set; }
        [Required]
        public bool AllowYearlyInstallments { get; set; }
        [Required]
        public bool AllowEarlyAccess { get; set; }
        [Required]
        public bool AllowFreeToPlay { get; set; }
        [Required]
        public bool AllowReleasedInternationally { get; set; }
        [Required]
        public bool AllowExpansions { get; set; }

        [Required]
        public string DraftSystem { get; set; }
        [Required]
        public string PickupSystem { get; set; }
        [Required]
        public string ScoringSystem { get; set; }
        [Required]
        public bool PublicLeague { get; set; }

        public EditLeagueYearParameters ToDomain(FantasyCriticUser manager, EligibilityLevel maximumEligibilityLevel)
        {
            DraftSystem draftSystem = Lib.Enums.DraftSystem.FromValue(DraftSystem);
            PickupSystem pickupSystem = Lib.Enums.PickupSystem.FromValue(PickupSystem);
            ScoringSystem scoringSystem = Lib.Domain.ScoringSystems.ScoringSystem.GetScoringSystem(ScoringSystem);

            EditLeagueYearParameters parameters = new EditLeagueYearParameters(manager, LeagueID, Year, StandardGames, GamesToDraft, CounterPicks,
                maximumEligibilityLevel, AllowYearlyInstallments, AllowEarlyAccess, AllowFreeToPlay, AllowReleasedInternationally, AllowExpansions,
                draftSystem, pickupSystem, scoringSystem, PublicLeague);
            return parameters;
        }
    }
}
