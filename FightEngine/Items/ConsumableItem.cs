using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Items
{
    public class ConsumableItem : Item
    {
        public CharacterFluentAttributes FluentAttributesEffekts { get; set; }

        public void Apply(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
