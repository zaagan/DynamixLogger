using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DynamixLogger.LogStrategy.File
{
    public class FilePaths
    {
        public static string ApplicationFolder = AppDomain.CurrentDomain.BaseDirectory;

        public static string AllUsersDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        public static string UserRoamingDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static string UserDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);


        public static DriveInfo ChooseADrive(long minimumSpace, bool includeOSPath = false)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string osPath = Path.GetPathRoot(Environment.SystemDirectory);

            List<DriveInfo> availableDrives = new List<DriveInfo>();
            foreach (DriveInfo drive in drives)
            {
                if (includeOSPath)
                {
                    if (drive.DriveType == DriveType.Fixed) availableDrives.Add(drive);
                }
                else

                if (drive.DriveType == DriveType.Fixed && drive.Name != osPath) availableDrives.Add(drive);
            }

            availableDrives = availableDrives.OrderBy(x => x.AvailableFreeSpace).ToList();
            DriveInfo selectedDrive = null;
            foreach (DriveInfo dInfo in availableDrives)
                if (dInfo.AvailableFreeSpace > minimumSpace)
                {
                    selectedDrive = dInfo;
                    break;
                }
            return selectedDrive;
        }

        /// <summary>
        /// AppData\Local\Temp\
        /// </summary>
        public static string TempPath = Path.GetTempPath();

    }
}
