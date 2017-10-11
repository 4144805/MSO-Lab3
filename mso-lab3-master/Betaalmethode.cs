using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public interface IBetaal
    {
        void Connect();
        void Disconnect();
        int BeginTransaction(float amount);
        bool EndTransaction(int id);
        void CancelTransaction(int id);
    }

    // Mock CreditCard implementation
    public class CreditCard : IBetaal
    {
        public void Connect()
        {
            MessageBox.Show("Verbinden met creditcardlezer");
        }

        public void Disconnect()
        {
            MessageBox.Show("Verbinding met creditcardlezer verbreken");
        }

        public int BeginTransaction(float amount)
        {
            MessageBox.Show("Betaal nu " + amount + " EUR");
            return 1;
        }

        public bool EndTransaction(int id)
        {
            if (id != 1)
                return false;

            MessageBox.Show("Beëindig transactie 1");
            return true;
        }

        public void CancelTransaction(int id)
        {
            if (id != 1)
                throw new Exception("Verkeerde transactie id (maar we weten niet wat het nut daar van is)");

            MessageBox.Show("Annuleer transactie nummer 1");
        }
    }

    // Mock CreditCard implementation
    public class DebitCard : IBetaal
    {
        public void Connect()
        {
            MessageBox.Show("Verbinden met pinpaslezer");
        }

        public void Disconnect()
        {
            MessageBox.Show("Verbinding met pinpaslezer verbreken");
        }

        public int BeginTransaction(float amount)
        {
            MessageBox.Show("Betaal nu " + amount + " EUR");
            return 1;
        }

        public bool EndTransaction(int id)
        {
            if (id != 1)
                return false;

            MessageBox.Show("Beëindig transactie 1");
            return true;
        }

        public void CancelTransaction(int id)
        {
            if (id != 1)
                throw new Exception("Verkeerde transactie id (maar we weten niet wat het nut daar van is)");

            MessageBox.Show("Annuleer transactie nummer 1");
        }
    }

    // Mock Cash implementation
    public class CashBetaal : IBetaal
    {
        public void Connect()
        {
            MessageBox.Show("Welkom");
        }

        public void Disconnect()
        {
            MessageBox.Show("Afsluiten");
        }

        public int BeginTransaction(float amount)
        {
            MessageBox.Show("Betaal nu gelijk fucking " + amount + " EUR");
            return 1;
        }

        public bool EndTransaction(int id)
        {
            MessageBox.Show("Doei");
            return true;
        }

        public void CancelTransaction(int id)
        {
            
        }
    }

    public class Betaalmethode
    {
        BetaalmethodeB kind;//verander deze naam nog
        public Betaalmethode(UIPayment betaling)
        {
            if (betaling == UIPayment.Cash)
            {
                kind = new CashBetaling(betaling);
            }
            else
            {
                kind = new KaartBetaling(betaling);
            }
        }
    }

    public class BetaalmethodeB
    {
        public BetaalmethodeB(UIPayment betaling) 
        {

        }
    }

    public class KaartBetaling : BetaalmethodeB
    {
        UIPayment betaling;

        public KaartBetaling(UIPayment betaling) : base(betaling)
        {
            this.betaling = betaling;
        }

        public void Connect()
        {
            MessageBox.Show("Aan het verbinden met " + betaling + "-lezer");
        }

        public void Disconnect()
        {
            MessageBox.Show("Disconnecting from " + betaling + "-lezer");
        }

        public int BeginTransaction(float prijs)
        {
            MessageBox.Show("Begin transaction 1 of " + prijs + " EUR");
            return 1;
        }

        public bool EndTransaction(int id)
        {
            if (id != 1)
                return false;

            MessageBox.Show("End transaction 1");
            return true;
        }

        public void CancelTransaction(int id)
        {
            if (id != 1)
                throw new Exception("Incorrect transaction id");

            MessageBox.Show("Cancel transaction 1");
        }
    }

    public class CashBetaling : BetaalmethodeB
    {
        public CashBetaling(UIPayment betaling) : base(betaling)
        {

        }

        public void starta()
        {
            MessageBox.Show("Welkom");
        }

        public void stoppa()
        {
            MessageBox.Show("Tot ziens!");
        }

        public void betala(int prijs)
        {
            MessageBox.Show("€" + prijs);
        }
    }
}
