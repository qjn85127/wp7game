using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utility;

namespace Striker
{
    public class Player : BaseObject
    {
        
        private int _hp;
        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public Vector2 Center
        {
            get
            {
                float x = this._position.X + this._size.Width * this._scale/ 2;
                float y = this._position.Y - this._size.Height * this._scale / 2;
                return new Vector2(x, y);
            }
        }

        public Player(ContentManager content, SpriteBatch batch)
        {
            this._content = content;
            this._batch = batch;
            this._scale = 1;
            this._rotation = (float)(-Math.PI / 2);
        }

        public void Update( )
        {
            float deltaX = 0f;
            float deltaY = 0f;
            switch (GlobalValue.CtrlDirection)
            {
                case PlayerDirection.Left:
                    deltaX = -GlobalValue.PlayerSpeed;
                    break;
                case PlayerDirection.Down:
                    deltaY = GlobalValue.PlayerSpeed;
                    break;
                case PlayerDirection.Up:
                    deltaY = -GlobalValue.PlayerSpeed;
                    break;
                case PlayerDirection.Right:
                    deltaX = GlobalValue.PlayerSpeed;
                    break;
                case PlayerDirection.UpLeft:
                    deltaX = -GlobalValue.PlayerSpeed;
                    deltaY = GlobalValue.PlayerSpeed;
                    break;
                case PlayerDirection.UpRight:
                    deltaX = GlobalValue.PlayerSpeed;
                    deltaY = GlobalValue.PlayerSpeed;
                    break;
                case PlayerDirection.DownLeft:
                    deltaX = -GlobalValue.PlayerSpeed;
                    deltaY = -GlobalValue.PlayerSpeed;
                    break;
                case PlayerDirection.DownRight:
                    deltaX = GlobalValue.PlayerSpeed;
                    deltaY = -GlobalValue.PlayerSpeed;
                    break;
            }
            float x = this.Position.X + deltaX;
            float y = this.Position.Y + deltaY;
            if (x < 0) x = 0;
            if (x > GlobalValue.ScreenWidth- this._scale * this._size.Width) x = GlobalValue.ScreenWidth- this._scale * this._size.Width;
            if (y < 0) y = 0;
            if(y >=GlobalValue.ScreenHeight - 100 - this._size.Height * this._scale) y = GlobalValue.ScreenHeight - 100 - this._size.Height * this._scale;
            this.Position = new Vector2(x, y);
        }
        
        
        
    }
}
