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

        }
    }
}
