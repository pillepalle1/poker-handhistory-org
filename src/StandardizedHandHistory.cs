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
    class StandardizedHandHistory
    {
        private const string SPECIFICATION_VERSION = "1.0.0";
        private const string SPECIFICATION_INTERNAL_VERSION = "1.0.5";

        /// <summary>
        /// A string with information describing the version of the specification.
        /// </summary>
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
        public string Site
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the network that the client site belongs to.
        /// </summary>
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
        public TournamentInfoObject TournamentInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// The game number or other identifier that uniquely identifies the hand on the network.
        /// </summary>
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
        public string GameType
        {
            get;
            private set;
        }

        /// <summary>
        /// The limitations on the betting for the game.
        /// </summary>
        public string Limit
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
        public string TableSize
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
        public string Currency
        {
            get;
            private set;
        }

        /// <summary>
        /// The seat number of the button.
        /// </summary>
        public int DealerSeat
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of the small blind (in the currency specified).
        /// </summary>
        public double SmallBlindAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of the big blind (in the currency specified).
        /// </summary>
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
        public double? Ante
        {
            get;
            private set;
        }

        /// <summary>
        /// The Id of the player (from the list of players in the player list) that is the hero.
        /// </summary>
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
        public string[] Flags
        {
            get;
            private set;
        }

        /// <summary>
        /// An array of <player_obj> objects for all of the players dealt into the hand.
        /// </summary>
        public PlayerObject[] Players
        {
            get;
            private set;
        }

        /// <summary>
        /// An array of <round_obj> objects betting rounds that occurred within the hand.
        /// Every hand must have one round 0 (Pre-Flop) and one round 4 (Showdown).
        /// </summary>
        public RoundObject[] BettingRounds
        {
            get;
            private set;
        }

        /// <summary>
        /// The pots and pot results for the hand.
        /// </summary>
        public PlayerObject[] Pots
        {
            get;
            private set;
        }

        /// <summary>
        /// The re-buys, add-ons and re-entries that occurred within the hand.
        /// 
        /// <para>For tournaments and sit n' go's only.  Omit for cash games.</para>
        /// </summary>
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
        public TournamentBountyObject[] Bounties
        {
            get;
            private set;
        }
    }
}
