/*  LoadSaveModel TODO-List:
        - Clean-up\Review comments, since most of it was copy and pasted from my previous project.
        - Review the code and ensure this is the final version of what i want, if not add the remaining desired functionality.
        - Add Comments in places where i could (or would have wanted) to add functionality, that i ended up not adding because of reasons.
 */
using System.Collections;
using System.Text;

namespace MauiLearningApp.Models
{
    internal class LoadSaveModel
    {
        // Local dictionaries to store data that is fetched or should be saved.
        private static readonly Dictionary<string, int> TimeResults = new();
        private static readonly Dictionary<string, int> DateResults = new();
        private static readonly Dictionary<int, string> DayNames = new();
        private static readonly Dictionary<int, string> MonthNames = new();

        // Local state variables to detect if something was loaded allready, should be set during App init stages.
        internal static bool TimeLoaded { get; set; }
        internal static bool DateLoaded { get; set; }
        internal static bool NamesLoaded { get; set; }

        /*  LoadSaveModel Constructor:
                This constructor was designed to load 2 pre-defined resource files, and load name values from 2 hardcoded resource files, both only once.
                The initial intent was just to test file loading and saving within the MAUI framework.
                But this could also be expanded to be actually usefull, and load saved data or allow changing said default values as a setting etc.
                
                Expected use:
                    LoadSaveModel lsm = new("DefaultTime.csv", "DefaultDate.csv");

                Files & Locations:
                    ../Resource/Raw/DefaultTime.csv - Default time values, currently all set to 0.
                    ../Resource/Raw/DefaultDate.csv - Default date values, currently all set to 0.
                    ../Resource/Raw/DayNames.csv    - Default day name values in English.
                    ../Resource/Raw/MonthNames.csv  - Default moth name values in English.
                    
         */
        public LoadSaveModel(string fileName_1, string fileName_2)
        {
            if (!TimeLoaded)                                                                            // Evaluate the state variable to see if a task was already performed.
            {
                Task.Run(() => ParseFile(fileName_1, "time")).Wait();                                   // Run Task with fileName_1, and string value to represent the model its used for.
                TimeLoaded = true;                                                                      // Flip the state variable, so we don't re-run this if triggered by accident.
            }

            if (!DateLoaded)
            {
                Task.Run(() => ParseFile(fileName_2, "date")).Wait();
                DateLoaded = true;
            }

            if (!NamesLoaded)
            {
                Task.Run(() => ParseFile("DayNames.csv", "dayNames")).Wait();                           // Run task with a hardcoded resource filename, and string to indicate what its used for.
                Task.Run(() => ParseFile("MonthNames.csv", "monthNames")).Wait();                       // Run task with a hardcoded resource filename, and string to indicate what its used for.
                NamesLoaded = true;
            }
        }

        // Open and Parse file, using the .NET MAUI file system helpers for bundled files
        private static async Task<Task> ParseFile(string fileName, string model)
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);       // Load file from current 'FileSystem'
            using StreamReader sr = new(fileStream);                                                    // Hand over the 'fileStream' to the 'StreamReader'

            while (!sr.EndOfStream)                                                                     // Itterate over the 'StreamReader'
            {
                var line = sr.ReadLine();                                                               // Store the line in a temp variable
                var values = line.Split(",");                                                           // Store and seperate the content using ',' as a delimiter

                if (model == "time" && values[0] != "property")                                         // Evaluate the model name, and the first value of the header
                {
                    if (values.Length > 0)                                                              // Itterate over the remaining values
                    {
                        TimeResults.Add(values[0], Convert.ToInt32(values[1]));                         // Add the values to 'Results' in the correct order
                    }
                }
                else if (model == "date" && values[0] != "property")
                {
                    if (values.Length > 0)
                    {
                        DateResults.Add(values[0], Convert.ToInt32(values[1]));
                    }
                }
                else if (model == "dayNames" && values[0] != "index")
                {
                    if (values.Length > 0)
                    {
                        DayNames.Add(Convert.ToInt32(values[0]), values[1]);
                    }
                }
                else if (model == "monthNames" && values[0] != "index")
                {
                    if (values.Length > 0)
                    {
                        MonthNames.Add(Convert.ToInt32(values[0]), values[1]);
                    }
                }
            }

            return Task.CompletedTask;                                                                  // Indicate that the task is complete
        }

        // Write data to file, using the .NET MAUI file system to write to app data folder
        private static async Task<Task> WriteFile(string fileName, Dictionary<string, string> data)
        {
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);            // Create a target file in the app data folder
            using FileStream outputStream = File.OpenWrite(targetFile);                                 // Create a output stream that can write to the target file
            using StreamWriter streamWriter = new(outputStream);                                        // Create a stream writer instance for the output stream
            StringBuilder csv = new();                                                                  // Create a string builder instance for our data

            if (data.Count != 0)                                                                        // Check if data is not empty
            {
                csv.AppendLine("property, value");                                                      // Append a header to our string builder instance

                foreach (KeyValuePair<string, string> entry in data)                                    // Itterate over the data
                {
                    string newLine = string.Format("{0}, {1}", entry.Key, entry.Value);                 // Format each line into a new string line
                    csv.AppendLine(newLine);                                                            // Append each line to the string builder instance
                }
            }

            await streamWriter.WriteAsync(csv);                                                         // Write 'csv' to 'streamWriter'

            return Task.CompletedTask;                                                                  // Indicate that the task is complete
        }

        // Get data with model and property name
        public static int GetResult(string model, string property)
        {
            if (model == "time")                                                                        // Evaluate 'model' so we load the correct file
            {
                IDictionaryEnumerator reEnum = TimeResults.GetEnumerator();                             // Add enumerator to 'TimeResults'

                while (reEnum.MoveNext())                                                               // Enumerate over 'TimeResults'
                {
                    if (reEnum.Key.ToString() == property)                                              // If 'Results' has the requested property (type cast required to evaluate)
                    {
                        return Convert.ToInt32(reEnum.Value);                                           // Convert that to int32 (default int type) and return it
                    }
                }
            }
            else if (model == "date")
            {
                IDictionaryEnumerator reEnum = DateResults.GetEnumerator();

                while (reEnum.MoveNext())
                {
                    if (reEnum.Key.ToString() == property)
                    {
                        return Convert.ToInt32(reEnum.Value);
                    }
                }
            }

            return 10;                                                                                  // Incase everything else fails, return 10 to make problems obvious
        }

        // Get function to retrieve the loaded names.
        public static Dictionary<int, string> GetNames(string property)
        {
            if (property == "days") { return DayNames; }
            else if (property == "months") { return MonthNames; }
            return null;
        }

        // Save data based on a model name, with dictionary type data, simply executing the async method.
        // Though the App data folder is located in:
        //      "AppData\Local\Packages\[some random long number]\LocalState"
        // I know to little about this to see a use for it, or to know if that can change depending on where your app is 'installed'.
        // But i can confirm its working, and the expected data is writen to file in the intended format, and that is all i wanted to test\learn.
        public static void Save(string model, Dictionary<string, string> data)
        {
            if (model == "time")
            {
                Task.Run(() => WriteFile("SaveTime.csv", data)).Wait();
            }
            else if (model == "date")
            {
                Task.Run(() => WriteFile("SaveDate.csv", data)).Wait();
            }
        }
    }
}
