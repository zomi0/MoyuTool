﻿using System;
using System.Windows.Forms;

namespace MyTool
{
    public partial class LuaShopForm : Form
    {
        ExcelOpration eo = new ExcelOpration();
        public LuaShopForm()
        {
            InitializeComponent();
        }

        //读取excel文件
        private void OpenExcel_button1_Click(object sender, EventArgs e)
        {
            //成功
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //判断是否是excel
                string FileNameExtension = System.IO.Path.GetExtension(openFileDialog1.FileName);
                if (FileNameExtension == ".xls" || FileNameExtension == ".xlsx")
                {
                    //打开excel
                    eo.OpenExcel(openFileDialog1.FileName);
                    
                    //表名不正确
                    if (!eo.IsExcelSheetNameTrue(eo.wb, "筹码币商店"))
                    {
                        MessageBox.Show("筹码币商店表不存在。");
                    }
                    else
                    {
                        MessageBox.Show("读取成功！");
                        textBox1.Clear();
                        //MessageBox.Show(eo.GetLuaShopSql(eo.ws));
                        //textBox1.Text = mso.GetLuaDataTitle();
                        //textBox1.Text = textBox1.Text + "\r\n" + eo.GetLuaShopSql(eo.ws);
                    }

                    //关闭excel
                    //eo.CloseExcel();
                }
                else
                {
                    MessageBox.Show("请打开excel。");
                }
            }
        }

        private void CreateSql_button1_Click(object sender, EventArgs e)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            textBox1.Clear();
            textBox1.Text = eo.GetLuaDataTitle();
            textBox1.Text = textBox1.Text + "\r\n" + eo.GetLuaShopSql(eo.ws);
            //watch.Stop();
            //MessageBox.Show(watch.ElapsedMilliseconds.ToString());
        }

        private void CreateLua_button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = eo.GetLuaShopTable(eo.ws);
        }
    }
}
