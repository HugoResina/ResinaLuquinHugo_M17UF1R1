using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (MoveBehaviour))]
public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions

    
{
    private MoveBehaviour _mb;
    private Rigidbody2D _rb;
    private InputSystem_Actions inputAction;
    private Vector2 _dir;
    [SerializeField] private Transform RespawnPoint;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        inputAction = new InputSystem_Actions();
        inputAction.Player.SetCallbacks(this);
        _mb = GetComponent<MoveBehaviour>();
       
    }

    private void OnEnable()
    {
        inputAction.Enable();
        HurtBehaviour.OnPlayerHurt += OnPlayerHurt;

    }

    private void OnDisable()
    {
        inputAction.Disable();
        HurtBehaviour.OnPlayerHurt -= OnPlayerHurt;

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed) 
        _mb.Jump(_rb.gravityScale);
      
       

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _dir = context.ReadValue<Vector2>();
        //_dir.y = _rb.linearVelocityY;


    }
    private void OnPlayerHurt(GameObject player)
    {
        //teletransporta
        player.transform.position = RespawnPoint.position;
        
        _rb.gravityScale = 1f;

        Vector3 scale = transform.localScale;
        scale.y = Mathf.Abs(scale.y) * (_rb.gravityScale > 0 ? 1 : -1);
        transform.localScale = scale;

        _rb.linearVelocity = Vector2.zero;

    }

    void Update()
    {
        _mb.MoveCharacter(_dir);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
