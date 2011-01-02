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
    public class BaseObject
    {
        protected ContentManager _content;
        protected SpriteBatch _batch;
        protected Texture2D _image;
        protected Color _drawingColor;
        protected float _layer;
        protected Vector2 _position;
        protected Rectangle _size;
        protected float _rotation;
        protected float _scale;
        protected float _direction;
        protected float _speed;
        protected float _accelaration;
        protected float _age;
        protected float _score;
        protected bool _hit;
        // Dying Effects
        // Killing Bouns

        public Texture2D Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public Color DrawingColor
        {
            get { return _drawingColor; }
            set { _drawingColor = value; }
        }
        public float Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Rectangle Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }
        public float Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public float Accelaration
        {
            get { return _accelaration; }
            set { _accelaration = value; }
        }
        public float Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public bool Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }
        public float Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public BaseObject()
        {
            this._scale = 1;
            
        }
        public void Load(string location, Color color,float layer)
        {
           this._image = this._content.Load<Texture2D>(location);
            this._drawingColor = color;
            this._layer = layer;
        }
        public void InitializeDrawing(string location, float layer)
        {
            this._image = this._content.Load<Texture2D>(location);
            this._drawingColor = Color.White;
            this._layer = layer;
        }
        public void IntializePosition(float x, float y, int width, int height)
        {
           
            this._size = new Rectangle(0, 0, width, height);
            this._position = new Vector2(x, y);
        }
        public void Draw()
        {
            this._batch.Draw(this._image, CommonLibiary.ConverToRealCoor(this._position), this._size, this._drawingColor, this._rotation, new Vector2(),this._scale ,SpriteEffects.None, this._layer);
        }
        public Rectangle Bound
        {
            get
            {
                int x = (int)this._position.X;
                int y = (int)this._position.Y;
                int width = (int)(this._size.Width * this._scale);
                int height = (int)(this._size.Height * this._scale);
                return new Rectangle(x, y, width, height);
            }
        }
    }
    
}
