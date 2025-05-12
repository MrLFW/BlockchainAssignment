using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainAssignment
{
    public static class StakeValidator
    {
        // Minimum balance required to participate in staking
        private const double MINIMUM_STAKE = 1.0;
        
        // Time in seconds between stakes
        private const int STAKE_TIME_WINDOW = 60;
        
        // Factor to weight stake amount in validation
        private const double STAKE_WEIGHT_FACTOR = 0.1;

        // Verify if an address is eligible to create the next block based on their stake
        //public static bool ValidateStake(string address, double balance, DateTime lastStakeTime, Block block)
        //{
        //    // Check if validator has minimum required stake
        //    if (balance < MINIMUM_STAKE)
        //        return false;

        //    // Calculate time since last stake
        //    TimeSpan coinAge = DateTime.Now - lastStakeTime;
            
        //    // Calculate stake weight
        //    double stakeWeight = CalculateStakeWeight(balance, coinAge);
            
        //    // Generate stake hash
        //    using (var sha256 = SHA256.Create())
        //    {
        //        var input = Encoding.UTF8.GetBytes(address + lastStakeTime.Ticks + stakeWeight);
        //        var hash = sha256.ComputeHash(input);
                
        //        // Convert first 8 bytes to value between 0 and 1
        //        ulong value = BitConverter.ToUInt64(hash, 0);
        //        double normalized = value / (double)ulong.MaxValue;
                
        //        // Higher stake weight = higher chance of being selected
        //        return normalized < (stakeWeight / 100.0);
        //    }
        //}
    }
}
