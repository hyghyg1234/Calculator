using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] num = new string[100];
        string flag;
        Point panel1Position;

        List<Button> butList = new List<Button>();
        List<string> numList = new List<string>();

        private void list_Add()
        {
            butList.Add(num0);
            butList.Add(num1);
            butList.Add(num2);
            butList.Add(num3);
            butList.Add(num4);
            butList.Add(num5);
            butList.Add(num6);
            butList.Add(num7);
            butList.Add(num8);
            butList.Add(num9);            
            butList.Add(button16);
            for (int i = 0; i < 11; i++)
            {
                butList[i].Click += new System.EventHandler(this.butlist_Click);
            }
        }

        private void butlist_Click(object sender, EventArgs e)
        {
            //鼠标相对于屏幕的坐标
            Point p1 = MousePosition;
            //鼠标相对于窗体的坐标
            Point p2 = this.PointToClient(MousePosition);

            //计算出按键相对于panel的坐标
            int PointX = p2.X - panel1Position.X;   
            int PointY = p2.Y - panel1Position.Y;

            for (int i = 0; i < 10; i++)
            {
                if ((PointX >= butList[i].Location.X) && (PointX <= butList[i].Location.X + 35) && (PointY >= butList[i].Location.Y) && (PointY <= butList[i].Location.Y + 35))
                {
                    //textBox3.Text = PointX.ToString() + "   " + PointY.ToString();
                    numList[but_flag] = numList[but_flag] + i.ToString();
                    textBox1.Text = numList[but_flag];
                }
            }           
            //textBox2.Text = this.butList[0].Location.ToString();           
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        int but_flag = 0;

        private void button10_Click(object sender, EventArgs e)
        {
            numList.Add("");
            but_flag++;
            flag = "+";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            numList.Add("");
            but_flag++;
            flag = "-";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            numList.Add("");
            but_flag++;
            flag = "*";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            numList.Add("");
            but_flag++;
            flag = "/";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            long res = 0;

            if (but_flag == 0)
            {
                return;     //跳出函数
            }
            if (flag == "+")
            {
                res = Convert.ToInt64(numList[but_flag]) + Convert.ToInt64(numList[but_flag - 1]);
            }
            else if (flag == "*")
            {
                res = Convert.ToInt64(numList[but_flag]) * Convert.ToInt64(numList[but_flag - 1]);
            }
            but_flag = 0;
            numList.Clear();
            numList.Add("");
            textBox1.Text = res.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list_Add();
            numList.Add("");
            panel1Position = this.panel1.Location;
            textBox2.Text = panel1Position.ToString();
        }
    }
}
