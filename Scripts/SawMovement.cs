using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public Transform cameraTransform; // Камерата, която следим
    public float treeWidth = 2f;      // Половината ширина на дървото
    public float yOffset = -2f;       // Офсет по Y

    private bool isOnLeftSide = true; // Позиция на резачката (ляво или дясно)

    void LateUpdate()
    {
        // Резачката следва камерата с офсет по Y
        Vector3 newPosition = transform.position;
        newPosition.y = cameraTransform.position.y + yOffset;
        transform.position = newPosition;

        // Смяна на страната при клик
        if (Input.GetMouseButtonDown(0)) // Ляв бутон на мишката
        {
            ToggleSide();
        }
    }

    void ToggleSide()
    {
        // Променя страната на резачката
        if (isOnLeftSide)
        {
            // Премести се вдясно
            transform.position = new Vector3(treeWidth, transform.position.y, transform.position.z);
        }
        else
        {
            // Премести се вляво
            transform.position = new Vector3(-treeWidth, transform.position.y, transform.position.z);
        }

        // Флипни резачката
        FlipSaw();

        // Обнови текущата позиция
        isOnLeftSide = !isOnLeftSide;
    }

    void FlipSaw()
    {
        // Флипва резачката по оста X
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Обръща знака на X
        transform.localScale = scale;
    }
}
