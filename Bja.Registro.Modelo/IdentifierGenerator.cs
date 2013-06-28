using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bja.Registro.Modelo
{

    /// <summary>
    /// Class used to generate identifiers
    /// </summary>
    public static class IdentifierGenerator
    {

        private const long _yearMonthTrail = 10000000000000000L;
        private const long _millisecondTrail = 1000000L;
        private const long _maxSequence = 0x983039L;

        // Sincronizer for multiple threads
        private static object _syncRoot = new object();

        // Sequencer for the latter part of the ID
        private static long _sequencer = 0;
        // last id moment
        private static DateTime _lastTimestamp = DateTime.Now;

        /// <summary>
        /// Generates a new ID;
        /// </summary>
        /// <returns>New ID generated</returns>
        public static long NewId()
        {
            long result = 0;
            bool reDo = false;
            DateTime source = DateTime.Now;

            result = (source.Year - 2000) * 12 + (source.Month - 1);
            result *= _yearMonthTrail;
            result += ((source.Day * 86400 + source.Hour * 3600 + source.Minute * 60 + source.Second) * 1000 + source.Millisecond) * _millisecondTrail;

            lock (_syncRoot)
            {
                if (_lastTimestamp != source)
                {
                    _sequencer = 0;
                    _lastTimestamp = source;
                }
                else
                {
                    _sequencer++;
                    if (_sequencer > _maxSequence)
                        reDo = true;
                }
            }

            if (reDo)
            {
                Thread.Sleep(1);
                return NewId();
            }

            result += _sequencer;

            return result;
        }

    }
}
