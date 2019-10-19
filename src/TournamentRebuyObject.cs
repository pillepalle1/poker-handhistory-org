using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/tournament-rebuy-object/tournament_rebuy_obj
    /// 
    /// <para>An object defining a tournament rebuy, add-on or re-entry.</para>
    /// <para>
    /// This object represents one re-buy, add-on or re-entry.  If there are multiple rebuys, addons or 
    /// re-entries then each one should be represented by this object within the  tournament_rebuys array.
    /// </para>
    /// </summary>
    class TournamentRebuyObject
    {
        /// <summary>
        /// Creates a new TournamentRebuyObject
        /// </summary>
        /// <param name="playerId">Unique player identifier for the player who won the bounty.</param>
        /// <param name="rebuyAction">The type of re-buy, addon or re-entry.</param>
        /// <param name="amount">The total amount of the rebuy action.</param>
        /// <param name="chips">The number of chips received from the rebuy or re-entry.</param>
        public TournamentRebuyObject(int playerId, string rebuyAction, double amount, int chips)
        {
            PlayerId = playerId;
            RebuyAction = rebuyAction;
            Amount = amount;
            Chips = chips;
        }

        /// <summary>
        /// The unique player identifier, as defined in PlayerObject, of the player performing the re-buy, add-on or re-entry.
        /// </summary>
        [JsonProperty("player_id")]
        public int PlayerId
        {
            get;
            private set;
        }

        /// <summary>
        /// The type of re-buy, addon or re-entry
        /// 
        /// <para>
        /// "REBUY"
        /// A player rebuys chips at various points in a tournament.
        /// Typically when their stack is less than the start stack and before the conclusion of the rebuy period.
        /// </para>
        /// 
        /// <para>
        /// "ADDON"
        /// A player adds chips to their stack.
        /// This usually occurs at the end of the rebuy period.
        /// </para>
        /// 
        /// <para>
        /// "REENTRY"
        /// This is similiar to a rebuy, however, it is only available when a player is felted.
        /// </para>
        /// </summary>
        [JsonProperty("rebuy_action")]
        public string RebuyAction
        {
            get;
            private set;
        }

        /// <summary>
        /// The total amount of the rebuy action (in the currency specified for the tournament).
        /// </summary>
        [JsonProperty("amount")]
        public double Amount
        {
            get;
            private set;
        }

        /// <summary>
        /// The number of chips received from the rebuy or re-entry.
        /// </summary>
        [JsonProperty("chips")]
        public int Chips
        {
            get;
            private set;
        }
    }
}
