﻿using FakeSimulator.Views.Home.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FakeSimulator.Views.Home.ViewSimulation
{
    /// <summary>
    /// Lógica de interacción para SimulationView.xaml
    /// </summary>
    public partial class SimulationView : Window
    {
        public SimulationView()
        {
            InitializeComponent();
            var viewModel = new SimulationMainModel();
            this.DataContext = viewModel;
        }
    }
}
