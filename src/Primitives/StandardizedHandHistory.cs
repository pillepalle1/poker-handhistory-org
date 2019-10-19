using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/json-object/untitled-1
    /// 
    /// <para>Standardized Hand History Specification.</para>
    /// </summary>
    public class StandardizedHandHistory
    {
        private const string SPECIFICATION_VERSION = "1.0.0";
        private const string SPECIFICATION_INTERNAL_VERSION = "1.0.5";

        /// <summary>
        /// Creates a new Standardized Hand History Object
        /// </summary>
        /// <param name="heroPlayerId">The Id of the player (from the list of players in the player list) that is the hero.</param>
        /// <param name="siteName">The name of the poker site.</param>
        /// <param name="networkName">The name of the network that the client site belongs to.</param>
        /// <param name="gameNumber">The game number or other identifier that uniquely identifies the hand on the network.</param>
        /// <param name="gameType">The type of game being played.</param>
        /// <param name="betLimit">The limitations on the betting for the game.</param>
        /// <param name="startDateUtc">The date and time at the start of the hand.</param>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="tableSize">Number of seats at the table that are available for players to be seated.</param>
        /// <param name="dealerSeat">The seat number of the button.</param>
        /// <param name="currency">The currency of the game or tournament buy-in and fee.</param>
        /// <param name="sbAmount">The amount of the small blind (in the currency specified).</param>
        /// <param name="bbAmount">The amount of the big blind (in the currency specified).</param>
        /// <param name="anteAmount">The amount of the ante, for all players, in the currency specified.</param>
        /// <param name="flags">Hand flags that may be relevant. Special characteristics about a hand that may be needed to fully understand the hand. This is easily expanded without hand history format change.</param>
        /// <param name="players">An array of <player_obj> objects for all of the players dealt into the hand.</param>
        /// <param name="rounds">An array of <round_obj> objects betting rounds that occurred within the hand. Every hand must have one round 0 (Pre-Flop) and one round 4 (Showdown).</param>
        /// <param name="pots">The pots and pot results for the hand.</param>
        /// <param name="tournamentInfo">A JSON object collection of tournament specific properties.</param>
        /// <param name="rebuys">The re-buys, add-ons and re-entries that occurred within the hand.</param>
        /// <param name="bounties">Bounties received by a player in the hand.</param>
        public StandardizedHandHistory(
            int heroPlayerId,

            string siteName, 
            string networkName, 
            
            string gameNumber,
            string gameType,
            BetLimitObject betLimit,
            
            DateTime startDateUtc, 
            
            string tableName, 
            int tableSize,
            int dealerSeat,

            string currency, 
            double sbAmount, 
            double bbAmount, 

            double? anteAmount, 

            string[] flags, 

            PlayerObject[] players, 
            RoundObject[] rounds, 
            PotObject[] pots, 

            TournamentInfoObject tournamentInfo = null, 
            TournamentRebuyObject[] rebuys = null, 
            TournamentBountyObject[] bounties = null)
        {
            HeroPlayerId = heroPlayerId;
            Site = siteName;
            Network = networkName;
            GameNumber = gameNumber;
            GameType = gameType;
            Limit = betLimit;
            StartDateUtc = startDateUtc.ToString("o");
            TableName = tableName;
            TableSize = tableSize;
            DealerSeat = dealerSeat;
            Currency = currency;
            SmallBlindAmount = sbAmount;
            BigBlindAmount = bbAmount;
            Ante = anteAmount;
            Flags = flags;

            Players = players;
            BettingRounds = rounds;
            Pots = pots;

            TournamentInfo = tournamentInfo;
            Rebuys = rebuys;
            Bounties = bounties;
        }

        /// <summary>
        /// A string with information describing the version of the specification.
        /// </summary>
        [JsonProperty("spec_version")]
        public string Version
        {
            get
            {
                return SPECIFICATION_VERSION;
            }
        }

        /// <summary>
        /// The name of the poker site.
        /// </summary>
        [JsonProperty("size_name")]
        public string Site
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the network that the client site belongs to.
        /// </summary>
        [JsonProperty("network_name")]
        public string Network
        {
            get;
            private set;
        }

        /// <summary>
        /// The site's internal version of the created hand history.
        /// 
        /// <para>
        /// Any modification to the generated hand history should increment the version.  Even minor bug fixes!
        /// </para>
        /// 
        /// <para>
        /// It is recommended but not required to increment the major and minor versions of the internal_version to match the spec_version and bug fixes increment the patch number.
        /// </para>
        /// </summary>
        [JsonProperty("internal_version")]
        public string InternalVersion
        {
            get
            {
                return SPECIFICATION_INTERNAL_VERSION;
            }
        }

        /// <summary>
        /// A JSON object of tournament specific properties.
        /// 
        /// <para>
        /// Required: cash games=no, optional for tournaments/sit n' go's if applicable.
        /// </para>
        /// </summary>
        [JsonProperty("tournament_info")]
        public TournamentInfoObject TournamentInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// The game number or other identifier that uniquely identifies the hand on the network.
        /// </summary>
        [JsonProperty("game_number")]
        public string GameNumber
        {
            get;
            private set;
        }

        /// <summary>
        /// The date and time at the start of the hand in UTC/GMT.
        /// 
        /// <para>
        /// Format: ISO8601 format. "yyyy-mm-ddThh:mm:ssZ" | See section 5.8 in the RFC: https://tools.ietf.org/html/rfc3339#section-5.8
        /// </para>
        /// </summary>
        [JsonProperty("start_date_utc")]
        public string StartDateUtc
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the table
        /// 
        /// <para>
        /// If your site intends to allow Head-Up Displays, the table_name must also be available either directly in the window title 
        /// or easily computed based on the window title to uniquely identify the table window with the hand history.
        /// </para>
        /// 
        /// </summary>
        [JsonProperty("table_name")]
        public string TableName
        {
            get;
            private set;
        }

        /// <summary>
        /// The type of game being played.
        /// 
        /// <para>Holdem | Omaha | OmahaHiLo | Stud | StudHiLo | Draw</para>
        /// 
        /// <para>
        /// If your network spreads a game type that is not supported, please see the Change Request Process to learn how to submit your 
        /// request to have the game_type added to the specification, at which point, we'll add it and increment the spec_version number 
        /// to support the new game type.
        /// </para>
        /// </summary>
        [JsonProperty("game_type")]
        public string GameType
        {
            get;
            private set;
        }

        /// <summary>
        /// The limitations on the betting for the game.
        /// </summary>
        [JsonProperty("bet_limit")]
        public BetLimitObject Limit
        {
            get;
            private set;
        }

        /// <summary>
        /// Number of seats at the table that are available for players to be seated.
        /// 
        /// <para>
        /// Number of seats at the table that are available for players to be seated.
        /// </para>
        /// 
        /// <para>
        /// Format: Integer from 2 to 10 seats
        /// </para>
        /// </summary>
        [JsonProperty("table_size")]
        public int TableSize
        {
            get;
            private set;
        }

        /// <summary>
        /// The currency of the game or tournament buy-in and fee.
        /// 
        /// <para>"PPC" - Poker play coin (play money | "XSC" - PokerStars coin</para>
        /// 
        /// <para>
        /// If your site uses a coin specific to your site that has value and is not considered play money 
        /// then please see the Change Request Process to learn how to submit your coin for inclusion in the specification 
        /// at which point we will include it and increase the specification's version number.  Your site specific coin 
        /// should be three characters and not conflict with any existing currencies.
        /// </para>
        /// </summary>
        [JsonProperty("curency")]
        public string Currency
        {
            get;
            private set;
        }

        /// <summary>
        /// The seat number of the button.
        /// </summary>
        [JsonProperty("dealer_seat")]
        public int DealerSeat
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of the small blind (in the currency specified).
        /// </summary>
        [JsonProperty("small_blind_amount")]
        public double SmallBlindAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of the big blind (in the currency specified).
        /// </summary>
        [JsonProperty("big_blind_amount")]
        public double BigBlindAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of the ante, for all players, in the currency specified.
        /// 
        /// <para>if the game does not have antes then "ante_amount" can either be ommitted, set to null or set to 0.</para>
        /// </summary>
        [JsonProperty("ante_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? Ante
        {
            get;
            private set;
        }

        /// <summary>
        /// The Id of the player (from the list of players in the player list) that is the hero.
        /// </summary>
        [JsonProperty("hero_player_id")]
        public int HeroPlayerId
        {
            get;
            private set;
        }

        /// <summary>
        /// Hand flags that may be relevant. Special characteristics about a hand that may be needed to fully understand 
        /// the hand. This is easily expanded without hand history format change.
        /// 
        /// <para>"RUN_IT_TWICE": Two sets of board cards are used in the play of the same hand.</para>
        /// <para>"ANONYMOUS": The players at the table are all anonymous players and do not have a specified name or ID associated with them for historical records.</para>
        /// <para>"OBSERVED": The hand was observed and the hero was not dealt into the hand.</para>
        /// <para>"FAST":  Fast poker game.Any fast fold variant where once you fold you immediately move to the next hand.</para>
        /// <para>"CAP": A game that limits the amount that each player can wager per hand.</para>
        /// 
        /// <para>
        /// If you need to flag a hand that is currently not an option then please see the Change Request Process to learn how to submit your request for inclusion in the 
        /// specification at which point we will add it and increase the specification version number.
        /// </para>
        /// </summary>
        [JsonProperty("flags")]
        public string[] Flags
        {
            get;
            private set;
        }

        /// <summary>
        /// An array of <player_obj> objects for all of the players dealt into the hand.
        /// </summary>
        [JsonProperty("players")]
        public PlayerObject[] Players
        {
            get;
            private set;
        }

        /// <summary>
        /// An array of <round_obj> objects betting rounds that occurred within the hand.
        /// Every hand must have one round 0 (Pre-Flop) and one round 4 (Showdown).
        /// </summary>
        [JsonProperty("rounds")]
        public RoundObject[] BettingRounds
        {
            get;
            private set;
        }

        /// <summary>
        /// The pots and pot results for the hand.
        /// </summary>
        [JsonProperty("pots")]
        public PotObject[] Pots
        {
            get;
            private set;
        }

        /// <summary>
        /// The re-buys, add-ons and re-entries that occurred within the hand.
        /// 
        /// <para>For tournaments and sit n' go's only.  Omit for cash games.</para>
        /// </summary>
        [JsonProperty("tournament_rebuys")]
        public TournamentRebuyObject[] Rebuys
        {
            get;
            private set;
        }

        /// <summary>
        /// Bounties received by a player in the hand.
        /// 
        /// <para>For tournaments and sit n' go's only.  Omit for cash games.</para>
        /// </summary>
        [JsonProperty("tournament_bounties")]
        public TournamentBountyObject[] Bounties
        {
            get;
            private set;
        }
    }
}
