using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using DevExpress.CodeRush.Core;

namespace CR_DrawLinesBetweenMethods
{
	public partial class OptDrawLinesBetweenMethods
	{
		private System.Windows.Forms.CheckBox _fullWidthChk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox _lineStyleLst;
		private System.Windows.Forms.ComboBox _lineWidthLst;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox _drawLineAtEndChk;
		private System.Windows.Forms.CheckBox _drawShadowChk;
		private Button _lineColorBtn;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this._fullWidthChk = new System.Windows.Forms.CheckBox();
			this._lineStyleLst = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this._lineWidthLst = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._drawLineAtEndChk = new System.Windows.Forms.CheckBox();
			this._drawShadowChk = new System.Windows.Forms.CheckBox();
			this._lineColorBtn = new System.Windows.Forms.Button();
			this._mainPanel = new System.Windows.Forms.Panel();
			this._enabledChk = new System.Windows.Forms.CheckBox();
			this._mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// _fullWidthChk
			// 
			this._fullWidthChk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._fullWidthChk.Location = new System.Drawing.Point(3, 4);
			this._fullWidthChk.Name = "_fullWidthChk";
			this._fullWidthChk.Size = new System.Drawing.Size(184, 24);
			this._fullWidthChk.TabIndex = 0;
			this._fullWidthChk.Text = "Draw line across full width of page";
			// 
			// _lineStyleLst
			// 
			this._lineStyleLst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._lineStyleLst.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot"});
			this._lineStyleLst.Location = new System.Drawing.Point(75, 34);
			this._lineStyleLst.Name = "_lineStyleLst";
			this._lineStyleLst.Size = new System.Drawing.Size(121, 21);
			this._lineStyleLst.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(3, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 14);
			this.label1.TabIndex = 2;
			this.label1.Text = "Line style:";
			// 
			// _lineWidthLst
			// 
			this._lineWidthLst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._lineWidthLst.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
			this._lineWidthLst.Location = new System.Drawing.Point(75, 61);
			this._lineWidthLst.Name = "_lineWidthLst";
			this._lineWidthLst.Size = new System.Drawing.Size(121, 21);
			this._lineWidthLst.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(3, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "Line width:";
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(3, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 14);
			this.label3.TabIndex = 2;
			this.label3.Text = "Line color:";
			// 
			// _drawLineAtEndChk
			// 
			this._drawLineAtEndChk.Location = new System.Drawing.Point(3, 147);
			this._drawLineAtEndChk.Name = "_drawLineAtEndChk";
			this._drawLineAtEndChk.Size = new System.Drawing.Size(193, 24);
			this._drawLineAtEndChk.TabIndex = 3;
			this._drawLineAtEndChk.Text = "Draw line at end of method";
			// 
			// _drawShadowChk
			// 
			this._drawShadowChk.Location = new System.Drawing.Point(3, 117);
			this._drawShadowChk.Name = "_drawShadowChk";
			this._drawShadowChk.Size = new System.Drawing.Size(104, 24);
			this._drawShadowChk.TabIndex = 3;
			this._drawShadowChk.Text = "Shadow";
			// 
			// _lineColorBtn
			// 
			this._lineColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this._lineColorBtn.Location = new System.Drawing.Point(75, 88);
			this._lineColorBtn.Name = "_lineColorBtn";
			this._lineColorBtn.Size = new System.Drawing.Size(121, 23);
			this._lineColorBtn.TabIndex = 4;
			this._lineColorBtn.UseVisualStyleBackColor = true;
			this._lineColorBtn.Click += new System.EventHandler(this._lineColorBtn_Click);
			// 
			// _mainPanel
			// 
			this._mainPanel.Controls.Add(this._drawLineAtEndChk);
			this._mainPanel.Controls.Add(this._lineColorBtn);
			this._mainPanel.Controls.Add(this._drawShadowChk);
			this._mainPanel.Controls.Add(this.label3);
			this._mainPanel.Controls.Add(this.label1);
			this._mainPanel.Controls.Add(this.label2);
			this._mainPanel.Controls.Add(this._lineStyleLst);
			this._mainPanel.Controls.Add(this._lineWidthLst);
			this._mainPanel.Controls.Add(this._fullWidthChk);
			this._mainPanel.Location = new System.Drawing.Point(13, 27);
			this._mainPanel.Name = "_mainPanel";
			this._mainPanel.Size = new System.Drawing.Size(333, 203);
			this._mainPanel.TabIndex = 5;
			// 
			// _enabledChk
			// 
			this._enabledChk.AutoSize = true;
			this._enabledChk.Checked = true;
			this._enabledChk.CheckState = System.Windows.Forms.CheckState.Checked;
			this._enabledChk.Location = new System.Drawing.Point(4, 4);
			this._enabledChk.Name = "_enabledChk";
			this._enabledChk.Size = new System.Drawing.Size(65, 17);
			this._enabledChk.TabIndex = 6;
			this._enabledChk.Text = "Enabled";
			this._enabledChk.UseVisualStyleBackColor = true;
			// 
			// OptDrawLinesBetweenMethods
			// 
			this.Controls.Add(this._enabledChk);
			this.Controls.Add(this._mainPanel);
			this.Name = "OptDrawLinesBetweenMethods";
			this.Size = new System.Drawing.Size(661, 617);
			this.Load += new System.EventHandler(this.OptDrawLinesBetweenMethods_Load);
			this.PreparePage += new DevExpress.CodeRush.Core.OptionsPage.PreparePageEventHandler(this.OptDrawLinesBetweenMethods_PreparePage);
			this.CommitChanges += new DevExpress.CodeRush.Core.OptionsPage.CommitChangesEventHandler(this.OptDrawLinesBetweenMethods_CommitChanges);
			this._mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region CodeRush generated code
		protected override void Initialize()
		{
			base.Initialize();

			//
			// TODO: Add your initialization code here.
			//
		}

		public static string GetCategory()
		{
			return @"Editor\Painting";
		}

		public static string GetPageName()
		{
			return @"Draw Lines Between Methods";
		}

		public static DecoupledStorage Storage
		{
			get
			{
				return CodeRush.Options.GetStorage(GetCategory(), GetPageName());
			}
		}

		public override string Category
		{
			get
			{
				return OptDrawLinesBetweenMethods.GetCategory();
			}
		}

		public override string PageName
		{
			get
			{
				return OptDrawLinesBetweenMethods.GetPageName();
			}
		}

		public new static void Show()
		{
			CodeRush.Command.Execute("Options", FullPath);
		}

		private Panel _mainPanel;
		private CheckBox _enabledChk;

		public static string FullPath
		{
			get
			{
				return GetCategory() + "\\" + GetPageName();
			}
		}
		#endregion

	}
}
