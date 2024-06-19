using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Timers;

public partial class Form1 : Form
{
    private string targetFilePath;
    private string lastFileContent;
    private System.Timers.Timer timer;

    public Form1()
    {
        InitializeComponent();
        timer = new System.Timers.Timer(15000); // 15 seconds interval
        timer.Elapsed += OnTimedEvent;
    }

    private void btnSetTargetFile_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                targetFilePath = openFileDialog.FileName;
                lblFilePath.Text = targetFilePath;
                lastFileContent = File.ReadAllText(targetFilePath, Encoding.UTF8);
                timer.Start();
            }
        }
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        if (File.Exists(targetFilePath))
        {
            string currentFileContent = File.ReadAllText(targetFilePath, Encoding.UTF8);
            if (currentFileContent != lastFileContent)
            {
                string changes = GetChanges(lastFileContent, currentFileContent);
                this.Invoke((MethodInvoker)delegate {
                    txtChanges.AppendText($"{DateTime.Now}: {changes}\n");
                });
                lastFileContent = currentFileContent;
            }
        }
    }

    private string GetChanges(string oldContent, string newContent)
    {
        StringBuilder changes = new StringBuilder();

        using (StringReader oldReader = new StringReader(oldContent))
        using (StringReader newReader = new StringReader(newContent))
        {
            string oldLine, newLine;
            while ((oldLine = oldReader.ReadLine()) != null &&
                   (newLine = newReader.ReadLine()) != null)
            {
                if (!oldLine.Equals(newLine))
                {
                    changes.AppendLine($"- {oldLine}");
                    changes.AppendLine($"+ {newLine}");
                }
            }

            while ((oldLine = oldReader.ReadLine()) != null)
            {
                changes.AppendLine($"- {oldLine}");
            }

            while ((newLine = newReader.ReadLine()) != null)
            {
                changes.AppendLine($"+ {newLine}");
            }
        }

        return changes.ToString();
    }
}
