namespace Conexão
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerrede = new System.Windows.Forms.Timer(this.components);
            this.lblstatus = new System.Windows.Forms.Label();
            this.btnverificar = new System.Windows.Forms.Button();
            this.btnligar = new System.Windows.Forms.Button();
            this.btndesligar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblstatus.Location = new System.Drawing.Point(355, 142);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(35, 13);
            this.lblstatus.TabIndex = 0;
            this.lblstatus.Text = "label1";
            this.lblstatus.Click += new System.EventHandler(this.lblstatus_Click);
            // 
            // btnverificar
            // 
            this.btnverificar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnverificar.Location = new System.Drawing.Point(337, 314);
            this.btnverificar.Name = "btnverificar";
            this.btnverificar.Size = new System.Drawing.Size(112, 39);
            this.btnverificar.TabIndex = 1;
            this.btnverificar.Text = "Verificar";
            this.btnverificar.UseVisualStyleBackColor = false;
            // 
            // btnligar
            // 
            this.btnligar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnligar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnligar.Location = new System.Drawing.Point(142, 132);
            this.btnligar.Name = "btnligar";
            this.btnligar.Size = new System.Drawing.Size(129, 33);
            this.btnligar.TabIndex = 2;
            this.btnligar.Text = "Ligar";
            this.btnligar.UseVisualStyleBackColor = false;
            this.btnligar.Click += new System.EventHandler(this.btnligar_Click);
            // 
            // btndesligar
            // 
            this.btndesligar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btndesligar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btndesligar.Location = new System.Drawing.Point(528, 132);
            this.btndesligar.Name = "btndesligar";
            this.btndesligar.Size = new System.Drawing.Size(129, 33);
            this.btndesligar.TabIndex = 3;
            this.btndesligar.Text = "Desligar";
            this.btndesligar.UseVisualStyleBackColor = false;
            this.btndesligar.Click += new System.EventHandler(this.btndesligar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btndesligar);
            this.Controls.Add(this.btnligar);
            this.Controls.Add(this.btnverificar);
            this.Controls.Add(this.lblstatus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerrede;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Button btnverificar;
        private System.Windows.Forms.Button btnligar;
        private System.Windows.Forms.Button btndesligar;
    }
}

