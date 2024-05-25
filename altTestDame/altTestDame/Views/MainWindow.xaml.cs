using altTestDame.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using altTestDame.Services;
using System;
using altTestDame.Models;
using System.Windows.Documents;

namespace altTestDame.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }


        public void Save_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is GameVM gameVM)
            {
                gameVM.SaveClick();
            }
        }

        public void Load_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is GameVM gameVM)
            {
                gameVM.Load_Click();
            }
        }

        public void Statistics_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is GameVM gameVM)
            {
                gameVM.Statistics_Click();
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is GameVM gameVM)
            {
                gameVM.NewGame();
            }
        }  
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nume:Tomescu Andrei-Cristian\n\nEmail:andrei-cristian.tomescu@student.unitbv.ro\n\nGrupa:10LF224\n\nFeatures:\n-Saritura simpla\n-Saritura multipla\n-Posibilitatea de salvare/incarcare a unui joc\n\nReguli:\n-Jucatorul cu piesele negre incepe mereu primul\n-Piesele se pot muta doar pe diagonala\n-Daca o piesa ajunge in capatul opus devine rege,acesta se poate muta si in spate");
        }
    }
}
