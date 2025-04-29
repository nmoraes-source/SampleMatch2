using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SampleMatch
{
    public class SubtextMatcher : Form
    {
        private TextBox textBox;
        private TextBox subtextBox;
        private Button matchButton;
        private TextBox outputBox;

        public SubtextMatcher()
        {
            Label textLabel = new Label
            {
                Text = "Text:",
                AutoSize = true,
                Location = new System.Drawing.Point(10, 10)
            };
            this.Controls.Add(textLabel);

            textBox = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Location = new System.Drawing.Point(10, 30),
                Size = new System.Drawing.Size(400, 150)
            };
            this.Controls.Add(textBox);

            Label subtextLabel = new Label
            {
                Text = "Subtext:",
                AutoSize = true,
                Location = new System.Drawing.Point(10, 190)
            };
            this.Controls.Add(subtextLabel);

            subtextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 210),
                Size = new System.Drawing.Size(400, 20)
            };
            this.Controls.Add(subtextBox);

            matchButton = new Button
            {
                Text = "Match",
                Location = new System.Drawing.Point(10, 240),
                Size = new System.Drawing.Size(75, 23)
            };
            matchButton.Click += new EventHandler(MatchButton_Click);
            this.Controls.Add(matchButton);

            Label outputLabel = new Label
            {
                Text = "Match positions:",
                AutoSize = true,
                Location = new System.Drawing.Point(10, 270)
            };
            this.Controls.Add(outputLabel);

            outputBox = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Location = new System.Drawing.Point(10, 290),
                Size = new System.Drawing.Size(400, 100)
            };
            this.Controls.Add(outputBox);

            this.Text = "Subtext Matcher";
            this.Size = new System.Drawing.Size(430, 450);
        }

        private void MatchButton_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            string subtext = subtextBox.Text;

            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext))
            {
                MessageBox.Show("Both text and subtext are required.");
                return;
            }

            int matchIndex = 0;
            string output = "";
            while (matchIndex < text.Length)
            {
                matchIndex = text.IndexOf(subtext, matchIndex, StringComparison.OrdinalIgnoreCase);
                if (matchIndex != -1)
                {
                    output += matchIndex.ToString() + Environment.NewLine;
                    matchIndex += 1;
                }
                else
                {
                    break;
                }
            }

            if (string.IsNullOrEmpty(output))
            {
                outputBox.Text = "No matches found.";
            }
            else
            {
                outputBox.Text = output;
            }
        }

    }

}

