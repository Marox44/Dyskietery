using System;
using System.Collections.Generic;
using System.Text;

namespace Dyskietery
{
    public class dzwiek
    {
        public dzwiek(uint _track, uint _czas, bool _stan, uint _nuta, bool _endTrack = false)
        {
            this.track = _track;
            this.czas = _czas;
            this.stan = _stan;
            this.nuta = _nuta;
            this.endTrack = _endTrack;
        }
        public uint track;
        public uint czas;
        public bool stan;
        public uint nuta;
        public bool endTrack = false;
    }
}
