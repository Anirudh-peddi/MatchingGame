using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oct15matchinggame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null, secondClicked = null;

        Random random = new Random();
        //List
        List<string> icons = new List<string>()
        {

            "!","!","N","N",",",",","k","k",
            "b","b","v","v","w","w","z","z"

        };



        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        //assigning the 16 icons [from webdings font] to the squares [labels]
        // on the table-layout container
        private void AssignIconsToSquares()
        {
            //assigning the symbols to the cells randomly.
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                Label cell = ctrl as Label;

                if (cell != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    // assing the text to the label
                    cell.Text = icons[randomNumber];
                    //set the foreground color of the label same as the
                    //background color.
                    cell.ForeColor = cell.BackColor;


                    //remove that string/icon from the list
                    icons.RemoveAt(randomNumber);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //stop the timer
            timer1.Stop();

            //make both firstClick and secondClick label contents invisible
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            //reset the first and second click lavels.
            firstClicked = null;
            secondClicked = null;
        }







        //Once user clicks on the cell/label
        //change the fore-color of the label to black
        // so that the icon gets visible.
        //if its already visible then don't change it


        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            //if timer is already running/enabled then dont do anything.
            //just return
            if (timer1.Enabled == true)
                return; 



            //if secondClicked is not null,then return
            if (secondClicked != null)
                return;

            Label ClickedLabel = sender as Label;
            if (ClickedLabel != null)
            {
                if (ClickedLabel.ForeColor == Color.Black)
                    return;
            }

            if (firstClicked == null)
            {
                firstClicked = ClickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            //if its user's second click 
            secondClicked = ClickedLabel;
            secondClicked.ForeColor = Color.Black;
            CheckForWinner();


            //if the icons of both the cell/label are same 
            //means user has found a matching pair
            //so keep them visible and continue the game
            if(firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }


            // user has clicked on two different icons 
            // so start the timer.
            timer1.Start();

        }

        private void CheckForWinner()
        {
            //make sure if the forecolor of all the labels is equal to black
            //then user has finished the game
            //so pop up a message

            foreach(Control ctrl in tableLayoutPanel1.Controls)
            {
                Label cell = ctrl as Label;
                if (cell != null)
                {


                    if (cell.ForeColor != Color.Black)
                    {
                        return;
                    }
                }
               
            }
            MessageBox.Show("Your have finished the game","Congragulations");
        }


    }



 

    
    

}
