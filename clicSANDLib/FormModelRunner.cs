using System;
using Eto.Forms;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace clicSANDLib
{
    public partial class FormModelRunner : Form
    {
        string logFileName = null;

        public FormModelRunner()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            string dataFileName = textBoxDataSource.Text;
            string lpFileName = textBoxDataSource.Text + ".lp";
            string resultsFileName = textBoxDataSource.Text + ".results.txt";
            string processedResultsFileName = resultsFileName + ".processed_results.csv";
            string resFile = resultsFileName + ".res_data.txt";
            logFileName = string.Format("{0}{1}.log.txt", textBoxDataSource.Text, DateTime.Now.ToString("yyyyMMddHHmmss"));

            textBoxOutput.Text = "";

            textBoxOutput.Text += new string('-', 150) + "\r\n";
            textBoxOutput.Text += "Data file: " + dataFileName + "\r\n";
            textBoxOutput.Text += "Model file: " + textBoxModel.Text + "\r\n";
            textBoxOutput.Text += "GLPSOL Output file: " + lpFileName + "\r\n";
            textBoxOutput.Text += "Results file: " + resultsFileName + "\r\n";
            textBoxOutput.Text += "Processed Results file: " + processedResultsFileName + "\r\n";
            textBoxOutput.Text += "RES data file: " + resFile + "\r\n";
            textBoxOutput.Text += "Log file: " + logFileName + "\r\n";
            textBoxOutput.Text += new string('-', 150) + "\r\n";

            //TODO Cursor.Current = Cursors.WaitCursor;
            try
            {
                textBoxOutput.Text += "Converting files for RES visualisation";
                CreateRESOutput(dataFileName, resFile);
            }
            catch (Exception exc)
            {
                textBoxOutput.Text += "Unable to convert RES result: " + exc.Message + "\r\n";
            }
            try
            {
                bool result = false;
                result = RunGLPSOL(dataFileName, textBoxModel.Text, lpFileName);
                if (result)
                {
                    result = RunCBC(lpFileName, resultsFileName, (bool)checkCBCRatio.Checked, numericRatio.Value.ToString().Replace(',', '.'));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error Running Model");
            }
            try
            {
                textBoxOutput.Text += "Converting results for visualisation";
                ConvertResults(resultsFileName, resultsFileName);
            }
            catch (Exception exc)
            {
                textBoxOutput.Text += "Unable to convert results: " + exc.Message + "\r\n";
            }
            finally
            {
                //TODO Cursor.Current = Cursors.Default;

                try
                {
                    SaveLog(logFileName, textBoxOutput.Text);

                }
                catch (Exception exc)
                {
                    textBoxOutput.Text += "Unable to save log: " + exc.Message + "\r\n";
                }
            }
        }



        //private bool ExtractDataFromXLS(string xlsFileName, string dataFileName)
        //{
        //    try
        //    {
        //        var Excel = new Excel.Application();
        //        var workBook = Excel.Workbooks.Open(xlsFileName);
        //        Excel.Application.Visible = true;
        //        Excel.Application.Run(String.Format("'{0}'!Module1.writefile", xlsFileName));
        //        workBook.Saved = true;
        //        workBook.Close();
        //        Excel.Quit();
        //    }
        //    catch (Exception exc)
        //    {
        //        textBoxOutput.Text += String.Format("Error extracting data:\r\n{0}", exc.Message);
        //        return false;
        //    }
        //    return true;
        //}

        private void ConvertResults(string input, string output_dir)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            // startInfo.CreateNoWindow = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"converter/dist/python_converter");
            startInfo.FileName = path;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            string input_path = Path.GetDirectoryName(input);
            startInfo.Arguments = input + " " + input_path;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception exc)
            {
                textBoxOutput.Text += "Unable to run python converter: " + exc.Message + "\r\n";
            }
        }

        private void CreateRESOutput(string input, string output_dir)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            // startInfo.CreateNoWindow = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"RES/sand_filter_v2");
            startInfo.FileName = path;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            string input_path = Path.GetDirectoryName(input);
            startInfo.Arguments = input + " " + output_dir;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception exc)
            {
                textBoxOutput.Text += "Unable to run RES converter: " + exc.Message + "\r\n";
            }
        }


        private bool RunGLPSOL(string dataFileName, string modelFileName, string lpFileName)
        {
            return RunProcess(String.Format(@"{0}/glpsol", ConfigurationManager.AppSettings["glpsolLocation"]), string.Format("--check -m \"{0}\" -d \"{1}\" --wlp \"{2}\"", modelFileName, dataFileName, lpFileName));
        }

        private bool RunCBC(string inputFileName, string outputFileName, bool applyRatio, string ratio)
        {
            string cbcParams = null;

            if (applyRatio)
            {
                cbcParams = String.Format("\"{0}\" ratio {1} solve -solu \"{2}\"", inputFileName, ratio, outputFileName);
            }
            else
            {
                cbcParams = String.Format("\"{0}\" solve -solu \"{1}\"", inputFileName, outputFileName);
            }
            return RunProcess(String.Format(@"{0}/cbc", ConfigurationManager.AppSettings["cbcLocation"]), cbcParams);
        }

        private bool RunProcess(string filename, string args)
        {
            try
            {
                textBoxOutput.Text += new string('-', 150) + "\r\n";
                textBoxOutput.Text += string.Format("Running {0} {1}\r\n", filename, args);
                textBoxOutput.Text += new string('-', 150) + "\r\n";
                Process compiler = new Process();
                compiler.StartInfo.FileName = filename;
                compiler.StartInfo.Arguments = args;
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.CreateNoWindow = false;

                compiler.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        textBoxOutput.Text += e.Data;
                    }
                });

                compiler.Start();

                textBoxOutput.Text += compiler.StandardOutput.ReadToEnd();

                compiler.WaitForExit();

                return true;
            }
            catch (Exception e)
            {
                textBoxOutput.Text += "Error: " + e.Message + "\r\n";
                return false;
            }
        }

        private void buttonOpenDataSource_Click(object sender, EventArgs e)
        {
            var filename = OpenFile("Model input files|*.txt");

            if (!String.IsNullOrEmpty(filename))
            {
                textBoxDataSource.Text = filename;
            }
        }

        private string OpenFile(string filter)
        {
            var fileDialog = new OpenFileDialog();
            string[] filterparts = filter.Split(new char[] { '|' });
            fileDialog.Filters.Add(new FileFilter(filterparts[0], new string[] { filterparts[1] }));
            //fileDialog.Multiselect = false;

            DialogResult dialogResult = fileDialog.ShowDialog(this);

            if (dialogResult.Equals(DialogResult.Ok))
            {
                return fileDialog.FileName;
            }
            return null;
        }

        protected void buttonOpenModel_Click(object sender, EventArgs e)
        {
            var filename = OpenFile("Text files|*.txt");

            if (!String.IsNullOrEmpty(filename))
            {
                textBoxModel.Text = filename;
            }
        }

        private void SaveLog(string logFileName, string lines)
        {
            System.IO.StreamWriter file = new StreamWriter(logFileName);
            file.WriteLine(lines);
        }

        private void checkCBCRatio_CheckedChanged(object sender, EventArgs e)
        {
            numericRatio.Enabled = (bool)checkCBCRatio.Checked;
        }

        protected void buttonSaveTemplates_Click(object sender, EventArgs e)
        {
            SelectFolderDialog folderDialog = new SelectFolderDialog();
            folderDialog.Title = "Extract templates";
            //folderDialog.ShowNewFolderButton = true;
            DialogResult result = folderDialog.ShowDialog(this);

            var location = new Uri(System.Reflection.Assembly.GetEntryAssembly().GetName().CodeBase);
            DirectoryInfo runningFolder = new FileInfo(location.AbsolutePath).Directory;

            if (result.Equals(DialogResult.Ok))
            {
                try
                {
                    foreach (FileInfo file in runningFolder.GetDirectories("Templates")[0].GetFiles())
                    {
                        File.Copy(file.FullName, Path.Combine(folderDialog.Directory, file.Name), true);
                    }
                    MessageBox.Show(String.Format("Templates exported to {0}", folderDialog.Directory));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(String.Format("Failed to copy files: \r\n{0}", exc.Message));
                }
            }
        }
    }
}

