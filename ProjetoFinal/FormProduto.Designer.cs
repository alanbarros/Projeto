namespace ProjetoFinal
{
    partial class FormProduto
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
            this.cmbStatusProduto = new System.Windows.Forms.ComboBox();
            this.lblStatusProduto = new System.Windows.Forms.Label();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.txtPrecoProduto = new System.Windows.Forms.TextBox();
            this.lblPrecoProduto = new System.Windows.Forms.Label();
            this.cmbTipoProduto = new System.Windows.Forms.ComboBox();
            this.lblTipoProduto = new System.Windows.Forms.Label();
            this.txtGarantiaProduto = new System.Windows.Forms.TextBox();
            this.lblGarantiaProduto = new System.Windows.Forms.Label();
            this.btnGravarProduto = new System.Windows.Forms.Button();
            this.btnCancelarProduto = new System.Windows.Forms.Button();
            this.txtMarcaProduto = new System.Windows.Forms.TextBox();
            this.lblMarcaProduto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbStatusProduto
            // 
            this.cmbStatusProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusProduto.FormattingEnabled = true;
            this.cmbStatusProduto.Items.AddRange(new object[] {
            "Inativo",
            "Ativo",
            "Bloqueado"});
            this.cmbStatusProduto.Location = new System.Drawing.Point(289, 10);
            this.cmbStatusProduto.Name = "cmbStatusProduto";
            this.cmbStatusProduto.Size = new System.Drawing.Size(92, 21);
            this.cmbStatusProduto.TabIndex = 20;
            // 
            // lblStatusProduto
            // 
            this.lblStatusProduto.AutoSize = true;
            this.lblStatusProduto.Location = new System.Drawing.Point(243, 13);
            this.lblStatusProduto.Name = "lblStatusProduto";
            this.lblStatusProduto.Size = new System.Drawing.Size(40, 13);
            this.lblStatusProduto.TabIndex = 21;
            this.lblStatusProduto.Text = "Status:";
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Location = new System.Drawing.Point(82, 36);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(161, 20);
            this.txtDescricaoProduto.TabIndex = 22;
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Location = new System.Drawing.Point(23, 39);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(38, 13);
            this.lblDescricaoProduto.TabIndex = 23;
            this.lblDescricaoProduto.Text = "Nome:";
            // 
            // txtPrecoProduto
            // 
            this.txtPrecoProduto.Location = new System.Drawing.Point(82, 66);
            this.txtPrecoProduto.Name = "txtPrecoProduto";
            this.txtPrecoProduto.Size = new System.Drawing.Size(81, 20);
            this.txtPrecoProduto.TabIndex = 24;
            // 
            // lblPrecoProduto
            // 
            this.lblPrecoProduto.AutoSize = true;
            this.lblPrecoProduto.Location = new System.Drawing.Point(23, 69);
            this.lblPrecoProduto.Name = "lblPrecoProduto";
            this.lblPrecoProduto.Size = new System.Drawing.Size(38, 13);
            this.lblPrecoProduto.TabIndex = 25;
            this.lblPrecoProduto.Text = "Preço:";
            // 
            // cmbTipoProduto
            // 
            this.cmbTipoProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoProduto.FormattingEnabled = true;
            this.cmbTipoProduto.Items.AddRange(new object[] {
            "Computador",
            "Serviço",
            "Acessório"});
            this.cmbTipoProduto.Location = new System.Drawing.Point(82, 104);
            this.cmbTipoProduto.Name = "cmbTipoProduto";
            this.cmbTipoProduto.Size = new System.Drawing.Size(113, 21);
            this.cmbTipoProduto.TabIndex = 26;
            // 
            // lblTipoProduto
            // 
            this.lblTipoProduto.AutoSize = true;
            this.lblTipoProduto.Location = new System.Drawing.Point(23, 112);
            this.lblTipoProduto.Name = "lblTipoProduto";
            this.lblTipoProduto.Size = new System.Drawing.Size(31, 13);
            this.lblTipoProduto.TabIndex = 27;
            this.lblTipoProduto.Text = "Tipo:";
            // 
            // txtGarantiaProduto
            // 
            this.txtGarantiaProduto.Location = new System.Drawing.Point(289, 105);
            this.txtGarantiaProduto.Name = "txtGarantiaProduto";
            this.txtGarantiaProduto.Size = new System.Drawing.Size(81, 20);
            this.txtGarantiaProduto.TabIndex = 28;
            // 
            // lblGarantiaProduto
            // 
            this.lblGarantiaProduto.AutoSize = true;
            this.lblGarantiaProduto.Location = new System.Drawing.Point(233, 112);
            this.lblGarantiaProduto.Name = "lblGarantiaProduto";
            this.lblGarantiaProduto.Size = new System.Drawing.Size(50, 13);
            this.lblGarantiaProduto.TabIndex = 29;
            this.lblGarantiaProduto.Text = "Garantia:";
            // 
            // btnGravarProduto
            // 
            this.btnGravarProduto.Location = new System.Drawing.Point(225, 171);
            this.btnGravarProduto.Name = "btnGravarProduto";
            this.btnGravarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnGravarProduto.TabIndex = 30;
            this.btnGravarProduto.Text = "Gravar";
            this.btnGravarProduto.UseVisualStyleBackColor = true;
            this.btnGravarProduto.Click += new System.EventHandler(this.btnGravarProduto_Click);
            // 
            // btnCancelarProduto
            // 
            this.btnCancelarProduto.Location = new System.Drawing.Point(306, 171);
            this.btnCancelarProduto.Name = "btnCancelarProduto";
            this.btnCancelarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarProduto.TabIndex = 31;
            this.btnCancelarProduto.Text = "Cancelar";
            this.btnCancelarProduto.UseVisualStyleBackColor = true;
            this.btnCancelarProduto.Click += new System.EventHandler(this.btnCancelarProduto_Click);
            // 
            // txtMarcaProduto
            // 
            this.txtMarcaProduto.Location = new System.Drawing.Point(82, 141);
            this.txtMarcaProduto.Name = "txtMarcaProduto";
            this.txtMarcaProduto.Size = new System.Drawing.Size(113, 20);
            this.txtMarcaProduto.TabIndex = 32;
            // 
            // lblMarcaProduto
            // 
            this.lblMarcaProduto.AutoSize = true;
            this.lblMarcaProduto.Location = new System.Drawing.Point(26, 147);
            this.lblMarcaProduto.Name = "lblMarcaProduto";
            this.lblMarcaProduto.Size = new System.Drawing.Size(37, 13);
            this.lblMarcaProduto.TabIndex = 33;
            this.lblMarcaProduto.Text = "Marca";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Código: ";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(73, 9);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(37, 20);
            this.txtId.TabIndex = 35;
            // 
            // FormProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 206);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMarcaProduto);
            this.Controls.Add(this.txtMarcaProduto);
            this.Controls.Add(this.btnCancelarProduto);
            this.Controls.Add(this.btnGravarProduto);
            this.Controls.Add(this.lblGarantiaProduto);
            this.Controls.Add(this.txtGarantiaProduto);
            this.Controls.Add(this.lblTipoProduto);
            this.Controls.Add(this.cmbTipoProduto);
            this.Controls.Add(this.lblPrecoProduto);
            this.Controls.Add(this.txtPrecoProduto);
            this.Controls.Add(this.lblDescricaoProduto);
            this.Controls.Add(this.txtDescricaoProduto);
            this.Controls.Add(this.lblStatusProduto);
            this.Controls.Add(this.cmbStatusProduto);
            this.Name = "FormProduto";
            this.Text = "Produto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStatusProduto;
        private System.Windows.Forms.Label lblStatusProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.TextBox txtPrecoProduto;
        private System.Windows.Forms.Label lblPrecoProduto;
        private System.Windows.Forms.ComboBox cmbTipoProduto;
        private System.Windows.Forms.Label lblTipoProduto;
        private System.Windows.Forms.TextBox txtGarantiaProduto;
        private System.Windows.Forms.Label lblGarantiaProduto;
        private System.Windows.Forms.Button btnGravarProduto;
        private System.Windows.Forms.Button btnCancelarProduto;
        private System.Windows.Forms.TextBox txtMarcaProduto;
        private System.Windows.Forms.Label lblMarcaProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
    }
}