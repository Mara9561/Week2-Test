using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaskUtente.Entities
{
    public class Task
    {
        public string Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
        public string LivelloImportanza { get; set; }

    }
}
