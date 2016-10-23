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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        int x1, y1;
        int x2, y2;

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        bool isDrag = false;
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                x1 = x2 = e.X;
                y1 = y2 = e.Y;
            }
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                x2 = e.X;
                y2 = e.Y;
                this.Invalidate();
            }
        }

        List<PenParam> AllPenInfo = new List<PenParam>();
        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            x2 = e.X;
            y2 = e.Y;

            PenParam OldPenParam = new PenParam();
            OldPenParam.StarX1 = x1;
            OldPenParam.StarY1 = y1;
            OldPenParam.StarX2 = x2;
            OldPenParam.StarY2 = y2;
            OldPenParam.ActionBehovior = Singleton.Instance().BehaviorIndex;
            AllPenInfo.Add(OldPenParam);

            this.Invalidate();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (PenParam pa in AllPenInfo)
            {
                pa.DrawGraphics(g); //將舊的資料先畫上畫布
            }

            if (isDrag)
            { //設定當前畫的這筆圖形資料給CurPenParam
                PenParam CurPenParam = new PenParam();
                CurPenParam.StarX1 = x1;
                CurPenParam.StarY1 = y1;
                CurPenParam.StarX2 = x2;
                CurPenParam.StarY2 = y2;
                CurPenParam.ActionBehovior = Singleton.Instance().BehaviorIndex;
                CurPenParam.DrawGraphics(g);
            }
        }
    }
}
