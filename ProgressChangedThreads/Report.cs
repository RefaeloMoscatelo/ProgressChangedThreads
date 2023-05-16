using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressChangedThreads
{
   public class Report
    {
       public event ProgressChangedEventHandler ProgressChanged;
       public bool IsCancelRequested;
       private void OnProgressChanged(int percent)
       {
           if (ProgressChanged!=null)
           {
               ProgressChanged(this, new ProgressChangedEventArgs(percent, null));
           }

       }

       public void DoWork()
       {
           
           for (int i = 0; i < 100; i++)
           {
               if (IsCancelRequested)
               {
                   break;
               }
               Thread.Sleep(800);
               OnProgressChanged(i);
           }

       }

       public void DoWorkAsync()
       {
           Thread t = new Thread(DoWork);
           t.IsBackground = true;
           t.Start();
       }

       public void Cancel()
       {
           IsCancelRequested = true;


       }

    }
}
