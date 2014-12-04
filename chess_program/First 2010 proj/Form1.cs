using System;
using System.Collections.Generic;
using System.Timers;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Net.Sockets;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Media;

namespace First_2010_proj
{
    public partial class Form1 : Form
    {
        bool lWRookHasMoved;
        bool rWRookHasMoved;
        bool lBRookHasMoved;
        bool rBRookHasMoved;

        Thread clientThread;
        TcpClient client;
        private TcpListener tcpListener;
        private Thread listenThread;
        //SoundPlayer //soundEffect;
        //SoundPlayer //victoryEffect;
        //SoundPlayer //defeatEffect;
        //SoundPlayer //checkEffect;
        //SoundPlayer //gameOverEffect;
        //SoundPlayer //alarmEffect;
        //SoundPlayer //tickEffect;
        //SoundPlayer //newGameEffect;
        bool checkmate;
        int selectedBox;
        Color prevColor;
        Control[] pbaBoard;
        Piece[] aPieces;
        static int turn;
        int enp;
        int timerWhite;
        int timerBlack;
        Color backColor;
        Color hoverColor;
        Color clickColor;
        static String threadInput = "";
        static String threadOutput = "";
        int myTurn;
        bool ready = false;
        bool ready2 = false;
        //***********************************************************************************************************//
        public Form1()
        {
            InitializeComponent();
            cbTime.SelectedIndex = cbTime.FindString("NO TIMER");
            cbAi.SelectedIndex = cbAi.FindString("W: HUM B: HUM");
        }

        public void initialize(String side)
        {
            //backColor = Color.Brown;
            //soundEffect = new SoundPlayer(@"C:\Users\chrisa\Downloads\hitsound.WAV");
            //victoryEffect = new SoundPlayer(@"C:\Users\chrisa\Downloads\your_team_won.WAV");
            //defeatEffect = new SoundPlayer(@"C:\Users\chrisa\Downloads\your_team_lost.WAV");
            //checkEffect = new SoundPlayer(@"C:\Users\chrisa\Downloads\check.WAV");
            //gameOverEffect = new /SoundPlayer(@"C:\Users\chrisa\Downloads\game_over.WAV");
            //alarmEffect = new //SoundPlayer(@"C:\Users\chrisa\Downloads\alarm.WAV");
            //newGameEffect = new //SoundPlayer(@"C:\Users\chrisa\Downloads\new_game.WAV");
            //tickEffect = new //SoundPlayer(@"C:\Users\chrisa\Downloads\tick.WAV");
            tTimer.Start();
            //newGameEffect.Play();
            checkmate = false;
            txtInput.Text = "";
            lbNotation.Items.Clear();
            lbNotation2.Items.Clear();

            lbTurn.Text = "White's Turn 1";
            enp = -1;
            selectedBox = -1;
            lWRookHasMoved = false;
            rWRookHasMoved = false;
            lBRookHasMoved = false;
            rBRookHasMoved = false;
            pbaBoard = new Button[64];
            aPieces = new Piece[64];
            turn = 0;

            for (int i = 0; i < 8; i++)
            {
                Control label = new Label();
                this.Controls.Add(label);
                label.Location = new Point(50 + 80 * i, 660);
                label.ForeColor = Color.White;
                label.Text = getLetter(i);
                label.Size = new System.Drawing.Size(20, 20);
            }

            for (int i = 0; i < 8; i++)
            {
                Control label = new Label();
                this.Controls.Add(label);
                label.Location = new Point(0, 50 + 80 * i);
                label.ForeColor = Color.White;
                label.Text = (8 - i).ToString();
                label.Size = new System.Drawing.Size(20, 20);
            }

            Bitmap myBitmap = new Bitmap(Properties.Resources.Chess_symbols, new Size(450, 230));
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;

            for (int i = 0; i < 64; i++)
            {/*
                pbaBoard[i] = new PictureBox();
                this.Controls.Add(pbaBoard[i]);
                pbaBoard[i].Location = new Point(20 + 80 * (i % 8), 20 + 80 * (i / 8));
                pbaBoard[i].Size = new System.Drawing.Size(77, 77);
                getBackColor(i);*/

                pbaBoard[i] = new Button();
                this.Controls.Add(pbaBoard[i]);
                if(side == "WHITE")
                    pbaBoard[i].Location = new Point(20 + 80 * (i % 8), 20 + 80 * (i / 8));
                else
                    pbaBoard[i].Location = new Point(20 + 560 - 80 * (i % 8), 20 + 560 - 80 * (i / 8));
                pbaBoard[i].Size = new System.Drawing.Size(77, 77);
                getBackColor(i);
                ((Button)pbaBoard[i]).FlatStyle = FlatStyle.Flat;
                ((Button)pbaBoard[i]).FlatAppearance.BorderSize = 0;
                pbaBoard[i].Click += button_Click;
                pbaBoard[i].MouseEnter += new EventHandler(button_MouseEnter);
                pbaBoard[i].MouseLeave += new EventHandler(button_MouseLeave);

                if (i >= 8 && i <= 15)
                {
                    Rectangle cloneRect = new Rectangle(371, 124, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Pawn(1);
                }
                else if (i >= 48 && i <= 55)
                {
                    Rectangle cloneRect = new Rectangle(371, 20, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Pawn(0);
                }
                else if (i == 60)
                {
                    Rectangle cloneRect = new Rectangle(5, 20, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new King(0);
                }
                if (i == 4)
                {
                    Rectangle cloneRect = new Rectangle(5, 123, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new King(1);
                }
                else if (i == 3)
                {
                    Rectangle cloneRect = new Rectangle(77, 123, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Queen(1);
                }
                else if (i == 59)
                {
                    Rectangle cloneRect = new Rectangle(77, 20, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Queen(0);
                }
                else if (i == 2 || i == 5)
                {
                    Rectangle cloneRect = new Rectangle(225, 121, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Bishop(1);
                }
                else if (i == 58 || i == 61)
                {
                    Rectangle cloneRect = new Rectangle(225, 20, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Bishop(0);
                }
                else if (i == 0 || i == 7)
                {
                    Rectangle cloneRect = new Rectangle(150, 123, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Rook(1);
                }
                else if (i == 56 || i == 63)
                {
                    Rectangle cloneRect = new Rectangle(150, 20, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Rook(0);
                }
                else if (i == 1 || i == 6)
                {
                    Rectangle cloneRect = new Rectangle(302, 123, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Knight(1);
                }
                else if (i == 57 || i == 62)
                {
                    Rectangle cloneRect = new Rectangle(297, 20, 77, 77);
                    pbaBoard[i].BackgroundImage = myBitmap.Clone(cloneRect, format);
                    aPieces[i] = new Knight(0);
                }

            }
            cbColor.SelectedIndex = cbColor.FindString("Brown");
        }
        public string getBestMoveHead()
        {
            int highScore = -10000;
            int highI = 0;
            int highJ = 0;

            bool notLegal = true;
            int k = 0;
            while (notLegal)
            {
                Random random = new Random();
                int i = random.Next(0, 64);
                int j = random.Next(0, 64);
                Piece[] temp = new Piece[64];
                Array.Copy(aPieces, temp, 64);
                if (turn % 2 == 1)
                {
                    if ((temp[j] == null || temp[j].type != 8 && temp[j].side != 1) && (temp[i] != null && temp[i].side == 1))
                    {
                        temp[j] = temp[i];
                        temp[i] = null;

                        if (!aPieces[i].check(1, temp, pbaBoard) &&
                            aPieces[i].canMove(lWRookHasMoved, rWRookHasMoved, enp, 1, i, j, aPieces, pbaBoard)
                            )
                        {
                            highI = i;
                            highJ = j;
                            notLegal = false;
                        }
                    }
                }
                k++;
            }
            return (char)(highI % 8 + 'a') + "" + (char)((8 - (highI) / 8) + '0') + (char)(highJ % 8 + 'a') + "" + (char)((8 - (highJ) / 8) + '0');
        }
        public void handleInput(int index, String newPos)
        {
            if (timerWhite > 0 && timerBlack > 0)
            {
                if (txtInput.Text == "" && aPieces[index] != null && aPieces[index].side == turn % 2)
                {
                    selectedBox = index;
                    txtInput.Text = newPos;
                    if (turn % 2  == myTurn || myTurn == 2)
                         pbaBoard[index].BackColor = clickColor;
                }
                else if (txtInput.Text != "" && txtInput.Text.Substring(0, 2) == newPos)
                {
                    txtInput.Text = "";
                    if (turn % 2 == myTurn || myTurn == 2)
                    {
                    pbaBoard[index].BackColor = hoverColor;
                    }
                    selectedBox = -1;
                }
                else if (txtInput.Text != "")
                {
                    int tempTurn = turn;
                    txtInput.Text = txtInput.Text.Substring(0, 2) + newPos;
                    compute();
                    if (tempTurn < turn)
                    {
                        if (checkMate((txtInput.Text.ToLower()[0] - 'a')))
                        {
                            
                            lbTurn.Text = "CHECKMATE";
                            if (myTurn != 2)
                                send("CHECKMATE");
                            tTimer.Stop();
                            if (turn % 2 == 1)
                            {
                                lbNotation.Items[lbNotation.Items.Count - 1] =
                                    lbNotation.Items[lbNotation.Items.Count - 1].ToString().Substring(0, lbNotation.Items[lbNotation.Items.Count - 1].ToString().Length - 1) + "#";
                            }
                            else
                            {
                                lbNotation2.Items[lbNotation.Items.Count - 1] =
                                     lbNotation2.Items[lbNotation2.Items.Count - 1].ToString().Substring(0, lbNotation2.Items[lbNotation.Items.Count - 1].ToString().Length - 1) + "#";
                            }
                            //if (turn % 2 != myTurn || myTurn == 2)
                                //victoryEffect.Play();
                            //else
                                //defeatEffect.Play();
                        }
                        else if(myTurn != 2)
                        {
                            send(txtInput.Text);
                        }
                        txtInput.Text = ""; 
                        
                        if ((tempTurn) % 2 == myTurn || myTurn == 2)
                        {
                            pbaBoard[index].BackColor = hoverColor;
                            pbaBoard[selectedBox].BackColor = getBackColor(selectedBox);
                        }
                        selectedBox = -1;
                        
                    }
                }
            }
        }
        public void button_Click(object sender, EventArgs e)
        {
            if (timerWhite > 0 && timerBlack > 0 && (myTurn == 2 || turn % 2 == myTurn) && (myTurn != 2 && ready && ready2 || myTurn == 2))
            {
                int index;
                String newPos = "";
                for (index = 0; index < 64; index++)
                {
                    if (sender == pbaBoard[index])
                    {
                        newPos = (char)(index % 8 + 'a') + "" + (char)((8 - (index) / 8) + '0');
                        break;
                    }
                }
                handleInput(index, newPos);
            }
            /* Piece temp = new Piece(0, 0, 0, 0, 0);
             if (txtInput.Text.Length > 2 && 
                 temp.checkMate(turn % 2, lWRookHasMoved, rWRookHasMoved, lBRookHasMoved, rBRookHasMoved, (txtInput.Text.ToLower()[0] - 'a'), aPieces, pbaBoard))
             {
                 lbTurn.Text = "CHECKMATE";
             }*/
        }
        public void compute()
        {
            if (txtInput.Text.Length == 4)
            {
                int oldPos = txtInput.Text.ToLower()[0] - 'a' + (8 - (txtInput.Text[1] - '0')) * 8;
                int newPos = txtInput.Text.ToLower()[2] - 'a' + (8 - (txtInput.Text[3] - '0')) * 8;
                int x = (txtInput.Text.ToLower()[0] - 'a');
                /*int x2 = (txtInput.Text.ToLower()[2] - 'a');
                int n = (8 - (txtInput.Text[1] - '0'));
                int n2 = (8 - (txtInput.Text[3] - '0'));*/
                if (oldPos >= 0 && newPos <= 63 && aPieces[oldPos] != null /*&& x >= 0 && x <= 7 && x2 >= 0 && x2 <= 7
                    && n >= 1 && n <= 8 && n2 >= 1 && n2 <= 8*/)
                {
                    if (turn % 2 == 0 && 0 == aPieces[oldPos].side)//white
                    {
                        if (aPieces[oldPos].type == 1 && ((Pawn)aPieces[oldPos]).canMove(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))//pawn
                        {
                            enp = ((Pawn)aPieces[oldPos]).moveWhite(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            addMoveToBoxWhite("");
                        }
                        else if (aPieces[oldPos].type == 9 && ((Queen)aPieces[oldPos]).canMove(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                        {
                            ((Queen)aPieces[oldPos]).moveWhite(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            addMoveToBoxWhite("Q");
                        }
                        else if (aPieces[oldPos].type == 2 && ((Bishop)aPieces[oldPos]).canMove(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                        {
                            ((Bishop)aPieces[oldPos]).moveWhite(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            addMoveToBoxWhite("B");
                        }
                        else if (aPieces[oldPos].type == 4 && ((Rook)aPieces[oldPos]).canMove(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                        {
                            ((Rook)aPieces[oldPos]).moveWhite(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            if (oldPos == 0)
                            {
                                lWRookHasMoved = true;
                            }
                            else if (oldPos == 7)
                            {
                                rWRookHasMoved = true;
                            }
                            addMoveToBoxWhite("R");
                        }
                        else if (aPieces[oldPos].type == 3 && ((Knight)aPieces[oldPos]).canMove(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                        {
                            ((Knight)aPieces[oldPos]).moveWhite(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            addMoveToBoxWhite("Kt");
                        }
                        else if (aPieces[oldPos].type == 8 && ((King)aPieces[oldPos]).canMove(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                        {

                            turn++;
                            if (((King)aPieces[oldPos]).castleW(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                            {
                                if (oldPos - newPos < 0)
                                {
                                    ((Rook)aPieces[63]).moveWhite(enp, 63, 61, aPieces, pbaBoard);
                                    addMoveToBoxWhite("0");
                                }
                                else
                                {
                                    ((Rook)aPieces[56]).moveWhite(enp, 56, 59, aPieces, pbaBoard);
                                    addMoveToBoxWhite("-1");
                                }
                            }
                            else
                            {
                                addMoveToBoxWhite("K");
                            }

                            ((King)aPieces[oldPos]).moveWhite(enp, oldPos, newPos, aPieces, pbaBoard);
                            lWRookHasMoved = true;
                            rWRookHasMoved = true;
                        }
                    }
                    else if (turn % 2 == 1 && 1 == aPieces[oldPos].side)//black
                    {
                        if (aPieces[oldPos].type == 1 && ((Pawn)aPieces[oldPos]).canMoveBlack(lBRookHasMoved, rBRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))//pawn
                        {
                            enp = ((Pawn)aPieces[oldPos]).moveBlack(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            addMoveToBoxBlack("");
                        }
                        else if (aPieces[oldPos].type == 9 && ((Queen)aPieces[oldPos]).canMoveBlack(lBRookHasMoved, rBRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))//Queen
                        {
                            ((Queen)aPieces[oldPos]).moveBlack(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            addMoveToBoxBlack("Q");
                        }
                        else if (aPieces[oldPos].type == 2 && ((Bishop)aPieces[oldPos]).canMoveBlack(lBRookHasMoved, rBRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))//Bishop
                        {
                            ((Bishop)aPieces[oldPos]).moveBlack(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            addMoveToBoxBlack("B");
                        }
                        else if (aPieces[oldPos].type == 4 && ((Rook)aPieces[oldPos]).canMoveBlack(lBRookHasMoved, rBRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))//Rook
                        {
                            ((Rook)aPieces[oldPos]).moveBlack(enp, oldPos, newPos, aPieces, pbaBoard);
                            if (oldPos == 0)
                            {
                                lBRookHasMoved = true;
                            }
                            else if (oldPos == 7)
                            {
                                rBRookHasMoved = true;
                            }
                            turn++;
                            addMoveToBoxBlack("R");
                        }
                        else if (aPieces[oldPos].type == 3 && ((Knight)aPieces[oldPos]).canMoveBlack(lBRookHasMoved, rBRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                        {
                            ((Knight)aPieces[oldPos]).moveBlack(enp, oldPos, newPos, aPieces, pbaBoard);
                            turn++;
                            addMoveToBoxBlack("Kt");
                        }
                        else if (aPieces[oldPos].type == 8 && ((King)aPieces[oldPos]).canMoveBlack(lBRookHasMoved, rBRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                        {
                            turn++;
                            if (((King)aPieces[oldPos]).castleB(lBRookHasMoved, rBRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard))
                            {
                                if (oldPos - newPos < 0)
                                {
                                    ((Rook)aPieces[7]).moveBlack(enp, 7, 5, aPieces, pbaBoard);
                                    addMoveToBoxBlack("0");
                                }
                                else
                                {
                                    ((Rook)aPieces[0]).moveBlack(enp, 0, 3, aPieces, pbaBoard);
                                    addMoveToBoxBlack("-1");
                                }
                            }
                            else
                            {
                                addMoveToBoxBlack("K");
                            }

                            ((King)aPieces[oldPos]).moveBlack(enp, oldPos, newPos, aPieces, pbaBoard);
                            lBRookHasMoved = true;
                            rBRookHasMoved = true;
                        }
                    }
                }
            }
        }
        public bool checkMate(int x)
        {
            int i = 0;
            if (turn % 2 == 0)
            {
                for (i = 0; i < aPieces.Length; i++)
                {
                    if (aPieces[i] != null && aPieces[i].side == 0)
                    {
                        for (int j = 0; j < pbaBoard.Length; j++)
                        {
                            Piece[] temp = new Piece[64];
                            Array.Copy(aPieces, temp, 64);
                            if (temp[j] == null || temp[j].type != 8)
                            {
                                temp[j] = temp[i];
                                temp[i] = null;
                                if (!aPieces[i].check(0, temp, pbaBoard) && aPieces[i].canMove(lWRookHasMoved, rWRookHasMoved, enp, x, i, j, aPieces, pbaBoard))
                                    return false;
                            }
                        }
                    }
                }
                checkmate = true;

            }
            else
            {
                for (i = 0; i < aPieces.Length; i++)
                {
                    if (aPieces[i] != null && aPieces[i].side == 1)
                    {
                        for (int j = 0; j < pbaBoard.Length; j++)
                        {
                            Piece[] temp = new Piece[64];
                            Array.Copy(aPieces, temp, 64);
                            if (temp[j] == null || temp[j].type != 8)
                            {
                                temp[j] = temp[i];
                                temp[i] = null;
                                if (!aPieces[i].check(1, temp, pbaBoard) && aPieces[i].canMoveBlack(lBRookHasMoved, rBRookHasMoved, enp, x, i, j, aPieces, pbaBoard))
                                    return false;
                            }
                        }
                    }
                }
                checkmate = true;
            }

            return true;
        }

        public String getLetter(int i)
        {
            switch (i)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                default:
                    return "H";
            }
        }
        public Color getBackColor(int i)
        {
            if ((i + i / 8) % 2 == 0)
            {
                pbaBoard[i].BackColor = Color.White;
                return Color.White;
            }
            else
            {
                pbaBoard[i].BackColor = backColor;
                return backColor;
            }
        }
        public void addMoveToBoxWhite(String type)
        {
            lbTurn.Text = "Black's Turn " + (turn / 2 + 1);
            Piece temp = new Piece(0);
            if (temp.check(1, aPieces, pbaBoard))
            {
                lbNotation.Items.Add((turn / 2 + 1) + ". " + type + txtInput.Text[0] + txtInput.Text[1] + "-" + txtInput.Text[2] + txtInput.Text[3] + "+");
                //checkEffect.Play();
            }
            else if (type == "0")
            {
                //soundEffect.Play();
                lbTurn.Text = "Black's Turn " + (turn / 2 + 1);
                lbNotation.Items.Add((turn / 2 + 1) + ". O-O");
            }
            else if (type == "-1")
            {
                //soundEffect.Play();
                lbTurn.Text = "Black's Turn " + (turn / 2 + 1);
                lbNotation.Items.Add((turn / 2 + 1) + ". O-O-O");
            }
            else
            {
                //soundEffect.Play();
                lbNotation.Items.Add((turn / 2 + 1) + ". " + type + txtInput.Text[0] + txtInput.Text[1] + "-" + txtInput.Text[2] + txtInput.Text[3]);
            }
           }
        public void addMoveToBoxBlack(String type)
        {
            lbTurn.Text = "White's Turn " + (turn / 2 + 1);
            Piece temp = new Piece(0);
            if (checkmate)
                lbNotation2.Items.Add((turn / 2) + ". " + type + txtInput.Text[0] + txtInput.Text[1] + "-" + txtInput.Text[2] + txtInput.Text[3] + "#");
            else if (temp.check(0, aPieces, pbaBoard))
            {
                //checkEffect.Play();
                lbNotation2.Items.Add((turn / 2) + ". " + type + txtInput.Text[0] + txtInput.Text[1] + "-" + txtInput.Text[2] + txtInput.Text[3] + "+");
            }
            else if (type == "0")
            {
                //soundEffect.Play();
                lbTurn.Text = "White's Turn " + (turn / 2 + 1);
                lbNotation2.Items.Add((turn / 2) + ". O-O");
            }
            else if (type == "-1")
            {
                //soundEffect.Play();
                lbTurn.Text = "White's Turn " + (turn / 2 + 1);
                lbNotation2.Items.Add((turn / 2) + ". O-O-O");
            }
            else
            {
                //soundEffect.Play();
                lbNotation2.Items.Add((turn / 2) + ". " + type + txtInput.Text[0] + txtInput.Text[1] + "-" + txtInput.Text[2] + txtInput.Text[3]);
            }
        }
        public void button_MouseEnter(object sender, EventArgs e)
        {
            for (int index = 0; index < 64; index++)
            {
                if (sender == pbaBoard[index])
                {
                    prevColor = getBackColor(index);
                    if (txtInput.Text == "")
                        pbaBoard[index].BackColor = hoverColor;
                    else if(turn % 2 == myTurn || myTurn == 2)
                        pbaBoard[index].BackColor = clickColor;
                    break;
                }
            }
        }
        public void button_MouseLeave(object sender, EventArgs e)
        {
            for (int index = 0; index < 64; index++)
            {
                if (sender == pbaBoard[index] && index != selectedBox)
                {
                    pbaBoard[index].BackColor = prevColor;
                    break;
                }
            }
        }

        private void bMove_Click(object sender, EventArgs e)
        {
        }
        private void bRestart_Click_1(object sender, EventArgs e)//Quit
        {
            if (myTurn != 2)
            {
                send("QUIT");
            }            
            quit();
        }
        private void bResume_Click(object sender, EventArgs e)//resume
        {
            if (myTurn != 2)
            {
                send("RESUME");
            }
            resume();
        }

        public void resume()
        {
            gbAllMenu.Visible = false;
            gbPauseMenu.Visible = false;
            bPause.Visible = true;
            tTimer.Start();
        }
        private void bRestart_Click(object sender, EventArgs e)//pause
        {
            if (myTurn != 2)
            {
                send("PAUSE");
            }
            pause();
        }
        private void bOptions_Click(object sender, EventArgs e)//options
        {
            //pause menu options
        }
        private void bNewGame_Click(object sender, EventArgs e)
        {
            gbNotationPanel.Visible = true;
            gbMainMenu.Visible = false;
            gbAllMenu.Visible = false;
            bPause.Visible = true;
            initialize("WHITE");
            pbTimers.Visible = true;
            myTurn = 2;
            setUpTimer();
        }
        private void setUpTimer()
        {
            if (cbTime.SelectedIndex == 0)
            {
                timerBlack = 1;
                timerWhite = 1;
                pbTimers.Visible = false;
            }
            else if (cbTime.SelectedIndex == 1)
            {
                timerBlack = 300;
                timerWhite = 300;
            }
            else if (cbTime.SelectedIndex == 2)
            {
                timerBlack = 600;
                timerWhite = 600;
            }
            else if (cbTime.SelectedIndex == 3)
            {
                timerBlack = 900;
                timerWhite = 900;
            }
            else if (cbTime.SelectedIndex == 4)
            {
                timerBlack = 1800;
                timerWhite = 1800;
            }
            else if (cbTime.SelectedIndex == 5)
            {
                timerBlack = 2700;
                timerWhite = 2700;
            }
            else if (cbTime.SelectedIndex == 6)
            {
                timerBlack = 3600;
                timerWhite = 3600;
            }
            else if (cbTime.SelectedIndex == 7)
            {
                timerBlack = 90 * 60;
                timerWhite = 90 * 60;
            }
            else if (cbTime.SelectedIndex == 8)
            {
                timerBlack = 120 * 60;
                timerWhite = 120 * 60;
            }
            txtTimerBlack.Text = (timerBlack / 60).ToString() + ":00";
            txtTimer.Text = (timerWhite / 60).ToString() + ":00";
        }
        private void tTimer_Tick(object sender, EventArgs e)
        {
            
            if (txtTimer.Visible == true)
            {
                if (turn % 2 == 0)
                {
                    if (timerWhite > 0)
                    {
                        //tickEffect.Play();
                        timerWhite -= 1;
                        if (timerWhite % 60 < 10)
                            txtTimer.Text = (timerWhite / 60).ToString() + ":0" + (timerWhite % 60).ToString();
                        else
                            txtTimer.Text = (timerWhite / 60).ToString() + ":" + (timerWhite % 60).ToString();
                    }
                    if (timerWhite == 0)
                    {
                        //alarmEffect.Play();
                        txtTimer.Text = "0:00";
                        lbTurn.Text = "OUT OF TIME";
                        tTimer.Stop();
                    }
                }
                else
                {
                    if (timerBlack > 0)
                    {
                        //tickEffect.Play();
                        timerBlack -= 1;
                        if (timerBlack % 60 < 10)
                            txtTimerBlack.Text = (timerBlack / 60).ToString() + ":0" + (timerBlack % 60).ToString();
                        else
                            txtTimerBlack.Text = (timerBlack / 60).ToString() + ":" + (timerBlack % 60).ToString();

                    }
                    if (timerBlack == 0)
                    {
                        //alarmEffect.Play();
                        txtTimerBlack.Text = "0:00";
                        lbTurn.Text = "OUT OF TIME";
                        tTimer.Stop();
                    }
                }
            }

        }
        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColor.SelectedIndex == 0)
            {
                hoverColor = Color.LightBlue;
                clickColor = Color.Blue;
                backColor = Color.Brown;
            }
            else if (cbColor.SelectedIndex == 1)
            {
                hoverColor = Color.LightGreen;
                clickColor = Color.Green;
                backColor = Color.Gray;
            }
            else if (cbColor.SelectedIndex == 2)
            {
                hoverColor = Color.PaleVioletRed;
                clickColor = Color.Red;
                backColor = Color.DarkGreen;
            }
            else if (cbColor.SelectedIndex == 3)
            {
                hoverColor = Color.LightGreen;
                clickColor = Color.Green;
                backColor = Color.DarkRed;
            }
            else if (cbColor.SelectedIndex == 4)
            {
                hoverColor = Color.LightGreen;
                clickColor = Color.Green;
                backColor = Color.Purple;
            }
            else if (cbColor.SelectedIndex == 5)
            {
                hoverColor = Color.LightBlue;
                clickColor = Color.Blue;
                backColor = Color.Orange;
            }
            for (int i = 0; i < 64; i++)
            {
                pbaBoard[i].BackColor = getBackColor(i);
            }
        }
        public int getVal(int id)
        {
            if (id == 1)
                return 1;
            else if (id == 2 || id == 3)
                return 3;
            else if (id == 4)
                return 5;
            else if (id == 9)
                return 9;
            else
                return 0;
        }
        private void tBot_Tick(object sender, EventArgs e)
        {/*
            if (turn % 2 == 1)
            {
                String input = getBestMoveHead();
                txtInput.Text = input.Substring(0, 2);
                String newPos2 = input.Substring(2, 2);
                int index2 = (newPos2[0] - 'a') + (8 - (newPos2[1] - '0')) * 8;
                selectedBox = 1;
                handleInput(index2, newPos2);
            }*/
        }
        public class Ai
        {
            bool lWRookHasMoved;
            bool rWRookHasMoved;
            int enp;
            Piece[] aPieces;
            Control[] pbaBoard;
            int turn;
            Control txtThread;
            public String input = "";

            public Ai(bool lWRookHasMoved, bool rWRookHasMoved, int enp, Piece[] aPieces, Control[] pbaBoard, int turn, Control txtThread)
            {
                this.lWRookHasMoved = lWRookHasMoved;
                this.rWRookHasMoved = rWRookHasMoved;
                this.enp = enp;
                this.aPieces = aPieces;
                this.pbaBoard = pbaBoard;
                this.turn = turn;
                this.txtThread = txtThread;
            }

            public void getBestMoveHead()
            {
                int highScore = -10000;
                int highI = 0;
                int highJ = 0;

                bool notLegal = true;
                int k = 0;
                while (notLegal)
                {
                    Random random = new Random();
                    int i = random.Next(0, 64);
                    int j = random.Next(0, 64);
                    Piece[] temp = new Piece[64];
                    Array.Copy(aPieces, temp, 64);
                    if (turn % 2 == 1)
                    {
                        if ((temp[j] == null || temp[j].type != 8 && temp[j].side != 1) && (temp[i] != null && temp[i].side == 1))
                        {
                            temp[j] = temp[i];
                            temp[i] = null;

                            if (!aPieces[i].check(1, temp, pbaBoard) &&
                                aPieces[i].canMove(lWRookHasMoved, rWRookHasMoved, enp, 1, i, j, aPieces, pbaBoard)
                                )
                            {
                                highI = i;
                                highJ = j;
                                notLegal = false;
                            }
                        }
                    }
                    k++;
                }
                input = (char)(highI % 8 + 'a') + "" + (char)((8 - (highI) / 8) + '0') + (char)(highJ % 8 + 'a') + "" + (char)((8 - (highJ) / 8) + '0');
            }

            /*
            public int getBestMove(int level, int side, Piece[] newAPieces)
            {
                int highScore = -10000;
                if (level > 0 + side)
                {
                    return 0;
                }
                else
                {
                    if (level % 2 == 0)
                    {
                        for (int i = 0; i < 64; i++)
                        {
                            if (newAPieces[i] != null && newAPieces[i].side == 0)
                            {
                                for (int j = 0; j < 64; j++)
                                {
                                    Piece[] temp = new Piece[64];
                                    Array.Copy(aPieces, temp, 64);
                                    if (temp[j] == null || temp[j].type != 8 && temp[j].side != 0)
                                    {
                                        int dif;
                                        if(temp[j] == null){
                                            dif = 0;
                                        }
                                        else{
                                            dif = getVal(temp[j].id);
                                        }
                                        temp[j] = temp[i];
                                        temp[i] = null;
                                        dif += getBestMove(level + 1, side, temp);
                                        if (!newAPieces[i].check(0, temp, pbaBoard) &&
                                            newAPieces[i].canMove(lWRookHasMoved, rWRookHasMoved, enp, (txtInput.Text.ToLower()[0] - 'a'), i, j, aPieces, pbaBoard) &&
                                            dif > highScore
                                            )
                                            highScore = dif;
                                    }
                                }
                            }
                        }
                        if (side == 0)
                            return highScore;
                    
                        else
                            return -highScore;
                    }
                    else
                    {
                        for (int i = 0; i < 64; i++)
                        {
                            if (newAPieces[i] != null && newAPieces[i].side == 1)
                            {
                                for (int j = 0; j < 64; j++)
                                {
                                    Piece[] temp = new Piece[64];
                                    Array.Copy(aPieces, temp, 64);
                                    if (temp[j] == null || temp[j].type != 8 && temp[j].side != 1)
                                    {
                                        int dif;
                                        if (temp[j] == null)
                                        {
                                            dif = 0;
                                        }
                                        else
                                        {
                                            dif = getVal(temp[j].id);
                                        }
                                        temp[j] = temp[i];
                                        temp[i] = null;
                                        dif += getBestMove(level + 1, side, temp);
                                        if (!newAPieces[i].check(0, temp, pbaBoard) &&
                                            newAPieces[i].canMove(lWRookHasMoved, rWRookHasMoved, enp, (0), i, j, aPieces, pbaBoard) &&
                                            dif > highScore
                                            )
                                            highScore = dif;
                                    }
                                }
                            }
                        }
                        if (side == 1)
                            return highScore;

                        else
                            return -highScore;
                    }
                }
            }*/
        }
        private void cbAi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pause()
        {
            tTimer.Stop();
            gbAllMenu.Visible = true;
            gbPauseMenu.Visible = true;
            bPause.Visible = false;
            cbTime.SelectedIndex = cbTime.FindString("NO TIMER");
            cbAi.SelectedIndex = cbAi.FindString("W: HUM B: HUM");
        }
        private void quit()
        {
            //gameOverEffect.Play();
            for (int i = 0; i < 64; i++)
            {
                this.Controls.Remove(pbaBoard[i]);
            }
            txtTimer.Text = "";
            txtTimerBlack.Text = "";
            gbPauseMenu.Visible = false;
            gbNotationPanel.Visible = false;
            gbMainMenu.Visible = true;
            bSend.Visible = false;
            ready = false;
            ready2 = false;
            threadInput = "";
            threadOutput = "";
            if (myTurn != 2)
            {
                tThread.Enabled = false;
                this.tcpListener.Stop();
                this.listenThread.Abort();
                if (clientThread != null)
                {
                    clientThread.Abort();
                    client.Close();
                }
                txtThread.Text = "";
            }

        }

        private void bServer_Click(object sender, EventArgs e)
        {
            tThread.Enabled = true;
            gbNotationPanel.Visible = true;
            gbMainMenu.Visible = false;
            gbAllMenu.Visible = false;
            bPause.Visible = true;
            pbTimers.Visible = true;
            myTurn = 0;
            initialize("WHITE");

            this.tcpListener = new TcpListener(IPAddress.Any, 3000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.IsBackground = true;
            this.listenThread.Start();
            bSend.Visible = true;
            setUpTimer();
            tTimer.Stop();
        }

        private void bClient_Click(object sender, EventArgs e)
        {
            tThread.Enabled = true;
            gbNotationPanel.Visible = true;
            gbMainMenu.Visible = false;
            gbAllMenu.Visible = false;
            bPause.Visible = true; 
           // changeText("IAMCLIENT");
            myTurn = 1;
            initialize("BLACK");
            pbTimers.Visible = true;
            
            this.tcpListener = new TcpListener(IPAddress.Any, 3001);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.IsBackground = true;
            this.listenThread.Start();
            bSend.Visible = true;
            setUpTimer();
            tTimer.Stop();
        }

        private void connectToServer()
        {
            tryConnect:
            try
            {
                TcpClient client = new TcpClient();

                int port = 3000;
                if (myTurn == 0)
                {
                    port = 3001;
                }

                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

                client.Connect(serverEndPoint);

                NetworkStream clientStream = client.GetStream();

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes("" + threadOutput);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            catch
            {
                goto tryConnect;
            }
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();
            try
            {
                while (true)
                {
                    //blocks until a client has connected to the server
                    client = this.tcpListener.AcceptTcpClient();

                    //create a thread to handle communication 
                    //with connected client
                    clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            catch (SocketException) 
            {

            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                changeInputText(encoder.GetString(message, 0, bytesRead));
            }

            tcpClient.Close();
        }

        private static void changeInputText(string text)
        { 
            threadInput = text;
        }

        private static void changeOutputText(string text)
        {
            threadOutput = text;
        }

        private void tThread_Tick(object sender, EventArgs e)
        {
            if (txtThread.Text != threadInput)
            {
                txtThread.Text = threadInput;
                if (threadInput == "QUIT")
                {
                    quit();
                }
                else if (threadInput == "READY")
                {
                    ready2 = true;
                }
                else if (threadInput.Length > 4 && threadInput.Substring(0, 4) == "TIME")
                {
                    cbTime.SelectedIndex = Convert.ToInt32(threadInput.Substring(4, threadInput.Length - 4));
                    setUpTimer();
                }
                else if (threadInput == "PAUSE")
                {
                    pause();
                }
                else if (threadInput == "RESUME")
                {
                    resume();
                }
                else if (threadInput != "CHECKMATE")
                {
                    txtInput.Text = threadInput.Substring(0, 2);
                    handleInput(threadInput.ToLower()[2] - 'a' + (8 - (threadInput[3] - '0')) * 8, threadInput.Substring(2, 2));

                }
                

            }
           // txtTimerBlack.Text = threadOutput;
            if (ready && ready2)
            {
                tTimer.Start();
                
            }
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            send("READY");
            send("TIME" + cbTime.SelectedIndex);
            ready = true;
            bSend.Visible = false;
        }

        private void send(String output)
        {
            changeOutputText(output);
            this.listenThread = new Thread(new ThreadStart(connectToServer));
            this.listenThread.Start();
        }
    }
    //***********************************************************************************************************//
    //***********************************************************************************************************//

    public class Piece
    {
        public int type;
        public int side;
        public Piece(int side)
        {
            this.side = side;
        }

        public bool movingV(int oldPos, int newPos)
        {
            return (newPos - oldPos) % 8 == 0; 
        }

        public bool movingH(int oldPos, int newPos)
        {
            return (newPos - newPos % 8) / 8 == (oldPos - oldPos % 8) / 8;
        }

        public bool movingK(int oldPos, int newPos)
        {
            int distance = oldPos - newPos;
            int sign = oldPos % 8 - newPos % 8;
            return sign > 0 && (distance == -6 || distance == 10 || distance == -15 || distance == 17) || sign < 0 && (distance == 6 || distance == -10 || distance == 15 || distance == - 17);
        }

        public bool movingD(int oldPos, int newPos)
        {
            int s = oldPos - newPos;
            int x = oldPos % 8 - newPos % 8;
            int y7 = (newPos - oldPos) / 7;
            int y9 = (newPos - oldPos) / 9;
            return 
                (((newPos - oldPos) % 9 == 0) && 
                x < 0 && s < 0 && y9 == -x || (newPos - oldPos) % 7 == 0 && x > 0 && s < 0 && y7 == x ||
                (newPos - oldPos) % 7 == 0 && x < 0 && s > 0 && y7 == x 
                || ((newPos - oldPos) % 9 == 0) && x > 0 && s > 0 && y9 == -x );
        }

        public bool spaceIsAdjacent(int oldPos, int newPos)
        {
            int d = Math.Abs(oldPos - newPos);
            return (d == 1 || d == 7 || d == 8 || d == 9) && (movingD(oldPos, newPos) ||
                movingH(oldPos, newPos) || movingV(oldPos, newPos));
        }

        
        public bool check(int side, Piece[] aPieces, Control[] pbaBoard)
        {
            int kingPos = 0;
            for (int i = 0; i < aPieces.Length; i++)
            {
                if (aPieces[i] != null && aPieces[i].type == 8 && aPieces[i].side == side)
                {
                    kingPos = i;
                    break;
                }
            }
            for(int i = 0; i < aPieces.Length; i++)
            {
                if (aPieces[kingPos] == null)
                {
                    return false;
                }
                if (aPieces[i] != null && aPieces[i].side != aPieces[kingPos].side)
                {
                    if (aPieces[i].type == 1)
                    {
                        if (aPieces[i].side == 1)
                        {
                            if (((i + 7) == kingPos || (i + 9) == kingPos) && movingD(i, kingPos) && collidesDiagonal(i, kingPos, aPieces, pbaBoard))
                                return true;
                        }
                        else if (aPieces[i].side == 0)
                        {
                            if (((i - 7) == kingPos || (i - 9) == kingPos) && movingD(i, kingPos) && collidesDiagonal(i, kingPos, aPieces, pbaBoard))
                                return true;
                        }
                    }
                    else if (aPieces[i].type == 2)
                    {
                        if (movingD(i, kingPos) && collidesDiagonal(i, kingPos, aPieces, pbaBoard))
                            return true;
                    }
                    else if (aPieces[i].type == 3)
                    {
                        if(movingK(i, kingPos))
                            return true;
                    }
                    else if (aPieces[i].type == 4)
                    {
                        if ((movingV(i, kingPos) || movingH(i, kingPos)) && collidesStraight(i, kingPos, aPieces, pbaBoard))
                            return true;
                    }
                    else if (aPieces[i].type == 8)
                    {
                        if(spaceIsAdjacent(i, kingPos))
                            return true;
                    }
                    else if (aPieces[i].type == 9)
                    {
                        if ((movingD(i, kingPos) && collidesDiagonal(i, kingPos, aPieces, pbaBoard)) || (movingV(i, kingPos) || 
                            movingH(i, kingPos)) && collidesStraight(i, kingPos, aPieces, pbaBoard))
                            return true;
                    }
                }

            }
            return false;
        }

        public bool collidesStraight (int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            int distance = newPos - oldPos;
            if (distance > 0)
            {
                if (movingV(oldPos, newPos))
                {
                    for (int i = 1; i < distance / 8; i++)
                    {
                        if (aPieces[oldPos + i * 8] != null)
                        {
                            return false;
                        }
                    }
                }
                else if (movingH(oldPos, newPos))
                {
                    for (int i = 1; i < distance; i++)
                    {
                        if (aPieces[oldPos + i] != null)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (movingV(oldPos, newPos))
                {
                    for (int i = 1; i < -1 * distance / 8; i++)
                    {
                        if (aPieces[oldPos - i * 8] != null)
                        {
                            return false;
                        }
                    }
                }
                else if (movingH(oldPos, newPos))
                {
                    for (int i = 1; i < -1 * distance; i++)
                    {
                        if (aPieces[oldPos - i] != null)
                        {
                            return false;
                        }
                    }
                }  
            }
            return true;
        }

        public bool collidesDiagonal (int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            int distance = newPos - oldPos;
            if (distance > 0 && movingD(oldPos, newPos))
            {
                if ((distance) % 7 == 0)
                {
                    for (int i = 1; i < distance / 7; i++)
                    {
                        if (aPieces[oldPos + i * 7] != null)
                        {
                            return false;
                        }
                    }
                }
                else if ((distance) % 9 == 0)
                {
                    for (int i = 1; i < distance / 9; i++)
                    {
                        if (aPieces[oldPos + i * 9] != null)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                if ((distance) % 7 == 0)
                {
                    for (int i = 1; i < -1 * distance / 7; i++)
                    {
                        if (aPieces[oldPos - i * 7] != null)
                        {
                            return false;
                        }
                    }
                }
                else if ((distance) % 9 == 0)
                {
                    for (int i = 1; i < -1 * distance / 9; i++)
                    {
                        if (aPieces[oldPos - i * 9] != null)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public virtual bool canMove(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            return false;
        }
        public virtual bool canMoveBlack(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            return false;
        }
        public virtual int moveWhite(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            return -1;
        }
        public virtual int moveBlack(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            return -1;
        }
    }
    //***********************************************************************************************************//
    public class Pawn : Piece
    {
        public Pawn(int side)
            : base(side)
        {
            type = 1;
        }

        public override bool canMove(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(0, temp, pbaBoard) &&(
                aPieces[newPos] == null && (oldPos - newPos == 8 || oldPos - x == 48 && oldPos - newPos == 16) ||
                   aPieces[newPos] != null && aPieces[newPos].side == 1 && (oldPos - newPos == 7 || oldPos - newPos == 9) ||
                   aPieces[newPos] == null &&
                   (oldPos - newPos == 7 && aPieces[oldPos + 1] != null && aPieces[oldPos + 1].side == 1 && oldPos + 1 == enp||
                   oldPos - newPos == 9 && aPieces[oldPos - 1] != null && aPieces[oldPos - 1].side == 1 && oldPos - 1 == enp));
        }
        public override bool canMoveBlack(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(1, temp, pbaBoard) &&(
                aPieces[newPos] == null && (oldPos - newPos == -8 || oldPos - x == 8 && oldPos - newPos == -16) ||
               aPieces[newPos] != null && aPieces[newPos].side == 0 && (oldPos - newPos == -7 || oldPos - newPos == -9) ||
               aPieces[newPos] == null &&
               (oldPos - newPos == -7 && aPieces[oldPos - 1] != null && aPieces[oldPos - 1].side == 0 && oldPos - 1 == enp ||
               oldPos - newPos == -9 && aPieces[oldPos + 1] != null && aPieces[oldPos + 1].side == 0 && oldPos + 1 == enp));
        }
        public override int moveWhite(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            if (newPos / 8 == 0)
            {
                Bitmap myBitmap = new Bitmap(Properties.Resources.Chess_symbols, new Size(450, 230));
                System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
                Rectangle cloneRect = new Rectangle(77, 20, 77, 77);
                pbaBoard[newPos].BackgroundImage = myBitmap.Clone(cloneRect, format);
                aPieces[newPos] = new Queen(0);
            }
            else
            {
                pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
                aPieces[newPos] = aPieces[oldPos];
            }
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[oldPos] = null;
            if (enp == oldPos - 1 && newPos % 8 - oldPos % 8 == -1 || enp == oldPos + 1 && newPos % 8 - oldPos % 8 == 1)
            { 
                pbaBoard[newPos + 8].BackgroundImage = null;
                aPieces[newPos + 8] = null;
            }
            if (oldPos - newPos == 16)
                return newPos;
            else
                return -1;
        }
        public override int moveBlack(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            if (newPos / 8 == 7)
            {
                Bitmap myBitmap = new Bitmap(Properties.Resources.Chess_symbols, new Size(450, 230));
                System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
                Rectangle cloneRect = new Rectangle(77, 123, 77, 77);
                pbaBoard[newPos].BackgroundImage = myBitmap.Clone(cloneRect, format);

                aPieces[newPos] = new Queen(1);
            }
            else
            {
                pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
                aPieces[newPos] = aPieces[oldPos];
            }
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[oldPos] = null;
            if (enp == oldPos - 1 && newPos % 8 - oldPos % 8 == -1 || enp == oldPos + 1 && newPos % 8 - oldPos % 8 == 1)
            {
                pbaBoard[newPos - 8].BackgroundImage = null;
                aPieces[newPos - 8] = null;
            }

            if (oldPos - newPos == -16)
                return newPos;
            else
                return -1;
        }
    }
    //***********************************************************************************************************//
    public class Queen : Piece
    { 
        public Queen(int side)
            : base(side)
        {
            type = 9;
        }

        public override bool canMove(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            bool collides = collidesDiagonal(oldPos, newPos, aPieces, pbaBoard) && collidesStraight(oldPos, newPos, aPieces, pbaBoard);

            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(0, temp, pbaBoard) &&( (movingV(oldPos, newPos) || movingH(oldPos, newPos) || movingD(oldPos, newPos))
                    && newPos != oldPos && collides && (aPieces[newPos] == null || aPieces[newPos].side == 1));
        }
        public override bool canMoveBlack(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            bool collides = collidesDiagonal(oldPos, newPos, aPieces, pbaBoard) && collidesStraight(oldPos, newPos, aPieces, pbaBoard);
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(1, temp, pbaBoard) &&( (movingV(oldPos, newPos) || movingH(oldPos, newPos) || movingD(oldPos, newPos)) 
                    && newPos != oldPos && collides && (aPieces[newPos] == null || aPieces[newPos].side == 0));
        }
        public override int moveWhite(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;

            return -1;
        }
        public override int moveBlack(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;
            return -1;
        }
    }
    //***********************************************************************************************************//
    public class Bishop : Piece
    {
        public Bishop(int side)
            : base(side)
        {
            type = 2;
        }

        public override bool canMove(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            bool collides = collidesDiagonal(oldPos, newPos, aPieces, pbaBoard);
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(0, temp, pbaBoard) && movingD(oldPos, newPos) && newPos != oldPos && collides &&
                   (aPieces[newPos] == null || aPieces[newPos].side == 1);
        }
        public override bool canMoveBlack(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            bool collides = collidesDiagonal(oldPos, newPos, aPieces, pbaBoard);
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(1, temp, pbaBoard) && movingD(oldPos, newPos) && newPos != oldPos && collides &&
                   (aPieces[newPos] == null || aPieces[newPos].side == 0);
        }
        public override int moveWhite(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;

            return -1;
        }
        public override int moveBlack(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;
            return -1;
        }
    }
    //***********************************************************************************************************//
    public class Rook : Piece
    {
        public Rook(int side)
            : base(side)
        {
            type = 4;
        }

        public override bool canMove(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            bool collides = collidesStraight(oldPos, newPos, aPieces, pbaBoard);
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(0, temp, pbaBoard) && (movingH(oldPos, newPos) || movingV(oldPos, newPos)) && newPos != oldPos && collides &&
                   (aPieces[newPos] == null || aPieces[newPos].side == 1);
        }
        public override bool canMoveBlack(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            bool collides = collidesStraight(oldPos, newPos, aPieces, pbaBoard);
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(1, temp, pbaBoard) && (movingH(oldPos, newPos) || movingV(oldPos, newPos)) && newPos != oldPos && collides &&
                   (aPieces[newPos] == null || aPieces[newPos].side == 0);
        }
        public override int moveWhite(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;

            return -1;
        }
        public override int moveBlack(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;
            return -1;
        }
    }
    //***********************************************************************************************************//
    public class Knight : Piece
    {
        public Knight(int side)
            : base(side)
        {
            type = 3;
        }

        public override bool canMove(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(0, temp, pbaBoard) && movingK(oldPos, newPos) && newPos != oldPos && 
                   (aPieces[newPos] == null || aPieces[newPos].side == 1);
        }
        public override bool canMoveBlack(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(1, temp, pbaBoard) && movingK(oldPos, newPos) && newPos != oldPos &&
                   (aPieces[newPos] == null || aPieces[newPos].side == 0);
        }
        public override int moveWhite(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;

            return -1;
        }
        public override int moveBlack(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;
            return -1;
        }
    }
    //***********************************************************************************************************//
    public class King : Piece
    {
        public King(int side)
            : base(side)
        {
            type = 8;
        }

        public bool castleW(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x, 
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            Piece[] temp2 = new Piece[64];
            Array.Copy(aPieces, temp2, 64);
            if (Math.Abs(oldPos - newPos) == 2)
            {
                if (oldPos - newPos > 0)
                {
                    temp2[newPos + 1] = temp2[oldPos];
                    temp2[oldPos] = null;
                    return !lWRookHasMoved && !check(0, temp2, pbaBoard) && (aPieces[newPos + 1] == null) && (aPieces[newPos + 1] == null);
                }

                if (oldPos - newPos < 0)
                {
                    temp2[newPos - 1] = temp2[oldPos];
                    temp2[oldPos] = null;
                    return !rWRookHasMoved && !check(0, temp2, pbaBoard) && (aPieces[newPos - 1] == null);
                }
            }

            return false;
        }

        public bool castleB(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            Piece[] temp2 = new Piece[64];
            Array.Copy(aPieces, temp2, 64);
            if (Math.Abs(oldPos - newPos) == 2)
            {
                if (oldPos - newPos > 0)
                {
                    temp2[newPos + 1] = temp2[oldPos];
                    temp2[oldPos] = null;
                    return !lWRookHasMoved && !check(0, temp2, pbaBoard) && (aPieces[newPos + 1] == null) && (aPieces[newPos + 1] == null);
                }

                if (oldPos - newPos < 0)
                {
                    temp2[newPos - 1] = temp2[oldPos];
                    temp2[oldPos] = null;
                    return !rWRookHasMoved && !check(0, temp2, pbaBoard) && (aPieces[newPos - 1] == null);
                }
            }

            return false;
        }

        public override bool canMove(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;

            return !check(0, temp, pbaBoard) && (spaceIsAdjacent(oldPos, newPos) || 
                    castleW(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard) && (aPieces[newPos] == null))
                     && (aPieces[newPos] == null || aPieces[newPos].side == 1);
        }

        public override bool canMoveBlack(bool lWRookHasMoved, bool rWRookHasMoved, int enp, int x,
                            int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            Piece[] temp = new Piece[64];
            Array.Copy(aPieces, temp, 64);
            temp[newPos] = temp[oldPos];
            temp[oldPos] = null;
            return !check(1, temp, pbaBoard) && (spaceIsAdjacent(oldPos, newPos) || 
                    castleW(lWRookHasMoved, rWRookHasMoved, enp, x, oldPos, newPos, aPieces, pbaBoard) && (aPieces[newPos] == null))
                     && (aPieces[newPos] == null || aPieces[newPos].side == 0);
        }

        public override int moveWhite(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            aPieces[newPos] = aPieces[oldPos];
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[oldPos] = null;
            return -1;
        }
        public override int moveBlack(int enp, int oldPos, int newPos, Piece[] aPieces, Control[] pbaBoard)
        {
            pbaBoard[newPos].BackgroundImage = pbaBoard[oldPos].BackgroundImage;
            pbaBoard[oldPos].BackgroundImage = null;
            aPieces[newPos] = aPieces[oldPos];
            aPieces[oldPos] = null;
            return -1;
        }
    }
}









/* if (turn % 2 == 0)
                 {
                     for (int i = 0; i < 64; i++)
                     {
                         if (aPieces[i] != null && aPieces[i].side == 0)
                         {
                             for (int j = 0; j < 64; j++)
                             {
                                 Piece[] temp = new Piece[64];
                                 Array.Copy(aPieces, temp, 64);
                                 if (temp[j] == null || temp[j].type != 8 && temp[j].side != 0)
                                 {
                                     int dif;
                                     if (temp[j] == null)
                                     {
                                         dif = 0;
                                     }
                                     else
                                     {
                                         dif = getVal(temp[j].id);
                                     }
                                     temp[j] = temp[i];
                                     temp[i] = null;
                                     dif += getBestMove(0, 0, temp);
                                     if (!aPieces[i].check(0, temp, pbaBoard) &&
                                         aPieces[i].canMove(lWRookHasMoved, rWRookHasMoved, enp, (txtInput.Text.ToLower()[0] - 'a'), i, j, aPieces, pbaBoard) &&
                                         dif > highScore
                                         )
                                     {
                                         highScore = dif;
                                         highI = i;
                                         highJ = j;
                                     }
                                 }
                             }
                         }

                     }
                 }
                 else
                 {
                     for (int i = 0; i < 64; i++)
                     {
                         if (aPieces[i] != null && aPieces[i].side == 1)
                         {
                             for (int j = 0; j < 64; j++)
                             {
                                 Piece[] temp = new Piece[64];
                                 Array.Copy(aPieces, temp, 64);
                                 if (temp[j] == null || temp[j].type != 8 && temp[j].side != 1)
                                 {
                                     int dif;
                                     if (temp[j] == null)
                                     {
                                         dif = 0;
                                     }
                                     else
                                     {
                                         dif = getVal(temp[j].id);
                                     }
                                     temp[j] = temp[i];
                                     temp[i] = null;
                                     dif += getBestMove(1, 1, temp);
                                     if (!aPieces[i].check(0, temp, pbaBoard) &&
                                         aPieces[i].canMove(lWRookHasMoved, rWRookHasMoved, enp, (0), i, j, aPieces, pbaBoard) &&
                                         dif > highScore
                                         ){
                                         highScore = dif;
                                         highI = i;
                                         highJ = j;
                                     }
                                 }
                             }
                         }
                     }
                 }*/
