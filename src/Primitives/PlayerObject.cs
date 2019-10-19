using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/player-object/player-object-definition
    /// 
    /// <para>The player object defining one of the players dealt into the hand</para>
    /// </summary>
    public class PlayerObject
    {
        /// <summary>
        /// Creates a new player object defining one of the players dealt into the hand
        /// </summary>
        /// <param name="id">Unique identifier WITHIN THE HAND</param>
        /// <param name="seat">The seat number where the player is seated at the table</param>
        /// <param name="name">The name of the player as displayed at the table</param>
        /// <param name="startingStack">The starting stack of the player at the beginning of the hand</param>
        /// <param name="playerBounty">The amount that will be awarded as a bounty to the player that eliminates this player from a tournament</param>
        public PlayerObject(int id, int seat, string name, double startingStack, double? playerBounty)
        {
            Id = id;
            Seat = seat;
            Name = name;
            StartingStack = startingStack;
            Bounty = playerBounty;
        }

        /// <summary>
        /// <para>The unique identifier for the player within the hand</para>
        /// <para>This id is used to identify the player in all other locations of the hand history</para>
        /// <para>This player identifier is hand history specific and does not need to be the same across hand histories</para>
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// The seat number where the player is seated at the table
        /// </summary>
        [JsonProperty("seat")]
        public int Seat
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the player as displayed at the table
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// The starting stack of the player at the beginning of the hand
        /// </summary>
        [JsonProperty("starting_stack")]
        public double StartingStack
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount that will be awarded as a bounty to the player that eliminates this player from a tournament
        /// <para>For bounty tournaments only</para>
        /// </summary>
        [JsonProperty("player_bounty")]
        public double? Bounty
        {
            get;
            private set;
        }
    }
}
