﻿
using System;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Map;

namespace eZet.Eve.EoLib.Entity {
    public class Map : BaseEntity {
        protected override sealed string UriBase { get; set; }

        internal Map() {
            UriBase = "https://api.eveonline.com";
        }

        /// <summary>
        /// Returns a list of contestable solarsystems and the NPC faction currently occupying them.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<FacWarSystems> GetFactionWarSystems() {
            const string path = "/map/FacWarSystems.xml.aspx";
            return request(path, new FacWarSystems());
        }

        /// <summary>
        /// Returns all possible stargate jumps.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<Jumps> GetJumps() {
            const string path = "/map/Jumps.xml.aspx";
            return request(path, new Jumps());
        }

        /// <summary>
        /// Returns the number of kills in solarsystems within the last hour. Only solar system where kills have been made are listed.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<Kills> GetKills() {
            const string path = "/map/Kills.xml.aspx";
            return request(path, new Kills());
        }

        /// <summary>
        /// Returns a list of solarsystems and what faction or alliance controls them.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<Sovereignty> GetSovereignty() {
            const string path = "/map/Sovereignty.xml.aspx";
            return request(path, new Sovereignty());
        }

        /// <summary>
        /// Returns a list of all sovereignty structures in EVE.
        /// </summary>
        public void GetSovereigntyStatus() {
            throw new NotImplementedException();
            // Temporarily disabled by CCP
        }



    }
}