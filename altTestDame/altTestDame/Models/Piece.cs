﻿using altTestDame.Models;
using Microsoft.Owin.Security.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace altTestDame.Models
{
    class Piece : BaseNotification
    {

        private colorpiece color;
        bool king = false;
        public int row { get; set; }

        public int column { get; set; }

        private SolidColorBrush _textColor;

        public SolidColorBrush TextColor
        {
            get { return _textColor; }
            set
            {
                if (_textColor != value)
                {
                    _textColor = value;
                    OnPropertyChanged(nameof(TextColor));
                }
            }
        }

        private bool _isVisible;


        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    OnPropertyChanged("IsVisible");

                }
            }
        } 
        public colorpiece Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        

        public Piece(int row, int column, colorpiece v1, bool v2)
        {
            this.row = row;
            this.column = column;

            this.color = v1;
            this.king = v2;
        }

        public bool King
        {
            get { return king; }
            set
            {
                king = value;
                OnPropertyChanged("King");
            }
        }

       public new event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }
}
