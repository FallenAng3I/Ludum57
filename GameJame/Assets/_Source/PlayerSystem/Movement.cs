using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Rigidbody2D rb;

        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            float moveInput = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            rb.velocity = movement;
        }
    }
}