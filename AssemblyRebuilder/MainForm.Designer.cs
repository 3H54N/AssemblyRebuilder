namespace AssemblyRebuilder {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tbAssemblyPath = new System.Windows.Forms.TextBox();
			this.btSelectAssembly = new System.Windows.Forms.Button();
			this.odlgSelectAssembly = new System.Windows.Forms.OpenFileDialog();
			this.cmbEntryPoint = new System.Windows.Forms.ComboBox();
			this.btRebuild = new System.Windows.Forms.Button();
			this.cmbManifestModuleKind = new System.Windows.Forms.ComboBox();
			this.chkNoStaticConstructor = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// tbAssemblyPath
			// 
			this.tbAssemblyPath.Location = new System.Drawing.Point(12, 13);
			this.tbAssemblyPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbAssemblyPath.Name = "tbAssemblyPath";
			this.tbAssemblyPath.Size = new System.Drawing.Size(965, 23);
			this.tbAssemblyPath.TabIndex = 0;
			this.tbAssemblyPath.TextChanged += new System.EventHandler(this.tbAssemblyPath_TextChanged);
			// 
			// btSelectAssembly
			// 
			this.btSelectAssembly.Location = new System.Drawing.Point(983, 13);
			this.btSelectAssembly.Name = "btSelectAssembly";
			this.btSelectAssembly.Size = new System.Drawing.Size(98, 23);
			this.btSelectAssembly.TabIndex = 1;
			this.btSelectAssembly.Text = "选择程序集...";
			this.btSelectAssembly.UseVisualStyleBackColor = true;
			this.btSelectAssembly.Click += new System.EventHandler(this.btSelectAssembly_Click);
			// 
			// cmbEntryPoint
			// 
			this.cmbEntryPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEntryPoint.Enabled = false;
			this.cmbEntryPoint.FormattingEnabled = true;
			this.cmbEntryPoint.Location = new System.Drawing.Point(12, 43);
			this.cmbEntryPoint.Name = "cmbEntryPoint";
			this.cmbEntryPoint.Size = new System.Drawing.Size(718, 25);
			this.cmbEntryPoint.TabIndex = 2;
			this.cmbEntryPoint.SelectedIndexChanged += new System.EventHandler(this.cmbEntryPoint_SelectedIndexChanged);
			// 
			// btRebuild
			// 
			this.btRebuild.Enabled = false;
			this.btRebuild.Location = new System.Drawing.Point(983, 42);
			this.btRebuild.Name = "btRebuild";
			this.btRebuild.Size = new System.Drawing.Size(98, 27);
			this.btRebuild.TabIndex = 3;
			this.btRebuild.Text = "重建";
			this.btRebuild.UseVisualStyleBackColor = true;
			this.btRebuild.Click += new System.EventHandler(this.btRebuild_Click);
			// 
			// cmbManifestModuleKind
			// 
			this.cmbManifestModuleKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbManifestModuleKind.Enabled = false;
			this.cmbManifestModuleKind.FormattingEnabled = true;
			this.cmbManifestModuleKind.Location = new System.Drawing.Point(853, 43);
			this.cmbManifestModuleKind.Name = "cmbManifestModuleKind";
			this.cmbManifestModuleKind.Size = new System.Drawing.Size(124, 25);
			this.cmbManifestModuleKind.TabIndex = 4;
			this.cmbManifestModuleKind.SelectedIndexChanged += new System.EventHandler(this.cmbManifestModuleKind_SelectedIndexChanged);
			// 
			// chkNoStaticConstructor
			// 
			this.chkNoStaticConstructor.AutoSize = true;
			this.chkNoStaticConstructor.Checked = true;
			this.chkNoStaticConstructor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkNoStaticConstructor.Enabled = false;
			this.chkNoStaticConstructor.Location = new System.Drawing.Point(736, 45);
			this.chkNoStaticConstructor.Name = "chkNoStaticConstructor";
			this.chkNoStaticConstructor.Size = new System.Drawing.Size(111, 21);
			this.chkNoStaticConstructor.TabIndex = 5;
			this.chkNoStaticConstructor.Text = "过滤静态构造器";
			this.chkNoStaticConstructor.UseVisualStyleBackColor = true;
			this.chkNoStaticConstructor.CheckedChanged += new System.EventHandler(this.chkNoStaticConstructor_CheckedChanged);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1093, 82);
			this.Controls.Add(this.chkNoStaticConstructor);
			this.Controls.Add(this.cmbManifestModuleKind);
			this.Controls.Add(this.btRebuild);
			this.Controls.Add(this.cmbEntryPoint);
			this.Controls.Add(this.btSelectAssembly);
			this.Controls.Add(this.tbAssemblyPath);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbAssemblyPath;
		private System.Windows.Forms.Button btSelectAssembly;
		private System.Windows.Forms.OpenFileDialog odlgSelectAssembly;
		private System.Windows.Forms.ComboBox cmbEntryPoint;
		private System.Windows.Forms.Button btRebuild;
		private System.Windows.Forms.ComboBox cmbManifestModuleKind;
		private System.Windows.Forms.CheckBox chkNoStaticConstructor;
	}
}
