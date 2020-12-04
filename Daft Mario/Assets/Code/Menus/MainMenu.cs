using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
    public partial class UIManager
    {
        private class MainMenu : Menu
        {
            public MainMenu()
            {
                Go = (GameObject) GameObject.Instantiate(Resources.Load("Menus/Main Menu"), Canvas);
                InitializeButtons();
            }

            /// <summary>
            /// Add listeners to the MainMenu buttons
            /// </summary>
            private void InitializeButtons ()
            {
                GameObject.Find("Play").GetComponent<Button>().onClick.AddListener(Game.Ctx.StartGame);
                GameObject.Find("How to Play").GetComponent<Button>().onClick.AddListener(() =>
                {
                    Hide();
                    Game.Ctx.UI.ShowInstrMenu();
                });
            }
        }
    }
}