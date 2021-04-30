using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Launcher
{

    public static class Program
    {
        public class Launcher
        {
            public bool ErrorDialog;
            public string WorkingDirectory;
            public string FileName;
            public bool LoadUserProfile;
            public string Domain;
            public string PasswordInClearText;
            public System.Security.SecureString Password;
            public string UserName;
            public bool UseShellExecute;
            public System.Text.Encoding StandardOutputEncoding;
            public System.Text.Encoding StandardErrorEncoding;
            public bool RedirectStandardError;
            public bool RedirectStandardOutput;
            public bool RedirectStandardInput;
            public bool CreateNoWindow;
            public string Arguments;
            public string Verb;
            // public IntPtr ErrorDialogParentHandle;
            public ProcessWindowStyle WindowStyle;

        }
        private static void Main()
        {
            try
            {
                /* 
                // First write something so that there is something to read ...  
                var b = new Launcher();
                var a = new ProcessStartInfo();
                b.Arguments=a.Arguments;
                b.CreateNoWindow =a.CreateNoWindow;
                b.Domain=a.Domain;
                b.ErrorDialog=a.ErrorDialog;
                b.FileName=a.FileName;
                b.LoadUserProfile=a.LoadUserProfile;
                b.Password=a.Password;
                b.PasswordInClearText = a.PasswordInClearText;
                b.RedirectStandardError=a.RedirectStandardError;
                b.RedirectStandardInput=a.RedirectStandardInput;
                b.RedirectStandardOutput=a.RedirectStandardOutput;
                b.StandardErrorEncoding=a.StandardErrorEncoding;
                b.StandardOutputEncoding=a.StandardErrorEncoding;
                b.UserName=a.UserName;
                b.UseShellExecute=a.UseShellExecute;
                b.Verb=a.Verb;
                b.WindowStyle=a.WindowStyle;
                b.WorkingDirectory=a.WorkingDirectory;
                var writer = new System.Xml.Serialization.XmlSerializer(typeof(Launcher));
                var wfile = new System.IO.StreamWriter("Default.xml");
                writer.Serialize(wfile, b);
                wfile.Close(); 
                 */

                // Now we can read the serialized obj ...  
                var file = new System.IO.StreamReader(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + AppDomain.CurrentDomain.SetupInformation.ApplicationName.Substring(0, AppDomain.CurrentDomain.SetupInformation.ApplicationName.Length - 3) + "xml");
                Launcher mypsi = (Launcher)new System.Xml.Serialization.XmlSerializer(typeof(Launcher)).Deserialize(file);
                file.Close();


                var psi = new ProcessStartInfo();
                Environment.SetEnvironmentVariable("LauncherDir", AppDomain.CurrentDomain.SetupInformation.ApplicationBase.Substring(0,AppDomain.CurrentDomain.SetupInformation.ApplicationBase.Length - 1));
                psi.Arguments = mypsi.Arguments == null ? null : Environment.ExpandEnvironmentVariables(mypsi.Arguments);
                psi.CreateNoWindow = mypsi.CreateNoWindow;
                psi.Domain = mypsi.Domain == null ? null : Environment.ExpandEnvironmentVariables(mypsi.Domain);
                psi.ErrorDialog = mypsi.ErrorDialog;
                psi.FileName = mypsi.FileName == null ? null : Environment.ExpandEnvironmentVariables(mypsi.FileName);
                psi.LoadUserProfile = mypsi.LoadUserProfile;
                psi.Password = mypsi.Password;
                psi.PasswordInClearText = mypsi.PasswordInClearText == null ? null : Environment.ExpandEnvironmentVariables(mypsi.PasswordInClearText);
                psi.RedirectStandardError = mypsi.RedirectStandardError;
                psi.RedirectStandardInput = mypsi.RedirectStandardInput;
                psi.RedirectStandardOutput = mypsi.RedirectStandardOutput;
                psi.StandardErrorEncoding = mypsi.StandardErrorEncoding;
                psi.StandardOutputEncoding = mypsi.StandardErrorEncoding;
                psi.UserName = mypsi.UserName == null ? null : Environment.ExpandEnvironmentVariables(mypsi.UserName);
                psi.UseShellExecute = mypsi.UseShellExecute;
                psi.Verb = mypsi.Verb == null ? null : Environment.ExpandEnvironmentVariables(mypsi.Verb);
                psi.WindowStyle = mypsi.WindowStyle;
                psi.WorkingDirectory = mypsi.WorkingDirectory == null ? null : Environment.ExpandEnvironmentVariables(mypsi.WorkingDirectory);
                Environment.SetEnvironmentVariable("LauncherDir", null);

                Process.Start(psi);

            }
            catch (Exception e)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                _ = MessageBox.Show(e.Message);
            }
        }
    }
}