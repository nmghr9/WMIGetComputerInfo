﻿namespace WMIGetComputerInfo
{
    partial class GetComputerInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetComputerInfo));
            this.attributeTree = new System.Windows.Forms.TreeView();
            this.InforMationView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // attributeTree
            // 
            this.attributeTree.Location = new System.Drawing.Point(13, 13);
            this.attributeTree.Name = "attributeTree";
            this.attributeTree.Size = new System.Drawing.Size(268, 580);
            this.attributeTree.TabIndex = 0;
            this.attributeTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.attributeTree_BeforeExpand);
            // 
            // InforMationView
            // 
            this.InforMationView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.InforMationView.Location = new System.Drawing.Point(314, 13);
            this.InforMationView.Name = "InforMationView";
            this.InforMationView.Size = new System.Drawing.Size(554, 580);
            this.InforMationView.TabIndex = 1;
            this.InforMationView.UseCompatibleStateImageBehavior = false;
            this.InforMationView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 194;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 358;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 599);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(856, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // GetComputerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 630);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.InforMationView);
            this.Controls.Add(this.attributeTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GetComputerInfo";
            this.Text = "GetComputerInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetComputerInfo_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView attributeTree;
        private System.Windows.Forms.ListView InforMationView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

