namespace rfc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int estado;
        int[,] estados = {
            { 0,'A', 1},
            { 1,'A', 2},
            { 2,'A', 3},
            { 3,'A', 4},
            { 3,'9', 5},
            { 4,'9', 5},
            { 5,'9', 6},
            { 6,'9', 7},
            { 7,'9', 8},
            { 8,'9', 9},
            { 9,'9',10},
            {10,'X',11},
            {11,'X',12},
            {12,'X',13} };

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ValidarCampo(textBox1.Text))
            {
                label1.Text = "El formato es incorrecto!";
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.Text = "El formato es correcto...";
                label1.ForeColor = Color.Blue;
            }
        }

        private bool ValidarCampo(string campo)
        {
            int i = 0, c = 0;
            char[] arr = campo.ToCharArray();
            estado = 0;
            for (c = 0; c < campo.Length; c++)
            {
                for (i = 0; i < estados.GetLength(0); i++)
                {
                    if (estados[i, 0] == estado &&
                        estados[i, 1] == 'A' &&
                        Char.IsLetter(arr[c]))
                    {
                        estado = estados[i, 2];
                        break;
                    }
                    else if (estados[i, 0] == estado &&
                             estados[i, 1] == '9' &&
                             Char.IsDigit(arr[c]))
                    {
                        estado = estados[i, 2];
                        break;
                    }
                    else if (estados[i, 0] == estado &&
                             estados[i, 1] == 'X' &&
                             Char.IsLetterOrDigit(arr[c]))
                    {
                        estado = estados[i, 2];
                        break;
                    }
                }
                if (i == estados.GetLength(0)) return true;
                if (estado == 3) radioButton1.Checked = true;
                if (estado == 4) radioButton2.Checked = true;
            }
            return false;
        }
    }
}
