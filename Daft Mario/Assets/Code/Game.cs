using UnityEditor;
using UnityEngine;
using Assets.Code.Menus;

namespace Assets.Code
{
    public interface IManager
    {
        void GameStart();
        void GameEnd();
    }

    public class Game : MonoBehaviour
    {
        public static Game Ctx;

        public UIManager UI { get; private set; }

        private Player.Player _player;

        internal void Start()
        {
            Ctx = this;
            UI = new UIManager();
            UI.ShowMainMenu();
            Time.timeScale = 0f;
        }

        public void StartGame()
        {
            UI.GameStart();
            Time.timeScale = 1f;
        }

        public void ReturnToMenu()
        {
            UI.ShowMainMenu();
        }
    }
}