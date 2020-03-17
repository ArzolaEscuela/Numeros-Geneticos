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
        private List<IndividualRunResults> _results = new List<IndividualRunResults>();

        //------------------------------------------------------------------------------------//
        /*--------------------------------- PROPERTIES ---------------------------------------*/
        //------------------------------------------------------------------------------------//

        public int TargetValue => _resultsInfo.TargetValue;
        public bool CanContinue => _results[0].differenceFromTarget != 0; // If the target value wasn't hit spot on, don't stop.

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
            }
        }

        public void PopulateWithGenerationInfo(ref Image toDrawAt, DataGridView toWriteAt, RichTextBox resultsArea)
        {
            int totalResults = _results.Count;
            for (int i = 0; i < totalResults; i++)
            {
                _results[i].PopulateWithIndividualInfo(ref toDrawAt, toWriteAt, i);
            }

            resultsArea.Text = $@"The best run from this generation was the following:{Environment.NewLine}{_results[0].ToString()}";
        }

        public Generation(Results results)
        {
            _resultsInfo = results;

            for (int i = 0; i < SettingsManager.IndividualsPerGeneration; i++)
            {
                RecordResult(new Individual(this).RunResult);
            }
        }

        public Generation(Results results, Generation previousGeneration)
        {
            _resultsInfo = results;

            int totalElitismPicks = SettingsManager.SelectionsByElitism;
            int individualsPerGeneration = SettingsManager.IndividualsPerGeneration;

            for (int i = 0; i < totalElitismPicks; i++)
            {
                Individual father = previousGeneration._results[i].tester;
                int motherIndex = RandomManager.RandomIntWithHollowSpot(0, individualsPerGeneration - 1, i);
                Individual mother = previousGeneration._results[motherIndex].tester;

                RecordResult(new Individual(this, father, true, mother, motherIndex < totalElitismPicks).RunResult);
            }

            for (int i = totalElitismPicks; i < individualsPerGeneration; i++)
            {
                Individual father = previousGeneration._results[i].tester;
                int motherIndex = RandomManager.RandomIntWithHollowSpot(totalElitismPicks, individualsPerGeneration - 1, i);
                Individual mother = previousGeneration._results[motherIndex].tester;

                RecordResult(new Individual(this, father, false, mother, false).RunResult);
            }
        }
    }
}