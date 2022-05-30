using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.Views
{
    internal class AccountSettings
    {
        public static void Settings()
        {
            string[] Settings = { "Delete Account", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Menu===", Settings);

            switch (CurrentSelection)
            {
                case 0:
                    RemoveAccount.DeleteAccount();
                    break;

                case 1:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
