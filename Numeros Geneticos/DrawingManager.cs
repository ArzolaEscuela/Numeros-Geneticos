using System;
using System.Drawing;

namespace Numeros_Geneticos
{
    public static class DrawingManager
    {
        private const int _LINE_WIDTH = 1;
        private const int _FILL_SIZE = 17;

        private static readonly Color _GRID_COLOR = Color.Black;

        public static void DrawGrid(ref Image image, int individualsPerGeneration, int totalChromosomes)
        {
            Graphics g = Graphics.FromImage(image);
            Pen p = new Pen(_GRID_COLOR);

            int height = CalculateHeight(individualsPerGeneration);
            int width = CalculateWidth(totalChromosomes);

            for (int horizontalIndex = 0; horizontalIndex <= individualsPerGeneration; horizontalIndex++)
            {
                int targetY = horizontalIndex * (_LINE_WIDTH + _FILL_SIZE);
                for (int i = 0; i < _LINE_WIDTH; i++)
                {
                    g.DrawLine(p, 0, targetY + i, width, targetY + i);
                }
            }

            for (int verticalIndex = 0; verticalIndex <= totalChromosomes; verticalIndex++)
            {
                int targetX = verticalIndex * (_LINE_WIDTH + _FILL_SIZE);
                for (int i = 0; i < _LINE_WIDTH; i++)
                {
                    g.DrawLine(p, targetX + i, 0, targetX + i, height);
                }
            }
        }

        /// <param name="individualIndex">Base 0 index that will determine the Y position, from top to bottom.</param>
        /// <param name="chromosomeIndex">Base 0 index that will determine the X position, from left to right.</param>
        public static void FillSlot(ref Image image, int individualIndex, int chromosomeIndex, Color drawColor)
        {
            int startX = _LINE_WIDTH + (chromosomeIndex * (_LINE_WIDTH + _FILL_SIZE));
            int startY = _LINE_WIDTH + (individualIndex * (_LINE_WIDTH + _FILL_SIZE));

            Graphics g = Graphics.FromImage(image);
            Pen p = new Pen(drawColor);

            for (int i = 0; i < _FILL_SIZE; i++)
            {
                g.DrawLine(p, startX, startY + i, startX + _FILL_SIZE - 1, startY + i);
            }
        }

        private static int CalculateWidth(int totalChromosomes) => (totalChromosomes * _FILL_SIZE) + ((totalChromosomes + 1) * _LINE_WIDTH);
        private static int CalculateHeight(int individualsPerGeneration) => (individualsPerGeneration * _FILL_SIZE) + ((individualsPerGeneration + 1) * _LINE_WIDTH);

        public static Image GenerateBlankImage(int individualsPerGeneration, int totalChromosomes)
        {
            int width = CalculateWidth(totalChromosomes);
            int height = CalculateHeight(individualsPerGeneration);
            return new Bitmap(width, height);
        }
    }
}