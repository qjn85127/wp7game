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
    public class Enemies : List<Enemy>
    {
        ContentManager _content;
        SpriteBatch _batch;
        public Enemies(ContentManager content, SpriteBatch batch)
        {
            this._content = content;
            this._batch = batch;
        }
        public void Create(float x, float y)
        {
            this.Add(new Enemy(this._content, this._batch, x, y));
        }
        public void Update()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                this[i].Update();
                if (this[i].HP <=0 || this[i].OutOfBound())
                {
                    this.RemoveAt(i);
                }
            }
        }
        public void Draw()
        {
            this._batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (!this[i].Hit)
                {
                    this[i].Draw();
                }
            }
            this._batch.End();

            this._batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this[i].Hit)
                {
                    this[i].Draw();
                    this[i].Hit = false;
                }
            }
            this._batch.End();
        }
    }
    public class Enemy : BaseObject
    {
        private int _hp;

        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public Enemy(ContentManager content, SpriteBatch batch, float x, float y)
        {
            this._hp = 100;
            this._batch = batch;
            this._content = content;
            this._scale = 1;
            this.InitializeDrawing(@"Enemy\Enemy", 1f);
            this.IntializePosition(x, y, 64, 64);
            this._rotation = (float)(-Math.PI/2);
            this._speed = 3f;
            this._direction = 6;
        }
        public void Update()
        {
            double degree = 30 * this._direction * Math.PI / 180;
            this._speed += this.Accelaration;
            float x = (float)(this._speed * Math.Sin(degree)) + this._position.X;
            float y = -(float)(this._speed * Math.Cos(degree)) + this._position.Y;
            this._position = new Vector2(x, y);
        }
        public bool OutOfBound()
        {
            if (this.Position.X < 0 || this.Position.X > GlobalValue.ScreenWidth || this.Position.Y > GlobalValue.ScreenHeight || this.Position.Y < -10)
            {
                return true;
            }
            return false;
        }
   
    }
}
