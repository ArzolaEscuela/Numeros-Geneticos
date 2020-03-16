using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            ValidateAll();
            RedrawText();
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

        }

        #endregion Validators
    }
}
