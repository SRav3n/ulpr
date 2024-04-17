using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace _11_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Note
        {
            public string FullName { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime DateOfBirth { get; set; }

            public override string ToString()
            {
                return $"{FullName}; {PhoneNumber}; {DateOfBirth.ToShortDateString()}";
            }
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        List<Note> notes = new List<Note>();
        private void button2_Click(object sender, EventArgs e)
        {
                Random random = new Random();

                List<string> firstNames = new List<string> { "Пётр", "Олег", "Александр", "Данил", "Алексей", "Фёдор", "Емельян", "Георгий", "Иван", "Кирилл" };
                List<string> lastNames = new List<string> { "Самойлов", "Михайлов", "Кемеров", "Борискин", "Ваянт", "Давыдов", "Харченко", "Топский", "Кузнецов", "Медведев" };

                for (int i = 0; i < 10; i++)
                {
                    Note note = new Note
                    {
                        FullName = $"{firstNames[random.Next(firstNames.Count)]} {lastNames[random.Next(lastNames.Count)]}",
                        PhoneNumber = random.Next(800000000, 899999999).ToString(),
                        DateOfBirth = DateTime.Today.AddYears(-random.Next(18, 60))
                    };
                    notes.Add(note);
                }

            using (StreamWriter writer = new StreamWriter("spisok.txt"))
            {
                foreach (var note in notes)
                {
                    writer.WriteLine($"{note.FullName},{note.PhoneNumber},{note.DateOfBirth.ToShortDateString()}");
                }
            }
            foreach (var note in notes)
            {
                listBox1.Items.Add(note);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            notes = notes.OrderBy(x => x.PhoneNumber.Substring(0, 2)).ToList();

            foreach (var note in notes)
            {
                listBox2.Items.Add($"{note.FullName} - {note.PhoneNumber} - {note.DateOfBirth.ToShortDateString()}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchLastName = textBox1.Text;
            var results = notes.Where(x => x.FullName.IndexOf(searchLastName, 0, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            if (results.Any())
            {
                foreach (var result in results)
                {
                    MessageBox.Show($"Оп, нашелся! {result.FullName} - {result.PhoneNumber} - {result.DateOfBirth.ToShortDateString()}");
                }
            }
            else
            {
                MessageBox.Show("Етих людей нет.");
            }
        }
    }
}
