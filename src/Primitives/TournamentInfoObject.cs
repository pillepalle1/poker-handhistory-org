using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/tournament-info-object/tournament_info_obj
    /// 
    /// <para>The object defining the tournament</para>
    /// </summary>
    public class TournamentInfoObject
    {
        /// <summary>
        /// Creates a new TournamentInfoObject
        /// </summary>
        /// <param name="tournamentNumber">The tournament number as specified by the site.</param>
        /// <param name="name">The name of the tournament.</param>
        /// <param name="startDateUtc">The start date and time of the tournament in UTC/GMT</param>
        /// <param name="currency">The currency of the tournament buy-in and fee.</param>
        /// <param name="buyinAmount">The buy-in amount for the tournament (as specified in currency).</param>
        /// <param name="feeAmount">The fee paid to buy-in to the tournament (as specified in currency).</param>
        /// <param name="bountyFeeAmount">The fee paid for the player's tournament bounty.</param>
        /// <param name="initialStack">The number of chips provided to the player to start the tournament.</param>
        /// <param name="type">The type of the tournament - single or multi-table (STT, MTT)</param>
        /// <param name="flags">Descriptive properties of the tournament.</param>
        /// <param name="speed">The speed the blinds increase in the tournament.</param>
        public TournamentInfoObject(
            string tournamentNumber, 
            string name, 
            DateTime startDateUtc, 
            string currency, 
            double buyinAmount, 
            double feeAmount, 
            double bountyFeeAmount, 
            int initialStack, 
            string type, 
            string[] flags, 
            object[] speed)
        {
            TournamentNumber = tournamentNumber;
            Name = name;
            Currency = currency;
            BuyinAmount = buyinAmount;
            FeeAmount = feeAmount;
            BountyFeeAmount = bountyFeeAmount;
            InitialStack = initialStack;
            TournamentType = type;
            Flags = flags;
            Speed = speed;

            // As per https://stackoverflow.com/questions/114983/given-a-datetime-object-how-do-i-get-an-iso-8601-date-in-string-format
            StartDate = startDateUtc.ToString("o");
        }

        /// <summary>
        /// The tournament number as specified by the site.
        /// </summary>
        [JsonProperty("tournament_number")]
        public string TournamentNumber
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the tournament.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// The start date and time of the tournament in UTC/GMT.
        /// 
        /// <para>ISO8601 format. "yyyy-mm-ddThh:mm:ssZ"</para>
        /// </summary>
        [JsonProperty("start_date_utc")]
        public string StartDate
        {
            get;
            private set;
        }

        /// <summary>
        /// The currency of the tournament buy-in and fee. (ISO4217 currency code)
        /// 
        /// <para>
        /// If your site uses a coin specific to your site that has value and is not considered play money then 
        /// please see the Change Request Process to learn how to submit your coin for inclusion in the specification 
        /// at which point we will include it and increase the specification's version number.
        /// 
        /// Your site specific coin should be three characters and not conflict with any existing currencies.
        /// </para>
        /// </summary>
        [JsonProperty("currency")]
        public string Currency
        {
            get;
            private set;
        }

        /// <summary>
        /// The buy-in amount for the tournament (as specified in currency).
        /// </summary>
        [JsonProperty("buyin_amount")]
        public double BuyinAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// The fee paid to buy-in to the tournament (as specified in currency).
        /// </summary>
        [JsonProperty("fee_amount")]
        public double FeeAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// The fee paid for the player's tournament bounty.
        /// </summary>
        [JsonProperty("bounty_fee_amount")]
        public double BountyFeeAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// The number of chips provided to the player to start the tournament.
        /// 
        /// <para>The integer should not be formatted.  No thousands separators, etc.</para>
        /// </summary>
        [JsonProperty("initial_stack")]
        public int InitialStack
        {
            get;
            private set;
        }

        /// <summary>
        /// The type of the tournament - single or multi-table.
        /// <para>"STT": Single table tournament</para>
        /// <para>"MTT": Multi-table tournament</para>
        /// </summary>
        [JsonProperty("type")]
        public string TournamentType
        {
            get;
            private set;
        }

        /// <summary>
        /// <para>"SNG": Sit 'N Go.</para>
        /// <para>"DON": Double or nothing.Half of the players win double their buy-in and half win nothing.</para>
        /// <para>"BOUNTY": Bounty.Players are awarded prizes for knocking out specific players.</para>
        /// <para>"SHOOTOUT": Players' hands are all played face up without betting rounds.</para>
        /// <para>"REBUY": Players are offered the opportunity to rebuy stacks of chips. There are various forms of this that include timed or when a player is felted, or a maximum number of rebuys. Rebuy tournaments where the only option for rebuy comes as the player is felted should be flagged as "RE-ENTRY" instead of rebuy tournaments.</para>
        /// <para>"MATRIX": One buyin is split between multiple games.  Some of the prize pool is awarded for each game while another portion is awarded for the aggregate total placing between the games.</para>
        /// <para>"PUSH_OR_FOLD": For every hand you are required to fold or push all-in.</para>
        /// <para>"SATELLITE": Prize includes entry into another tournament.</para>
        /// <para>"STEPS": Steps tournament where players incrementally gain seats to additional tournaments of greater value.</para>
        /// <para>"DEEP": Deep stack tournament.Starting stacks are more big blinds than a normal tournament starting stack.</para>
        /// <para>"MULTI-ENTRY": Players can have more than a single entry into the same tournament.  It is not synonymous with rebuy tournaments, but rather includes tournaments where a player can have more than a single entry at the beginning of the tournament.</para>
        /// <para>"FIFTY50": Fifty fifty.  Fifty percent of players win a prize.All winners are awarded the same base prize plus an amount based on the number of chips remaining in the player's stack.</para>
        /// <para>"FLIIPOUT": Similiar to a shootout; however, after the first round the remaining play is normal.</para>
        /// <para>"TRIPLEUP": A third of the players win three times their buy-in and the remaining players win nothing.</para>
        /// <para>"LOTTERY": Three person games with accelerated blind level timings and shorter stacks.The prize is randomly chosen before the game begins and only the first place winner gets the prize.</para>
        /// <para>"RE-ENTRY": A player can re-enter a tournament after they are felted.</para>
        /// <para>"POWER_UP": Three person game with special "powers" that are not typically possible in table games.</para>
        /// <para>"PROGRESSIVE-BOUNTY": Same as bounty tournaments except half of the bounty amount goes to the hand winner and the other half of the bounty is added to the winner's bounty.</para>
        /// </summary>
        [JsonProperty("flags")]
        public string[] Flags
        {
            get;
            private set;
        }

        /// <summary>
        /// The speed the blinds increase in the tournament.
        /// </summary>
        [JsonProperty("speed")]
        public object[] Speed
        {
            get;
            private set;
        }
    }
}
