using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Numeros_Geneticos
{
    public class Generation
    {
        //------------------------------------------------------------------------------------//
        /*----------------------------------- FIELDS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        private readonly Results _resultsInfo;
        private readonly int _generationNumber;
        private List<IndividualRunResults> _results = new List<IndividualRunResults>();

        private bool _stoppedBySimilarity = false;

        //------------------------------------------------------------------------------------//
        /*--------------------------------- PROPERTIES ---------------------------------------*/
        //------------------------------------------------------------------------------------//

        public int TargetValue => _resultsInfo.TargetValue;

        public bool StoppedBySimilarity => _stoppedBySimilarity;

        public bool CanContinue
        {
            get
            {
                // If the target value was hit spot on, stop.
                if (_results[0].differenceFromTarget == 0) { return false; }

                // If the chromosomes from this generation are too similar, stop.
                int totalResults = _results.Count;
                int totalSimilar = 0;
                for (int i = 0; i < totalResults; i++)
                {
                    Individual current = _results[i].tester;
                    for (int j = i+1; j < totalResults; j++)
                    {
                        Individual toCompareWith = _results[j].tester;
                        if (current.HasSimilarChromosomes(toCompareWith))
                        {
                            totalSimilar++;

                            Console.WriteLine(current.Name + "|" + toCompareWith.Name);
                            if (totalSimilar >= SettingsManager.IndividualMatchesToStopSimulation)
                            {
                                _stoppedBySimilarity = true;
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
        }

        public int GenerationNumber => _generationNumber;

        //------------------------------------------------------------------------------------//
        /*---------------------------------- METHODS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        public void RecordResult(IndividualRunResults result)
        {
            _results.Add(result);

            if (_results.Count == SettingsManager.IndividualsPerGeneration)
            {
                _results.Sort((a, b) => a.differenceFromTarget == b.differenceFromTarget ? 0
                    : a.differenceFromTarget.CompareTo(b.differenceFromTarget));

                _resultsInfo.AttemptToRegisterAsBestRun(_results[0]);
            }
        }

        public void PopulateWithGenerationInfo(ref Image toDrawAt, DataGridView toWriteAt, RichTextBox resultsArea)
        {
            int totalResults = _results.Count;
            for (int i = 0; i < totalResults; i++)
            {
                _results[i].PopulateWithIndividualInfo(ref toDrawAt, toWriteAt, i);
            }

            resultsArea.Text += $@"La mejor corrida de esta generación fue la siguiente:{Environment.NewLine}{_results[0].ToString()}";
        }

        public Generation(Results results, int generationNumber)
        {
            _resultsInfo = results;
            _generationNumber = generationNumber;

            for (int i = 0; i < SettingsManager.IndividualsPerGeneration; i++)
            {
                RecordResult(new Individual(this).RunResult);
            }
        }

        public Generation(Results results, int generationNumber, Generation previousGeneration)
        {
            _resultsInfo = results;
            _generationNumber = generationNumber;

            int totalElitismPicks = SettingsManager.SelectionsByElitism;
            int individualsPerGeneration = SettingsManager.IndividualsPerGeneration;

            for (int i = 0; i < totalElitismPicks; i++)
            {
                if (SettingsManager.GuaranteedSurvivalForElites)
                {
                    RecordResult(previousGeneration._results[i].tester.RunResult);
                    continue;
                }

                Individual father = previousGeneration._results[i].tester;
                int motherIndex = RandomManager.RandomIntWithHollowSpot(0, individualsPerGeneration - 1, i);
                Individual mother = previousGeneration._results[motherIndex].tester;

                RecordResult(new Individual(this, father, true, mother, motherIndex < totalElitismPicks).RunResult);
            }

            for (int i = totalElitismPicks; i < individualsPerGeneration; i++)
            {
                Individual father = previousGeneration._results[i].tester;
                int motherIndex = RandomManager.RandomIntWithHollowSpot(0, individualsPerGeneration - 1, i);
                Individual mother = previousGeneration._results[motherIndex].tester;

                RecordResult(new Individual(this, father, false, mother, motherIndex < totalElitismPicks).RunResult);
            }
        }
    }
}