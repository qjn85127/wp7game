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
    public class PlayerBullets :List<Bullet>
    {
        private ShootingType _shootType;
        public ShootingType ShootType
        {
            get { return _shootType; }
            set { _shootType = value; }
        }
        ContentManager _content;
        SpriteBatch _batch;
        public PlayerBullets(ContentManager content, SpriteBatch batch)
        {
            _content = content;
            _batch = batch;
            this._shootType = ShootingType.HeavyDeiperse;
        }
      
        public void Create(float x, float y)
        {
            if (this._shootType == ShootingType.Default)
            {
                this.Add(new Bullet(x+10, y , 12, this._content, this._batch));
                this.Add(new Bullet(x-10, y , 12, this._content, this._batch));
            }
            else if(this._shootType == ShootingType.LightDisperse)
            {
                this.Add(new Bullet(x - 10, y, 11.5f, this._content, this._batch));
                this.Add(new Bullet(x - 10, y, 12f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 12f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 0.5f, this._content, this._batch));
            }
            else if (this._shootType == ShootingType.MidDeiperse)
            {
                this.Add(new Bullet(x - 10, y, 11.5f, this._content, this._batch));
                this.Add(new Bullet(x - 10, y, 11.75f, this._content, this._batch));
                this.Add(new Bullet(x - 10, y, 12f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 12f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 0.25f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 0.5f, this._content, this._batch));
            }
            else if (this._shootType == ShootingType.HeavyDeiperse)
            {
                this.Add(new Bullet(x - 10, y, 11.4f, this._content, this._batch));
                this.Add(new Bullet(x - 10, y, 11.6f, this._content, this._batch));
                this.Add(new Bullet(x - 10, y, 11.8f, this._content, this._batch));
                this.Add(new Bullet(x - 10, y, 12f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 12f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 0.2f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 0.4f, this._content, this._batch));
                this.Add(new Bullet(x + 10, y, 0.6f, this._content, this._batch));
            }
        }

        public void Update()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                this[i].Update();
                if (this[i].OutOfBound())
                {
                    this.RemoveAt(i);
                }
            }
        }

        public void Draw()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                this[i].Draw();
            }
        }

    }
    public class Bullet : BaseObject
    {
        private int _damage;

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public Bullet(float x, float y, float direction, ContentManager content, SpriteBatch batch)
        {
            _damage = 10;
            this._content = content;
            this._batch = batch;
            this.InitializeDrawing(@"Bullet\PlayerBullet", 1f);
            this.IntializePosition(x+6, y, 12, 12);
            this.Speed = 15f;
            this._direction = direction;
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
            if (this.Position.X < 0 || this.Position.X > GlobalValue.ScreenWidth || this.Position.Y > GlobalValue.ScreenHeight || this.Position.Y < 0)
            {
                return true;
            }
            return false;
        }
    }
}
