using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class Camera 
    {
        //define class member variables
        private Vector2 cameraPos;

        //define class methods

        public Vector2 GetCameraPos()
        {
            return cameraPos;
        }

        public void SetCameraPos(Vector2 newCameraPos)
        {
            cameraPos = newCameraPos;
        }
    }
}
