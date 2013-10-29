namespace NeuronStudio
{
    partial class NNTrainingForm
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
            this._tbErrorFactor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._buttonRunNextPattern = new System.Windows.Forms.Button();
            this._buttonTrainIt = new System.Windows.Forms.Button();
            this._tbNumberOfSynapses = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._buttonTest = new System.Windows.Forms.Button();
            this._tbEpoch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._tbMinErrorSoFar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._tbCorrectSelectionsPercentage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._tbCorrectSelections = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._tbSizeOfTrainingSample = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this._buttonReset = new System.Windows.Forms.Button();
            this._buttonSave = new System.Windows.Forms.Button();
            this._buttonOpen = new System.Windows.Forms.Button();
            this._tbNumberOfRacesForTraining = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbAvgSignalStrength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._tbTotalBets = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._tbTotalWinners = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._tbTotalAmountBet = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this._tbTotalAmountWon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._tbNumberOfRacesForTesting = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this._tbWinPercent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._tbCorrectPercentage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._tbGlobalWinningFavoritePercentage = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this._neuralNetworkCtrl = new NeuronStudio.NeuralNetworkCtrl();
            this._tbNumberOfInputNodes = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this._tbNumberOfHiddenNeurons = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this._buttonTrainUsingGeneticAlgorithm = new System.Windows.Forms.Button();
            this._tbOutput = new System.Windows.Forms.TextBox();
            this._tbNumberOfFirstFavorites = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this._tbNumberOfSecondFavorites = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this._tbNumberOfThirdFavorites = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tbErrorFactor
            // 
            this._tbErrorFactor.BackColor = System.Drawing.Color.Black;
            this._tbErrorFactor.Font = new System.Drawing.Font("Levenim MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._tbErrorFactor.ForeColor = System.Drawing.Color.Lime;
            this._tbErrorFactor.Location = new System.Drawing.Point(19, 19);
            this._tbErrorFactor.Name = "_tbErrorFactor";
            this._tbErrorFactor.ReadOnly = true;
            this._tbErrorFactor.Size = new System.Drawing.Size(95, 30);
            this._tbErrorFactor.TabIndex = 4;
            this._tbErrorFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Error:";
            // 
            // _buttonRunNextPattern
            // 
            this._buttonRunNextPattern.Location = new System.Drawing.Point(561, 9);
            this._buttonRunNextPattern.Name = "_buttonRunNextPattern";
            this._buttonRunNextPattern.Size = new System.Drawing.Size(75, 40);
            this._buttonRunNextPattern.TabIndex = 5;
            this._buttonRunNextPattern.Text = "Run Next Pattern";
            this._buttonRunNextPattern.UseVisualStyleBackColor = true;
            this._buttonRunNextPattern.Click += new System.EventHandler(this.RunNextPatternClick);
            // 
            // _buttonTrainIt
            // 
            this._buttonTrainIt.Location = new System.Drawing.Point(654, 9);
            this._buttonTrainIt.Name = "_buttonTrainIt";
            this._buttonTrainIt.Size = new System.Drawing.Size(75, 40);
            this._buttonTrainIt.TabIndex = 6;
            this._buttonTrainIt.Text = "Train It";
            this._buttonTrainIt.UseVisualStyleBackColor = true;
            this._buttonTrainIt.Click += new System.EventHandler(this.TrainClick);
            // 
            // _tbNumberOfSynapses
            // 
            this._tbNumberOfSynapses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfSynapses.Location = new System.Drawing.Point(345, 23);
            this._tbNumberOfSynapses.Name = "_tbNumberOfSynapses";
            this._tbNumberOfSynapses.ReadOnly = true;
            this._tbNumberOfSynapses.Size = new System.Drawing.Size(70, 26);
            this._tbNumberOfSynapses.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Synapses";
            // 
            // _buttonTest
            // 
            this._buttonTest.Location = new System.Drawing.Point(748, 9);
            this._buttonTest.Name = "_buttonTest";
            this._buttonTest.Size = new System.Drawing.Size(75, 40);
            this._buttonTest.TabIndex = 10;
            this._buttonTest.Text = "Test";
            this._buttonTest.UseVisualStyleBackColor = true;
            this._buttonTest.Click += new System.EventHandler(this.TestClick);
            // 
            // _tbEpoch
            // 
            this._tbEpoch.BackColor = System.Drawing.Color.Black;
            this._tbEpoch.Font = new System.Drawing.Font("Levenim MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._tbEpoch.ForeColor = System.Drawing.Color.Lime;
            this._tbEpoch.Location = new System.Drawing.Point(231, 19);
            this._tbEpoch.Name = "_tbEpoch";
            this._tbEpoch.ReadOnly = true;
            this._tbEpoch.Size = new System.Drawing.Size(70, 30);
            this._tbEpoch.TabIndex = 13;
            this._tbEpoch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Epoch";
            // 
            // _tbMinErrorSoFar
            // 
            this._tbMinErrorSoFar.BackColor = System.Drawing.Color.Black;
            this._tbMinErrorSoFar.Font = new System.Drawing.Font("Levenim MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._tbMinErrorSoFar.ForeColor = System.Drawing.Color.Lime;
            this._tbMinErrorSoFar.Location = new System.Drawing.Point(120, 19);
            this._tbMinErrorSoFar.Name = "_tbMinErrorSoFar";
            this._tbMinErrorSoFar.ReadOnly = true;
            this._tbMinErrorSoFar.Size = new System.Drawing.Size(95, 30);
            this._tbMinErrorSoFar.TabIndex = 15;
            this._tbMinErrorSoFar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "MinError:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this._tbCorrectSelectionsPercentage);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this._tbCorrectSelections);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this._tbSizeOfTrainingSample);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(947, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 92);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selections";
            // 
            // _tbCorrectSelectionsPercentage
            // 
            this._tbCorrectSelectionsPercentage.BackColor = System.Drawing.Color.MintCream;
            this._tbCorrectSelectionsPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbCorrectSelectionsPercentage.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbCorrectSelectionsPercentage.Location = new System.Drawing.Point(181, 50);
            this._tbCorrectSelectionsPercentage.Name = "_tbCorrectSelectionsPercentage";
            this._tbCorrectSelectionsPercentage.ReadOnly = true;
            this._tbCorrectSelectionsPercentage.Size = new System.Drawing.Size(70, 26);
            this._tbCorrectSelectionsPercentage.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(178, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "%";
            // 
            // _tbCorrectSelections
            // 
            this._tbCorrectSelections.BackColor = System.Drawing.Color.MintCream;
            this._tbCorrectSelections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbCorrectSelections.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbCorrectSelections.Location = new System.Drawing.Point(105, 50);
            this._tbCorrectSelections.Name = "_tbCorrectSelections";
            this._tbCorrectSelections.ReadOnly = true;
            this._tbCorrectSelections.Size = new System.Drawing.Size(70, 26);
            this._tbCorrectSelections.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(102, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Correct";
            // 
            // _tbSizeOfTrainingSample
            // 
            this._tbSizeOfTrainingSample.BackColor = System.Drawing.Color.MintCream;
            this._tbSizeOfTrainingSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSizeOfTrainingSample.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbSizeOfTrainingSample.Location = new System.Drawing.Point(19, 50);
            this._tbSizeOfTrainingSample.Name = "_tbSizeOfTrainingSample";
            this._tbSizeOfTrainingSample.ReadOnly = true;
            this._tbSizeOfTrainingSample.Size = new System.Drawing.Size(70, 26);
            this._tbSizeOfTrainingSample.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Count";
            // 
            // _buttonReset
            // 
            this._buttonReset.Location = new System.Drawing.Point(463, 9);
            this._buttonReset.Name = "_buttonReset";
            this._buttonReset.Size = new System.Drawing.Size(75, 40);
            this._buttonReset.TabIndex = 52;
            this._buttonReset.Text = "Reset";
            this._buttonReset.UseVisualStyleBackColor = true;
            this._buttonReset.Click += new System.EventHandler(this.ResetClick);
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(463, 55);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(75, 40);
            this._buttonSave.TabIndex = 53;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // _buttonOpen
            // 
            this._buttonOpen.Location = new System.Drawing.Point(561, 55);
            this._buttonOpen.Name = "_buttonOpen";
            this._buttonOpen.Size = new System.Drawing.Size(75, 40);
            this._buttonOpen.TabIndex = 54;
            this._buttonOpen.Text = "Open";
            this._buttonOpen.UseVisualStyleBackColor = true;
            this._buttonOpen.Click += new System.EventHandler(this.OpenClick);
            // 
            // _tbNumberOfRacesForTraining
            // 
            this._tbNumberOfRacesForTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfRacesForTraining.Location = new System.Drawing.Point(19, 72);
            this._tbNumberOfRacesForTraining.Name = "_tbNumberOfRacesForTraining";
            this._tbNumberOfRacesForTraining.ReadOnly = true;
            this._tbNumberOfRacesForTraining.Size = new System.Drawing.Size(123, 26);
            this._tbNumberOfRacesForTraining.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Races For Training";
            // 
            // _tbAvgSignalStrength
            // 
            this._tbAvgSignalStrength.BackColor = System.Drawing.Color.MintCream;
            this._tbAvgSignalStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAvgSignalStrength.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbAvgSignalStrength.Location = new System.Drawing.Point(966, 248);
            this._tbAvgSignalStrength.Name = "_tbAvgSignalStrength";
            this._tbAvgSignalStrength.ReadOnly = true;
            this._tbAvgSignalStrength.Size = new System.Drawing.Size(70, 26);
            this._tbAvgSignalStrength.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(963, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Avg Signal Strength";
            // 
            // _tbTotalBets
            // 
            this._tbTotalBets.BackColor = System.Drawing.Color.MintCream;
            this._tbTotalBets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTotalBets.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbTotalBets.Location = new System.Drawing.Point(966, 336);
            this._tbTotalBets.Name = "_tbTotalBets";
            this._tbTotalBets.ReadOnly = true;
            this._tbTotalBets.Size = new System.Drawing.Size(70, 26);
            this._tbTotalBets.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(963, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Total Bets";
            // 
            // _tbTotalWinners
            // 
            this._tbTotalWinners.BackColor = System.Drawing.Color.MintCream;
            this._tbTotalWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTotalWinners.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbTotalWinners.Location = new System.Drawing.Point(1052, 336);
            this._tbTotalWinners.Name = "_tbTotalWinners";
            this._tbTotalWinners.ReadOnly = true;
            this._tbTotalWinners.Size = new System.Drawing.Size(70, 26);
            this._tbTotalWinners.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1049, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Total Winners";
            // 
            // _tbTotalAmountBet
            // 
            this._tbTotalAmountBet.BackColor = System.Drawing.Color.MintCream;
            this._tbTotalAmountBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTotalAmountBet.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbTotalAmountBet.Location = new System.Drawing.Point(969, 401);
            this._tbTotalAmountBet.Name = "_tbTotalAmountBet";
            this._tbTotalAmountBet.ReadOnly = true;
            this._tbTotalAmountBet.Size = new System.Drawing.Size(70, 26);
            this._tbTotalAmountBet.TabIndex = 68;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(966, 385);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Total Amount Bet";
            // 
            // _tbTotalAmountWon
            // 
            this._tbTotalAmountWon.BackColor = System.Drawing.Color.MintCream;
            this._tbTotalAmountWon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTotalAmountWon.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbTotalAmountWon.Location = new System.Drawing.Point(1073, 401);
            this._tbTotalAmountWon.Name = "_tbTotalAmountWon";
            this._tbTotalAmountWon.ReadOnly = true;
            this._tbTotalAmountWon.Size = new System.Drawing.Size(70, 26);
            this._tbTotalAmountWon.TabIndex = 70;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1070, 385);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 69;
            this.label12.Text = "Total Amount Won";
            // 
            // _tbNumberOfRacesForTesting
            // 
            this._tbNumberOfRacesForTesting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfRacesForTesting.Location = new System.Drawing.Point(162, 71);
            this._tbNumberOfRacesForTesting.Name = "_tbNumberOfRacesForTesting";
            this._tbNumberOfRacesForTesting.ReadOnly = true;
            this._tbNumberOfRacesForTesting.Size = new System.Drawing.Size(123, 26);
            this._tbNumberOfRacesForTesting.TabIndex = 72;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(159, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 71;
            this.label16.Text = "Races For Testing";
            // 
            // _tbWinPercent
            // 
            this._tbWinPercent.BackColor = System.Drawing.Color.MintCream;
            this._tbWinPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbWinPercent.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbWinPercent.Location = new System.Drawing.Point(1142, 336);
            this._tbWinPercent.Name = "_tbWinPercent";
            this._tbWinPercent.ReadOnly = true;
            this._tbWinPercent.Size = new System.Drawing.Size(70, 26);
            this._tbWinPercent.TabIndex = 74;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1139, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Win %";
            // 
            // _tbCorrectPercentage
            // 
            this._tbCorrectPercentage.BackColor = System.Drawing.Color.MintCream;
            this._tbCorrectPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbCorrectPercentage.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbCorrectPercentage.Location = new System.Drawing.Point(1226, 336);
            this._tbCorrectPercentage.Name = "_tbCorrectPercentage";
            this._tbCorrectPercentage.ReadOnly = true;
            this._tbCorrectPercentage.Size = new System.Drawing.Size(70, 26);
            this._tbCorrectPercentage.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1223, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 75;
            this.label10.Text = "Correct %";
            // 
            // _tbGlobalWinningFavoritePercentage
            // 
            this._tbGlobalWinningFavoritePercentage.BackColor = System.Drawing.Color.MintCream;
            this._tbGlobalWinningFavoritePercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbGlobalWinningFavoritePercentage.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbGlobalWinningFavoritePercentage.Location = new System.Drawing.Point(1184, 401);
            this._tbGlobalWinningFavoritePercentage.Name = "_tbGlobalWinningFavoritePercentage";
            this._tbGlobalWinningFavoritePercentage.ReadOnly = true;
            this._tbGlobalWinningFavoritePercentage.Size = new System.Drawing.Size(70, 26);
            this._tbGlobalWinningFavoritePercentage.TabIndex = 78;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1181, 385);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 13);
            this.label17.TabIndex = 77;
            this.label17.Text = "Winning Favorite%";
            // 
            // _neuralNetworkCtrl
            // 
            this._neuralNetworkCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._neuralNetworkCtrl.Location = new System.Drawing.Point(12, 114);
            this._neuralNetworkCtrl.Name = "_neuralNetworkCtrl";
            this._neuralNetworkCtrl.Size = new System.Drawing.Size(903, 678);
            this._neuralNetworkCtrl.TabIndex = 0;
            this._neuralNetworkCtrl.Text = "neuralNetworkCtrl1";
            // 
            // _tbNumberOfInputNodes
            // 
            this._tbNumberOfInputNodes.BackColor = System.Drawing.Color.MintCream;
            this._tbNumberOfInputNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfInputNodes.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbNumberOfInputNodes.Location = new System.Drawing.Point(969, 535);
            this._tbNumberOfInputNodes.Name = "_tbNumberOfInputNodes";
            this._tbNumberOfInputNodes.ReadOnly = true;
            this._tbNumberOfInputNodes.Size = new System.Drawing.Size(70, 26);
            this._tbNumberOfInputNodes.TabIndex = 80;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(966, 519);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 13);
            this.label18.TabIndex = 79;
            this.label18.Text = "Number Of Input Neurons";
            // 
            // _tbNumberOfHiddenNeurons
            // 
            this._tbNumberOfHiddenNeurons.BackColor = System.Drawing.Color.MintCream;
            this._tbNumberOfHiddenNeurons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfHiddenNeurons.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbNumberOfHiddenNeurons.Location = new System.Drawing.Point(1145, 535);
            this._tbNumberOfHiddenNeurons.Name = "_tbNumberOfHiddenNeurons";
            this._tbNumberOfHiddenNeurons.ReadOnly = true;
            this._tbNumberOfHiddenNeurons.Size = new System.Drawing.Size(70, 26);
            this._tbNumberOfHiddenNeurons.TabIndex = 82;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1142, 519);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 13);
            this.label19.TabIndex = 81;
            this.label19.Text = "Number Of Hidden Neurons";
            // 
            // _buttonTrainUsingGeneticAlgorithm
            // 
            this._buttonTrainUsingGeneticAlgorithm.Location = new System.Drawing.Point(654, 55);
            this._buttonTrainUsingGeneticAlgorithm.Name = "_buttonTrainUsingGeneticAlgorithm";
            this._buttonTrainUsingGeneticAlgorithm.Size = new System.Drawing.Size(169, 40);
            this._buttonTrainUsingGeneticAlgorithm.TabIndex = 83;
            this._buttonTrainUsingGeneticAlgorithm.Text = "Train Using Genetic Algorithm";
            this._buttonTrainUsingGeneticAlgorithm.UseVisualStyleBackColor = true;
            this._buttonTrainUsingGeneticAlgorithm.Click += new System.EventHandler(this.TrainUsingGeneticAlgorithmClick);
            // 
            // _tbOutput
            // 
            this._tbOutput.Location = new System.Drawing.Point(969, 580);
            this._tbOutput.Multiline = true;
            this._tbOutput.Name = "_tbOutput";
            this._tbOutput.ReadOnly = true;
            this._tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._tbOutput.Size = new System.Drawing.Size(368, 184);
            this._tbOutput.TabIndex = 84;
            // 
            // _tbNumberOfFirstFavorites
            // 
            this._tbNumberOfFirstFavorites.BackColor = System.Drawing.Color.MintCream;
            this._tbNumberOfFirstFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfFirstFavorites.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbNumberOfFirstFavorites.Location = new System.Drawing.Point(969, 461);
            this._tbNumberOfFirstFavorites.Name = "_tbNumberOfFirstFavorites";
            this._tbNumberOfFirstFavorites.ReadOnly = true;
            this._tbNumberOfFirstFavorites.Size = new System.Drawing.Size(70, 26);
            this._tbNumberOfFirstFavorites.TabIndex = 86;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(966, 445);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 13);
            this.label20.TabIndex = 85;
            this.label20.Text = "# Of First Favorites";
            // 
            // _tbNumberOfSecondFavorites
            // 
            this._tbNumberOfSecondFavorites.BackColor = System.Drawing.Color.MintCream;
            this._tbNumberOfSecondFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfSecondFavorites.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbNumberOfSecondFavorites.Location = new System.Drawing.Point(1073, 461);
            this._tbNumberOfSecondFavorites.Name = "_tbNumberOfSecondFavorites";
            this._tbNumberOfSecondFavorites.ReadOnly = true;
            this._tbNumberOfSecondFavorites.Size = new System.Drawing.Size(70, 26);
            this._tbNumberOfSecondFavorites.TabIndex = 88;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1070, 445);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 13);
            this.label21.TabIndex = 87;
            this.label21.Text = "# Of Second Favorites";
            // 
            // _tbNumberOfThirdFavorites
            // 
            this._tbNumberOfThirdFavorites.BackColor = System.Drawing.Color.MintCream;
            this._tbNumberOfThirdFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfThirdFavorites.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._tbNumberOfThirdFavorites.Location = new System.Drawing.Point(1203, 461);
            this._tbNumberOfThirdFavorites.Name = "_tbNumberOfThirdFavorites";
            this._tbNumberOfThirdFavorites.ReadOnly = true;
            this._tbNumberOfThirdFavorites.Size = new System.Drawing.Size(70, 26);
            this._tbNumberOfThirdFavorites.TabIndex = 90;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1200, 445);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 13);
            this.label22.TabIndex = 89;
            this.label22.Text = "# Of Third Favorites";
            // 
            // NNTrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 804);
            this.Controls.Add(this._tbNumberOfThirdFavorites);
            this.Controls.Add(this.label22);
            this.Controls.Add(this._tbNumberOfSecondFavorites);
            this.Controls.Add(this.label21);
            this.Controls.Add(this._tbNumberOfFirstFavorites);
            this.Controls.Add(this.label20);
            this.Controls.Add(this._tbOutput);
            this.Controls.Add(this._buttonTrainUsingGeneticAlgorithm);
            this.Controls.Add(this._tbNumberOfHiddenNeurons);
            this.Controls.Add(this.label19);
            this.Controls.Add(this._tbNumberOfInputNodes);
            this.Controls.Add(this.label18);
            this.Controls.Add(this._tbGlobalWinningFavoritePercentage);
            this.Controls.Add(this.label17);
            this.Controls.Add(this._tbCorrectPercentage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._tbWinPercent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._tbNumberOfRacesForTesting);
            this.Controls.Add(this.label16);
            this.Controls.Add(this._tbTotalAmountWon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._tbTotalAmountBet);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._tbTotalWinners);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._tbTotalBets);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._tbAvgSignalStrength);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._tbNumberOfRacesForTraining);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._buttonOpen);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this._buttonReset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._tbMinErrorSoFar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._tbEpoch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._buttonTest);
            this.Controls.Add(this._tbNumberOfSynapses);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._buttonTrainIt);
            this.Controls.Add(this._buttonRunNextPattern);
            this.Controls.Add(this._tbErrorFactor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._neuralNetworkCtrl);
            this.Name = "NNTrainingForm";
            this.Text = "Neural Network Studio (John Pazarzis (c) March 2011 version 1.0)  ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLoad);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NeuralNetworkCtrl _neuralNetworkCtrl;
        private System.Windows.Forms.TextBox _tbErrorFactor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _buttonRunNextPattern;
        private System.Windows.Forms.Button _buttonTrainIt;
        private System.Windows.Forms.TextBox _tbNumberOfSynapses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _buttonTest;
        private System.Windows.Forms.TextBox _tbEpoch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbMinErrorSoFar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _tbCorrectSelectionsPercentage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _tbCorrectSelections;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _tbSizeOfTrainingSample;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button _buttonReset;
        private System.Windows.Forms.Button _buttonSave;
        private System.Windows.Forms.Button _buttonOpen;
        private System.Windows.Forms.TextBox _tbNumberOfRacesForTraining;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbAvgSignalStrength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _tbTotalBets;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _tbTotalWinners;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _tbTotalAmountBet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _tbTotalAmountWon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _tbNumberOfRacesForTesting;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox _tbWinPercent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _tbCorrectPercentage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _tbGlobalWinningFavoritePercentage;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox _tbNumberOfInputNodes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox _tbNumberOfHiddenNeurons;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button _buttonTrainUsingGeneticAlgorithm;
        private System.Windows.Forms.TextBox _tbOutput;
        private System.Windows.Forms.TextBox _tbNumberOfFirstFavorites;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox _tbNumberOfSecondFavorites;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox _tbNumberOfThirdFavorites;
        private System.Windows.Forms.Label label22;
    }
}

