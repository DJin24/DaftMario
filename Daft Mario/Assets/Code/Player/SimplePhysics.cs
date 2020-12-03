using UnityEngine;

namespace Assets.Code.Player
{
    /// <inheritdoc />
    /// <summary>
    /// Class for simulating the player's physics
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class SimplePhysics : MonoBehaviour
    {
        public static readonly Vector2 Gravity = new Vector2(0f, -9.8f);

        public static float TimeScale { get; private set; }
        public static void Pause () { TimeScale = 0f; }
        public static void Unpause () { TimeScale = 1f; }

        public Material DebugMaterial;

        public delegate void OnCollision (Collider2D other);
        public event OnCollision CollisionDown = other => { }; // fill it in with an empty one at first

        private Rigidbody2D _rb;
        private LayerMask _mask;
        private DebugHUD _hud;

        private Vector2 _velocity;

        internal void Start () {
            _rb = GetComponent<Rigidbody2D>();
            _mask = LayerMask.GetMask("Platforms");
            _velocity = Vector2.right;

            _hud = new DebugHUD(DebugMaterial);

            Unpause();
        }

        internal void FixedUpdate () {
            AddVelocity(Gravity * Time.deltaTime);
            ProcessCollision();
            _rb.position += _velocity * Time.deltaTime * TimeScale;
        }


        /// <summary>
        /// Called whenever our player hits anything. Handles collisions by adjusting velocity.
        /// We're working under the assumption that everything that we hit is square.
        /// </summary>
        private void ProcessCollision () {
            RaycastHit2D hitHorizontal = Physics2D.BoxCast(_rb.position,
                new Vector2(gameObject.GetComponent<BoxCollider2D>().size.x,
                    gameObject.GetComponent<BoxCollider2D>().size.y / 2),
                _rb.rotation,
                new Vector2(_velocity.x, 0f), _velocity.x * Time.deltaTime,
                _mask);
            if (hitHorizontal.collider != null) {
                _velocity.x = 0;
            }
            RaycastHit2D hitVertical = Physics2D.BoxCast(_rb.position,
                new Vector2(gameObject.GetComponent<BoxCollider2D>().size.x / 2,
                    gameObject.GetComponent<BoxCollider2D>().size.y),
                _rb.rotation,
                new Vector2(0f, _velocity.y), _velocity.y * Time.deltaTime,
                _mask);
            if (hitVertical.collider != null) {
                CollisionDown.Invoke(hitVertical.collider);
                if (_velocity.y < 0) {
                    _velocity.y = 0;
                }
            }
        }

        /// <summary>
        /// Increase _velocity by some value
        /// </summary>
        /// <param name="value">The amount by which to increase the velocity</param>
        public void AddVelocity (Vector2 value) { _velocity += value * TimeScale; }

        internal void OnGUI () {
            var val = _velocity.normalized * 50f; // 50 pixel long vector in the direction of _velocity
            _hud.DrawArrow(val);
            _hud.DrawMagnitude(_velocity.magnitude);
        }

        /// <summary>
        /// Helper class to draw lines, etc. on the screen
        /// </summary>
        private class DebugHUD
        {
            private static readonly Vector2 HUDCorner = new Vector2(20f, 200f);
            private static readonly Vector3 ArrowStart = HUDCorner + new Vector2(50f, 50f);

            private readonly Material _mat;
            public DebugHUD (Material mat) { _mat = mat; }

            public void DrawArrow (Vector3 value)
            {
                Vector3 ArrowEnd = ArrowStart + value;
                _mat.SetPass(0);
                
                GL.PushMatrix();
                GL.LoadPixelMatrix();
                
                GL.Begin(GL.LINES);
                GL.Color(Color.red);
                GL.Vertex(ArrowStart);
                GL.Vertex(ArrowEnd);
                GL.End();
                
                GL.Begin(GL.TRIANGLES);
                GL.Color(Color.red);
                Vector3 perpendicular = new Vector3(-value.y, value.x) * 0.15f;
                GL.Vertex(ArrowEnd);
                GL.Vertex(ArrowStart + value * 0.7f + perpendicular);
                GL.Vertex(ArrowStart + value * 0.7f - perpendicular);
                GL.End();
                
                GL.PopMatrix();
            }

            public void DrawMagnitude (float magnitude) {
                _mat.SetPass(0);
                
                GL.PushMatrix();
                GL.LoadPixelMatrix();
                
                GL.Begin(GL.QUADS);
                GL.Color(Color.red);
                GL.Vertex(HUDCorner + new Vector2(0, magnitude));
                GL.Vertex(HUDCorner + new Vector2(10, magnitude));
                GL.Vertex(HUDCorner + new Vector2(10, 0));
                GL.Vertex(HUDCorner);
                GL.End();

                GL.PopMatrix();
            }
        }
    }
}
