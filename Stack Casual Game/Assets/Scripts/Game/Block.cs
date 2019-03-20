using UnityEngine; 

public class Block : MonoBehaviour
{
    private Rigidbody2D _blockRB;     
    private float _blockSpeed = 6;
    private float _negative = -1f;

    public enum speedDirection
    {
        forward,
        backward
    }
    public speedDirection currentSpeedDirection;

    public enum blockState 
    {
        idle,
        active
    }
    public blockState currentBlockState;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 2f), Random.Range(0,2f), Random.Range(0, 2f));
        _blockRB = this.GetComponent<Rigidbody2D>();
        _blockRB.gravityScale = 0;
        currentBlockState = blockState.active;

        BlockSpeedSetup();              
    }

    void Update()
    {        
        if (currentBlockState == blockState.active)
        {
            Movement();
        }

        TouchForDropBlock();    
    }

    public void TouchForDropBlock()
    {
        if (Input.touchCount > 0 && currentBlockState == blockState.active)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {                 
                _blockRB.gravityScale = 2;
                currentBlockState = blockState.idle;
                _blockRB.velocity = new Vector2(_blockSpeed / 2, 0);
            }
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && currentBlockState == blockState.active)
        {
            _blockRB.gravityScale = 2;
            currentBlockState = blockState.idle;
            _blockRB.velocity = new Vector2(_blockSpeed / 2, 0);
        }
        
    }

    public void BlockSpeedSetup()
    {
        currentSpeedDirection = (speedDirection)Random.Range(0, 2);
        switch (currentSpeedDirection)
        {
            case speedDirection.forward:
                _blockSpeed = _blockSpeed * (Controller.blockCount / 6 + 1) * 0.4f;
                break;
            case speedDirection.backward:
                _blockSpeed = _blockSpeed * (Controller.blockCount / 6 + 1) * 0.4f * _negative;
                break;
        }
    }

    public void Movement()
    {
        transform.Translate(Vector2.right * _blockSpeed * Time.deltaTime);
        if (transform.position.x >= 3.3  )
        {
            transform.position = new Vector3 (3.29f, transform.position.y, transform.position.z);             
            _blockSpeed = _blockSpeed * _negative;
        }
        if ( this.transform.position.x <= -3.3)
        {
            transform.position = new Vector3(-3.29f, transform.position.y, transform.position.z);
            _blockSpeed = _blockSpeed * _negative;
        }
    }
    
}
