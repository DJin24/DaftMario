using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
    public partial class UIManager
    {
        private class PauseMenu : Menu
        {
            public PauseMenu () {
                var pausemenuprefab = Resources.Load("Menus/Pause Menu");
                Go = (GameObject)Object.Instantiate(pausemenuprefab, Canvas);
                InitializeButtons();
            }

            /// <summary>
            /// Add listeners to the Pause Menu buttons
            /// </summary>
            private void InitializeButtons () {
                GameObject.Find("Resume").GetComponent<Button>().onClick.AddListener(Game.Ctx.Clock.Unpause);
                GameObject.Find("Main Menu").GetComponent<Button>().onClick.AddListener(Hide);
                GameObject.Find("Main Menu").GetComponent<Button>().onClick.AddListener(Game.Ctx.ReturnToMenu);
            }
        }
    }

}