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
	class Player : Entity {

		private float accel = 0.05f;
		private float angAccel = 0.01f;


		public Player(ContentManager content, string spritePath) : base(content, spritePath) { }

		public override void Update(GraphicsDevice gd) {
			HandleKeyboard();
			base.Update(gd);		
			
		}



		private void HandleKeyboard() {
			KeyboardState state = Keyboard.GetState();
			if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.S)) {
				Vector2 forward = new Vector2(state.IsKeyDown(Keys.S) ? -accel : accel, 0);
				Matrix m = Matrix.CreateRotationZ(angle + MathHelper.ToRadians(-90));
				Vector2.TransformNormal(ref forward, ref m, out forward);

				velocity += forward;
			}
			if (state.IsKeyDown(Keys.Space)) {
				Vector2 vel = velocity;
				vel.Normalize();
				Vector2.Negate(ref vel, out vel);
				vel *= accel;

				velocity += vel;
			}
			if (state.IsKeyDown(Keys.A)) {
				angle -= angAccel;
			}
			if (state.IsKeyDown(Keys.D)) {
				angle += angAccel;
			}
			if (state.IsKeyDown(Keys.R)) {
				velocity = Vector2.Zero;
				position = new Vector2(200, 200);
			}


		}

	}
}
