﻿using System;
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
        string flag = null;
        Point panel1Position;
        int but_flag = 0;
        bool symbolEqual = false;
        string modeFlag;
        List<string> symbol = new List<string>() { "+", "-", "*", "/" };
        List<string> numList = new List<string>() { "", "" };
        List<Button> butList = new List<Button>();
        
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

            butList.Add(button10);
            butList.Add(button11);
            butList.Add(button12);
            butList.Add(button13);
            for (int i = 0; i < 10; i++)
            {
                butList[i].Click += new System.EventHandler(this.Num_Click);
            }
            for (int i = 10; i < 14; i++)
            {
                butList[i].Click += new System.EventHandler(this.Symbol_Click);
            }
        }

        /// <summary>
        /// 符号按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Symbol_Click(object sender, EventArgs e)
        {
            //鼠标相对于屏幕的坐标
            Point p1 = MousePosition;
            //鼠标相对于窗体的坐标
            Point p2 = this.PointToClient(MousePosition);

            //计算出按键相对于panel的坐标
            int PointX = p2.X - panel1Position.X;
            int PointY = p2.Y - panel1Position.Y;

            for (int i = 10; i < 14; i++)
            {
                if ((PointX >= butList[i].Location.X) && (PointX <= butList[i].Location.X + 35) && (PointY >= butList[i].Location.Y) && (PointY <= butList[i].Location.Y + 35))
                {                   
                    flag = symbol[i - 10];
                    label1.Text = flag;

                    if (modeFlag == "1")
                    {
                        modeFlag = "2";
                    }
                    textBox2.Text = modeFlag;
                }
            }
        }

        /// <summary>
        /// 数字按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Num_Click(object sender, EventArgs e)
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
                    if (flag != null)
                    {
                        numList[0] = numList[0] + i.ToString();
                        textBox1.Text = numList[0];
                    }
                    else
                    {
                        numList[1] = numList[1] + i.ToString();
                        textBox1.Text = numList[1];
                    }
                    if (Cflag == true)  //表示还未按下任何按键
                    {
                        Cflag = false;
                        modeFlag = "1";
                    }
                    else
                    {
                        if (modeFlag == "2")
                        {
                            modeFlag = "3";
                        }
                    }

                    textBox2.Text = modeFlag;
                }
            }                     
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            long res = 0;
            symbolEqual = true;
            if (but_flag == 0)
            {
                return;     //跳出函数
            }
            if (flag == "+")
            {
                res = Convert.ToInt64(numList[1]) + Convert.ToInt64(numList[0]);
            }
            else if (flag == "-")
            {
                res = Convert.ToInt64(numList[1]) - Convert.ToInt64(numList[0]);
            }
            else if (flag == "*")
            {
                res = Convert.ToInt64(numList[1]) * Convert.ToInt64(numList[0]);
            }
            else if (flag == "/")
            {
                if ((Convert.ToInt64(numList[0]) == 0))
                {
                    textBox1.Text = "ERR";
                    return;
                }
                else
                {
                    textBox1.Text = (Convert.ToDouble(numList[1]) / Convert.ToDouble(numList[0])).ToString("f15");
                    return;
                }
            }
            numList[1] = res.ToString();
            textBox1.Text = res.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list_Add();
            panel1Position = this.panel1.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        bool Cflag = true;
        private void button2_Click(object sender, EventArgs e)
        {
            Cflag = true;
            textBox1.Text = "0";
            textBox2.Text = "0";
        }
    }
}
