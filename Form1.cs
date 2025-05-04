using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }

            else if (rbMedium.Checked)
            {
                return Convert.ToSingle(rbMedium.Tag);
            }
            else
            {
                return Convert.ToSingle(rbLarge.Tag);
            }
        }

        float CalculateToppingsPrice()
        {
            float ToppingsPrice = 0;

            if(chkExtraChees.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkExtraChees.Tag);
            }

            if (chkOnion.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkOnion.Tag);
            }

            if (chkMushroom.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkMushroom.Tag);
            }

            if (chkOlives.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkOlives.Tag);
            }

            if (chkTomatoes.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkTomatoes.Tag);
            }

            if (chkGreenPeppers.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }

            return ToppingsPrice;
        }

        float GetSelectedCrustPrice()
        {
            if (rbThin.Checked)
            {
                return Convert.ToSingle(rbThin.Tag);
            }
            else
            {
                return Convert.ToSingle(rbThick.Tag);
            }
        }

        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalculateToppingsPrice() + GetSelectedCrustPrice();
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }

            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }

        }

        void UpdateCrust()
        {
            UpdateTotalPrice();

            if (rbThin.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }

            if (rbThick.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            }

        }

        void UpdateToppings()
        {
            UpdateTotalPrice();

            string sToppings = "";

            if (chkExtraChees.Checked)
            {
                sToppings += "Extra Chees";
            }

            if (chkOnion.Checked)
            {
                sToppings += ", Onion";
            }

            if (chkMushroom.Checked)
            {
                sToppings += ", Mushroom";
            }

            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }

            if (chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }

            if (chkGreenPeppers.Checked)
            {
                sToppings += ", Green Peppers";
            }

            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();
            }

            if(sToppings == "")
            {
                sToppings = "No Toppings";
            }

            lblToppings.Text = sToppings;

        }

        void UpdateOrderInfo()
        {
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateSize();

        }

        void UpdateWhereToEat()
        {
            UpdateTotalPrice();

            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }

            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out";
                return;
            }

        }



        void ResetForm()
        {
            
            btnOrderPizza.Enabled = true;

            gbCrustType.Enabled = true;
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;

            rbSmall.Checked = true;
            rbThin.Checked = true;
            rbEatIn.Checked = true;

            chkExtraChees.Checked = false;
            chkOnion.Checked = false;
            chkMushroom.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkGreenPeppers.Checked = false;

        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Confirm Order", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                btnOrderPizza.Enabled = false;
                gbCrustType.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
            }

        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderInfo();
        }
    }
}
