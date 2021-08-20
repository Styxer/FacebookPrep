﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookPrepForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn3Sum_Click(object sender, EventArgs e)
        {
            var list = new[] { -1, 0, 1, 2, -1, -4, 2 };
            foreach (var item in _3Sum.Solution.ThreeSum(list))
            {
                Console.WriteLine(item);
            }
        }

        private void AccountsMerge_Click(object sender, EventArgs e)
        {
            List<string> a = new List<string>() { "John", "johnsmith@mail.com", "john_newyork@mail.com" };
            List<string> b = new List<string>() { "John", "johnsmith@mail.com", "john00@mail.com" };
            List<string> c = new List<string>() { "Mary", "mary@mail.com" };
            List<string> d = new List<string>() { "John", "johnnybravo@mail.com" };

            IList<IList<string>> items = new List<IList<string>>();
            items.Add(a); items.Add(b); items.Add(c); items.Add(d);
            Console.WriteLine(Accounts_Merge.Solution.AccountsMerge(items));
        }
    }
}
