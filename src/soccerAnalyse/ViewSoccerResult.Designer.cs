namespace soccerAnalyse
{
    partial class ViewSoccerResult
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
            this.dataGridViewSoccerResult = new System.Windows.Forms.DataGridView();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblHeadLineTable = new System.Windows.Forms.Label();
            this.btnExportData = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblLineTop = new System.Windows.Forms.Label();
            this.lblLineBottom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoccerResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSoccerResult
            // 
            this.dataGridViewSoccerResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSoccerResult.Location = new System.Drawing.Point(12, 72);
            this.dataGridViewSoccerResult.Name = "dataGridViewSoccerResult";
            this.dataGridViewSoccerResult.Size = new System.Drawing.Size(474, 150);
            this.dataGridViewSoccerResult.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(124, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Datei auswählen";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblHeadLineTable
            // 
            this.lblHeadLineTable.AutoSize = true;
            this.lblHeadLineTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadLineTable.Location = new System.Drawing.Point(9, 56);
            this.lblHeadLineTable.Name = "lblHeadLineTable";
            this.lblHeadLineTable.Size = new System.Drawing.Size(111, 13);
            this.lblHeadLineTable.TabIndex = 2;
            this.lblHeadLineTable.Text = "Tabelle aus Datei:";
            // 
            // btnExportData
            // 
            this.btnExportData.Location = new System.Drawing.Point(12, 255);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(114, 21);
            this.btnExportData.TabIndex = 3;
            this.btnExportData.Text = "Ergebnis exportieren";
            this.btnExportData.UseVisualStyleBackColor = true;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(136, 56);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(0, 13);
            this.lblFilename.TabIndex = 4;
            // 
            // lblLineTop
            // 
            this.lblLineTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineTop.Location = new System.Drawing.Point(11, 40);
            this.lblLineTop.Name = "lblLineTop";
            this.lblLineTop.Size = new System.Drawing.Size(475, 1);
            this.lblLineTop.TabIndex = 5;
            // 
            // lblLineBottom
            // 
            this.lblLineBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineBottom.Location = new System.Drawing.Point(13, 230);
            this.lblLineBottom.Name = "lblLineBottom";
            this.lblLineBottom.Size = new System.Drawing.Size(470, 1);
            this.lblLineBottom.TabIndex = 6;
            // 
            // ViewSoccerResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 300);
            this.Controls.Add(this.lblLineBottom);
            this.Controls.Add(this.lblLineTop);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnExportData);
            this.Controls.Add(this.lblHeadLineTable);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.dataGridViewSoccerResult);
            this.Name = "ViewSoccerResult";
            this.ShowIcon = false;
            this.Text = "Soccer Analyse Tool";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoccerResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSoccerResult;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblHeadLineTable;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label lblLineTop;
        private System.Windows.Forms.Label lblLineBottom;
    }
}

