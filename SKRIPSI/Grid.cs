using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKRIPSI
{
    class Grid
    {
        char[,] isi;
        int maxRows, maxColumns;

        public Grid (int maxRows, int maxColumns)
        {
            this.maxRows = maxColumns;
            this.maxRows = maxRows;

            isi = new char[maxRows, maxColumns];
            init();
        }

        public void setValue(int row, int column, char val)
        {

            if (row >= maxRows | column >= maxColumns | row < 0 | column < 0) return;

            isi[row,column] = val;
        }

        public char getValue(int row, int column)
        {

            if (row >= maxRows | column >= maxColumns | row < 0 | column < 0)
                return ' ';

            return isi[row,column];
        }

        public int getMaxRows()
        {
            return maxRows;
        }

        public int getMaxColumns()
        {
            return maxColumns;
        }

        public void init()
        {

            for (int i = 0; i < maxRows; i++)
                for (int j = 0; j < maxColumns; j++)
                    isi[i,j] = ' ';
        }

        public char[,] getAll()
        {
            return isi;
        }
    }
}
