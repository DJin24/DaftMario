using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Player
{

    public class Player : MonoBehaviour
    {
        private static readonly Vector2 Acceleration = new Vector2(2f, 0f);
        private static readonly Vector2 JumpVelocity = new Vector2(0f, 10f);
        private Rigidbody2D _rb;
        private bool _jumping = true;
        private bool _alive = true;
        private Vector3 startPos;

        internal void Start () {
            _rb = GetComponent<Rigidbody2D>();
            startPos = transform.position;
        }

        internal void Update () {
            CheckKeys();
        }

        private void CheckKeys () {
            //if (Input.GetKeyDown(KeyCode.P)) { Game.Ctx.Clock.TogglePause(); }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _alive = true;
                SceneManager.LoadScene("Level");
                ScoreKeeper.ResetScore();
            }

            if (_alive)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    Left();
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Right();
                }
                else
                {
                    _rb.velocity = new Vector2(0f, _rb.velocity.y);
                }
            }
        }

        private void Jump () {
            if (!_jumping) {
                _rb.velocity += JumpVelocity;
            }
            _jumping = true;
        }

        private void Left() {
            _rb.velocity = new Vector2(-5f, _rb.velocity.y);
        }

        private void Right() {
            _rb.velocity = new Vector2(5f, _rb.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            string colliderTag = other.collider.tag;
            if (colliderTag == "Foot" || colliderTag == "Flower") {
                transform.position = startPos;
                _alive = false;
                GetComponent<SpriteRenderer>().enabled = false;
            } else if (colliderTag == "Body") {
                Destroy(other.transform.parent.gameObject);
            }
            _jumping = false;
        }
    }
}
