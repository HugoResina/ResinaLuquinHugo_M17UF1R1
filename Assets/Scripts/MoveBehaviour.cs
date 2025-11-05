
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float speed = 5;
    private SpriteRenderer _spriteRenderer;
    private float lastDir = 0;
    private Animator _animator;
    //private bool _isJumping = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void MoveCharacter(Vector2 direction)
    {
       
        
        _rb.linearVelocity = new Vector2(direction.x * speed, _rb.linearVelocityY);
        
        if(direction.x != 0)
        {
            lastDir = direction.x;
            _animator.SetBool("IsMoving", true);


        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

            _spriteRenderer.flipX = lastDir < 0 ? true : false;






    }
    public void Jump(float dir)
    {
        
        _rb.AddForce(new Vector2(0, speed * 100 * dir));
        _rb.gravityScale *= -1f;
        _spriteRenderer.flipY = _rb.gravityScale < 0 ? true : false;


    }
   
}
