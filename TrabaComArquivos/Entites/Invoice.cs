using System;
using System.Globalization;

namespace TrabaComArquivos.Entites
{
    class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment
        {//propriedade calculada
            get { return BasicPayment + Tax; }//get que sera calculado

        }

        public override string ToString(){
            return "Basic payment: "
            + BasicPayment.ToString("F2", CultureInfo.InstalledUICulture)
            +"\nTax: "
            + Tax.ToString("F2", CultureInfo.InstalledUICulture)
            + "\nTotal payment: "
            + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
