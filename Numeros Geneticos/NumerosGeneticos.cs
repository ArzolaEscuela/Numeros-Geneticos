using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_Geneticos
{
    public partial class NumerosGeneticos : Form
    {
        #region Initializers

        public NumerosGeneticos()
        {
            InitializeComponent();
            Initialize();
        }

        private void NumerosGeneticos_Load(object sender, EventArgs e)
        {

        }

        private void Initialize()
        {
            bFirst.Enabled = false;
            bLast.Enabled = false;
            bNext.Enabled = false;
            bPrevious.Enabled = false;
            SetInitialValues();
            ValidateAll();
        }

        private void RedrawText()
        {
            var microsoft_12_bold = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            var microsoft_12 = new Font("Microsoft Sans Serif", 10);

            rtbInstructions.SelectionFont = microsoft_12_bold;
            rtbInstructions.AppendText($"Planteamiento del Problema{Environment.NewLine}{Environment.NewLine}");
            rtbInstructions.SelectionFont = microsoft_12;

            rtbInstructions.AppendText($@"El objetivo es que algún individuo llegue exactamente (o lo más cercano posible), a un número entero dado. Para lograr esto, sus cromosomas determinan una secuencia de operaciones que se ejecutarán, y por medio de selección, estas secuencias de operaciones se heredarán y mezclaran en generaciones futuras.
            {Environment.NewLine}Intencionalmente, hay un poco de ruido en la ejecución de las operaciones, es decir, es posible que un mismo individuo no siempre de el mismo resultado.");

            rtbInstructions.SelectionFont = microsoft_12_bold;
            rtbInstructions.AppendText($"{Environment.NewLine}{Environment.NewLine}División de Cromosomas{Environment.NewLine}{Environment.NewLine}");
            rtbInstructions.SelectionFont = microsoft_12;
            string parImpar = SettingsManager.ChromosomeShouldBeEven ? "par" : "impar";
            rtbInstructions.AppendText(
                $@"- Los primeros {SettingsManager.SecondaryMutationChromosomesAmount} cromosomas determinan el ruido, en este caso, una cantidad máxima de cromosomas que se ''voltearán'' en tiempo de ejecución (no afecta a los cromosomas que se heredan).
- El siguiente cromosoma determina un signo(pero estrictamente hablando, determina si el resultado final se multiplica por 1 o por - 1).
- Los siguientes {SettingsManager.InitialNumberChromosomesAmount} cromosomas determinan un número de partida.
- El resto de los cromosomas simula la siguiente secuencia de operaciones:{Environment.NewLine}
         ◆ [Suma/Resta/Nada > Multiplicacion/División/Nada] * 2 Veces  > Cuadrado/Raiz Cuadrada/Nada > ...
    ◆ Los cromosomas se dividen en pares para lograr la secuencia anterior.El primer cromosoma del par determina si la operación se lleva a cabo o no, mientras que el segundo determina cual de las dos operaciones sucede.
    ◆ La magnitud de las operaciones(exceptuando el cuadrado y la raiz), se duplica en base a la cantidad de veces que dicho par de cromosomas ha sucedido.Es decir, la primera vez que se encuentra un par de cromosomas que suma o resta, la cantidad potencialmente sumada o restada es 1, la siguiente vez será 2, luego 4, 8, etc.
    ◆ El valor acomulado es redondeado antes de un cuadrado/raiz y al finalizar todas las operaciones.
    ◆ En caso de underflow, overflow u otro error al momento de emajecutar una operación, la operación que lo causó es ignorada y se sigue normal.{Environment.NewLine}");
            rtbInstructions.AppendText($@"{Environment.NewLine}Por estas condiciones, la cantidad de chromosomas siempre deberá ser mayor a {SettingsManager.FakeMinimumChromosomeSize} y un número {parImpar}. Sin embargo, no se recomienda escoger {SettingsManager.FakeMinimumChromosomeSize}, ya que el mayor número al que se podría llegar es de 65, es mejor experimentar escogiendo un número mayor de cromosomas para una mayor variabilidad.");

            rtbInstructions.SelectionFont = microsoft_12_bold;
            rtbInstructions.AppendText($"{Environment.NewLine}{Environment.NewLine}Condiciones de Reproducción{Environment.NewLine}{Environment.NewLine}");
            rtbInstructions.SelectionFont = microsoft_12;

            rtbInstructions.AppendText($@"- Las parejas son elegidas al azar, pero los primeros lugares llenados son hijos de padres seleccionados por elitismo.
- Los primeros {SettingsManager.SecondaryMutationChromosomesAmount} cromosomas son heredados de los padres, independientemente de si alguno fue seleccionado por elitismo o no.
- Los individuos que son seleccionados por elitismo, tienen una mayor probabilidad (pero no garatía) de heredar la mayor parte de sus cromosomas a la siguiente generación.
- En caso de haber una reproducción entre dos individuos seleccionados por elitismo, la división de cromosomas se llevará a cabo como si ambos no fueran elitistas.");

            rtbInstructions.SelectionFont = microsoft_12_bold;
            rtbInstructions.AppendText($"{Environment.NewLine}{Environment.NewLine}Mutación{Environment.NewLine}{Environment.NewLine}");
            rtbInstructions.SelectionFont = microsoft_12;

            rtbInstructions.AppendText(@"Existe la posibilidad de alterar permanentemente los cromosomas de algún individuo al final de una generación, estas mutaciones son determinadas por los valores proporcionados.");

            rtbInstructions.SelectionFont = microsoft_12_bold;
            rtbInstructions.AppendText($"{Environment.NewLine}{Environment.NewLine}Resultados{Environment.NewLine}{Environment.NewLine}");
            rtbInstructions.SelectionFont = microsoft_12;

            rtbInstructions.AppendText(@"Cada generación será representada con una imagen, donde cada línea representa a un individuo, y cada uno de los pixeles, los cromosomas que tiene(siendo coloreado / no blanco un cromosoma ''encendido'').");

        }

        #endregion Initializers

        #region Validators

        private void ValidateAll()
        {
            RedrawText();

            List<string> errors = new List<string>();

            if (SettingsManager.SelectionsByElitism > SettingsManager.IndividualsPerGeneration)
            {
                errors.Add("No se pueden escoger más individuos por elitismo que los que va a haber en una generación.");
            }

            if (SettingsManager.TotalChromosomes < SettingsManager.MinimumChromosomeSize)
            {
                errors.Add($"El tamaño mínimo aceptable para el total de cromosomas es de {SettingsManager.MinimumChromosomeSize}. {SettingsManager.SecondaryMutationChromosomesAmount} para mutación temporal, {SettingsManager.InitialNumberChromosomesAmount} para el número inicial, 1 para el signo y al menos {SettingsManager.MINIMUM_OPERATION_CHROMOSOMES_COUNT} para operaciones.");
            }

            if (SettingsManager.MINIMUM_INITIAL_NUMBER_CHROMOSOMES_AMOUNT > SettingsManager.InitialNumberChromosomesAmount)
            {
                errors.Add($"El tamaño mínimo permitido de cromosomas para número inicial es de {SettingsManager.MINIMUM_INITIAL_NUMBER_CHROMOSOMES_AMOUNT}.");
            }

            if (SettingsManager.MINIMUM_MUTATION_CHROMOSOMES_AMOUNT > SettingsManager.SecondaryMutationChromosomesAmount)
            {
                errors.Add($"El tamaño mínimo permitido de cromosomas para mutación temporal es de {SettingsManager.MINIMUM_MUTATION_CHROMOSOMES_AMOUNT}.");
            }

            bool needsEven = SettingsManager.MinimumChromosomeSize % 2 == 0;
            if (needsEven != (SettingsManager.TotalChromosomes % 2 == 0))
            {
                errors.Add($"Dada la configuración actual, el número total de cromosomas debe ser " + (needsEven ? "par" : "impar"));
            }

            if (SettingsManager.MaxMutableChromosomes > SettingsManager.TotalChromosomes)
            {
                errors.Add("La cantidad de cromosomas que potencialmente se pueden cambiar en caso de mutación, no puede ser mayor al número de cromosomas totales.");
            }

            if (SettingsManager.ChromosomesMatchesToConcludeSimilar > SettingsManager.TotalChromosomes)
            {
                errors.Add("La cantidad de cromosomas iguales para determinar similitud entre dos individuos, no puede ser mayor que la cantidad de cromosomas.");
            }

            if (SettingsManager.IndividualMatchesToStopSimulation > SettingsManager.IndividualsPerGeneration)
            {
                errors.Add("La cantidad de individous similares para detener la simulación no puede ser mayor a la cantidad de individous que va a haber.");
            }

            rtbErrors.Clear();
            rtbErrors.ForeColor = Color.Red;
            rtbErrors.Font = new Font("Microsoft Sans Serif", 11);
            foreach (string error in errors)
            {
                rtbErrors.AppendText($"{error}{Environment.NewLine}{Environment.NewLine}");
            }

            bRun.Enabled = errors.Count == 0;
        }

        private void SetInitialValues()
        {
            cbSeed.Checked = SettingsManager.UseSeed;
            nudSeed.Value = SettingsManager.InitialSeed;

            nupIndividualsPerGeneration.Value = SettingsManager.IndividualsPerGeneration;
            nudMaxTotalGenerations.Value = SettingsManager.MaxTotalGenerations;
            nudSelectionsByElitism.Value = SettingsManager.SelectionsByElitism;

            barElitismChromosomeChance.Value = (int)(SettingsManager.ElitismChromosomeChance * 1000);
            lElitismChance.Text = $@"{barElitismChromosomeChance.Value / 10f}%";
            nupTotalChromosomes.Value = SettingsManager.TotalChromosomes;
            nupSecondaryMutationChromosomesAmount.Value = SettingsManager.SecondaryMutationChromosomesAmount;
            nupInitialNumberChromosomesAmount.Value = SettingsManager.InitialNumberChromosomesAmount;

            barMutationChance.Value = (int)(SettingsManager.MutationChance * 1000);
            lMutationChance.Text = $@"{barMutationChance.Value / 10f}%";
            nupMaxMutableChromosomes.Value = SettingsManager.MaxMutableChromosomes;

            nupChromosomesMatchesToConcludeSimilar.Value = SettingsManager.ChromosomesMatchesToConcludeSimilar;
            nupSimilarAmountToConcludeUniformity.Value = SettingsManager.IndividualMatchesToStopSimulation;
        }

        private void cbSeed_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.UseSeed = cbSeed.Checked;
        }

        private void nudSeed_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.InitialSeed = (int)nudSeed.Value;
        }

        private void nupIndividualsPerGeneration_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.IndividualsPerGeneration = (int)nupIndividualsPerGeneration.Value;
        }

        private void nudMaxTotalGenerations_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.MaxTotalGenerations = (int)nudMaxTotalGenerations.Value;
        }

        private void nudSelectionsByElitism_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.SelectionsByElitism = (int)nudSelectionsByElitism.Value;
            ValidateAll();
        }

        private void barElitismChromosomeChance_Scroll(object sender, EventArgs e)
        {
            float value = barElitismChromosomeChance.Value / 1000f;
            lElitismChance.Text = $@"{barElitismChromosomeChance.Value / 10f}%";
            SettingsManager.ElitismChromosomeChance = value;
        }

        private void barMutationChance_Scroll(object sender, EventArgs e)
        {
            float value = barMutationChance.Value / 1000f;
            lMutationChance.Text = $@"{barMutationChance.Value / 10f}%";
            SettingsManager.MutationChance = value;
        }

        private void nupTotalChromosomes_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.TotalChromosomes = (int)nupTotalChromosomes.Value;
            ValidateAll();
        }

        private void nupSecondaryMutationChromosomesAmount_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.SecondaryMutationChromosomesAmount = (int)nupSecondaryMutationChromosomesAmount.Value;
            ValidateAll();
        }

        private void nupInitialNumberChromosomesAmount_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.InitialNumberChromosomesAmount = (int)nupInitialNumberChromosomesAmount.Value;
            ValidateAll();
        }

        private void nupMaxMutableChromosomes_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.MaxMutableChromosomes = (int)nupMaxMutableChromosomes.Value;
            ValidateAll();
        }

        private void nupChromosomesMatchesToConcludeSimilar_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.ChromosomesMatchesToConcludeSimilar = (int)nupChromosomesMatchesToConcludeSimilar.Value;
            ValidateAll();
        }

        private void nupSimilarAmountToConcludeUniformity_ValueChanged(object sender, EventArgs e)
        {
            SettingsManager.IndividualMatchesToStopSimulation = (int)nupSimilarAmountToConcludeUniformity.Value;
            ValidateAll();
        }


        #endregion Validators

        #region Application Controls
        
        private void bRun_Click(object sender, EventArgs e)
        {

        }

        private void bFirst_Click(object sender, EventArgs e)
        {

        }

        private void bLast_Click(object sender, EventArgs e)
        {

        }

        private void bPrevious_Click(object sender, EventArgs e)
        {

        }

        private void bNext_Click(object sender, EventArgs e)
        {

        }

        #endregion Application Controls
    }
}
