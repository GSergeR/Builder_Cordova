using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace AppForBuildCordova
{
    class CommandControl
    {
        private Process process;
        private TaskCompletionSource<bool> eventHandled;
        //private EventHandler doneEvent;
        public processedEnd doneEvent;
        //private AppInfo currentInfo;
        private App app;

        public delegate void processedEnd();

        public void BuildApk(processedEnd callback)
        {
            Debug.WriteLine("start build apk");
            app = Data.instance.GetApp();
            doneEvent = callback;
            //SignApp
            QueryTerminal($"cd {app.project.path} & cordova build android --release", StartSignApp);
        }

        //private void StartSignApp(object sender, System.EventArgs e)
        private void StartSignApp()
        {
            Debug.WriteLine("start start sign app");
            checkOldFile(app.apkName);
            SignApp(doneEvent);
        }

        public void SignApp(processedEnd callback)
        {
            Debug.WriteLine("start sign app");
            //echo folder_path % 1 %
            //echo key_path % 2 %
            //echo key_alias % 3 %
            //echo key_pass % 4 %
            //echo apk_name % 5 %
            string attributes = "" +
                app.project.path + " " +
                app.buyer.key.path + " " +
                app.buyer.key.alias + " " +
                app.buyer.key.password + " " +
                app.apkName;
            Debug.WriteLine("start sign app " + attributes);
            QueryTerminal($"cd c:/WorkSpace/AppForBuildCordova/AppForBuildCordova/Data/ & signerApp.bat {attributes}", callback);
        }

        private async void QueryTerminal(string query, processedEnd end)
        {
            eventHandled = new TaskCompletionSource<bool>();
            using (process = new Process())
            {
                try
                {
                    process.StartInfo.FileName = "cmd";
                    process.StartInfo.Arguments = $@"/C {query}";
                    //process.StartInfo.Arguments = $@"/C cd {appInfo.path} & cordova build android";
                    //myProcess.StartInfo.Verb = "Print";
                    //myProcess.StartInfo.CreateNoWindow = true;

                    //process.EnableRaisingEvents = true;
                    //process.Exited += event_exited;

                    //process.Exited += new EventHandler(Process_Exited);
                    process.Start();

                    //StartProcess();
                    bool wait = true;
                    int iter = 100;
                    do
                    {
                        iter--;
                        wait = !process.WaitForExit(1000);

                        if (!process.HasExited)
                        {
                            Debug.WriteLine("NOT process.HasExited");
                        }
                        else
                        {
                            Debug.WriteLine("process.HasExited");
                            end();
                        }

                    }
                    while (wait && iter > 0);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Ошибка при билде apk файла:\n{ex.Message}");
                    return;
                }

                await Task.WhenAny(eventHandled.Task, Task.Delay(30000));
            }   
        }

        void checkOldFile(string apkName)
        {
            string curFile = @"c:\Unity\Projects\ReleaseAPK\" + apkName + ".apk";
            if (File.Exists(curFile))
            {
                File.Delete(curFile);
                Debug.WriteLine("checkOldFile # File exists and delete");
            }
        }
    }
}
