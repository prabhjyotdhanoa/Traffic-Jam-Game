using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficJamPuzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Global Variables
        List<string> ListOfArrows = new List<string>{"Red", "Red", "Red", "Red", "Red", "Blank", "Blue", "Blue", "Blue", "Blue", "Blue"};
        #endregion 

        #region Procedures
        private static bool CanPieceMove (List<string> list, bool right, int piecePosition, string LeftOrRight)
        {
            if (LeftOrRight == "Right")//right button press
            {
                if (right)//red
                {
                    if (piecePosition == 10)
                        return false;
                    else if (list[piecePosition + 1] == "Blank")
                        return true;

                    else if (list[piecePosition + 2] == "Blank")
                        return true;
                    else
                    {
                        return false;
                    }
                }

                else//blue
                {
                    return false;
                }
            }

            else if (LeftOrRight == "Left")//left button press
            {
                if (right)//red
                {
                    return false;
                }

                else//blue
                {
                    if (piecePosition == 0)
                        return false;
                    else if (list[piecePosition - 1] == "Blank")
                        return true;

                    else if (list[piecePosition - 2] == "Blank")
                        return true;
                    else
                    {
                        return false;
                    }
                    
                }
            }
            else
            {
                return true;
            }

        }

        private static List<string> MovePieceToPosition (List<string> list, int currentPosition, bool right)
        {
            if (right && list[currentPosition+1] == "Blank")
            {
                list[currentPosition + 1] = list[currentPosition];
                list[currentPosition] = "Blank";
                return list;
            }

            else if (right && list[currentPosition+2] == "Blank")
            {
                list[currentPosition + 2] = list[currentPosition];
                list[currentPosition] = "Blank";
                return list;
            }

            else if (!right && list[currentPosition - 1] == "Blank")
            {
                list[currentPosition - 1] = list[currentPosition];
                list[currentPosition] = "Blank";
                return list;
            }
            else if (!right && list[currentPosition - 2] == "Blank" && !right)
            {
                list[currentPosition - 2] = list[currentPosition];
                list[currentPosition] = "Blank";
                return list;
            }
            else
            {
                return null;
            }

        }

        private static string PiecePositionUpdater (List<string> list, int position)
        {
            if (list[position].Contains("Red"))
            {
                return "Red";
            }
            else if (list[position].Contains("Blue"))
            {
                return "Blue";
            }
            else
            {
                return "Blank";
            }
        }

        private static bool WinCheck (List<string> list)
        {
            List<string> winList = new List<string> { "Blue", "Blue", "Blue", "Blue", "Blue", "Blank", "Red", "Red", "Red", "Red", "Red" };
            if (winList.SequenceEqual(list))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool StalemateCheck (List<string> list)
        {


            for (int i = 0; i < 11; i++)
            {
                if (list[0] == "Blank" && i == 0 && list[1] == "Red" && list[2] == "Red")
                {
                    return true;
                }
                else if (list[10] == "Blank" && i == 10 && list[9] == "Blue" && list[8] == "Blue")
                {
                    return true;
                }
                else if ( i != 0 && list[i]== "Blank" && list[i-1] == "Blue" && list[i+1] == "Red")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region Event Handlers
        private void MoveLeftButton_Click(object sender, EventArgs e)
        {

            if (Position0.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[0].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[0].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[0].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 0, "Left" );
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 0, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position1.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[1].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[1].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[1].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 1, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 1, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position2.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[2].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[2].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[2].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 2, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 2, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position3.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[3].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[3].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[3].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 3, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 3, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position4.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[4].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[4].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[4].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 4, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 4, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position5.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[5].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[5].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[5].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 5, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 5, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position6.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[6].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[6].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[6].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows,rightDirection, 6, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 6, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                           if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }
            else if (Position7.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[7].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[7].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[7].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows,rightDirection, 7, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 7, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                           if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }
            else if (Position8.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[8].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[8].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[8].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 8, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 8, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }
            else if (Position9.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[9].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[9].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[9].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 9, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 9, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }
            else if (Position10.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[10].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[10].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[10].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 10, "Left");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 10, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }

            if (WinCheck(ListOfArrows))
            {
                Label.Text = "Winner!";
            }
        }

        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            if (Position0.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[0].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[0].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[0].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 0, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 0, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position1.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[1].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[1].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[1].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 1, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 1, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position2.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[2].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[2].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[2].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 2, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 2, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position3.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[3].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[3].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[3].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 3, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 3, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position4.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[4].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[4].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[4].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 4, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 4, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position5.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[5].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[5].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[5].Contains("Blue"))
                {
                    rightDirection = false;
                }

                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 5, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 5, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");

                }
            }
            else if (Position6.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[6].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[6].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[6].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 6, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 6, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }
            else if (Position7.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[7].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[7].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[7].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 7, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 7, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }
            else if (Position8.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[8].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[8].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[8].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 8, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 8, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }
            else if (Position9.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[9].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[9].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[9].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 9, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 9, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }
            else if (Position10.Checked)
            {
                bool rightDirection = true;
                if (ListOfArrows[10].Contains("Blank"))
                {
                    rightDirection = false;
                }
                else if (ListOfArrows[10].Contains("Red"))
                {
                    rightDirection = true;
                }
                else if (ListOfArrows[10].Contains("Blue"))
                {
                    rightDirection = false;
                }
                bool CanMove = CanPieceMove(ListOfArrows, rightDirection, 10, "Right");
                if (CanMove)
                {
                    ListOfArrows = MovePieceToPosition(ListOfArrows, 10, rightDirection);
                    for (int i = 0; i < 11; i++)
                    {
                        string PieceColour = PiecePositionUpdater(ListOfArrows, i);
                        #region GIANT LOOP CHECK
                        if (i == 0)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox0.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox0.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 1)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox1.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                            }
                        }
                        else if (i == 2)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox2.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 3)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox3.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 4)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox4.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 5)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox5.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 6)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox6.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 7)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox7.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 8)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox8.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 9)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox9.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        else if (i == 10)
                        {
                            if (PieceColour == "Red")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.RedArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blue")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.BlueArrow;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else if (PieceColour == "Blank")
                            {
                                pictureBox10.BackgroundImage = TrafficJamPuzzle.Properties.Resources.white;
                                pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        }
                        #endregion

                    }
                    if (WinCheck(ListOfArrows))
                    {
                        Label.Text = "Winner!";
                    }
                }
                else if (!CanMove)
                {
                    MessageBox.Show("Please enter a valid move");
                }
            }

            if (WinCheck(ListOfArrows))
            {
                Label.Text = "Winner!";
            }
        }

        #endregion
    }
}
