using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/bet-limit-object/bet_limit_obj
    /// 
    /// <para>The bet limit object which defines the betting limitations of the game</para>
    /// </summary>
    class BetLimitObject
    {
        /// <summary>
        /// Creates a new instance of a BetLimitObject
        /// </summary>
        /// <param name="betType">The betting type for the game</param>
        /// <param name="betCap">The cap on bets for the game</param>
        public BetLimitObject(EBetType betType, double betCap)
        {
            BetType = betType;
            BetCap = betCap;
        }

        /// <summary>
        /// The betting type for the game
        /// 
        /// <para>One of </para>
        /// <para>- "NL" for No-Limit</para>
        /// <para>- "PL" for Pot Limit</para>
        /// <para>- "FL" for Fixed Limit</para>
        /// </summary>
        [JsonProperty("bet_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EBetType BetType
        {
            get;
            private set;
        }

        /// <summary>
        /// The cap on bets for the game.
        /// 
        /// <para>If the game is not a CAP game then "bet_cap" can either be ommitted, set to null or set to 0.</para>
        /// </summary>
        [JsonProperty("bet_cap")]
        public double? BetCap
        {
            get;
            private set;
        }

        public enum EBetType
        {
            NL,
            PL,
            FL
        }
    }
}
