using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public interface IBetaalmiddel
    {
        void Connect();
        void Disconnect();
        int BeginTransaction(float amount);
        bool EndTransaction(int id);
        void CancelTransaction(int id);
    }

    // Mock CreditCard implementation
    public class CreditCard : IBetaalmiddel
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
    public class DebitCard : IBetaalmiddel
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
    public class Cash : IBetaalmiddel
    {
        IKEAMyntAtare2000 muntmachine = new IKEAMyntAtare2000();
        public void Connect()
        {
            muntmachine.starta();
        }

        public void Disconnect()
        {
            muntmachine.stoppa();
        }

        public int BeginTransaction(float amount)
        {
            int centen = (int)Math.Floor(amount * 100);
            muntmachine.betala(centen);
            return 1;
        }

        public bool EndTransaction(int id)
        {
            muntmachine.stoppa();
            return true;
        }

        public void CancelTransaction(int id)
        {
            muntmachine.stoppa();
        }
    }
}