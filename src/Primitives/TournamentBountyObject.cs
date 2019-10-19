using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/tournament-bounty-object/tournament_bounty_obj
    /// 
    /// <para>An object defining specific tournament bounties in the tournament.</para>
    /// </summary>
    public class TournamentBountyObject
    {
        /// <summary>
        /// Creates a new instance of a TournamentBountyObject
        /// </summary>
        /// <param name="playerId">Unique player identifier for the player who won the bounty.</param>
        /// <param name="bountyWon">The amount the player won, in the specified tournament currency, by obtaining the bounty.</param>
        /// <param name="defeatedPlayerId">The unique player identifier of the player with the bounty that was eliminated.</param>
        public TournamentBountyObject(int playerId, double bountyWon, int defeatedPlayerId)
        {

        }

        /// <summary>
        /// The unique player identifier, as defined in the players array, of the player who won the bounty.
        /// </summary>
        [JsonProperty("player_id")]
        public int PlayerId
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount the player won, in the specified tournament currency, by obtaining the bounty.
        /// </summary>
        [JsonProperty("bounty_won")]
        public double BountyWon
        {
            get;
            private set;
        }

        /// <summary>
        /// The unique player identifier, as defined in the players array, of the player with the bounty that was eliminated.
        /// </summary>
        [JsonProperty("defeated_player_id")]
        public int DefeatedPlayerId
        {
            get;
            private set;
        }
    }
}
