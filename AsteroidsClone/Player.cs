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
	class Player {
		Texture2D Graphic;

		public void OnLoad() {
			Graphic = Content.Load<Texture2D>("Test/Player");
		}
	}
}
