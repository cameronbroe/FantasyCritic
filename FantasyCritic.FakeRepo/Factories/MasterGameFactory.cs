﻿using System;
using System.Collections.Generic;
using System.Linq;
using FantasyCritic.Lib.Domain;
using NodaTime;
using NodaTime.Text;

namespace FantasyCritic.FakeRepo.Factories
{
    internal static class MasterGameFactory
    {
        public static List<MasterGame> GetMasterGames()
        {
            List<MasterGame> games = new List<MasterGame>();

            var sekiro = CreateMasterGame("96f5e8e3-672b-4626-b47e-4bff3a6c4430", "Sekiro: Shadows Die Twice", "2019-03-22", new LocalDate(2019, 3, 22), 6630,
                89.9200m, 2019, 0, false, false, false, false, "Sekiro_art.jpg", "2019-03-20T15:30:00Z", false, "2019-01-22T15:30:00Z");
            games.Add(sekiro);

            return games;
        }

        private static MasterGame CreateMasterGame(string guid, string name, string estimatedReleaseDate, LocalDate? releaseDate, int? openCriticID, decimal? criticScore,
            int minimumReleaseYear, int eligibilityLevelID, bool yearlyInstallment, bool earlyAccess, bool freeToPlay, bool releasedInternationally,
            string boxartFileName, string firstCriticScoreTimestamp, bool doNotRefresh, string addedTimestamp)
        {
            EligibilityLevel eligibilityLevel = EligibilityLevelFactory.GetEligibilityLevels().Single(x => x.Level == eligibilityLevelID);

            var game = new MasterGame(Guid.Parse(guid), name, estimatedReleaseDate, releaseDate, openCriticID,
                criticScore, minimumReleaseYear, eligibilityLevel, yearlyInstallment, earlyAccess, freeToPlay, releasedInternationally, 
                boxartFileName, InstantPattern.ExtendedIso.Parse(firstCriticScoreTimestamp).GetValueOrThrow(), doNotRefresh,
                InstantPattern.ExtendedIso.Parse(addedTimestamp).GetValueOrThrow());

            return game;
        }
    }
}
