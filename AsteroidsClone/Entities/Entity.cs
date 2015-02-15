using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace AsteroidsClone {
	 class Entity {
		protected Texture2D theSprite;
		protected Vector2 position = Vector2.Zero;
		protected Vector2 velocity = Vector2.Zero;

		protected Vector2 spriteOffset = Vector2.Zero;

		protected float angle = 0;

		public Entity() {}

		public Entity(ContentManager content, string spritePath) {
			theSprite = content.Load<Texture2D>(spritePath);

			spriteOffset = new Vector2(theSprite.Width / 2, theSprite.Height / 2);
		}

		public virtual void Update(GraphicsDevice gd) {
			position = position + velocity;
			Rectangle bounds = gd.Viewport.Bounds;

			if (position.X < 0)
				position.X = bounds.Width + position.X;
			if (position.Y < 0)
				position.Y = bounds.Height + position.Y;
			if (position.X > bounds.Width)
				position.X = bounds.Width - position.X;
			if (position.Y > bounds.Height)
				position.Y = bounds.Height - position.Y;

		}

		public virtual void Draw(SpriteBatch batch) {
			batch.Begin();

			Rectangle sourceRectangle = new Rectangle(0, 0, theSprite.Width, theSprite.Height);

			batch.Draw(theSprite, position, sourceRectangle, Color.White, angle, spriteOffset, 1.0f, SpriteEffects.None, 1);

			batch.End();
		}

	}
}
