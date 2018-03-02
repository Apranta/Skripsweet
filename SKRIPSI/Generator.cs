using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKRIPSI
{
    class Generator
    {
        Grid grid;
        List<String> kata;
        Hashtable Horizontal,Vertical;
        Random random;

        public Generator(Grid grid , List<String> kata){
        	this.grid = grid;
        	this.kata = kata;

        	random = new Random();
            urutKata();
        }

        public void urutKata(){
            StringLengthComparator compare = new StringLengthComparator();
            kata.Sort(compare);
        }

        public int generate()
        {
            List<String> remainingWords = new List<String>();
            foreach (String w in kata)
            {
                remainingWords.Add(w);
            }

            String word = remainingWords.ElementAt(0);
            KoordinateKata koor = new KoordinateKata(0, 0, random.Next(2), 0);
            while (word != null)
            {

                writeWordToGrid(word, koor);
                remainingWords.Remove(word);

                //addToPertanyaan(word, koor);

                Object[] result = pickupWord(remainingWords);
                word = (String)result[0];
                koor = (KoordinateKata)result[1];
            }

            return kata.Count() - remainingWords.Count();
        }

        private Object[] pickupWord(List<String> remainingWords)
        {
            KoordinateKata maxCoordinate = null;
            String theWord = null;

            foreach (String word in remainingWords)
            {

                List<KoordinateKata> coordinates = getPossibleCoordinates(word);

                if (coordinates.Capacity == 0) continue;
                
                coordinates.Sort(new WordCoordinateComparator());

                if (maxCoordinate == null || (maxCoordinate.getScore() < coordinates.ElementAt(0).getScore()))
                {

                    maxCoordinate = coordinates.ElementAt(0);
                    theWord = word;
                }
            }

            return new Object[] { theWord, maxCoordinate };
        }

        private List<KoordinateKata> getPossibleCoordinates(String word)
        {

            List<KoordinateKata> coordList = new List<KoordinateKata>();

            for (int k = 0; k < word.Length; k++)
            {

                for (int i = 0; i < grid.getMaxRows(); i++)
                {

                    for (int j = 0; j < grid.getMaxColumns(); j++)
                    {

                        //horizontal
                        if (j - k >= 0 && ((j - k) + word.Length < grid.getMaxColumns()))
                            coordList.Add(new KoordinateKata(i, j - k, 0, 0));

                        //vertical
                        if (i - k >= 0 && ((i - k) + word.Length < grid.getMaxRows()))
                            coordList.Add(new KoordinateKata(i - k, j, 1, 0));
                    }
                }
            }

            List<KoordinateKata> toRet = new List<KoordinateKata>();

            foreach (KoordinateKata coordinate in coordList)
            {

                int score = checkScore(word, coordinate);
                if (score == 0) continue;

                toRet.Add(new KoordinateKata(coordinate.getX(), coordinate.getY(), coordinate.getDirection(), score));
            }

            return toRet;
        }

        private int checkScore(String word, KoordinateKata coordinate)
        {
            int row = coordinate.getX();
            int col = coordinate.getY();

            if (col < 0 || row < 0)
                return 0;

            int count = 1;
            int score = 1;

            foreach (char letter in word.ToCharArray())
            {

                if (!isEmpty(row, col) && grid.getValue(row, col) != letter)
                    return 0;

                if (grid.getValue(row, col) == letter)
                    score++;

                if (coordinate.getDirection() == 1)
                {
                    //vertical
                    if (grid.getValue(row, col) != letter && (!isEmpty(row, col + 1) || !isEmpty(row, col - 1)))
                        return 0;

                    if (count == 1 && !isEmpty(row - 1, col))
                        return 0;

                    if (count == word.Length && !isEmpty(row + 1, col))
                        return 0;

                    row++;

                }
                else
                {
                    //Horizontal

                    if (grid.getValue(row, col) != letter && (!isEmpty(row - 1, col) || !isEmpty(row + 1, col)))
                        return 0;

                    if (count == 1 && !isEmpty(row, col - 1))
                        return 0;

                    if (count == word.Length && !isEmpty(row, col + 1))
                        return 0;

                    col++;
                }

                count++;
            }

            return score;
        }

        private bool isEmpty(int row, int column)
        {

            char value = grid.getValue(row, column);

            return value == ' ' || value == 0;
        }

        private void writeWordToGrid(String word, KoordinateKata coordinate)
        {

            int k = 0;

            for (int i = (coordinate.getDirection() == 0) ? coordinate.getY() : coordinate.getX();
                 i < word.Length + ((coordinate.getDirection() == 0) ? coordinate.getY() : coordinate.getX());
                 i++)
                grid.setValue(coordinate.getDirection() == 0 ? coordinate.getX() : i,
                        coordinate.getDirection() == 0 ? i : coordinate.getY(), word.ElementAt(k++));

        }

        private void addToPertanyaan(String word, KoordinateKata coordinate)
        {
            if (coordinate.getDirection() == 0)
            {
                //List<String> l = (List<String>)Horizontal[coordinate.getX()];
                //if (l == null) l = new List<String>();
                //l.Add(word);
                Horizontal.Add(coordinate.getX(), word);
            }
            else
            {

                //List<String> l = (List<String>)Vertical[coordinate.getY()];
                //if (l == null) l = new List<String>();
                //l.Add(word);
                Vertical.Add(coordinate.getY(), word);
            }
        }

        public Hashtable getHorizontalPertanyaan()
        {
            return Horizontal;
        }

        public Hashtable getVerticalPertanyaan()
        {
            return Vertical;
        }
    }
}
