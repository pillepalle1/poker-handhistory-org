using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/action-object/action_obj
    /// 
    /// <para>The action object defining the action within the round</para>
    /// </summary>
    public class ActionObject
    {
        /// <summary>
        /// Creates a new ActionObject
        /// </summary>
        /// <param name="actionNumber">The order of the action</param>
        /// <param name="playerId">The unique player identifier of the player performing the action</param>
        /// <param name="action">The action performed</param>
        /// <param name="amount">The amount of the action performed</param>
        /// <param name="isAllIn">Denotes whether the player has committed all of their chips to the pot</param>
        /// <param name="cards">The cards involved in the action</param>
        public ActionObject(int actionNumber, int playerId, string action, double amount, bool isAllIn, string[] cards)
        {
            ActionNumber = actionNumber;
            PlayerId = playerId;
            Action = action;
            Amount = amount;
            IsAllIn = isAllIn;
            Cards = cards;
        }

        /// <summary>
        /// <para>An integer that increments with each action in the round</para>
        /// <para>The first action of any round has an action_number of 0 and all susequent actions are sequentially numbered</para>
        /// </summary>
        [JsonProperty("action_number")]
        public int ActionNumber
        {
            get;
            private set;
        }

        /// <summary>
        /// The unique player identifier of the player performing the action as defined in the PlayerObject
        /// </summary>
        [JsonProperty("player_id")]
        public int PlayerId
        {
            get;
            private set;
        }

        /// <summary>
        /// The action performed. Valid values are
        /// 
        /// <para>"Dealt Cards": Player is dealt cards</para>
        /// <para>"Mucks Cards": The player mucks/doesn't show their cards</para>
        /// <para>"Shows Cards": The player shows their cards</para>
        /// <para>"Post Ante": The player posts an ante</para>
        /// <para>"Post SB": The player posts the small blind</para>
        /// <para>"Post BB": The player posts the big blind</para>
        /// <para>"Straddle": The player posts a straddle to buy the button</para>
        /// <para>"Post Dead": The player posts a dead blind</para>
        /// <para>"Post Extra Blind": The player posts any other type of blind</para>
        /// <para>"Fold": The player folds their cards</para>
        /// <para>"Check": The player checks</para>
        /// <para>"Bet": The player bets in an un-bet/unraised pot</para>
        /// <para>"Raise": The player makes a raise</para>
        /// <para>"Call": The player calls a bet/raise</para>
        /// <para>"Added Chips" - Player adds chips to his chip stack (cash game only)</para>
        /// <para>"Sits Down" - Player sits down at a seat</para>
        /// <para>"Stands Up" - Player removes them self from the table</para>
        /// </summary>
        [JsonProperty("action")]
        public string Action
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of the action performed / the total amount put in during this action
        /// 
        /// <para>If a player faces a $50 bet and raises $100 to $150, the amount is $150</para>
        /// </summary>
        [JsonProperty("amount")]
        public double Amount
        {
            get;
            private set;
        }

        /// <summary>
        /// Whether or not the player has committed all of their chips into the pot
        /// </summary>
        [JsonProperty("is_allin")]
        public bool IsAllIn
        {
            get;
            private set;
        }

        /// <summary>
        /// The cards involved in the action.
        /// 
        /// <para>If no cards are involved in the action then the "cards" property should be omitted</para>
        /// </summary>
        [JsonProperty("cards")]
        public string[] Cards
        {
            get;
            private set;
        }
    }
}
