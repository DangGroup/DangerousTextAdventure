using System;
using System.IO;

//Utility Namespace.
namespace DangerousTextAdventure.Utility
{
    /// <summary>
    /// Static helper class to log errors.
    /// </summary>
    internal static class ErrorLog
    {
        #region Defines
        /// <summary>
        /// Default folder to store error logs.
        /// </summary>
        public const string PATH = "logs";
        #endregion

        #region Methods
        /// <summary>
        /// Serializes error log from given Exception.
        /// </summary>
        /// <param name="pException">Exception to serialize.</param>
        /// <param name="pErrorName">Log file name, "error" per default.</param>
        /// <returns>Returns true if the serialization was successful.</returns>
        internal static bool Serialize(Exception pException, string pErrorName = "error")
        {
            //Set return variable.
            bool success = true;
            //Try-Catch-Block starting the serialization.
            try
            {
                //Checks if given error is null and if true, cancels serialization.
                if (pException == null)
                    throw new ArgumentNullException("pException", "pException can't be null for serialization");

                //Set path variables.
                string root = Directory.GetCurrentDirectory();
                string path = Path.Combine(root, PATH);

                //Checks if log path exists, and if not, creates it.
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //Creates log and serializes given error.
                DateTime today = DateTime.Today;
                string fileName = string.Format("{0}\\{1}[{2}.{3}.{4}][{5}:{6}].log", path, pErrorName, today.Day, today.Month, today.Year, today.Hour, today.Minute);
                using (StreamWriter stream = new StreamWriter(File.Create(fileName)))
                    stream.Write(pException.ToString());
            }
            catch
            {
                //set return variable false on unexpected errors.
                success = false;
            }
            //Returns serialization result.
            return success;
        }
        #endregion
    }
}
