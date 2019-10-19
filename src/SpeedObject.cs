using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poker_handhistory_org
{
    /// <summary>
    /// Implementation of https://hh-specs.handhistory.org/speed-object/speed_obj
    /// 
    /// <para>
    /// Speed.
    /// </para>
    /// </summary>
    class SpeedObject
    {
        /// <summary>
        /// Speed.
        /// </summary>
        /// <param name="type">The description at which the speed of the blinds increase.</param>
        /// <param name="roundTime">The amount of time (in seconds) between blinds increases.</param>
        public SpeedObject(string type, int roundTime)
        {
            this.TournamentType = type;
            this.RoundTime = roundTime;
        }

        /// <summary>
        /// The description at which the speed of the blinds increase. Classification of the speed is at the site/network's discretion.
        /// 
        /// <para>
        /// "NORMAL" | "SEMI-TURBO" | "TURBO" | SUPER-TURBO" | "HYPER-TURBO" | "ULTRA-TURBO"
        /// </para>
        /// </summary>
        [JsonProperty("type")]
        public string TournamentType
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of time (in seconds) between blinds increases.
        /// </summary>
        [JsonProperty("round_time")]
        public int RoundTime
        {
            get;
            private set;
        }
    }
}
