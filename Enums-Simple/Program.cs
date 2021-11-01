using System;

namespace Enums_Simple
{
    class Program
    {
       

        static void Main(string[] args)
        {
            useFirstEnum();
            useSecondEnum();
        }

        enum Colors
        {
            Red = 5,
            Green = 10,
            Blue = 15
        }

     
        static void useFirstEnum()
        {
            Colors myColor = Colors.Green;

            if (myColor == Colors.Blue)
            {
                Console.WriteLine("Farbe ist blau");
            }

            // int := (int)Color
            int myColorVal = (int)myColor;

            // Color := (Colors)int
            Colors myGreenCol = (Colors)myColorVal;

            // string := Colors.ToString
            string myColorStr = myColor.ToString();

            // Colors := Enum.Parse(string)
            Colors myConvertedColor1 = Enum.Parse<Colors>("Blue");

            // Colors := (Colors)object
            Colors myConvertedColor2 = (Colors)Enum.Parse(typeof(Colors), "Blue");

            Console.WriteLine("Done.");
        }

        //// Variante 1:
        //[Flags]
        //enum Rights
        //{
        //    AddUser = 1,
        //    DeleteUser = 2,
        //    DownloadData = 4,
        //    UploadData = 8,
        // All = AddUser | DeleteUser | DownloadData | UploadData
        //}

    //// Variante 2:
    [Flags]
        enum Rights
        {
            AddUser = 1 << 0,
            DeleteUser = 1 << 1,
            DownloadData = 1 << 2,
            UploadData = 1 << 3,
            All = AddUser | DeleteUser | DownloadData | UploadData
        }

        static void useSecondEnum()
        {
            Rights userRights = Rights.AddUser | Rights.DeleteUser;
            int userRightsAsInt = (int)userRights;  // casting to int works

            if ((userRights & Rights.AddUser) == Rights.AddUser)  // has User the AddUser right?
            {
                Console.WriteLine("User has AddUser right.");
            }

            if (userRights.HasFlag(Rights.AddUser))    // has User the AddUser right?
            {
                Console.WriteLine("User has AddUser right.");
            }

            Console.WriteLine("Done.");
        }
    }
}
