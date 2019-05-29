﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    public partial class ListaDeBitmons : Form
    {
        public List<string> listaBitmons = new List<string>();
        int bitActual = 1;
        int cantidadDeBitmons;
        public ListaDeBitmons(int cantidadDeBitmons)
        {
            InitializeComponent();
            this.cantidadDeBitmons = cantidadDeBitmons;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listaBitmons.Add(comboBox1.Text);
            bitActual += 1;
            label1.Text = "Bitmon " + bitActual;
            if (bitActual == cantidadDeBitmons+1)
            {
                Close();
            }else if (bitActual == cantidadDeBitmons)
            {
                button1.Text = "Guardar";
            }
        }
    }
}