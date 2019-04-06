 using UnityEngine;

public class Floor : MonoBehaviour
{
    private int _collisionCount = 0;
    public static bool IsGameOver=false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Block")
        {
            _collisionCount++;
        }

        if (_collisionCount >= 2)
        {            
            IsGameOver = true;            
        }
    }
}
