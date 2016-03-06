using System;
using System.Windows.Forms;
using System.Linq;

namespace Pocitadlo_landu
{
    public partial class d : Form
    {
        double KartyTed;
        double LandyTed;

        string nadavka = "Něco si asi posral";

        public d()
        {
            InitializeComponent();
        }

        //------------------------------ KEEPENS? ---------------------------------------
        private void VypocitatButton_Click(object sender, EventArgs e)
        {
            double[] pole = new double[6];

            KartyTed = (double)PocetKaretVBaliku.Value - (double)PocetKaretVRuce.Value;
            LandyTed = (double)PocetLanduVBaliku.Value - (double)PocetLanduVRuce.Value;

            if (KartyTed < 1)
            {
                MessageBox.Show(nadavka);
                return;
            }

            for (int nKolo = 0; nKolo < 6; nKolo++)
            {

                if (nKolo == 0)
                {
                    pole[nKolo] = 1 - (LandyTed / (KartyTed - nKolo));
                    continue;
                }

                pole[nKolo] = (1 - (LandyTed / (KartyTed - nKolo))) * pole[nKolo - 1];
            }

            if (Scry.Checked == true)
            {
                vysledek1.Text = FormatPravedpodobnsotFromDouble(pole[1]);
                vysledek2.Text = FormatPravedpodobnsotFromDouble(pole[2]);
                vysledek3.Text = FormatPravedpodobnsotFromDouble(pole[3]);
                vysledek4.Text = FormatPravedpodobnsotFromDouble(pole[4]);
                vysledek5.Text = FormatPravedpodobnsotFromDouble(pole[5]);
            }
            else
            {
                vysledek1.Text = FormatPravedpodobnsotFromDouble(pole[0]);
                vysledek2.Text = FormatPravedpodobnsotFromDouble(pole[1]);
                vysledek3.Text = FormatPravedpodobnsotFromDouble(pole[2]);
                vysledek4.Text = FormatPravedpodobnsotFromDouble(pole[3]);
                vysledek5.Text = FormatPravedpodobnsotFromDouble(pole[4]);

            }

            return;
        }
        
        private string FormatPravedpodobnsotFromDouble(double pst)
        {
            return ((1 - pst) * 100).ToString() + "%";
        }

        //------------------------------ STACK RESOLVER ---------------------------------------
        private string[] Stack = new string[0];
        private int stackSize = 0;
        private int numberOfTriggers = 0;

        private void ResolveAbility()
        {
            // to implement
        }

        private void PutNewTriggerOnStack(string newTrigger)
        {
            // to implement
        }

        private void ResolveAllOnStack()
        {
            // to implement
        }
        
        // ------------------ Eventy UI prvku - pro Sebka: zatim ignorovat a nehrabat :D ---------------------
        // Resolve
        private void PopStackButton_Click(object sender, EventArgs e)
        {
            ResolveAbility();

            UpdateListViewCollection();
        }

        // Trigger
        private void PushToStackButton_Click(object sender, EventArgs e)
        {
            var efect = EfectTextBox.Text;

            PutNewTriggerOnStack(efect);

            UpdateListViewCollection();
        }

        private void ResolveAllButton_Click(object sender, EventArgs e)
        {
            ResolveAllOnStack();

            UpdateListViewCollection();
        }

        private void UpdateListViewCollection()
        {
            StackListView.Items.Clear();

            for (int i = 0; i < stackSize; i++)
            {
                var lvi = new ListViewItem(i.ToString());
                
                lvi.SubItems.Add(Stack[i]);
                
                StackListView.Items.Add(lvi);
            }
        }
    }
}
