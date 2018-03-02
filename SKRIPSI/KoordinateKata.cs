using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKRIPSI
{
    class KoordinateKata
    {
        private int x;
        private int y;
        private int score;

        public KoordinateKata(int x, int y, int direction, int score)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.score = score;
        }

        private int direction; // 0 => hor, 1 => ver

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getDirection()
        {
            return direction;
        }

        public int getScore()
        {
            return score;
        }
    }
}
