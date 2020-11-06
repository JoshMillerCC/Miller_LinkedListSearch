using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miller_LinkedListSearch
{
    class MetaData
    {
        private char Gender;
        private string Name;
        private int Rank;
        private static int allNodeCount;
        private static int fNodeCount;
        private static int mNodeCount;

        public MetaData(char gender, string name, int rank)
        {
            // constructor to create each meta data for the nodes to hold onto
            Gender = gender;
            Name = name;
            Rank = rank;
            allNodeCount++;
            GenderCount();
        }

        static MetaData()
        {
            // static constructor to initiate each count to 0 and make sure there is only ever 1 of each
            allNodeCount = 0;
            fNodeCount = 0;
            mNodeCount = 0;
        }

        public string getName()
        {
            return Name;
        }
        public int getMCount()
        {
            return mNodeCount;
        }
        public int getFCount()
        {
            return fNodeCount;
        }
        public int getAllCount()
        {
            return allNodeCount;
        }
        public char getGender()
        {
            return Gender;
        }
        public int getRank()
        {
            return Rank;
        }
        private void GenderCount()
        {
            // add to either female node count or male node count depending on the data coming in
            if(Gender == 'F')
            {
                fNodeCount++;
            }
            else
            {
                mNodeCount++;
            }
        }
    }
}
