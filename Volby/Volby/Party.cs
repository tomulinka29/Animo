using System;
using System.Collections.Generic;
using System.Text;

namespace Volby
{
    class Party
    {
        public string name;
        public int voteCount;

        public Party(string name)
        {
            this.name = name;
        }

        public void AddVote() => voteCount++;
    }
}
