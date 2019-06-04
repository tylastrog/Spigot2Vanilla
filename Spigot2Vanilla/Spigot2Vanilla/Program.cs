using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Spigot2Vanilla
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Spigot2Vanilla";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\n" +
                          "  *   ____        _             _         ____     __     __          _ _ _         *\n" +
                          "  *  / ___| _ __ (_) __ _  ___ | |_      |___ \\    \\ \\   / /_ _ _ __ (_) | | __ _   *\n" +
                          "  *  \\___ \\| '_ \\| |/ _` |/ _ \\|  __|      __) |    \\ \\ / / _` | '_ \\| | | |/ _` |  *\n" +
                          "  *   ___) | |_) | | (_| | (_) | |_       / __/      \\ V / (_| | | | | | | | (_| |  *\n" +
                          "  *  |____/| .__/|_|\\__, |\\___/ \\__|     |_____|      \\_/ \\__,_|_| |_|_|_|_|\\__,_|  *\n" +
                          "  *        |_|      |___/                                                           *\n" +
                          "  *                              a minecraft (vanilla <--> spigot) world converter  *\n" +
                          "  *                                              by tylastrog (v1.0)                *\n" +
                          "  *                                                                                 *\n" +
                          "  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\n\n");
            Console.ResetColor();

        Start:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" > ");

            string response = Console.ReadLine();
            string _response = response.ToLower();

            switch (_response)
            {
                case "v2s":

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\tEnter directory of VANILLA world:");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\t(ex: C:\\Users\\John\\Desktop\\Server-Vanilla\\world)");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" \t");

                    string vanillaLoc = @"" + Console.ReadLine() + "";

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tEnter directory of SPIGOT server:");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\t(ex: C:\\Users\\John\\Desktop\\Server-Spigot)");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" \t");

                    string spigotLoc = @"" + Console.ReadLine() + "\\world";
                    string netherVanilla = vanillaLoc + "\\DIM-1";
                    string endVanilla = vanillaLoc + "\\DIM1";

                    Copy(netherVanilla, spigotLoc + "_nether");

                    Copy(endVanilla, spigotLoc + "_the_end");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tProcess has been completed.");

                    goto Start;

                case "s2v":

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\tEnter directory of SPIGOT server:");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\t(ex: C:\\Users\\John\\Desktop\\Server-Spigot)");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" \t");

                    string spigotLoc2 = @"" + Console.ReadLine() + "\\world";

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tEnter directory of VANILLA world:");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\t(ex: C:\\Users\\John\\Desktop\\Server-Vanilla\\world");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" \t");

                    string vanillaLoc2 = @"" + Console.ReadLine() + "";

                    string netherVanilla2 = vanillaLoc2 + "\\DIM-1";
                    string endVanilla2 = vanillaLoc2 + "\\DIM1";

                    Copy(spigotLoc2 + "_nether", netherVanilla2);

                    Copy(spigotLoc2 + "_the_end", endVanilla2);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tProcess has been completed.");

                    goto Start;

                case "stop":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case "exit":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case "help":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\n" +
                        " Available Commands:");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n" +
                        "   help \t Displays the help menu\n" +
                        "   stop | exit\t Stops the program\n" +
                        "   s2v      \t Converts Spigot world to Vanilla\n" +
                        "   v2s      \t Converts Vanilla world to Spigot\n\n");
                    Console.ResetColor();
                    goto Start;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nInvalid command. Type \"help\" for a list of commands.\n\n");
                    Console.ResetColor();
                    goto Start;
            }
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }
            
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
