using System.Security.Cryptography;
using System.Text;

namespace DemonstrationVideo
{
    internal class Program
    {

        private static string targetFile = ""; // Variable to store the path of the target file
        private static string previousContent = ""; // Variable to store the previous content of the file


        static void Main(string[] args)
        {
            Console.WriteLine("File Monitor Program");
            Console.WriteLine("--------------------");

            // Prompt user to enter target file path
            Console.Write("Enter the full path of the target text file (.txt only): ");
            targetFile = Console.ReadLine();

            // Validate file path
            while (!File.Exists(targetFile) || Path.GetExtension(targetFile).ToLower() != ".txt")
            {
                Console.WriteLine("File not found or not a .txt file. Please enter a valid path.");
                Console.Write("Enter the full path of the target text file (.txt only): ");
                targetFile = Console.ReadLine();
            }

            Console.WriteLine($"Monitoring changes to: {targetFile}");
            Console.WriteLine("Press Ctrl + C to exit.");

            // Start monitoring thread
            Thread monitorThread = new Thread(MonitorFileChanges);
            monitorThread.Start();
        }

        static void MonitorFileChanges()
        {
            while (true)
            {
                try
                {
                    // Read current content of the target file
                    string currentContent = File.ReadAllText(targetFile);

                    // Compare current content with previous content
                    if (currentContent != previousContent)
                    {
                        Console.WriteLine($"Changes detected in {targetFile} at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                        ReportChanges(previousContent, currentContent);

                        // Update previous content with the current content
                        previousContent = currentContent;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error monitoring file: {ex.Message}");
                }

                // Sleep for 15 seconds before checking again
                Thread.Sleep(15000);
            }
        }

        static void ReportChanges(string previous, string current)
        {
            // Split content into lines
            string[] previousLines = previous.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string[] currentLines = current.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Compare each line and report differences
            var changes = DiffUtil.DiffLines(previousLines, currentLines);

            if (changes.Count > 0)
            {
                Console.WriteLine("Changes:");

                foreach (var change in changes)
                {
                    switch (change.Operation)
                    {
                        case DiffOperation.Equal:
                            Console.WriteLine($"  {change.Text}");
                            break;
                        case DiffOperation.Insert:
                            Console.WriteLine($"+ {change.Text}");
                            break;
                        case DiffOperation.Delete:
                            Console.WriteLine($"- {change.Text}");
                            break;
                    }
                }
            }
        }

        public enum DiffOperation
        {
            Equal,
            Insert,
            Delete
        }

        public static class DiffUtil
        {
            public static List<DiffChange> DiffLines(string[] previous, string[] current)
            {
                var changes = new List<DiffChange>();

                int p = 0, c = 0;
                int pEnd = previous.Length, cEnd = current.Length;

                while (p < pEnd || c < cEnd)
                {
                    if (p < pEnd && c < cEnd)
                    {
                        if (previous[p] == current[c])
                        {
                            changes.Add(new DiffChange(DiffOperation.Equal, previous[p]));
                            p++;
                            c++;
                        }
                        else
                        {
                            bool pEndReached = p + 1 >= pEnd;
                            bool cEndReached = c + 1 >= cEnd;

                            if (!cEndReached && (pEndReached || previous[p] != current[c + 1]))
                            {
                                changes.Add(new DiffChange(DiffOperation.Insert, current[c]));
                                c++;
                            }
                            else if (!pEndReached && (cEndReached || previous[p + 1] != current[c]))
                            {
                                changes.Add(new DiffChange(DiffOperation.Delete, previous[p]));
                                p++;
                            }
                            else
                            {
                                changes.Add(new DiffChange(DiffOperation.Equal, previous[p]));
                                p++;
                                c++;
                            }
                        }
                    }
                    else if (p < pEnd)
                    {
                        changes.Add(new DiffChange(DiffOperation.Delete, previous[p]));
                        p++;
                    }
                    else if (c < cEnd)
                    {
                        changes.Add(new DiffChange(DiffOperation.Insert, current[c]));
                        c++;
                    }
                }

                return changes;
            }
        }

        public class DiffChange
        {
            public DiffOperation Operation { get; set; }
            public string Text { get; set; }

            public DiffChange(DiffOperation operation, string text)
            {
                Operation = operation;
                Text = text;
            }
        }
    }
}
