using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
    [SerializeField] private Block block;
    [SerializeField] private ParticleSystem hitParticle;

    public static float deltaYPos = 1.5f;
    public static int blockCount = 0;
    public static bool moveCamera;

    private float xPosSpawn =0;
    private float yPosSpawn = 9;    
    private bool isSpawnAvailable = true;    

    void Start()
    {      
        SpawnNewBlock();         
    }

    void Update()
    {
        TouchForBlockSpawn();              
    }

    public void TouchForBlockSpawn()
    {
        if (Input.touchCount > 0 && isSpawnAvailable == true)
        {
            blockCount++;
            isSpawnAvailable = false;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Invoke("SpawnNewBlock", 2f);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpawnAvailable = false;
            Invoke("SpawnNewBlock", 2f);
            blockCount++;
        }
        
    }

    public void SpawnNewBlock()
    {        
        yPosSpawn += deltaYPos;
        xPosSpawn = Random.Range(-2.5f, 2.5f);
        Instantiate<Block>(block, new Vector3(xPosSpawn, yPosSpawn, 1), Quaternion.identity);       
        moveCamera = true;
        isSpawnAvailable = true;
    }
 
}
