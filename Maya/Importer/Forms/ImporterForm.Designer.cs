namespace Maya2Babylon.Importer.Forms
{
    partial class ImporterForm
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
            this.components = new System.ComponentModel.Container();
            this.grpLoadFile = new System.Windows.Forms.GroupBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.butImport = new System.Windows.Forms.Button();
            this.errorProviderFileName = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpLoadFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLoadFile
            // 
            this.grpLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLoadFile.Controls.Add(this.labelFileName);
            this.grpLoadFile.Controls.Add(this.txtFilename);
            this.grpLoadFile.Controls.Add(this.butBrowse);
            this.grpLoadFile.Location = new System.Drawing.Point(12, 12);
            this.grpLoadFile.Name = "grpLoadFile";
            this.grpLoadFile.Size = new System.Drawing.Size(417, 72);
            this.grpLoadFile.TabIndex = 1;
            this.grpLoadFile.TabStop = false;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(6, 17);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(55, 13);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "File name:";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(18, 34);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(344, 20);
            this.txtFilename.TabIndex = 2;
            // 
            // butBrowse
            // 
            this.butBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBrowse.Location = new System.Drawing.Point(368, 32);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(43, 23);
            this.butBrowse.TabIndex = 3;
            this.butBrowse.Text = "...";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(12, 95);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(75, 23);
            this.butImport.TabIndex = 2;
            this.butImport.Text = "Import";
            this.butImport.UseVisualStyleBackColor = true;
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // errorProviderFileName
            // 
            this.errorProviderFileName.ContainerControl = this;
            // 
            // ImporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 128);
            this.Controls.Add(this.butImport);
            this.Controls.Add(this.grpLoadFile);
            this.Name = "ImporterForm";
            this.Text = "Import gltf file";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImporterForm_FormClosed);
            this.grpLoadFile.ResumeLayout(false);
            this.grpLoadFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFileName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLoadFile;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.ErrorProvider errorProviderFileName;
    }
}