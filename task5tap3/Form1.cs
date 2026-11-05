using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace task5tap3
{
    public partial class Form1 : Form
    {
        private readonly string reportPath = Path.Combine(Application.StartupPath, "hesabat.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Mətn faylları (*.txt)|*.txt|Bütün fayllar (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtFilePath.Text = ofd.FileName;
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            string path = txtFilePath.Text.Trim();
            if (!File.Exists(path))
            {
                MessageBox.Show("Fayl tapılmadı. Düzgün yol daxil edin.", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int lineCount = 0;
                int charCount = 0;
                int charNoSpaceCount = 0;   
                int wordCount = 0;
                string longestWord = "";
                Dictionary<string, int> freq = new Dictionary<string, int>();

                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lineCount++;
                        charCount += line.Length;
                        charNoSpaceCount += line.Count(c => !char.IsWhiteSpace(c));

                        foreach (Match m in Regex.Matches(line, @"[\p{L}\p{N}]+"))
                        {
                            string word = m.Value;
                            wordCount++;

                            if (word.Length > longestWord.Length)
                                longestWord = word;

                            string key = word.ToLower();
                            if (freq.ContainsKey(key))
                                freq[key]++;
                            else
                                freq[key] = 1;
                        }
                    }
                }

                
                List<KeyValuePair<string, int>> top3 = freq
                    .OrderByDescending(kv => kv.Value)
                    .ThenBy(kv => kv.Key)
                    .Take(3)
                    .ToList();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("=== MƏTN ANALİZ HESABATI ===");
                sb.AppendLine("Fayl: " + path);
                sb.AppendLine("Tarix: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.AppendLine();
                sb.AppendLine("Sətir sayı: " + lineCount);
                sb.AppendLine("Söz sayı: " + wordCount);
                sb.AppendLine("Simvol sayı (boşluqlarla): " + charCount);
                sb.AppendLine("Simvol sayı (boşluqsuz): " + charNoSpaceCount);
                sb.AppendLine("Ən uzun söz: " + longestWord + " (" + longestWord.Length + " hərf)");
                sb.AppendLine();
                sb.AppendLine("Ən çox təkrarlanan 3 söz:");

                int rank = 1;
                foreach (KeyValuePair<string, int> kv in top3)
                {
                    sb.AppendLine("  " + rank + ". " + kv.Key + " - " + kv.Value + " dəfə");
                    rank++;
                }


                using (StreamWriter sw = new StreamWriter(reportPath, false, Encoding.UTF8))
                {
                    sw.Write(sb.ToString());
                }

                txtReport.Text = sb.ToString() + Environment.NewLine + "Hesabat yazıldı: " + reportPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Analiz zamanı xəta: " + ex.Message, "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}