using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvoSetup_V_1._0
{
    public partial class EVENTOS : Form
    {
        public EVENTOS()
        {
          
            InitializeComponent();
            IniciarEventos();

        }

        void IniciarEventos()
        {
            Button button = new Button();
            button.Image =Properties.Resources.cocktail2;
            button.ImageAlign = ContentAlignment.BottomCenter;
            button.Location = new Point(650, 12);
            button.Name = "buttonmodify";
            button.Size = new Size(121, 65);
            button.TabIndex = 0;
            button.Text = "boton modificado";
            button.UseVisualStyleBackColor = true;

            button.Anchor = AnchorStyles.Top;
            button.Anchor = AnchorStyles.Right;
            Controls.Add(button);
            accionar(button);
        }

        void accionar(object sender)
        {
          var name =  ((Button)sender).Name.ToString();
            ((Button)sender).Click += EVENTOS_Click;
        }

        private void EVENTOS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todo bien por aqui");
        }
    }
}
