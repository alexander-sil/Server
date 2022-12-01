using Server.Enums;
using System;

namespace Server.Models
{
    public class EntryInModel
    {
        public StateEnum State;

        public string Name { get; set; }

        public uint Quantity { get; set; }

        public string Unit { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }
    }
}

