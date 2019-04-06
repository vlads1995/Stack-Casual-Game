using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    private const float Negative = -1f;

    private Rigidbody2D _blockRb;     
    private float _blockSpeed = 6;

    public enum SpeedDirection
    {
        Forward,
        Backward
    }
    public SpeedDirection CurrentSpeedDirection;

    public enum BlockState 
    {
        Idle,
        Active
    }
    public BlockState CurrentBlockState;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 2f), Random.Range(0,2f), Random.Range(0, 2f));
        _blockRb = this.GetComponent<Rigidbody2D>();
        _blockRb.gravityScale = 0;
        CurrentBlockState = BlockState.Active;

        BlockSpeedSetup();              
    }

    private void Update()
    {        
        if (CurrentBlockState == BlockState.Active)
        {
            Movement();
        }

        TouchForDropBlock();    
    }

    public void TouchForDropBlock()
    {
        const float fallingSpeedCorrector = 2;

        if (Input.touchCount > 0 && CurrentBlockState == BlockState.Active)
        {
            
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {                 
                _blockRb.gravityScale = 2;
                CurrentBlockState = BlockState.Idle;
                _blockRb.velocity = new Vector2(_blockSpeed / fallingSpeedCorrector, 0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && CurrentBlockState == BlockState.Active)
        {
            _blockRb.gravityScale = 2;
            CurrentBlockState = BlockState.Idle;
            _blockRb.velocity = new Vector2(_blockSpeed / fallingSpeedCorrector, 0);
        }
        
    }

    public void BlockSpeedSetup()
    {
        CurrentSpeedDirection = (SpeedDirection)Random.Range(0, 2);
        var changedSpeedWithDifficulty = _blockSpeed * (Controller.BlockCount / 6 + 1) * 0.4f;

        switch (CurrentSpeedDirection)
        {
            case SpeedDirection.Forward:
                _blockSpeed = changedSpeedWithDifficulty;
                break;
            case SpeedDirection.Backward:
                _blockSpeed = changedSpeedWithDifficulty * Negative;
                break;
        }
    }

    public void Movement()
    {
        const float delta = 0.1f;
        const float rightBoundary = 3.3f;
        const float leftBoundary = -3.3f;

        transform.Translate(Vector2.right * _blockSpeed * Time.deltaTime);
        if (transform.position.x >= rightBoundary)
        {
            transform.position = new Vector3 (rightBoundary-delta, transform.position.y, transform.position.z);             
            _blockSpeed = _blockSpeed * Negative;
        }
        if ( this.transform.position.x <= leftBoundary)
        {
            transform.position = new Vector3(leftBoundary+delta, transform.position.y, transform.position.z);
            _blockSpeed = _blockSpeed * Negative;
        }
    }
    
}
