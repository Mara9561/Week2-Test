using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TaskUtente.Entities;

namespace TaskUtente.GestioneDati
{
    public class DataManagement
    {
        public static void AddTaskToTaskArray(ref Task[] taskInseriti, Task taskDaAggiungere)
        {
            bool taskPresente = false;
            for (int i = 0; i < taskInseriti.Length; i++)
            {
                if ((taskInseriti[i].Descrizione == taskDaAggiungere.Descrizione) && (taskInseriti[i].DataScadenza == taskDaAggiungere.DataScadenza) && (taskInseriti[i].LivelloImportanza == taskDaAggiungere.LivelloImportanza))
                {
                    taskPresente = true;
                }
            }

            DateTime adesso = DateTime.Now;
            if (!taskPresente && taskDaAggiungere.DataScadenza>=adesso)
            {
                Array.Resize(ref taskInseriti, taskInseriti.Length + 1);
                taskInseriti[taskInseriti.Length - 1] = taskDaAggiungere;
            }
        }

        public static Task[] DeleteTaskFromTaskArray(ref Task[] taskInseriti, Task taskDaEliminare)
        {
            ArrayList taskList = new ArrayList();
            foreach (Task taskPresente in taskInseriti)
            {
                if ((taskPresente.Descrizione != taskDaEliminare.Descrizione) || (taskPresente.DataScadenza != taskDaEliminare.DataScadenza) || (taskPresente.LivelloImportanza != taskDaEliminare.LivelloImportanza))
                    taskList.Add(taskPresente);
            }

            taskInseriti = (Task[])taskList.ToArray(typeof(Task));
            return taskInseriti;
        }

        public static Task[] FilterForImportance(Task[] taskInseriti, string importanza)
        {
            ArrayList taskImportanti = new ArrayList();

            foreach(Task tk in taskInseriti)
            {
                if (tk.LivelloImportanza == importanza)
                    taskImportanti.Add(tk);
            }

            return (Task[])taskImportanti.ToArray(typeof(Task));
        }

    }
   
}
