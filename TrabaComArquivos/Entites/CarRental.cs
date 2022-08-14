using System;
using System.Collections.Generic;
using System.Text;

namespace TrabaComArquivos.Entites
{
    class CarRental
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime start, DateTime finish, vehicle vehicle)
        {
            Start = start;
            Finish = finish;
            Vehicle = vehicle;
            Invoice = null;// ñ é obrigatorio declararo nulo, pq altomaticamente obj associaodo recebe nulo
        }
    }
}
