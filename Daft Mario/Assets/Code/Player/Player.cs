using UnityEngine;

namespace Assets.Code.Player
{

    public class Player : MonoBehaviour
    {
        private static readonly Vector2 Acceleration = new Vector2(2f, 0f);
        private static readonly Vector2 JumpVelocity = new Vector2(0f, 10f);
        private Rigidbody2D _rb;
        private bool _jumping; // are we jumping?

        internal void Start () {
            _rb = GetComponent<Rigidbody2D>();
        }

        internal void Update () {
            CheckKeys();
        }

        private void CheckKeys () {
            if (Input.GetKeyDown(KeyCode.P)) { Game.Ctx.Clock.TogglePause(); }
            if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }
            if (Input.GetKeyDown(KeyCode.A)) { Left(); }
            if (Input.GetKeyDown(KeyCode.D)) { Right(); }
            else {
                _rb.velocity = new Vector2(0f, _rb.velocity.y);
            }
        }

        private void CollisionDown (Collider2D other) {
            _jumping = false;
        }

        private void Jump () {
            if (!_jumping) {
                _rb.velocity += JumpVelocity;
            }
            _jumping = true;
        }

        private void Left() {
            // Set sprite to face left
            _rb.velocity = new Vector2(-1f, _rb.velocity.y);
        }

        private void Right() {
            // Set sprite to face right
            _rb.velocity = new Vector2(1f, _rb.velocity.y);
        }
    }
}