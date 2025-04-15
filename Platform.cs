using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Platform : Entity
    {
        public Platform(ContentManager cm, Vector2 starterPos) : base(cm, "grass", starterPos, EntityType.Platform)
        {

        }

    }
}
