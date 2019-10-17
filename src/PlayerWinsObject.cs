using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/player-wins-object/player_wins_obj
    /// 
    /// <para>The object defining the win amount of the players in a pot</para>
    /// </summary>
    class PlayerWinsObject
    {
        /// <summary>
        /// Creates a new PlayerWinsObject
        /// </summary>
        /// <param name="playerId">The unique player identifier of the player involved in the pot</param>
        /// <param name="winAmount">The amount the player won in the pot</param>
        /// <param name="contributedRake">The amount of rake the player contributed to the rake from the pot</param>
        public PlayerWinsObject(int playerId, double winAmount, double contributedRake)
        {
            PlayerId = playerId;
            WinAmount = winAmount;
            RakeContributed = contributedRake;
        }

        /// <summary>
        /// The unique player identifier of the player involved in the pot as defined in the PlayerObject
        /// </summary>
        [JsonProperty("player_id")]
        public int PlayerId
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount the player won in the pot
        /// </summary>
        [JsonProperty("win_amount")]
        public double WinAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of rake the player contributed to the rake from the pot
        /// </summary>
        [JsonProperty("contributed_rake")]
        public double RakeContributed
        {
            get;
            private set;
        }
    }
}
