using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public Transform cameraTransform; 
    public float treeWidth = 2f;      
    public float yOffset = -2f;       

    private bool isOnLeftSide = true; 

    void LateUpdate()
    {
        // Fallow the camera on Y axis
        Vector3 newPosition = transform.position;
        newPosition.y = cameraTransform.position.y + yOffset;
        transform.position = newPosition;

        // Flip the saw if the player clicks
        if (Input.GetMouseButtonDown(0)) 
        {
            ToggleSide();
        }
    }

    void ToggleSide()
    {
        // Move to the right side
        if (isOnLeftSide)
        {
            
            transform.position = new Vector3(treeWidth, transform.position.y, transform.position.z);
        }
        else
        {
            // Move to the left side
            transform.position = new Vector3(-treeWidth, transform.position.y, transform.position.z);
        }

        
        FlipSaw();

        // Toggle the side
        isOnLeftSide = !isOnLeftSide;
    }

    void FlipSaw()
    {
        // Flip the saw
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }
}
