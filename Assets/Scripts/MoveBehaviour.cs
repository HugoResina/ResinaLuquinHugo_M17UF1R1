
using UnityEngine;
using UnityEngine.Tilemaps;
[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    

    private Rigidbody2D _rb;
    private float speed = 5;
    private SpriteRenderer _spriteRenderer;
    private float lastDir = 0;
    private Animator _animator;
    private bool _isJumping = false;
    private Rigidbody2D BGrb;

   //uso 3 punts per detectar el terra per que sino pots estar en una borera podent saltar i que no et deixi
    [SerializeField] private Transform groundCheckPoint; 
    [SerializeField] private Transform groundCheckPointR; 
    [SerializeField] private Transform groundCheckPointL; 

    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private float groundCheckDistance = 0.15f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
       
    
    }
    private void Update()
    {
        CheckGround();
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
        
        if (!_isJumping)
        {
            _rb.AddForce(new Vector2(0, speed * 100 * dir));
            _rb.gravityScale *= -1f;

            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.y) * (_rb.gravityScale > 0 ? 1 : -1);
            transform.localScale = scale;

            _isJumping = true;
        }

        _animator.SetBool("IsJumping", _isJumping);
      
    }
    private void CheckGround()
    {
        if (_rb == null) return;


        Vector2 origin = groundCheckPoint.position;
        Vector2 originR = groundCheckPointR.position;
        Vector2 originL = groundCheckPointL.position;

        
        Vector2 direction = _rb.gravityScale > 0 ? Vector2.down : Vector2.up;

        
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, groundCheckDistance, groundLayer);
        RaycastHit2D hitR = Physics2D.Raycast(originR, direction, groundCheckDistance, groundLayer);
        RaycastHit2D hitL = Physics2D.Raycast(originL, direction, groundCheckDistance, groundLayer);

      
        bool wasJumping = _isJumping;
        _isJumping = hit.collider == null && hitR.collider == null && hitL.collider == null; 

       
        if (wasJumping != _isJumping) _animator.SetBool("IsJumping", _isJumping);

        
        //Debug.DrawRay(origin, direction * groundCheckDistance, hit.collider != null ? Color.green : Color.red);
        //Debug.DrawRay(originR, direction * groundCheckDistance, hitR.collider != null ? Color.green : Color.red);
        //Debug.DrawRay(originL, direction * groundCheckDistance, hitL.collider != null ? Color.green : Color.red);
        
    }

}
