﻿using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Character {
    public class UpcomingCalendarEvents : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Event> Events { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Event {
            [XmlAttribute("eventID")]
            public long EventId { get; set; }

            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            [XmlIgnore]
            public DateTime EventDate { get; private set; }

            [XmlAttribute("eventDate")]
            public string EventDateAsString {
                get { return EventDate.ToString(DateFormat); }
                set { EventDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("eventTitle")]
            public string EventTitle { get; set; }

            [XmlAttribute("duration")]
            public int Duration { get; set; }

            [XmlAttribute("importance")]
            public bool Important { get; set; }

            [XmlAttribute("eventText")]
            public string EventText { get; set; }

            [XmlAttribute("response")]
            public EventResponse Response { get; set; }

        }
    }

            public enum EventResponse {
            Accepted,
            Declined,
            Tentative,
            Undecided
        }
}