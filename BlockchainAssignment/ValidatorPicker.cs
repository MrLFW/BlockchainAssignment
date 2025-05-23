﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockchainAssignment
{
    public static class ValidatorPicker
    {
        private static readonly Random random = new Random();
        public static string Pick(Dictionary<string, double> stakes)
        {
            if (stakes == null || stakes.Count == 0)
                throw new ArgumentException("Stakes dictionary cannot be null or empty.");

            double totalStake = stakes.Values.Sum();
            if (totalStake <= 0)
                throw new InvalidOperationException("Total stake must be positive to select a validator.");

            // Shuffle the stakes to remove any order bias
            var shuffledStakes = stakes.OrderBy(_ => random.Next()).ToList();

            // Generate a random value in [0, totalStake)
            double sample = random.NextDouble() * totalStake;
            double cumulative = 0;

            foreach (var kvp in shuffledStakes)
            {
                cumulative += kvp.Value;
                if (cumulative >= sample)
                    return kvp.Key;
            }

            return shuffledStakes.Last().Key;
        }
    }
}
