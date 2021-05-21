// #define CREATE
using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;


namespace Launcher
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
#if CREATE

                // First write something so that there is something to read ...  
                var b = new Launcher();
                var a = new ProcessStartInfo();

                b.Arguments = a.Arguments;
                b.CreateNoWindow = a.CreateNoWindow;
                b.Domain = a.Domain;
                b.Environment = new Launcher.EnvironmentVariable[a.Environment.Count];
                {
                    int i = 0;
                    foreach (var envi in a.Environment)
                    {
                        b.Environment[i++] = new Launcher.EnvironmentVariable(envi.Key, envi.Value);
                    }
                }

                // b.EnvironmentVariables = new Launcher.EnvironmentVariable[a.EnvironmentVariables.Count];
                // {
                //     int i = 0;
                //     foreach (System.Collections.DictionaryEntry envi in a.EnvironmentVariables)
                //     {
                //         b.EnvironmentVariables[i++] = new Launcher.EnvironmentVariable((string)envi.Key, (string)envi.Value);
                //     }
                // }
                b.ErrorDialog = a.ErrorDialog;
                b.FileName = a.FileName;
                b.LoadUserProfile = a.LoadUserProfile;
                b.Password = a.Password;
                b.PasswordInClearText = a.PasswordInClearText;
                b.RedirectStandardError = a.RedirectStandardError;
                b.RedirectStandardInput = a.RedirectStandardInput;
                b.RedirectStandardOutput = a.RedirectStandardOutput;
                b.StandardErrorEncoding = a.StandardErrorEncoding;
                b.StandardOutputEncoding = a.StandardErrorEncoding;
                b.UserName = a.UserName;
                b.UseShellExecute = a.UseShellExecute;
                b.Verb = a.Verb;
                b.WindowStyle = a.WindowStyle;
                b.WorkingDirectory = a.WorkingDirectory;

                var writer = new System.Xml.Serialization.XmlSerializer(typeof(Launcher));
                using wfile = new System.IO.StreamWriter("Default.xml");
                writer.Serialize(wfile, b);
#else

                // Now we can read the serialized obj ...  
                using var file = new System.IO.StreamReader(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + AppDomain.CurrentDomain.SetupInformation.ApplicationName.Substring(0, AppDomain.CurrentDomain.SetupInformation.ApplicationName.Length - 3) + "xml");
                Launcher mypsi = (Launcher)new System.Xml.Serialization.XmlSerializer(typeof(Launcher)).Deserialize(file);

                var psi = new ProcessStartInfo();
                Environment.SetEnvironmentVariable("LauncherDir", AppDomain.CurrentDomain.SetupInformation.ApplicationBase.Substring(0, AppDomain.CurrentDomain.SetupInformation.ApplicationBase.Length - 1));
                psi.Arguments = mypsi.Arguments == null ? null : Environment.ExpandEnvironmentVariables(mypsi.Arguments);
                psi.CreateNoWindow = mypsi.CreateNoWindow;
                psi.Domain = mypsi.Domain == null ? null : Environment.ExpandEnvironmentVariables(mypsi.Domain);
                if (mypsi.Environment != null)
                {
                    foreach (var item in mypsi.Environment)
                    {
                        if (item.Value == null)
                        {
                            _ = psi.Environment.Remove(item.Variable);
                        }
                        else
                        {
                            psi.Environment.Add(item.Variable, Environment.ExpandEnvironmentVariables(item.Value));
                        }
                    }
                }
                // foreach (var item in mypsi.EnvironmentVariables)
                // {
                //     psi.EnvironmentVariables.Add(item.Variable,item.Value);
                // }
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

                _ = Process.Start(psi);
#endif

            }
            catch (Exception e)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                _ = MessageBox.Show(e.ToString(), e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class Launcher
    {
        public class EnvironmentVariable
        {
            public EnvironmentVariable(string Variable, string Value)
            {
                this.Variable = Variable;
                this.Value = Value;
            }
            public EnvironmentVariable()
            {
            }
            public string Variable;
            public string Value;
        }
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
        public EnvironmentVariable[] Environment;
        // public EnvironmentVariable[] EnvironmentVariables;
        public bool CreateNoWindow;
        public string Arguments;
        public string Verb;
        // public IntPtr ErrorDialogParentHandle;
        public ProcessWindowStyle WindowStyle;

    }
}