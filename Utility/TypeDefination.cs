using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public enum ShootingType
    {
        Default = 0, // two lines ||
        LightDisperse = 1,  // 4 lines \||/
        MidDeiperse = 2,   // 6 lines \\||//
        HeavyDeiperse = 3 // 8 lines   \\||||//
    }
    public enum PlayerDirection
    {
        None = 0,  
        Left,               //
        Right,            //
        Up,              //
        Down,        //
        UpLeft,        
        UpRight,
        DownLeft, 
        DownRight
    }
}
