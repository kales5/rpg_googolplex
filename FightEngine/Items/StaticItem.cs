
using System;

namespace FightEngine.Items
{
    public class StaticItem : Item
    {
        public CharacterAttributes AttributesEffekts { get; set; }
        public CharacterFluentAttributes FluentAttributesEffekts { get; set; }

        public StaticItem()
        {
            AttributesEffekts = new CharacterAttributes();
            FluentAttributesEffekts = new CharacterFluentAttributes();
        }   
    }
}
