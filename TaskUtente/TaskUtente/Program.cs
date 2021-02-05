using System;
using TaskUtente.Entities;
using TaskUtente.GestioneDati;
using TaskUtente.GestioneFile;

namespace TaskUtente
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Salvo i task presenti in un array di Task
            Task[] taskInseriti = FileManagement.InsertedTasks();
            Console.WriteLine("Tasks presenti nel file:");
            foreach (Task tk in taskInseriti)
                Console.WriteLine(tk.Descrizione + " - " + tk.DataScadenza + " - " + tk.LivelloImportanza);
            Console.WriteLine("________________________________________________________________");

            //Faccio inserire all'utente un nuovo task
            string[] daInserire=new string[2];
            DateTime dataScadenza = new DateTime();
            Console.WriteLine("Inserisci un task");
            Console.Write("Inserisci Descrizione: ");
            daInserire[0]=Console.ReadLine();
            Console.Write("Inserisci Data di scadenza: ");
            dataScadenza = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Inserisci Livello di importanza: ");
            daInserire[1] = Console.ReadLine();

            Task taskDaInserire = new Task
            {
                Descrizione = daInserire[0],
                DataScadenza = dataScadenza,
                LivelloImportanza=daInserire[1]
            };

            Console.WriteLine("________________________________________________________________");


            //Aggiungo il task dato dall'utente al file
            DataManagement.AddTaskToTaskArray(ref taskInseriti, taskDaInserire);
            FileManagement.AddTaskToFile(taskInseriti);
            foreach (Task tk in taskInseriti)
                Console.WriteLine(tk.Descrizione + " - " + tk.DataScadenza + " - " + tk.LivelloImportanza);
            Console.WriteLine("________________________________________________________________");

            //Elimino il task dato dall'utente dal file - lo commento ma funziona
            //DataManagement.DeleteTaskFromTaskArray(ref taskInseriti, taskDaInserire);
            //FileManagement.AddTaskToFile(taskInseriti);
            //foreach (Task tk in taskInseriti)
            //    Console.WriteLine(tk.Descrizione + " - " + tk.DataScadenza + " - " + tk.LivelloImportanza);
            //Console.WriteLine("________________________________________________________________");

            //Mi faccioo stampare i task con la stessa importanza
            Task[] taskImportanti=DataManagement.FilterForImportance(taskInseriti,"Medio");
            foreach (Task tk in taskImportanti)
                Console.WriteLine(tk.Descrizione + " - " + tk.DataScadenza + " - " + tk.LivelloImportanza);
            Console.WriteLine("________________________________________________________________");

        }
    }
}
