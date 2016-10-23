using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redo_Undo
{
    public partial class Form1 : Form
    {
        Form2 subForm2 = new Form2();
        Form3 subForm3 = new Form3();

        public Form1()
        {
            InitializeComponent();

            subForm2.MdiParent = this;
            subForm2.Text = "工具";
            subForm2.Show();

            subForm3.MdiParent = this;
            subForm3.Left = 0;
            subForm3.Top = 0;
            subForm3.Width = 280;
            subForm3.Height = 260;
            subForm3.FormBorderStyle = FormBorderStyle.None;
            subForm3.Show();

            Button btn1 = new Button();
            btn1.Image = Image.FromFile("C:\\Users\\janson\\Documents\\Visual Studio 2013\\Projects\\Redo_Undo\\Redo_Undo\\pic\\1.PNG");
            btn1.ImageAlign = ContentAlignment.MiddleRight;
            btn1.Size = new System.Drawing.Size(30, 30);
            btn1.Location = new Point(0, 0); // 設定按鈕所在位置(相對於子表單而言)
            btn1.Click += new System.EventHandler(this.subFormBtClick); //註冊按下事件
            btn1.Tag = 0;
            subForm2.Controls.Add(btn1); // 將按鈕新增至子表單

            Button btn2 = new Button();
            btn2.Image = Image.FromFile("C:\\Users\\janson\\Documents\\Visual Studio 2013\\Projects\\Redo_Undo\\Redo_Undo\\pic\\redo.PNG");
            btn2.ImageAlign = ContentAlignment.MiddleRight;
            btn2.Size = new System.Drawing.Size(30, 30);
            btn2.Location = new Point(0, 30);
            btn2.Click += new System.EventHandler(this.subFormBtClick); //註冊按下事件
            btn2.Tag = 1;
            subForm2.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Image = Image.FromFile("C:\\Users\\janson\\Documents\\Visual Studio 2013\\Projects\\Redo_Undo\\Redo_Undo\\pic\\undo.PNG");
            btn3.ImageAlign = ContentAlignment.MiddleRight;
            btn3.Size = new System.Drawing.Size(30, 30);
            btn3.Location = new Point(0, 60);
            btn3.Click += new System.EventHandler(this.subFormBtClick); //註冊按下事件
            btn3.Tag = 2;
            subForm2.Controls.Add(btn3);

            lineToolStripMenuItem.Checked = true; //在工具列Tool下方的Line左方顯示勾勾
            subForm2.Controls[0].Focus();
        }

        int ToolSelected, BtnSelected;
        private void ToolItemClick(object sender, EventArgs e)
        {// 該func功能:按下工具列上Tool下方這五個其中一個會做的事情

            //subForm按鈕Enabled初始化
            subForm2.Controls[0].Enabled = true;
            subForm2.Controls[1].Enabled = true;
            subForm2.Controls[2].Enabled = true;

            //工具列Tool下方按鈕Checked初始化
            lineToolStripMenuItem.Checked = false;
            undoToolStripMenuItem.Checked = false;
            redoToolStripMenuItem.Checked = false;

            switch (((ToolStripMenuItem)sender).Text)
            {
                case "Line":
                    //subForm.Controls[0].Enabled = false;
                    subForm2.Controls[0].Focus(); //產生有藍色框框的
                    lineToolStripMenuItem.Checked = true; //顯示勾勾
                    ToolSelected = 0;
                    break;
                case "Undo":
                    subForm2.Controls[1].Focus();
                    undoToolStripMenuItem.Checked = true;
                    ToolSelected = 1;
                    break;
                case "Redo":
                    subForm2.Controls[2].Focus();
                    redoToolStripMenuItem.Checked = true;
                    ToolSelected = 2;
                    break;
            }
            Singleton.Instance().BehaviorIndex = ToolSelected;
        }

        private void subFormBtClick(object sender, EventArgs e)
        {// 該func功能:子選單按鈕被選取

            subForm2.Controls[0].Enabled = true;
            subForm2.Controls[1].Enabled = true;
            subForm2.Controls[2].Enabled = true;

            //工具列Tool下方按鈕Checked初始化
            lineToolStripMenuItem.Checked = false;
            undoToolStripMenuItem.Checked = false;
            redoToolStripMenuItem.Checked = false;

            switch (((Button)sender).Tag.ToString()) //取得tag編號
            {
                case "0":
                    lineToolStripMenuItem.Checked = true;
                    BtnSelected = 0;
                    break;
                case "1":
                    undoToolStripMenuItem.Checked = true;
                    BtnSelected = 1;
                    break;
                case "2":
                    redoToolStripMenuItem.Checked = true;
                    BtnSelected = 2;
                    break;
            }
            Singleton.Instance().BehaviorIndex = BtnSelected;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            subForm2.BringToFront();
        }
    }
}
