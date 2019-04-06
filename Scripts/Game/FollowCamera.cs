using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector2 _currentCameraPos;
    private Vector2 _newCameraPos;

    private void Update()
    {
        _currentCameraPos = new Vector2(transform.position.x, transform.position.y);
         
        if (Controller.MoveCamera == true)
        {
            _newCameraPos = new Vector2(transform.position.x, transform.position.y + Controller.DeltaYPos);
            Controller.MoveCamera = false;           
        }

        if (_currentCameraPos != _newCameraPos)
        {
            var cameraVelocity = new Vector2(0, 2);            
            transform.position = Vector2.SmoothDamp(_currentCameraPos, _newCameraPos, ref cameraVelocity, 1);
        }
        
     }
}
