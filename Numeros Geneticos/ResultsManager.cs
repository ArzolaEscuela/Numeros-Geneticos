using System;

namespace Numeros_Geneticos
{
    public class ResultsManager
    {
        // Settings Storers
        private int _chromosomesCount;
        private int _individualsCount;
        private bool _usedSeed;
        private int _seed;

        public int TargetValue => 0;

        public void StartNewRun()
        {

            // Check that the chromosomes amount allows for operation pairs
            throw new NotImplementedException();

            _chromosomesCount = SettingsManager.TotalChromosomes;
            _individualsCount = SettingsManager.IndividualsPerGeneration;

            _usedSeed = SettingsManager.UseSeed;
            _seed = SettingsManager.InitialSeed;
            if (_usedSeed) { RandomManager.SetSeed(_seed); } else { RandomManager.SetSeed(); }
        }
    }
}