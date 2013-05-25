using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace The_Valar_Quest
{
    
    public partial class Challenge : Form
    {
       public List<Question> easyquestions= new List<Question>();
       public List<Question> mediumquestions = new List<Question>();
       public List<Question> hardquestions = new List<Question>();
       public List<Template> extrahardquestions = new List<Template>();
       int timePassedChallenge = 0;
       int tot_time=20;
       Random r = new Random();
       Question selected;

        public Challenge()
        {
            InitializeComponent();
        }

        public Challenge(type_of_challenge type) {
            InitializeComponent();

            Template t1 = new Template();
            t1.br1 = r.Next(1, 5);
            t1.br2 = r.Next(1, 5);
            t1.question = t1.getQuestion("If you have % male Valar in your group and % female Valar, and each of the male and female Valar \n likes a female and a male Vala correspondingly is it true that that you \n can pick one Vala and by picking someone he or she likes go back to the first \n Vala you picked?(You can pick each person once except the first one)");
            t1.answers.Add("True");
            t1.answers.Add("False");
            t1.answers.Add("Can't tell");
            t1.type = type_of_challenge.EXTRA_HARD;
            if (t1.br1 == t1.br2)
            {
                t1.correct = "True";
            }
            else
            {
                t1.correct = "False";
            }
            extrahardquestions.Add(t1);

            Template t2 = new Template();
            t2.br1 = r.Next(1, 5);
            t2.br2 = r.Next(1, 5);
            t2.question = t2.getQuestion("If you have % male Valar in your group and % female Valar, and each \n of the male and female Valar likes a female and a male Vala correspondingly with how many marks can you mark \n all the Valar in your group so that no two Valar that like each other have the same mark?");
            t2.answers.Add("2");
            t2.answers.Add("3");
            t2.answers.Add("5");
            t2.correct = "2";
            t2.type = type_of_challenge.EXTRA_HARD;

            extrahardquestions.Add(t2);

            Template t3 = new Template();
            t3.br1 = t3.br2 = r.Next(1, 5);
            t3.question = t3.getQuestion("If you have % male Valar in your group and % female Valar, and each \n of the male and female Valar likes a female and a male Vala correspondingly what is the number of \n different ways that you can pick one Vala and by picking someone he or she likes go back to the first Vala you picked? \n (You can pick each person once except the first one)");
            t3.answers.Add("2*" + t3.br1 + "!");
            t3.answers.Add(t3.br1 + "*" + t3.br1 + "!");
            t3.answers.Add(2 * t3.br1 + "!/" + t3.br1 + "!*" + t3.br1 + "!");
            t3.correct = "2*" + t3.br1 + "!";
            t3.type = type_of_challenge.EXTRA_HARD;

            extrahardquestions.Add(t3);

            Question q1 = new Question();
            q1.question = "Every Vala in your group is a friend with all the other Valar in the group. \n If you can pick one of the Valar and by picking his friends you can get back to the same Vala you first picked then: \n (you can pick a person more than once if available but use every connection once)";
            q1.answers.Add("The number of people in the group is an odd number");
            q1.answers.Add("The number of people in the group is an even number");
            q1.answers.Add("More information is needed");
            q1.correct = "The number of people in the group is an odd number";
            q1.type = type_of_challenge.HARD;

            hardquestions.Add(q1);

            Question q2 = new Question();
            q2.question = "If you know that every Vala in your group has helped at least two other Valar, then it \n is true that and you have more than 3 Valar in your group:";
            q2.answers.Add("There exists a Vala that has been supported by a Vala that you have helped");
            q2.answers.Add("There exist a circle of 4 Valar that have helped each other");
            q2.answers.Add("Neither");
            q2.correct = "There exists a Vala that has been supported by a Vala that you have helped";
            q2.type = type_of_challenge.HARD;

            hardquestions.Add(q2);

            Question q3 = new Question();
            q3.question = "If every single Vala is a friend with all the other Valar in the group you \n are leading which of the following is true:";
            q3.answers.Add("More information is needed");
            q3.answers.Add("The sum of all the connections in the group is  the number of Vala times the number of Valar minus 1");
            q3.answers.Add("The number of Valar in the group  plus the number of Valar in the group (your friends)");
            q3.correct = "More information is needed";
            q3.type = type_of_challenge.HARD;

            hardquestions.Add(q3);

            Question q4 = new Question();
            q4.question = "If each one of the female Vala is a friend with one or more male Valar, and \n each one of the male Vala is a friends with one or more female Valar is it false to say that they are all friends?";
            q4.answers.Add("No");
            q4.answers.Add("Yes");
            q4.answers.Add("More information is neeeded");
            q4.correct = "No";
            q4.type = type_of_challenge.HARD;

            hardquestions.Add(q4);

            Question q5 = new Question();
            q5.question = "If your group has 30 Valar, is it true that there must be two Valar that \n have the same number of siblings in the group?";
            q5.answers.Add("It's true");
            q5.answers.Add("It's not true");
            q5.answers.Add("More information is neeeded");
            q5.correct = "It's true";
            q5.type = type_of_challenge.MEDUM_HARD;

            mediumquestions.Add(q5);

            Question q6 = new Question();
            q6.question = "Some of the Valar you are leading is a traitor or  you are safe. Is this sentence \n the same as you are not safe if some of the Valar you are leading is a traitor?";
            q6.answers.Add("It is not the same");
            q6.answers.Add("It's the same");
            q6.answers.Add("There s no way to tell");
            q6.correct = "It is not the same";
            q6.type = type_of_challenge.MEDUM_HARD;

            mediumquestions.Add(q6);

            Question q7 = new Question();
            q7.question = "You see a castle on your way. Entering the castle is the same as:";
            q7.answers.Add("Entering the castle and taking a nap, or entering the castle");
            q7.answers.Add("Entering the castle");
            q7.answers.Add("Neither");
            q7.correct = "Entering the castle and taking a nap, or entering the castle";
            q7.type = type_of_challenge.MEDUM_HARD;

            mediumquestions.Add(q7);

            Question q8 = new Question();
            q8.question = "A mighty spawn of Goliant has crossed your way. Defeating it or both defeating it and burning it means that:";
            q8.answers.Add("You burned it");
            q8.answers.Add("You defeated it");
            q8.answers.Add("Neither");
            q8.correct = "You burned it";
            q8.type = type_of_challenge.MEDUM_HARD;

            mediumquestions.Add(q8);

            Question q9 = new Question();
            q9.question = "You will not make it across the forest or you will reach a beautiful meadow. The negation of this sentence is:";
            q9.answers.Add("You will make it across the forest and you will not reach a beautiful meadow.");
            q9.answers.Add("If you reach a beautiful meadow you will make it across the forest");
            q9.answers.Add("You will make it across the forest or you will not reach a beautiful meadow.");
            q9.correct = "You will make it across the forest and you will not reach a beautiful meadow.";
            q9.type = type_of_challenge.EASY;

            easyquestions.Add(q9);

            Question q10 = new Question();
            q10.question = "If you manage to create a spell to fix the mess that Melcor has made on your way, you will earn the thrust of your people. \n Which one of the following sentences is equivalent with the previous sentence?";
            q10.answers.Add("If you do not manage to create a spell to fix the mess that Melcor has made on your way, you will not earn the thrust of your people.");
            q10.answers.Add("You will manage to create a spell to fix the mess that Melcor has made on your way or you will not earn the thrust of your people.");
            q10.answers.Add("If you manage to create a spell to fix the mess that Melcor has made on your way, you will not earn the thrust of your people.");
            q10.correct = "If you do not manage to create a spell to fix the mess that Melcor has made on your way, you will not earn the thrust of your people.";
            q10.type = type_of_challenge.EASY;

            easyquestions.Add(q10);

            Question q11 = new Question();
            q11.question = "If the Valar succeed to cross the river unseen,  they will avoid the danger lurking on the opposite bank.\n Which one of the following sentences is equivalent with the previous sentence?";
            q11.answers.Add("The Valar will not succed to cross the river unseen or they will avoid the danger lurking on the opposite bank");
            q11.answers.Add("If the Valar avoid the danger lurking on the opposite bank, they will cross the river unseen");
            q11.answers.Add("The Valar will succed to cross the river unseen or they will not avoid the danger lurking on the opposite bank.");
            q11.correct = "The Valar will not succed to cross the river unseen or they will avoid the danger lurking on the opposite bank";
            q11.type = type_of_challenge.EASY;

            easyquestions.Add(q11);

            Question q12 = new Question();
            q12.question = "The Valar are trapped in one of Melcor’s servants’ trap. If you come up with a truthfull \n sentence you will escape with no victims, otherwise one of your people is gonna be killed. What are you gonna say?";
            q12.answers.Add("You are gonna kill one of my people.");
            q12.answers.Add("You are not gonna kill one of my people");
            q12.answers.Add("We are going to escape ");
            q12.correct = "You are gonna kill one of my people.";
            q12.type = type_of_challenge.EASY;

            easyquestions.Add(q12);

            int rand = -1;
            if (type == type_of_challenge.EASY) {
                rand = r.Next(0, easyquestions.Count);
                selected = easyquestions.ElementAt(rand);
                question.Text = selected.question;
                List<int> indices = new List<int>();
                while (indices.Count != 3) {
                    int i = r.Next(0, 3);
                    if(!indices.Contains(i))indices.Add(i);
                }
                radioButton1.Text = selected.answers.ElementAt(indices.ElementAt(0));
                radioButton2.Text = selected.answers.ElementAt(indices.ElementAt(1));
                radioButton3.Text = selected.answers.ElementAt(indices.ElementAt(2));
                tot_time = 30;
            }
            if (type == type_of_challenge.MEDUM_HARD) {
                rand = r.Next(0, mediumquestions.Count);
                selected = mediumquestions.ElementAt(rand);
                question.Text = selected.question;
                List<int> indices = new List<int>();
                while (indices.Count != 3)
                {
                    int i = r.Next(0, 3);
                    if (!indices.Contains(i)) indices.Add(i);
                }
                radioButton1.Text = selected.answers.ElementAt(indices.ElementAt(0));
                radioButton2.Text = selected.answers.ElementAt(indices.ElementAt(1));
                radioButton3.Text = selected.answers.ElementAt(indices.ElementAt(2));
                tot_time = 40;
            }
            if (type == type_of_challenge.HARD) {
                rand = r.Next(0, hardquestions.Count);
                selected = hardquestions.ElementAt(rand);
                question.Text = selected.question;
                List<int> indices = new List<int>();
                while (indices.Count != 3)
                {
                    int i = r.Next(0, 3);
                    if (!indices.Contains(i)) indices.Add(i);
                }
                radioButton1.Text = selected.answers.ElementAt(indices.ElementAt(0));
                radioButton2.Text = selected.answers.ElementAt(indices.ElementAt(1));
                radioButton3.Text = selected.answers.ElementAt(indices.ElementAt(2));
                tot_time = 50;
            }
            if (type == type_of_challenge.EXTRA_HARD) {
                rand = r.Next(0, extrahardquestions.Count);
                selected = extrahardquestions.ElementAt(rand);
                question.Text = selected.question;
                List<int> indices = new List<int>();
                while (indices.Count != 3)
                {
                    int i = r.Next(0, 3);
                    if (!indices.Contains(i)) indices.Add(i);
                }
                radioButton1.Text = selected.answers.ElementAt(indices.ElementAt(0));
                radioButton2.Text = selected.answers.ElementAt(indices.ElementAt(1));
                radioButton3.Text = selected.answers.ElementAt(indices.ElementAt(2));
                tot_time = 60;
            }
            // Select random question of type argument
            // Select random type of question 1-5 za prvite 3, 1-3 za extrahard

            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timePassedChallenge < tot_time)
            {
                timePassedChallenge++;
                available_time.Text = String.Format("{0}:00", tot_time - timePassedChallenge);
                progressBar1.Value = 100*(tot_time - timePassedChallenge)/tot_time;
            }
            else {
                timer1.Stop();
                MessageBox.Show("Time s up!");
                this.DialogResult = DialogResult.No;
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("The correct answer is: "+ selected.correct);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) {
                if (radioButton1.Text == selected.correct)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Correct answer!");
                    timer1.Stop();
                    this.Close();
                }
                else {
                    this.DialogResult = DialogResult.No;
                    MessageBox.Show("Incorrect answer!");
                    timer1.Stop();
                    this.Close();
                }
            }
            if (radioButton2.Checked == true)
            {
                if (radioButton2.Text == selected.correct)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Correct answer!");
                    timer1.Stop();
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    MessageBox.Show("Incorrect answer!");
                    timer1.Stop();
                    this.Close();
                }
            }
            if (radioButton3.Checked == true)
            {
                if (radioButton3.Text == selected.correct)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Correct answer!");
                    timer1.Stop();
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    MessageBox.Show("Incorrect answer!");
                    timer1.Stop();
                    this.Close();
                }
            }
        }

        
    }

    public class Question {
        public type_of_challenge type { get; set; }
        public string question { get; set; }
        public List<string> answers = new List<string>();
        public string correct { get; set; }

    }

    public class Template: Question{
        public int br1 { get; set; }
        public int br2 { get; set; }

        public string getQuestion(string question){

            int pos1 = question.IndexOf("%");
            int pos2 = question.LastIndexOf("%");
            string str = ""; int br = 1;
            for (int i = 0; i < question.Length; i++) {
                char c=(char)question.ElementAt(i);
                if (c == '%')
                {
                    if (br == 1) str += br1.ToString();
                    if (br == 2) str += br2.ToString();
                }
                else {
                    str += c;
                }
                
            }
            return str;
        }
                 
            
    }
}
