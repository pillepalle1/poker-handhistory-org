using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/round-object/round_obj
    /// 
    /// <para>The round object defining the betting rounds that occurred during the hand</para>
    /// </summary>
    class RoundObject
    {
        /// <summary>
        /// Creates a new RoundObject
        /// </summary>
        /// <param name="id">The incrementing id of the round specifying the order of the rounds.</param>
        /// <param name="street">The name of the street/round</param>
        /// <param name="cards">The card(s) added to the board during the round</param>
        /// <param name="actions">Actions performed in the round</param>
        public RoundObject(int id, EStreet street, string[] cards, ActionObject[] actions)
        {
            Id = id;
            Street = street;
            Cards = cards ?? new string[] { };
            Actions = actions;
        }

        /// <summary>
        /// The round identifier that is an integer and increments for each successive round (specifying the order of rounds)
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the street or round
        /// <para>- "preflop"</para>
        /// <para>- "flop"</para>
        /// <para>- "turn"</para>
        /// <para>- "river"</para>
        /// <para>- "showdown"</para>
        /// <para>The street does not need to be unique in the rounds array.</para>
        /// <para>For instance, there will be two round objects with different id's that are both "flop" for run it twice hands.</para>
        /// <para>The round id specifies the order that the round occurred.</para>
        /// </summary>
        [JsonProperty("street")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EStreet Street
        {
            get;
            private set;
        }

        /// <summary>
        /// The card(s) added to the board during the round.
        /// <para>If the betting round adds no cards to the board then leave the array empty</para>
        /// </summary>
        [JsonProperty("cards")]
        public string[] Cards
        {
            get;
            private set;
        }

        /// <summary>
        /// An array of ActionObjects outlining the actions performed within the round in the order that they were performed.
        /// <para>Maining the order of the actions is important.</para>
        /// <para>The first action should be in array position 0, the second action in array position 1, etc.</para>
        /// </summary>
        [JsonProperty("actions")]
        public ActionObject[] Actions
        {
            get;
            private set;
        }

        public enum EStreet
        {
            preflop,
            flop,
            turn,
            river,
            showdown
        }
    }
}
