namespace QuizApp.View
{
    partial class Frmquiz
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
            this.lbl_Pergunta = new System.Windows.Forms.Label();
            this.PainelOpcao = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOp1 = new System.Windows.Forms.Button();
            this.btnOp2 = new System.Windows.Forms.Button();
            this.btnOp3 = new System.Windows.Forms.Button();
            this.btnOp4 = new System.Windows.Forms.Button();
            this.lbl_pontuacao = new System.Windows.Forms.Label();
            this.PainelOpcao.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Pergunta
            // 
            this.lbl_Pergunta.AutoSize = true;
            this.lbl_Pergunta.Location = new System.Drawing.Point(183, 112);
            this.lbl_Pergunta.Name = "lbl_Pergunta";
            this.lbl_Pergunta.Size = new System.Drawing.Size(35, 13);
            this.lbl_Pergunta.TabIndex = 0;
            this.lbl_Pergunta.Text = "label1";
            // 
            // PainelOpcao
            // 
            this.PainelOpcao.Controls.Add(this.btnOp1);
            this.PainelOpcao.Controls.Add(this.btnOp2);
            this.PainelOpcao.Controls.Add(this.btnOp3);
            this.PainelOpcao.Controls.Add(this.btnOp4);
            this.PainelOpcao.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PainelOpcao.Location = new System.Drawing.Point(175, 157);
            this.PainelOpcao.Name = "PainelOpcao";
            this.PainelOpcao.Size = new System.Drawing.Size(303, 146);
            this.PainelOpcao.TabIndex = 3;
            // 
            // btnOp1
            // 
            this.btnOp1.Location = new System.Drawing.Point(3, 3);
            this.btnOp1.Name = "btnOp1";
            this.btnOp1.Size = new System.Drawing.Size(142, 64);
            this.btnOp1.TabIndex = 0;
            this.btnOp1.Text = "button1";
            this.btnOp1.UseVisualStyleBackColor = true;
            // 
            // btnOp2
            // 
            this.btnOp2.Location = new System.Drawing.Point(3, 73);
            this.btnOp2.Name = "btnOp2";
            this.btnOp2.Size = new System.Drawing.Size(142, 64);
            this.btnOp2.TabIndex = 1;
            this.btnOp2.Text = "button2";
            this.btnOp2.UseVisualStyleBackColor = true;
            // 
            // btnOp3
            // 
            this.btnOp3.Location = new System.Drawing.Point(151, 3);
            this.btnOp3.Name = "btnOp3";
            this.btnOp3.Size = new System.Drawing.Size(142, 64);
            this.btnOp3.TabIndex = 2;
            this.btnOp3.Text = "button3";
            this.btnOp3.UseVisualStyleBackColor = true;
            // 
            // btnOp4
            // 
            this.btnOp4.Location = new System.Drawing.Point(151, 73);
            this.btnOp4.Name = "btnOp4";
            this.btnOp4.Size = new System.Drawing.Size(142, 64);
            this.btnOp4.TabIndex = 3;
            this.btnOp4.Text = "button4";
            this.btnOp4.UseVisualStyleBackColor = true;
            // 
            // lbl_pontuacao
            // 
            this.lbl_pontuacao.AutoSize = true;
            this.lbl_pontuacao.Location = new System.Drawing.Point(186, 339);
            this.lbl_pontuacao.Name = "lbl_pontuacao";
            this.lbl_pontuacao.Size = new System.Drawing.Size(35, 13);
            this.lbl_pontuacao.TabIndex = 4;
            this.lbl_pontuacao.Text = "label1";
            // 
            // Frmquiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 450);
            this.Controls.Add(this.lbl_pontuacao);
            this.Controls.Add(this.PainelOpcao);
            this.Controls.Add(this.lbl_Pergunta);
            this.Name = "Frmquiz";
            this.Text = "Frmquiz";
            this.Load += new System.EventHandler(this.Frmquiz_Load);
            this.PainelOpcao.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Pergunta;
        private System.Windows.Forms.FlowLayoutPanel PainelOpcao;
        private System.Windows.Forms.Button btnOp1;
        private System.Windows.Forms.Button btnOp2;
        private System.Windows.Forms.Button btnOp3;
        private System.Windows.Forms.Button btnOp4;
        private System.Windows.Forms.Label lbl_pontuacao;
    }
}