using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace Utility
{
    public static class GlobalValue
    {
        public static int ScreenWidth = 400;
        public static int ScreenHeight = 800;
        public static int ControlRegionWidth = 400;
        public static int ControlRegionHeight = 200;
        public static float PlayerSpeed = 10;
        public static PlayerDirection CtrlDirection = PlayerDirection.None;
    }

}
