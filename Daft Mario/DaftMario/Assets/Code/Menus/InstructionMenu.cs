using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Menus
{
    public partial class UIManager
    {
        private class InstructionMenu : Menu
        {
            public InstructionMenu () {
                Go = (GameObject) GameObject.Instantiate(Resources.Load("Menus/Instruction Menu"), Canvas);
                InitializeButtons();
            }
            private void InitializeButtons ()
            {
                GameObject.Find("Back").GetComponent<Button>().onClick.AddListener(() =>
                {
                    Hide();
                    Game.Ctx.UI.ShowMainMenu();
                });
            }
        }
    }

}