using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;
    private PlayerItems playerItems;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;
    private bool _isAttacking;



    private Vector2 _direction;

    [HideInInspector] public int handlingObj;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }
    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }
    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }
    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    public bool IsAttacking { get => _isAttacking; set => _isAttacking = value; }

    private void Start() 
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();
        initialSpeed = speed;
    }
    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObj = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObj = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                handlingObj = 3;
            }

            OnInput();
            OnRun();
            OnRoll();
            OnCut();
            OnDig();
            OnWatering();
            OnAttacking();
        }
        
    }
    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
    }

    #region Movement

    void OnAttacking()
    {
        if (handlingObj == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsAttacking = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsAttacking = false;
                speed = initialSpeed;
            }
        }
    }

    void OnWatering()
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItems.CurrentWater > 0)
            {
                isWatering = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0) || playerItems.CurrentWater < 0)
            {
                isWatering = false;
                speed = initialSpeed;
            }
            if (isWatering)
            {
                playerItems.CurrentWater -= 0.01f;
            }
        }
    }
    void OnCut()
    {
        if(handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCutting = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
    }

    void OnDig()
    {
        if(handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDigging = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDigging = false;
                speed = initialSpeed;
            }
        }
    }

    void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void OnMove()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }
    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }
    void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
            speed = runSpeed;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
            speed = initialSpeed;
        }
    }

    #endregion
}
