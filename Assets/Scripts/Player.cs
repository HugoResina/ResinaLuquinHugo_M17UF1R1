using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;
[RequireComponent (typeof (MoveBehaviour))]
public class Player : MonoBehaviour, IPlayerActions

    
{
    private MoveBehaviour _mb;
    private Rigidbody2D _rb;
    private InputSystem_Actions inputAction;

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

    }

    private void OnDisable()
    {
        inputAction.Disable();

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        
        _mb.Jump(_rb.gravityScale);
        _rb.gravityScale *= -1f;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        dir.y = 0;
        _mb.MoveCharacter(dir);
    }

    void Update()
    {

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
