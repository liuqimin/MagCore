﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MagCore.Monitor.Modules.Map
{
    public class Cell
    {
        public Cell(int x, int y)
        {
            Position = new Position(x, y);
            State = 0;
            OwnerIndex = -1;
        }

        private static Dictionary<int, Texture2D> _colorCells = null;

        public static void LoadContent(ContentManager content)
        {
            if (_colorCells == null)
            {
                _colorCells = new Dictionary<int, Texture2D>();
                foreach (PlayerColor item in Enum.GetValues(typeof(PlayerColor)))
                {
                    _colorCells.Add((int)item, content.Load<Texture2D>("Images/" + item.ToString()));
                }
            }
        }

        public Position Position { get; set; }

        public string Key => Position.ToString();

        public int Type { get; set; }

        public int State { get; set; }

        public int OwnerIndex { get; set; }

        public DateTime? OccupiedTime { get; set; } = null;

        private static Color _flickeColor1 = new Color(Color.White, 0.3f);
        private static Color _flickeColor2 = new Color(Color.White, 0.7f);

        public void Draw(SpriteBatch sb, Rectangle rect, int color, GameTime gt)
        {
            switch (State)
            {
                case 1:
                    //Flicke
                    int ms = gt.TotalGameTime.Milliseconds;
                    if (ms < 500)
                        sb.Draw(_colorCells[color], rect, _flickeColor1);
                    else
                        sb.Draw(_colorCells[color], rect, _flickeColor2);
                    break;
                case 2:
                    //Occupied
                    sb.Draw(_colorCells[color], rect, Color.White);
                    break;
                case 0:
                default:
                    break;
            }
        }
    }
}
