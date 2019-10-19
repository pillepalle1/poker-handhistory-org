using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/pot-object/pot_obj
    /// 
    /// <para>The pot object defining the pot and results for the hand</para>
    /// </summary>
    public class PotObject
    {
        /// <summary>
        /// The pot object defining the pot and results for the hand.
        /// </summary>
        /// <param name="number">Identifier of the pot within the hand</param>
        /// <param name="amount">The total amount in the pot (including rake)</param>
        /// <param name="rake">The amount of rake taken from the pot</param>
        /// <param name="playerWins">The wins for each player involved in the hand</param>
        public PotObject(int number, double amount, double rake, object[] playerWins)
        {
            Number = number;
            Amount = amount;
            Rake = rake;
            PlayerWins = playerWins;
        }

        /// <summary>
        /// An ordered identifier of the pot within the hand
        /// 
        /// <para>The main pot should be 0.  The first side pot would be 1, etc</para>
        /// </summary>
        [JsonProperty("number")]
        public int Number
        {
            get;
            private set;
        }

        /// <summary>
        /// The total amount in the pot (including rake)
        /// </summary>
        [JsonProperty("amount")]
        public double Amount
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount from the pot that was taken for rake
        /// </summary>
        [JsonProperty("rake")]
        public double Rake
        {
            get;
            private set;
        }

        /// <summary>
        /// The wins for each player involved in the hand.
        /// </summary>
        [JsonProperty("player_wins")]
        public object[] PlayerWins
        {
            get;
            private set;
        }
    }
}
