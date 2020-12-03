using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
    public partial class UIManager
    {
        private class MainMenu : Menu
        {
            
            public MainMenu () {
                var mainmenuprefab = Resources.Load("Menus/Main Menu");
                Go = (GameObject)Object.Instantiate(mainmenuprefab, Canvas);
                InitializeButtons();
            }

            /// <summary>
            /// Add listeners to the MainMenu buttons
            /// </summary>
            private void InitializeButtons () {
                GameObject.Find("Start").GetComponent<Button>().onClick.AddListener(Game.Ctx.StartGame);
                GameObject.Find("Quit").GetComponent<Button>().onClick.AddListener(Game.Ctx.QuitGame);
            }
        }
    }
}