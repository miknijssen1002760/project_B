using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_B.Models;
using project_B.Controllers;

namespace project_B.Views
{
    internal class RemoveAccount
    {
        public static void DeleteAccount()
        {
            Users accounts = new Users();
            string[] options = { "Yes", "No" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Menu===", options);

            switch (CurrentSelection)
            {
                case 0:
                    accounts.remove(Login.currentUser, accounts);
                    Program.HomeScreen();
                    break;

                case 1:
                    Program.MainMenu();
                    break;
            }

        }

    }
}
