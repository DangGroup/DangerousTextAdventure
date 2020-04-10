using DangerousTextAdventure.Exceptions;
using DangerousTextAdventure.Utility;
using System;

//Root Namespace.
namespace DangerousTextAdventure
{
    /// <summary>
    /// Static class, managing the default Game Logic.
    /// </summary>
    internal static class Program
    {
        #region Defines
        /// <summary>
        /// Accessable Exit Code.
        /// </summary>
        internal static int EXIT = 0;
        #endregion

        #region Methods
        /// <summary>
        /// Entry point for the application startup.
        /// </summary>
        /// <param name="pArgs">Arguments given to the game on start.</param>
        /// <returns>Exit Code after shutdown.</returns>
        internal static int Main(string[] pArgs)
        {
            //Try-Catch-Block to handle forced shutdown.
            try
            {
                //Enter application logic here.
                
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Title = "Dangerous Text Adventure";

                
                // Careful! Endless loop!!! For color-testing porpuses <3
                while(true)
                {
                    Console.WriteLine("Sehbehindertenfreundliche Farbe.");
                }

            }
            catch (ForcedShutdownException pException)
            {
                //Sets exit code given by the occured error.
                EXIT = pException.ExitCode;
                //Checks for forcing error logging, and if needed, logs the error.
                if (pException.LogError)
                    ErrorLog.Serialize(pException);
            }
            //Exit application and give windows the exit code.
            return EXIT;
        }
        #endregion
    }
}
