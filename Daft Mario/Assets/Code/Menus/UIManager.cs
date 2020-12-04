
using UnityEngine;

namespace Assets.Code.Menus
{
    public partial class UIManager : IManager
    {
        public static Transform Canvas { get; private set; }

        private MainMenu _main;
        private InstructionMenu _instruction;

        public UIManager () {
            Canvas = GameObject.Find("Canvas").transform;
        }

        public void ShowMainMenu () {
            _main = new MainMenu();
            _main.Show();
        }

        public void HideMainMenu () {
            _main.Hide();
            _main = null;
        }

        public void ShowInstrMenu()
        {
            _instruction = new InstructionMenu();
            _instruction.Show();
        }

        public void HideInstrMenu()
        {
            _instruction.Hide();
            _instruction = null;
        }

        public void GameStart () { HideMainMenu(); }

        public void GameEnd () { ShowMainMenu(); }

        private abstract class Menu
        {
            protected GameObject Go;
            public bool Showing { get; private set; }

            /// <summary>
            /// Show this menu
            /// </summary>
            public virtual void Show () {
                Showing = true;
                Go.SetActive(true);
            }

            /// <summary>
            /// Hide this menu
            /// </summary>
            public virtual void Hide () {
                GameObject.Destroy(Go);
                Showing = false;
            }
        }
    }

}
