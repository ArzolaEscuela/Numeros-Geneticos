namespace Numeros_Geneticos
{
    partial class NumerosGeneticos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumerosGeneticos));
            this.bNext = new System.Windows.Forms.Button();
            this.lSeed = new System.Windows.Forms.Label();
            this.pbGenerationResults = new System.Windows.Forms.PictureBox();
            this.dgvGenerationResults = new System.Windows.Forms.DataGridView();
            this.bPrevious = new System.Windows.Forms.Button();
            this.bFirst = new System.Windows.Forms.Button();
            this.bLast = new System.Windows.Forms.Button();
            this.rtbInstructions = new System.Windows.Forms.RichTextBox();
            this.lName = new System.Windows.Forms.Label();
            this.bRun = new System.Windows.Forms.Button();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.barElitismChromosomeChance = new System.Windows.Forms.TrackBar();
            this.cbSeed = new System.Windows.Forms.CheckBox();
            this.nupIndividualsPerGeneration = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSelectionsByElitism = new System.Windows.Forms.NumericUpDown();
            this.nudMaxTotalGenerations = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nupTotalChromosomes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nupSecondaryMutationChromosomesAmount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nupInitialNumberChromosomesAmount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lElitismChance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nupMaxMutableChromosomes = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.lMutationChance = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.barMutationChance = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.nupChromosomesMatchesToConcludeSimilar = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.nupSimilarAmountToConcludeUniformity = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.rtbErrors = new System.Windows.Forms.RichTextBox();
            this.lGenerationCount = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.pPicture = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerationResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenerationResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barElitismChromosomeChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupIndividualsPerGeneration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectionsByElitism)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxTotalGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupTotalChromosomes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSecondaryMutationChromosomesAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupInitialNumberChromosomesAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxMutableChromosomes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupChromosomesMatchesToConcludeSimilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSimilarAmountToConcludeUniformity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.pPicture.SuspendLayout();
            this.SuspendLayout();
            // 
            // bNext
            // 
            this.bNext.Location = new System.Drawing.Point(606, 282);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(75, 23);
            this.bNext.TabIndex = 1;
            this.bNext.Text = "🡲";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // lSeed
            // 
            this.lSeed.CausesValidation = false;
            this.lSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSeed.Location = new System.Drawing.Point(210, 6);
            this.lSeed.Name = "lSeed";
            this.lSeed.Size = new System.Drawing.Size(123, 23);
            this.lSeed.TabIndex = 2;
            this.lSeed.Text = "Semilla";
            this.lSeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbGenerationResults
            // 
            this.pbGenerationResults.Location = new System.Drawing.Point(-1, -2);
            this.pbGenerationResults.Name = "pbGenerationResults";
            this.pbGenerationResults.Size = new System.Drawing.Size(500, 250);
            this.pbGenerationResults.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbGenerationResults.TabIndex = 3;
            this.pbGenerationResults.TabStop = false;
            // 
            // dgvGenerationResults
            // 
            this.dgvGenerationResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenerationResults.Location = new System.Drawing.Point(403, 319);
            this.dgvGenerationResults.Name = "dgvGenerationResults";
            this.dgvGenerationResults.ReadOnly = true;
            this.dgvGenerationResults.Size = new System.Drawing.Size(496, 405);
            this.dgvGenerationResults.TabIndex = 4;
            // 
            // bPrevious
            // 
            this.bPrevious.Location = new System.Drawing.Point(506, 282);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(75, 23);
            this.bPrevious.TabIndex = 5;
            this.bPrevious.Text = "🡰";
            this.bPrevious.UseVisualStyleBackColor = true;
            this.bPrevious.Click += new System.EventHandler(this.bPrevious_Click);
            // 
            // bFirst
            // 
            this.bFirst.Location = new System.Drawing.Point(404, 282);
            this.bFirst.Name = "bFirst";
            this.bFirst.Size = new System.Drawing.Size(75, 23);
            this.bFirst.TabIndex = 6;
            this.bFirst.Text = "Primera";
            this.bFirst.UseVisualStyleBackColor = true;
            this.bFirst.Click += new System.EventHandler(this.bFirst_Click);
            // 
            // bLast
            // 
            this.bLast.Location = new System.Drawing.Point(705, 282);
            this.bLast.Name = "bLast";
            this.bLast.Size = new System.Drawing.Size(75, 23);
            this.bLast.TabIndex = 7;
            this.bLast.Text = "Última";
            this.bLast.UseVisualStyleBackColor = true;
            this.bLast.Click += new System.EventHandler(this.bLast_Click);
            // 
            // rtbInstructions
            // 
            this.rtbInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInstructions.Location = new System.Drawing.Point(12, 636);
            this.rtbInstructions.Name = "rtbInstructions";
            this.rtbInstructions.ReadOnly = true;
            this.rtbInstructions.Size = new System.Drawing.Size(375, 201);
            this.rtbInstructions.TabIndex = 8;
            this.rtbInstructions.Text = "";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(12, 844);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(179, 13);
            this.lName.TabIndex = 9;
            this.lName.Text = "Luis Raúl Arzola López - A01186956";
            // 
            // bRun
            // 
            this.bRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRun.Location = new System.Drawing.Point(208, 587);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(179, 30);
            this.bRun.TabIndex = 10;
            this.bRun.Text = "Empezar Simulación";
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // nudSeed
            // 
            this.nudSeed.Location = new System.Drawing.Point(213, 32);
            this.nudSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudSeed.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(120, 20);
            this.nudSeed.TabIndex = 12;
            this.nudSeed.ValueChanged += new System.EventHandler(this.nudSeed_ValueChanged);
            // 
            // barElitismChromosomeChance
            // 
            this.barElitismChromosomeChance.LargeChange = 50;
            this.barElitismChromosomeChance.Location = new System.Drawing.Point(28, 231);
            this.barElitismChromosomeChance.Maximum = 1000;
            this.barElitismChromosomeChance.Name = "barElitismChromosomeChance";
            this.barElitismChromosomeChance.Size = new System.Drawing.Size(288, 45);
            this.barElitismChromosomeChance.TabIndex = 13;
            this.barElitismChromosomeChance.TickFrequency = 50;
            this.barElitismChromosomeChance.Scroll += new System.EventHandler(this.barElitismChromosomeChance_Scroll);
            // 
            // cbSeed
            // 
            this.cbSeed.AutoSize = true;
            this.cbSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeed.Location = new System.Drawing.Point(72, 33);
            this.cbSeed.Name = "cbSeed";
            this.cbSeed.Size = new System.Drawing.Size(110, 17);
            this.cbSeed.TabIndex = 14;
            this.cbSeed.Text = "¿Usar Semilla?";
            this.cbSeed.UseVisualStyleBackColor = true;
            this.cbSeed.CheckedChanged += new System.EventHandler(this.cbSeed_CheckedChanged);
            // 
            // nupIndividualsPerGeneration
            // 
            this.nupIndividualsPerGeneration.Location = new System.Drawing.Point(249, 72);
            this.nupIndividualsPerGeneration.Name = "nupIndividualsPerGeneration";
            this.nupIndividualsPerGeneration.Size = new System.Drawing.Size(120, 20);
            this.nupIndividualsPerGeneration.TabIndex = 15;
            this.nupIndividualsPerGeneration.ValueChanged += new System.EventHandler(this.nupIndividualsPerGeneration_ValueChanged);
            // 
            // label1
            // 
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Individuos Por Generación";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // separator
            // 
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator.CausesValidation = false;
            this.separator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.separator.Location = new System.Drawing.Point(28, 62);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(349, 2);
            this.separator.TabIndex = 17;
            this.separator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Total de Elecciones Por Elitismo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudSelectionsByElitism
            // 
            this.nudSelectionsByElitism.Location = new System.Drawing.Point(249, 102);
            this.nudSelectionsByElitism.Name = "nudSelectionsByElitism";
            this.nudSelectionsByElitism.Size = new System.Drawing.Size(120, 20);
            this.nudSelectionsByElitism.TabIndex = 19;
            this.nudSelectionsByElitism.ValueChanged += new System.EventHandler(this.nudSelectionsByElitism_ValueChanged);
            // 
            // nudMaxTotalGenerations
            // 
            this.nudMaxTotalGenerations.Location = new System.Drawing.Point(249, 171);
            this.nudMaxTotalGenerations.Name = "nudMaxTotalGenerations";
            this.nudMaxTotalGenerations.Size = new System.Drawing.Size(120, 20);
            this.nudMaxTotalGenerations.TabIndex = 21;
            this.nudMaxTotalGenerations.ValueChanged += new System.EventHandler(this.nudMaxTotalGenerations_ValueChanged);
            // 
            // label3
            // 
            this.label3.CausesValidation = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Máximo de Generaciones";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nupTotalChromosomes
            // 
            this.nupTotalChromosomes.Location = new System.Drawing.Point(249, 272);
            this.nupTotalChromosomes.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupTotalChromosomes.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nupTotalChromosomes.Name = "nupTotalChromosomes";
            this.nupTotalChromosomes.Size = new System.Drawing.Size(120, 20);
            this.nupTotalChromosomes.TabIndex = 23;
            this.nupTotalChromosomes.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nupTotalChromosomes.ValueChanged += new System.EventHandler(this.nupTotalChromosomes_ValueChanged);
            // 
            // label4
            // 
            this.label4.CausesValidation = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Total de Cromosomas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nupSecondaryMutationChromosomesAmount
            // 
            this.nupSecondaryMutationChromosomesAmount.Location = new System.Drawing.Point(249, 302);
            this.nupSecondaryMutationChromosomesAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupSecondaryMutationChromosomesAmount.Name = "nupSecondaryMutationChromosomesAmount";
            this.nupSecondaryMutationChromosomesAmount.Size = new System.Drawing.Size(120, 20);
            this.nupSecondaryMutationChromosomesAmount.TabIndex = 25;
            this.nupSecondaryMutationChromosomesAmount.ValueChanged += new System.EventHandler(this.nupSecondaryMutationChromosomesAmount_ValueChanged);
            // 
            // label5
            // 
            this.label5.CausesValidation = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 26);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tamaño de Cromosomas para Mutación Temporal";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nupInitialNumberChromosomesAmount
            // 
            this.nupInitialNumberChromosomesAmount.Location = new System.Drawing.Point(249, 336);
            this.nupInitialNumberChromosomesAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupInitialNumberChromosomesAmount.Name = "nupInitialNumberChromosomesAmount";
            this.nupInitialNumberChromosomesAmount.Size = new System.Drawing.Size(120, 20);
            this.nupInitialNumberChromosomesAmount.TabIndex = 27;
            this.nupInitialNumberChromosomesAmount.ValueChanged += new System.EventHandler(this.nupInitialNumberChromosomesAmount_ValueChanged);
            // 
            // label6
            // 
            this.label6.CausesValidation = false;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 26);
            this.label6.TabIndex = 26;
            this.label6.Text = "Tamaño de Cromosomas para Número Inicial";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(385, 23);
            this.label7.TabIndex = 28;
            this.label7.Text = "Probabilidad de Herencia de un Cromosoma Por Elitismo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lElitismChance
            // 
            this.lElitismChance.CausesValidation = false;
            this.lElitismChance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lElitismChance.Location = new System.Drawing.Point(314, 231);
            this.lElitismChance.Name = "lElitismChance";
            this.lElitismChance.Size = new System.Drawing.Size(55, 23);
            this.lElitismChance.TabIndex = 29;
            this.lElitismChance.Text = "100%";
            this.lElitismChance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.CausesValidation = false;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(349, 2);
            this.label9.TabIndex = 30;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.CausesValidation = false;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(349, 2);
            this.label10.TabIndex = 31;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupMaxMutableChromosomes
            // 
            this.nupMaxMutableChromosomes.Location = new System.Drawing.Point(240, 452);
            this.nupMaxMutableChromosomes.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupMaxMutableChromosomes.Name = "nupMaxMutableChromosomes";
            this.nupMaxMutableChromosomes.Size = new System.Drawing.Size(120, 20);
            this.nupMaxMutableChromosomes.TabIndex = 33;
            this.nupMaxMutableChromosomes.ValueChanged += new System.EventHandler(this.nupMaxMutableChromosomes_ValueChanged);
            // 
            // label11
            // 
            this.label11.CausesValidation = false;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 445);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 35);
            this.label11.TabIndex = 32;
            this.label11.Text = "Máximo de Cromosomas Mutables";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMutationChance
            // 
            this.lMutationChance.CausesValidation = false;
            this.lMutationChance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMutationChance.Location = new System.Drawing.Point(312, 404);
            this.lMutationChance.Name = "lMutationChance";
            this.lMutationChance.Size = new System.Drawing.Size(57, 23);
            this.lMutationChance.TabIndex = 36;
            this.lMutationChance.Text = "100%";
            this.lMutationChance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.CausesValidation = false;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 381);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(385, 23);
            this.label13.TabIndex = 35;
            this.label13.Text = "Probabilidad de Mutación de un Cromosoma";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barMutationChance
            // 
            this.barMutationChance.LargeChange = 50;
            this.barMutationChance.Location = new System.Drawing.Point(28, 404);
            this.barMutationChance.Maximum = 1000;
            this.barMutationChance.Name = "barMutationChance";
            this.barMutationChance.Size = new System.Drawing.Size(288, 45);
            this.barMutationChance.TabIndex = 34;
            this.barMutationChance.TickFrequency = 50;
            this.barMutationChance.Scroll += new System.EventHandler(this.barMutationChance_Scroll);
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.CausesValidation = false;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(28, 490);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(349, 2);
            this.label14.TabIndex = 37;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupChromosomesMatchesToConcludeSimilar
            // 
            this.nupChromosomesMatchesToConcludeSimilar.Location = new System.Drawing.Point(236, 508);
            this.nupChromosomesMatchesToConcludeSimilar.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupChromosomesMatchesToConcludeSimilar.Name = "nupChromosomesMatchesToConcludeSimilar";
            this.nupChromosomesMatchesToConcludeSimilar.Size = new System.Drawing.Size(120, 20);
            this.nupChromosomesMatchesToConcludeSimilar.TabIndex = 39;
            this.nupChromosomesMatchesToConcludeSimilar.ValueChanged += new System.EventHandler(this.nupChromosomesMatchesToConcludeSimilar_ValueChanged);
            // 
            // label15
            // 
            this.label15.CausesValidation = false;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(25, 505);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(192, 26);
            this.label15.TabIndex = 38;
            this.label15.Text = "Cantidad de Cromosomas Iguales Para Concluir Similitud";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nupSimilarAmountToConcludeUniformity
            // 
            this.nupSimilarAmountToConcludeUniformity.Location = new System.Drawing.Point(236, 542);
            this.nupSimilarAmountToConcludeUniformity.Name = "nupSimilarAmountToConcludeUniformity";
            this.nupSimilarAmountToConcludeUniformity.Size = new System.Drawing.Size(120, 20);
            this.nupSimilarAmountToConcludeUniformity.TabIndex = 41;
            this.nupSimilarAmountToConcludeUniformity.ValueChanged += new System.EventHandler(this.nupSimilarAmountToConcludeUniformity_ValueChanged);
            // 
            // label16
            // 
            this.label16.CausesValidation = false;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(25, 539);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(192, 26);
            this.label16.TabIndex = 40;
            this.label16.Text = "Cantidad de Individuos Similares Para Detener Simulación";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtbErrors
            // 
            this.rtbErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbErrors.Location = new System.Drawing.Point(401, 742);
            this.rtbErrors.Name = "rtbErrors";
            this.rtbErrors.ReadOnly = true;
            this.rtbErrors.Size = new System.Drawing.Size(498, 95);
            this.rtbErrors.TabIndex = 42;
            this.rtbErrors.Text = "";
            // 
            // lGenerationCount
            // 
            this.lGenerationCount.CausesValidation = false;
            this.lGenerationCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGenerationCount.Location = new System.Drawing.Point(840, 281);
            this.lGenerationCount.Name = "lGenerationCount";
            this.lGenerationCount.Size = new System.Drawing.Size(57, 23);
            this.lGenerationCount.TabIndex = 43;
            this.lGenerationCount.Text = "100/100";
            this.lGenerationCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(97, 592);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(101, 20);
            this.numericUpDown1.TabIndex = 45;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label8
            // 
            this.label8.CausesValidation = false;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 591);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 23);
            this.label8.TabIndex = 44;
            this.label8.Text = "Número Blanco";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pPicture
            // 
            this.pPicture.AutoScroll = true;
            this.pPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pPicture.Controls.Add(this.pbGenerationResults);
            this.pPicture.Location = new System.Drawing.Point(403, 13);
            this.pPicture.Name = "pPicture";
            this.pPicture.Size = new System.Drawing.Size(502, 250);
            this.pPicture.TabIndex = 46;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(22, 131);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(364, 30);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.Text = "¿Los Individuos de Élite Pasan A La Siguiente Generación?\r\n(De Lo Contrario, Solo" +
    " Tendrán Prioridad de Reproducción)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // NumerosGeneticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 865);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lGenerationCount);
            this.Controls.Add(this.pPicture);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rtbErrors);
            this.Controls.Add(this.nupSimilarAmountToConcludeUniformity);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nupChromosomesMatchesToConcludeSimilar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lMutationChance);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.barMutationChance);
            this.Controls.Add(this.nupMaxMutableChromosomes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lElitismChance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nupInitialNumberChromosomesAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nupSecondaryMutationChromosomesAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nupTotalChromosomes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudMaxTotalGenerations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSelectionsByElitism);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nupIndividualsPerGeneration);
            this.Controls.Add(this.cbSeed);
            this.Controls.Add(this.barElitismChromosomeChance);
            this.Controls.Add(this.nudSeed);
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.rtbInstructions);
            this.Controls.Add(this.bLast);
            this.Controls.Add(this.bFirst);
            this.Controls.Add(this.bPrevious);
            this.Controls.Add(this.dgvGenerationResults);
            this.Controls.Add(this.lSeed);
            this.Controls.Add(this.bNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NumerosGeneticos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Números Genéticos - Luis Raúl Arzola López - A01186956";
            this.Load += new System.EventHandler(this.NumerosGeneticos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerationResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenerationResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barElitismChromosomeChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupIndividualsPerGeneration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectionsByElitism)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxTotalGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupTotalChromosomes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSecondaryMutationChromosomesAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupInitialNumberChromosomesAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxMutableChromosomes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupChromosomesMatchesToConcludeSimilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSimilarAmountToConcludeUniformity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.pPicture.ResumeLayout(false);
            this.pPicture.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Label lSeed;
        private System.Windows.Forms.PictureBox pbGenerationResults;
        private System.Windows.Forms.DataGridView dgvGenerationResults;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.Button bFirst;
        private System.Windows.Forms.Button bLast;
        private System.Windows.Forms.RichTextBox rtbInstructions;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.TrackBar barElitismChromosomeChance;
        private System.Windows.Forms.CheckBox cbSeed;
        private System.Windows.Forms.NumericUpDown nupIndividualsPerGeneration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSelectionsByElitism;
        private System.Windows.Forms.NumericUpDown nudMaxTotalGenerations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupTotalChromosomes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nupSecondaryMutationChromosomesAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nupInitialNumberChromosomesAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lElitismChance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nupMaxMutableChromosomes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lMutationChance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar barMutationChance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nupChromosomesMatchesToConcludeSimilar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nupSimilarAmountToConcludeUniformity;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox rtbErrors;
        private System.Windows.Forms.Label lGenerationCount;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pPicture;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

