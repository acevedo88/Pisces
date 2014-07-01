﻿using System;
using System.Windows.Forms;
using Aga.Controls.Tree;

namespace Reclamation.TimeSeries.Forms.Calculations
{
    public partial class CalculationProperties : Form
    {
        public CalculationProperties()
        {
            m_series = new CalculationSeries();
            InitializeComponent();
        }
        CalculationSeries m_series;

        PiscesTree tree1;

        public CalculationProperties(CalculationSeries s, ITreeModel model, string[] DBunits)
        {
            InitializeComponent();
            tree1 = new PiscesTree(model);
            tree1.ExpandRootNodes();

            tree1.AllowDrop = false;
            tree1.Parent = this.splitContainer1.Panel1;
            tree1.Dock = DockStyle.Fill;
            tree1.RemoveCommandLine();

            m_series = s;
            ReadSeriesProperties();
        }

        private void ReadSeriesProperties()
        {
            basicEquation1.SeriesExpression = m_series.Expression;
        }

        private void LoadList(ComboBox owner, string[] list)
        {
            owner.Items.Clear();
            for (int i = 0; i < list.Length; i++)
            {
                owner.Items.Add(list[i]);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            m_series.TimeInterval = basicEquation1.TimeInterval;
            if (m_series.IsValidExpression(basicEquation1.SeriesExpression, out errorMessage))
            {
                m_series.Expression = basicEquation1.SeriesExpression;
                
            }
            else
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(errorMessage);
            }
        }
    }
}