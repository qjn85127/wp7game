using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Utility;

namespace Striker
{

    /* ---------------------------(0,0)
     *                                               |
     *                                               |
     *                                               |
     *                                               |
     *                                               |
     *                                               |
     *                                               |
     *                                               |
     *                                               |
     *                                               |
     *   left  right    up    down    |   
     *   sceent(width,height)
     */

    public class ControlButtons
    {
        private ControlButton _left;
        private ControlButton _right;
        private ControlButton _up;
        private ControlButton _down;

        float btnWidth; 
        float btnHeight ;

        SpriteBatch _batch;
        ContentManager _content;

        public ControlButtons(ContentManager content, SpriteBatch batch)
        {

            _batch = batch;
            _content = content;

            btnWidth = GlobalValue.ScreenWidth / 4;
            btnHeight = btnWidth;

            GlobalValue.ControlRegionHeight = 100;
            GlobalValue.ControlRegionWidth = GlobalValue.ScreenWidth;

            this._left = new ControlButton(content, batch);
            this._right = new ControlButton(content, batch);
            this._up = new ControlButton(content,batch);
            this._down = new ControlButton(content, batch);
            this._left.InitializeDrawing(@"ControlButton\ArrowLeft", 1);
            this._right.InitializeDrawing(@"ControlButton\ArrowRight",1);
            this._up.InitializeDrawing(@"ControlButton\ArrowUp", 1);
            this._down.InitializeDrawing(@"ControlButton\ArrowDown", 1);

            float scale = btnWidth / this._left.Image.Bounds.Width;
            this._left.IntializePosition(0, GlobalValue.ScreenHeight - btnHeight, 100, 100);
            this._left.Scale = scale;
            this._right.IntializePosition( btnWidth * 1, GlobalValue.ScreenHeight - btnHeight, 100, 100);
            this._right.Scale = scale;
            this._up.IntializePosition(btnWidth * 2, GlobalValue.ScreenHeight - btnHeight , 100, 100);
            this._up.Scale = scale;
            this._down.IntializePosition(btnWidth * 3, GlobalValue.ScreenHeight - btnHeight , 100, 100);
            this._down.Scale = scale;
        }

        public void Draw()
        {
            switch (GlobalValue.CtrlDirection)
            {
                case PlayerDirection.None:
                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                    this._up.Draw();
                    this._left.Draw();
                    this._right.Draw();
                    this._down.Draw();
                    this._batch.End();
                    break;
                case PlayerDirection.Left:
                       this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

                       this._left.Draw();

                    this._batch.End();


                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                     this._up.Draw();
               
                    this._right.Draw();
                    this._down.Draw();

                    this._batch.End();
                    break;
                case PlayerDirection.Right:
                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

                    this._right.Draw();

                    this._batch.End();

                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                    this._up.Draw();
                    this._left.Draw();
                    this._down.Draw();

                    this._batch.End();
                    break;
                case PlayerDirection.Up:
                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

                    this._up.Draw();

                    this._batch.End();

                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                    this._right.Draw();
                    this._left.Draw();
                    this._down.Draw();

                    this._batch.End();

                    break;
                case PlayerDirection.Down:

                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

                    this._down.Draw();

                    this._batch.End();

                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                    this._right.Draw();
                    this._left.Draw();
                    this._up.Draw();

                    this._batch.End();

                    break;
                case PlayerDirection.UpLeft:
                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

                    this._left.Draw();
                    this._up.Draw();

                    this._batch.End();

                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                    this._right.Draw();
                    this._down.Draw();

                    this._batch.End();
                    break;
                case PlayerDirection.UpRight:
                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

          
                    this._up.Draw();
                    this._right.Draw();
                    this._batch.End();

                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                    this._left.Draw();
                    this._down.Draw();

                    this._batch.End();
                    break;
                case PlayerDirection.DownLeft:
                 this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

                     this._left.Draw();
                    this._down.Draw();
                
                    this._batch.End();

                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                        this._up.Draw();
                    this._right.Draw();
         

                    this._batch.End();
                    break;
                case PlayerDirection.DownRight:
                     this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

                    this._down.Draw();
                    this._right.Draw();

                    this._batch.End();

                    this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                    this._up.Draw();
                    this._left.Draw();
         

                    this._batch.End();
                    break;
            }
       
        }

        public void Update()
        {
            GlobalValue.CtrlDirection  = PlayerDirection.None;
            TouchCollection collection = TouchPanel.GetState(); 
            PlayerDirection pDir = PlayerDirection.None;
            for(int i = 0 ; i < collection.Count; i++)
            {
                Vector2 position = CommonLibiary.ConvertToViturialCoor(collection[i].Position);
                float x = position.X;
                float y = position.Y;
                if (y >= GlobalValue.ScreenHeight || y < GlobalValue.ScreenHeight - btnHeight)
                    continue;
                else
                {
                    if (x < 4 * btnWidth && x > 3 * btnWidth)
                    {
                        pDir = PlayerDirection.Down;
                    }
                    else if (x < 3 * btnWidth && x > 2 * btnWidth)
                    {
                        pDir = PlayerDirection.Up;
                    }
                    else if (x < 2 * btnWidth && x > 1 * btnWidth)
                    {
                        pDir = PlayerDirection.Right;
                    }
                    else if (x < 1 * btnWidth && x > 0 * btnWidth)
                    {
                        pDir = PlayerDirection.Left;
                    }
                 }
                switch (pDir)
                {
                 
                    case PlayerDirection.Left:
                        if (GlobalValue.CtrlDirection == PlayerDirection.Up)
                            GlobalValue.CtrlDirection = PlayerDirection.UpLeft;
                        else if (GlobalValue.CtrlDirection == PlayerDirection.Down)
                            GlobalValue.CtrlDirection = PlayerDirection.DownLeft;
                        else
                            GlobalValue.CtrlDirection = PlayerDirection.Left;
                        break;
                    case PlayerDirection.Right:
                        if (GlobalValue.CtrlDirection == PlayerDirection.Up)
                            GlobalValue.CtrlDirection = PlayerDirection.UpRight;
                        else if (GlobalValue.CtrlDirection == PlayerDirection.Down)
                            GlobalValue.CtrlDirection = PlayerDirection.UpRight;
                        else
                            GlobalValue.CtrlDirection = PlayerDirection.Right;
                        break;
                    case PlayerDirection.Up:
                        if (GlobalValue.CtrlDirection == PlayerDirection.Left)
                            GlobalValue.CtrlDirection = PlayerDirection.UpLeft;
                        else if (GlobalValue.CtrlDirection == PlayerDirection.Right)
                            GlobalValue.CtrlDirection = PlayerDirection.UpRight;
                        else
                            GlobalValue.CtrlDirection = PlayerDirection.Up;
                        break;
                    case PlayerDirection.Down:
                        if (GlobalValue.CtrlDirection == PlayerDirection.Left)
                            GlobalValue.CtrlDirection = PlayerDirection.DownLeft;
                        else if (GlobalValue.CtrlDirection == PlayerDirection.Right)
                            GlobalValue.CtrlDirection = PlayerDirection.DownRight;
                        else
                            GlobalValue.CtrlDirection = PlayerDirection.Down;
                        break;
                }
            }
            
        }

    }

    public class ControlButton : BaseObject
    {
        private bool _touched;

        public bool Touched
        {
            get { return _touched; }
            set { _touched = value; }
        }

        public ControlButton(ContentManager content, SpriteBatch batch)
        {
            this._content = content;
            this._batch = batch;
            this._rotation = (float)(-Math.PI / 2);
            _touched = false;
        }
    }
}
