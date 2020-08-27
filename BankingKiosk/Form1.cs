using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingKiosk
{
    public partial class Form1 : Form
    {
        BankAccount _account;
        public Form1(BankAccount account)
        {
           
            _account = account;
            InitializeComponent();
            UpdateUi();
        }

        private void UpdateUi()
        {
            this.Text = _account.GetBalance().ToString("c");
        }
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);
        }

        public void DoTransaction(Action<decimal> op)
        {
            if(decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                try
                {
                    op(amount);
                    UpdateUi();
                   
                }
                catch (OverdraftException)
                {
                    MessageBox.Show("You don't have enough money!");
                }
                catch (ImproperTransactionException)
                {
                    MessageBox.Show("Don't try to hack me, bro.");
                    
                } 
                finally
                {
                    txtAmount.SelectAll();
                    txtAmount.Focus();
                }
               
            } else
            {
                MessageBox.Show("Enter in a number, fool.");
                txtAmount.SelectAll();
                txtAmount.Focus();

            }
        }

       
    }

    public class WindowsFormsFedNotifier : INotifyTheFeds
    {
        void INotifyTheFeds.NotifyOfDeposit(decimal amountToDeposit)
        {
            MessageBox.Show("Notification", $"Notifying the fed of a deposit {amountToDeposit:c}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
