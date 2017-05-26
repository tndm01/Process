using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessMonitorSample
{
    public class GetProcessFromWin
    {
        public List<ObjectProcess> Process()
        {
            List<ObjectProcess> abc = new List<ObjectProcess>();
            try
            {
                //Process CurrentProcess = System.Diagnostics.Process.GetCurrentProcess();
                //ProcessThreadCollection threadList = CurrentProcess.Threads;
                Process[] processArray = System.Diagnostics.Process.GetProcesses();
                foreach (var item in processArray)
                {
                    if (item.ProcessName.Contains("ITD"))
                    {
                        ObjectProcess oProcess = new ObjectProcess();
                        oProcess.Id = item.Id.ToString();
                        oProcess.Name = item.ProcessName;
                        oProcess.CPU = TinhCPU(item.ProcessName).ToString();
                        oProcess.Ram = (item.PrivateMemorySize64 / (int)1048576).ToString();
                        oProcess.Des = item.MainModule.FileVersionInfo.FileName;
                        if (item.Responding)
                        {
                            oProcess.Status = "Running";
                        }
                        else
                        {
                            oProcess.Status = "Not Responding";
                        }
                        abc.Add(oProcess);
                    }
                    //ObjectProcess oProcess = new ObjectProcess();
                    //oProcess.Id = item.Id.ToString();
                    //oProcess.Name = item.ProcessName;
                    //oProcess.CPU = TinhCPU(item.ProcessName).ToString();
                    //oProcess.Ram = (item.PrivateMemorySize64 / (int)1048576).ToString();
                    ////oProcess.Des = item.MainModule.FileVersionInfo.FileName;
                    //oProcess.Des = item.SessionId.ToString();
                    //if (item.Responding)
                    //{
                    //    oProcess.Status = "Running";
                    //}
                    //else
                    //{
                    //    oProcess.Status = "Not Responding";
                    //}
                    //abc.Add(oProcess);
                }
                return abc;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return abc;
        }
        public float TinhCPU(string name)
        {
            try
            {
                PerformanceCounter total_cpu = new PerformanceCounter("Process", "% Processor Time", "_Total");
                PerformanceCounter process_cpu = new PerformanceCounter("Process", "% Processor Time", name);
                float t = total_cpu.NextValue();
                float p = process_cpu.NextValue();
                if (p == 0.0)
                    return 0;
                //Console.WriteLine(String.Format("_Total = {0}  App = {1} {2}%\n", t, p, p / t * 100));
                //System.Threading.Thread.Sleep(1000);
                return (p / t) * 100;
                
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return 0;
        }
        private static void RunTest(string appName)
        {
            bool done = false;
            PerformanceCounter total_cpu = new PerformanceCounter("Process", "% Processor Time", "_Total");
            PerformanceCounter process_cpu = new PerformanceCounter("Process", "% Processor Time", appName);
            while (!done)
            {
                float t = total_cpu.NextValue();
                float p = process_cpu.NextValue();
                Console.WriteLine(String.Format("_Total = {0}  App = {1} {2}%\n", t, p, p / t * 100));
                //System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
