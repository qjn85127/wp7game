using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Utility
{
    public static class CommonLibiary
    {
        public static Vector2 ConverToRealCoor(Vector2 vectror)
        {
            Vector2 temp = new Vector2();
            temp.X = vectror.Y;
            temp.Y = GlobalValue.ScreenWidth - vectror.X;
            return temp;
        }
        public static Vector2 ConvertToViturialCoor(Vector2 vectror)
        {
            Vector2 temp = new Vector2();
            temp.X = GlobalValue.ScreenWidth - vectror.Y;
            temp.Y =  vectror.X;
            return temp;
        }
        
    }
}
