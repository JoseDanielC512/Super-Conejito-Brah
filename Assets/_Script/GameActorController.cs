/*
Descripcion: Clase base para definir el comportamiento de los actores del juego
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class GameActorController : MonoBehaviour
{
    #region Inspector Properties

        [SerializeField] protected float movementSpeed = 4f; //Velocidad de movimiento del actor
        [SerializeField] protected float jumpForce = 2f; // Define la fuerza del salto del actor
        
        [Range(0,2)]
        [SerializeField] protected float groundCheckDistance = 1f;
        [SerializeField] protected LayerMask whatIsGround;


    #endregion

    #region Private Properties

    protected Rigidbody2D _rigidBody2D;
    protected Transform _transform;
    protected Animator _animator;
    protected AudioSource _audiosource;
    protected BoxCollider2D _boxcollider;
    protected SpriteRenderer _sprite;


    protected bool _isGrounded = true;
    protected bool _isRunning = false;
    protected bool _isAttacking = false;
    protected bool _isJumping = false;
    protected float _vx;
    protected float _vy;

    #endregion

    void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audiosource = GetComponent<AudioSource>();
        _boxcollider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        if (_transform == null)
            Debug.LogError("Missing component !");
        if (_rigidBody2D == null)
            Debug.LogError("Missing component !");
        if (_animator == null)
            Debug.LogError("Missing component !");
        if (_audiosource == null)
            Debug.LogError("Missing component !");
        if (_boxcollider == null)
            Debug.LogError("Missing component !");
        if (_sprite == null)
            Debug.LogError("Missing component !");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update() // Actualizar el estado del personaje
    {
        //  Comprobar si estamos tocando el piso
        
        DoGroundCheck(_transform.position, new Vector2(_transform.position.x, _transform.position.y-groundCheckDistance));
        _vy=_rigidBody2D.velocity.y;
        DoAnimation();
        
        
        
    }

    protected void FixedUpdate(){    
        DoMove();
        if (_isJumping && _isGrounded)
        {
            DoJump();
        }

    }
    protected void DoJump()
    {    
        _vy = 0;
        _rigidBody2D.AddForce(new Vector2(0, jumpForce));  
        _isJumping = false;
    }

    protected void DoMove() // Metodo para que el personaje se mueva
    {
        _rigidBody2D.velocity = new Vector2(_vx*movementSpeed, _vy);

        if(_vx != 0)
            _isRunning = true;
        else
            _isRunning = false;
    }

    void DoAnimation()
    {
        Flip();
        _animator.SetBool("IsRunning", _isRunning);
        if (!_isGrounded)
        {
            _animator.SetTrigger("IsJumping");
        }
        _animator.SetBool("IsGrounded", _isGrounded);

        
    }
    void Flip(){
        if (_vx < 0)
        {
           _sprite.flipX = true; 
        }
        else if (_vx > 0)
        {
            _sprite.flipX = false;
        }        
    }

    void DoGroundCheck(Vector3 start, Vector3 end){
        _isGrounded = Physics2D.Linecast(start, end, whatIsGround);
        Debug.DrawLine(start, end, Color.red);
    }
}
