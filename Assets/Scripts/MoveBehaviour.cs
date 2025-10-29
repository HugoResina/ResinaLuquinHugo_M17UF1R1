
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 2;
    //private bool _isJumping = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector2 direction)
    {
        //_rb.AddForce(direction.normalized * speed * 30);
        _rb.linearVelocity = new Vector2(direction.x * speed, _rb.linearVelocityY);
    }
    public void Jump(float dir)
    {
        
        _rb.AddForce(new Vector2(0, speed * 100 * dir));
        //_isJumping = true;
        
    }
   
}
