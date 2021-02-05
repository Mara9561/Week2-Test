using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskUtente.Entities;

namespace TaskUtente.GestioneFile
{
    public class FileManagement
    {
        //procedura per recuperare il path
        public static string path { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test_Week2/FileTask.txt");

        public static string header { get; set; } 

        //metodo per salvare i task presenti nel file
        public static Task[] InsertedTasks()
        {
            if (!File.Exists(path))
            {
                Task[] taskInseriti = new Task[0];
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Descriione,DataScadenza,LivelloImportanza");
                    
                }

                return taskInseriti;
            }
            else
            {
                string line;
                int numeroRigheFile = File.ReadLines(path).Count();
                Task[] taskInseriti = new Task[numeroRigheFile - 1];

                using (StreamReader reader = File.OpenText(path))
                {
                    header = reader.ReadLine();
                    for (int i = 0; i < numeroRigheFile - 1; i++)
                    {
                        line = reader.ReadLine();
                        string[] singoloTask = line.Split(",");

                        Task newTask = new Task
                        {
                            Descrizione = singoloTask[0],
                            DataScadenza = Convert.ToDateTime(singoloTask[1]),
                            LivelloImportanza = singoloTask[2]
                        };

                        taskInseriti[i] = newTask;
                    }
                }

                return taskInseriti;
            }
        }

        public static void AddTaskToFile(Task[] tasksDaInserire)
        {
            using(StreamWriter writer = File.CreateText(path)) 
            {
                //writer.WriteLine(header);
                writer.WriteLine("Descriione,DataScadenza,LivelloImportanza");
                for (int i = 0; i < tasksDaInserire.Length; i++)
                    writer.WriteLine(tasksDaInserire[i].Descrizione + "," + tasksDaInserire[i].DataScadenza.Date + "," + tasksDaInserire[i].LivelloImportanza);
            }
        }

    }
}
