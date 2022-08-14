using System;
using System.Collections.Generic;
using System.Text;

namespace TrabaComArquivos.Services
{
    class BrazilTaxService : ITaxService{
        public double Tax(double amount){
            if(amount <= 100.0){
                return amount * 0.02;
            }
            else
            {
                return amount * 0.15;
            }
        }


    }
}
