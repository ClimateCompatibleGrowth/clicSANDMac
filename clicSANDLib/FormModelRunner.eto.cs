using Eto.Forms;
using Eto.Drawing;

namespace clicSANDLib
{
    partial class FormModelRunner : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.layout = new PixelLayout();
            Content = layout;

            this.labelDataSource = new Label();
            this.textBoxDataSource = new TextBox();
            this.labelModel = new Label();
            this.textBoxModel = new TextBox();
            this.buttonRun = new Button();
            this.textBoxOutput = new TextArea();
            this.buttonOpenXLS = new Button();
            this.buttonOpenModel = new Button();
            this.buttonOpenResults = new Button();
            this.numericRatio = new NumericUpDown();
            this.checkCBCRatio = new CheckBox();
            this.buttonSaveTemplates = new Button();
            //((System.ComponentModel.ISupportInitialize)(this.numericRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDataSource
            // 
            //this.labelDataSource.AutoSize = true;
            this.layout.Add(labelDataSource, 13, 13);
            this.labelDataSource.ID = "labelDataSource";
            this.labelDataSource.Size = new Size(118, 13);
            this.labelDataSource.TabIndex = 0;
            this.labelDataSource.Text = "Data Source (txt)";
            // 
            // textBoxDataSource
            // 
            this.layout.Add(textBoxDataSource, 138, 13);
            this.textBoxDataSource.ID = "textBoxDataSource";
            this.textBoxDataSource.Size = new Size(651, 20);
            this.textBoxDataSource.TabIndex = 1;
            // 
            // buttonOpenXLS
            // 
            this.layout.Add(buttonOpenXLS, 795, 13);
            this.buttonOpenXLS.ID = "buttonOpenDataSource";
            this.buttonOpenXLS.Size = new Size(28, 20);
            this.buttonOpenXLS.TabIndex = 2;
            this.buttonOpenXLS.Text = "...";
            //this.buttonOpenXLS.UseVisualStyleBackColor = true;
            this.buttonOpenXLS.Click += new System.EventHandler<System.EventArgs>(this.buttonOpenDataSource_Click);
            // 
            // labelModel
            // 
            //this.labelModel.AutoSize = true;
            this.layout.Add(labelModel, 13, 43);
            this.labelModel.ID = "labelModel";
            this.labelModel.Size = new Size(46, 13);
            this.labelModel.TabIndex = 3;
            this.labelModel.Text = "Model";
            // 
            // textBoxModel
            // 
            this.textBoxModel.TextColor = SystemColors.ControlText;
            this.layout.Add(textBoxModel, 138, 40);
            this.textBoxModel.ID = "textBoxModel";
            this.textBoxModel.Size = new Size(651, 20);
            this.textBoxModel.TabIndex = 4;
            // 
            // buttonOpenModel
            // 
            this.layout.Add(buttonOpenModel, 795, 40);
            this.buttonOpenModel.ID = "buttonOpenModel";
            this.buttonOpenModel.Size = new Size(28, 20);
            this.buttonOpenModel.TabIndex = 5;
            this.buttonOpenModel.Text = "...";
            //this.buttonOpenModel.UseVisualStyleBackColor = true;
            this.buttonOpenModel.Click += new System.EventHandler<System.EventArgs>(this.buttonOpenModel_Click);
            // 
            // buttonRun
            // 
            this.layout.Add(buttonRun, 105, 95);
            this.buttonRun.ID = "buttonRun";
            this.buttonRun.Size = new Size(100, 23);
            this.buttonRun.TabIndex = 6;
            this.buttonRun.Text = "Run";
            //this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler<System.EventArgs>(this.buttonRun_Click);
            // 
            // textBoxOutput
            // 
            this.layout.Add(textBoxOutput, 13, 124);
            //this.textBoxOutput.MaxLength = 100000;
            //this.textBoxOutput.Multiline = true;
            this.textBoxOutput.ID = "textBoxOutput";
            //this.textBoxOutput.ScrollBars = ScrollBars.Vertical;
            this.textBoxOutput.Size = new Size(811, 313);
            this.textBoxOutput.TabIndex = 7;
            // 
            // // buttonOpenResults
            // // 
            // this.layout.Add(buttonOpenResults,211, 95);
            // this.buttonOpenResults.ID = "buttonOpenResults";
            // this.buttonOpenResults.Size = new Size(100, 23);
            // this.buttonOpenResults.TabIndex = 10;
            // this.buttonOpenResults.Text = "Open Log";
            // //this.buttonOpenResults.UseVisualStyleBackColor = true;
            // this.buttonOpenResults.Click += new System.EventHandler<System.EventArgs>(this.buttonOpenResults_Click);
            // 
            // numericRatio
            // 
            this.numericRatio.DecimalPlaces = 2;
            this.numericRatio.Increment = 0.01;
            this.layout.Add(numericRatio, 108, 68);
            this.numericRatio.MinValue = 0.0;
            this.numericRatio.MaxValue = 1.0;
            this.numericRatio.ID = "numericRatio";
            this.numericRatio.Size = new Size(55, 20);
            this.numericRatio.TabIndex = 13;
            this.numericRatio.Value = 0.05;
            // 
            // checkCBCRatio
            // 
            //this.checkCBCRatio.AutoSize = true;
            this.checkCBCRatio.Checked = true;
            //this.checkCBCRatio.CheckState = CheckState.Checked;
            this.layout.Add(checkCBCRatio, 13, 70);
            this.checkCBCRatio.ID = "checkCBCRatio";
            this.checkCBCRatio.Size = new Size(81, 17);
            this.checkCBCRatio.TabIndex = 14;
            this.checkCBCRatio.Text = "Ratio (CBC)";
            //this.checkCBCRatio.UseVisualStyleBackColor = true;
            this.checkCBCRatio.CheckedChanged += new System.EventHandler<System.EventArgs>(this.checkCBCRatio_CheckedChanged);
            // 
            // buttonSaveTemplates
            // 
            this.layout.Add(buttonSaveTemplates, 211, 95);
            this.buttonSaveTemplates.ID = "buttonSaveTemplates";
            this.buttonSaveTemplates.Size = new Size(120, 23);
            this.buttonSaveTemplates.TabIndex = 15;
            this.buttonSaveTemplates.Text = "Export Templates ...";
            //this.buttonSaveTemplates.UseVisualStyleBackColor = true;
            this.buttonSaveTemplates.Click += new System.EventHandler<System.EventArgs>(this.buttonSaveTemplates_Click);
            // 
            // FormModelRunner
            // 
            //this.AutoScaleDimensions = new SizeF(6F, 13F);
            //this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(836, 449);
            //this.Controls.Add(this.buttonSaveTemplates);
            //this.Controls.Add(this.checkCBCRatio);
            //this.Controls.Add(this.numericRatio);
            //this.Controls.Add(this.buttonOpenResults);
            //this.Controls.Add(this.buttonOpenModel);
            //this.Controls.Add(this.buttonOpenXLS);
            //this.Controls.Add(this.textBoxOutput);
            //this.Controls.Add(this.buttonRun);
            //this.Controls.Add(this.textBoxModel);
            //this.Controls.Add(this.labelModel);
            //this.Controls.Add(this.textBoxDataSource);
            //this.Controls.Add(this.labelDataSource);
            this.ID = "FormModelRunner";
            this.Title = "clicSAND";
            //((System.ComponentModel.ISupportInitialize)(this.numericRatio)).EndInit();
            //this.ResumeLayout(false);
            //this.PerformLayout();

            var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
            quitCommand.Executed += (sender, e) => Application.Instance.Quit();

            Menu = new MenuBar

            {
                QuitItem = quitCommand
            };
        }

        #endregion

        private Label labelDataSource;
        private TextBox textBoxDataSource;
        private Label labelModel;
        private TextBox textBoxModel;
        private Button buttonRun;
        private TextArea textBoxOutput;
        private Button buttonOpenXLS;
        private Button buttonOpenModel;
        private Button buttonOpenResults;
        private NumericUpDown numericRatio;
        private CheckBox checkCBCRatio;
        private Button buttonSaveTemplates;

        private PixelLayout layout;
    }
}

