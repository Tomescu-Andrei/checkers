﻿using altTestDame.Models;
using altTestDame.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using altTestDame.Commands;
using System;

namespace altTestDame.ViewModels
{
    internal class GameVM : INotifyPropertyChanged
    {
        private GameLogic gameLogic;

        private ObservableCollection<ObservableCollection<Piece>> _board;


        private int red;
        private int black;

        private bool multiplejumps;
        private bool block=true;

        public bool Block
        {
            get { return block; }
            set
            {
                if (block != value)
                {
                    block = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Multiplejumps
        {
            get { return multiplejumps; }
            set
            {
                if (multiplejumps != value)
                {
                    multiplejumps = value;
                    OnPropertyChanged();
                }
            }
        }



        public GameVM()
        {

            gameLogic = new GameLogic(this);
           
        }
        private string labelTurn= "Black  player to move";

        public string LabelTurn
        {
            get { return labelTurn; }
            set
            {
                if (labelTurn != value)
                {
                    labelTurn = value;
                    OnPropertyChanged(nameof(labelTurn));
                }
            }
        }

        public int LabelTextRed
        {
            get { return red; }
            set
            {
                if (red != value)
                {
                    red = value;
                    OnPropertyChanged(nameof(LabelTextRed));
                }
            }
        }
        public int LabelTextBlack
        {
            get { return black; }
            set
            {
                if (black != value)
                {
                    black = value;
                    OnPropertyChanged(nameof(LabelTextBlack));
                }
            }
        }

        private ICommand pieceClicked;
        public ICommand PieceClickedCommand
        {
           
            get
            {
                if (pieceClicked == null)
                {
                    pieceClicked = new RelayCommand<Piece>(gameLogic.PieceClicked);
                }
                return pieceClicked;
            }
        }


        public ObservableCollection<ObservableCollection<Piece>> Board
        {
            get { return _board; }
            set
            {
                if (_board != value)
                {
                    _board = value;
                    OnPropertyChanged(nameof(Board));
                }
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public void SaveClick()
        {

            if (gameLogic.playerTurn == colorpiece.Red)
                Utility.SaveGame(Board, multiplejumps.ToString(),"red");

            else
            {
                Utility.SaveGame(Board, multiplejumps.ToString(),"black");
            }

        }

        public void Load_Click()
        {
            string aux,turn;
            (Board,aux,turn) = Utility.LoadGame();
            Multiplejumps = Convert.ToBoolean(aux);
            if (turn == "red")
            {
                gameLogic.playerTurn = colorpiece.Red;
                LabelTurn = "red";
            }
            else
            {
                gameLogic.playerTurn = colorpiece.Black;
                LabelTurn = "black";

            }
            int red = 0;
            int black = 0;
            for (int i = 0;i<Board.Count;i++)
            {
                for (int j = 0; j < Board[i].Count;j++)
                {
                    if (Board[i][j].Color==colorpiece.Red)
                        red++;
                    else if (Board[i][j].Color == colorpiece.Black)
                        black++;
                }
            }
            LabelTextBlack = 12 - red;
            LabelTextRed = 12 - black;
            gameLogic.redScore = LabelTextRed;
            gameLogic.blackScore = LabelTextBlack;
        }

        public void Statistics_Click()
        {
            (int scoreRed, int maxRed,int scoreBlack,int maxBlack) = ManageJson.ReadStatisticsFromJson();
            MessageBox.Show("Score red:"+ scoreRed+"\nmaxRed:"+maxRed+"\nscoreBlack"+scoreBlack+"\nmaxBlack:"+maxBlack);

        }

        public void NewGame()
        {
            Block = true;
            LabelTurn = "black";
            gameLogic.playerTurn = colorpiece.Black;
            LabelTextRed = 0;
            LabelTextBlack = 0;
            gameLogic = new GameLogic(this);

        }

    }
}

