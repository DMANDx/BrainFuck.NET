using Microsoft.VisualBasic;

namespace BrainFEmulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length > 0)
                Brainfuck(textBox2.Text.Trim());
        }

        private void Console(string T)
        {
            textBox1.Text += T;
        }

        private void Brainfuck(string Code)
        {
            int[] Mem = new int[1];

            int J; int F; int N = 0;
            J = Code.Length - 1;
            for (var I = 0; I <= J; I++)
            {
                switch (Code.Substring(I, 1))
                {
                    case ">":
                        {
                            N++;
                            if (N > Mem.GetUpperBound(0))
                                Array.Resize(ref Mem, Mem.Length + 1);                            
                            break;
                        }
                    case "<":
                        {
                            N--;
                            if (N < 0)
                            {
                                Console(Environment.NewLine + "”казатель вне диапазона!" + Environment.NewLine + "“екуща€ позици€ символа: " + I + 1);
                                return;
                            }
                            break;
                        }
                    case "+":
                        {
                            Mem[N] = Mem[N] + 1;
                            break;
                        }
                    case "-":
                        {
                            Mem[N] = Mem[N] - 1;
                            break;
                        }
                    case ".":
                        {
                            Console(Char.ConvertFromUtf32(Mem[N]).ToString());
                            this.Text += Char.ConvertFromUtf32(123).ToString();
                            break;
                        }
                    case ",":
                        {
                            Mem[N] = (int)Conversion.Val(Interaction.InputBox("¬ведите значение €чейки [" + N + "] (0-255)", "Brainfuck"));
                            break;
                        }
                    case "[":
                        {
                            if (Mem[N] == 0)
                            {
                                F = 1;
                                while (F > 0)
                                {
                                    I++;
                                    if (Code.Substring(I, 1) == "[")
                                        F++;
                                    if (Code.Substring(I, 1) == "]")
                                        F--;
                                }
                            }
                            break;
                        }
                    case "]":
                        {
                            if (Mem[N] > 0)
                            {
                                F = -1;
                                while (F != 0)
                                {
                                    I--;
                                    if (Code.Substring(I, 1) == "[")
                                        F++;
                                    if (Code.Substring(I, 1) == "]")
                                        F--;
                                }
                                I--;
                            }
                            break;
                        }
                }
            }
            Console(Environment.NewLine + Environment.NewLine + "»спользовано €чеек пам€ти: " + Mem.Length);
            Console(Environment.NewLine + "OK.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}