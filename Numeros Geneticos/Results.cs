﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Numeros_Geneticos.Properties;

namespace Numeros_Geneticos
{
    public enum EMoveTo
    {
        Next = 0,
        Previous = 1,
        First = 2,
        Last = 3
    }

    public class Results
    {
        //------------------------------------------------------------------------------------//
        /*----------------------------------- FIELDS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        // Settings Storers
        private bool _usedSeed;
        private int _seed;
        private int _chromosomesCount;
        private int _individualsCount;
        private int _targetValue;

        // Draw References
        private PictureBox _canvas;
        private DataGridView _sheet;
        private Label _currentGenerationLabel;
        private RichTextBox _errors;

        private Button _next;
        private Button _previous;
        private Button _first;
        private Button _last;

        // Results Browser
        private List<Generation> _generations = new List<Generation>();
        private int _currentlyReviewedGeneration = 0;

        private IndividualRunResults _bestRun;
        private int _bestRunGeneration = -1;

        private int _elapsedGenerations = 0;

        //------------------------------------------------------------------------------------//
        /*--------------------------------- PROPERTIES ---------------------------------------*/
        //------------------------------------------------------------------------------------//

        public int TargetValue => _targetValue;

        private int CurrentGeneration
        {
            get => _currentlyReviewedGeneration;
            set
            {
                int targetValue = value;
                if (targetValue < 0)
                {
                    targetValue = 0;
                }
                if (targetValue > _generations.Count - 1)
                {
                    targetValue = _generations.Count - 1;
                }

                _first.Enabled = _previous.Enabled = targetValue != 0;
                _last.Enabled = _next.Enabled = targetValue != _generations.Count - 1;

                _currentGenerationLabel.Text = $"{targetValue + 1}/{_generations.Count}";
                _currentlyReviewedGeneration = targetValue;

                DrawGenerationResults();
            }
        }

        //------------------------------------------------------------------------------------//
        /*---------------------------------- METHODS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        public void MoveTo(EMoveTo toMoveTo)
        {
            switch (toMoveTo)
            {
                case EMoveTo.Next:
                    CurrentGeneration++;
                    break;
                case EMoveTo.Previous:
                    CurrentGeneration--;
                    break;
                case EMoveTo.First:
                    CurrentGeneration = 0;
                    break;
                case EMoveTo.Last:
                    CurrentGeneration = _generations.Count - 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(toMoveTo), toMoveTo, null);
            }
        }

        private void ReallyStartNewRun()
        {
            Individual.ResetIndividualsCount();

            _elapsedGenerations++;
            _generations.Add(new Generation(this, _elapsedGenerations));
            while (_generations.Count < SettingsManager.MaxTotalGenerations && _generations.Last().CanContinue)
            {
                _elapsedGenerations++;
                Generation last = _generations.Last();
                _generations.Add(new Generation(this, _elapsedGenerations, last));
            }
        }

        public void AttemptToRegisterAsBestRun(IndividualRunResults potentiallyBest)
        {
            if (_elapsedGenerations != 1 && potentiallyBest.differenceFromTarget >= _bestRun.differenceFromTarget) { return; }

            _bestRun = potentiallyBest;
            _bestRunGeneration = _elapsedGenerations;
        }

        private void DrawGenerationResults()
        {
            _canvas.ClearAndRedrawGrid();
            _sheet.Clear();

            _sheet.Columns.Add("Nombre", "Nombre");
            _sheet.Columns.Add("Generación", "Generación");
            _sheet.Columns.Add("Valor Inicial", "Valor Inicial");
            for (int i = 1; i < Individual.AmountOfEntriesInResults - 2; i++)
            {
                _sheet.Columns.Add($"Operación #{i}", $"Operación #{i}");
            }
            _sheet.Columns.Add("Signo", "Signo");
            _sheet.Columns.Add("Resultado", "Resultado");

            _errors.ForeColor = Color.Black;
            _errors.Clear();

            if (_generations.Last().StoppedBySimilarity)
            {
                _errors.Text = $@"El programa se detuvo ya que se encontró que las cromosomas de la última generación eran muy parecidas.{Environment.NewLine}{Environment.NewLine}";
            }

            _errors.Text += $@"La mejor corrida individual dentro de todas las generaciones es la siguiente de la generación #{_bestRunGeneration}:{Environment.NewLine}{_bestRun.ToString()}{Environment.NewLine}{Environment.NewLine}";

            #region Draw Image

            //first, create a dummy bitmap just to get a graphics object
            Image generationImage = DrawingManager.GenerateBlankImage(_individualsCount, _chromosomesCount);
            DrawingManager.DrawGrid(ref generationImage, _individualsCount, _chromosomesCount);
            DrawingManager.FillSlot(ref generationImage, 4, 4, Color.Aquamarine);

            #endregion Draw Image

            _generations[_currentlyReviewedGeneration].PopulateWithGenerationInfo(ref generationImage, _sheet, _errors);
            _canvas.Image = generationImage;
        }

        public void StartNewRun(PictureBox pbGenerationResults, DataGridView dgvGenerationResults, Label lGenerationCount, RichTextBox rtbErrors,
            Button first, Button last, Button next, Button previous)
        {
            // Store Draw References
            _canvas = pbGenerationResults;
            _sheet = dgvGenerationResults;
            _currentGenerationLabel = lGenerationCount;
            _errors = rtbErrors;
            _next = next;
            _previous = previous;
            _first = first;
            _last = last;

            // Store Settings
            _chromosomesCount = SettingsManager.TotalChromosomes;
            _individualsCount = SettingsManager.IndividualsPerGeneration;
            _targetValue = SettingsManager.TargetNumber;
            _usedSeed = SettingsManager.UseSeed;
            _seed = SettingsManager.InitialSeed;
            if (_usedSeed) { RandomManager.SetSeed(_seed); } else { RandomManager.SetSeed(); }

            ReallyStartNewRun();

            CurrentGeneration = 0;
        }
    }
}