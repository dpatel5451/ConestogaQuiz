
/*
* Filename		:	Program
* Project		:	RDB - Assignment 04 
* Programmer	:	Deep Patel & Dhruvanshi Ghiya
* First Version	:	10/12/2021
* Description	:	This form contains all the forms used.
*                   Styled to be used as the "Main" of the application
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace A04_Quiz
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EntryPage());
        }
    }
}
