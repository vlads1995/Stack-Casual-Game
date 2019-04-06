using UnityEngine;

public class Controller : MonoBehaviour
{
    public static float DeltaYPos = 1.5f;
    public static int BlockCount = 0;
    public static bool MoveCamera;

    private float _xPosSpawn =0;
    private float _yPosSpawn = 9;    
    private bool _isSpawnAvailable = true;
    [SerializeField]
    private Block _block;

    private void Start()
    {      
        SpawnNewBlock();         
    }

    private void Update()
    {
        TouchForBlockSpawn();              
    }

    public void TouchForBlockSpawn()
    {
        if ((Input.touchCount > 0) && (_isSpawnAvailable == true))
        {
            BlockCount++;
            _isSpawnAvailable = false;
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Invoke("SpawnNewBlock", 2f);
            }
        }
    }

    public void SpawnNewBlock()
    {        
        _yPosSpawn += DeltaYPos;
        _xPosSpawn = Random.Range(-2.5f, 2.5f);
        Instantiate<Block>(_block, new Vector3(_xPosSpawn, _yPosSpawn, 1), Quaternion.identity);       
        MoveCamera = true;
        _isSpawnAvailable = true;
    }
 
}
