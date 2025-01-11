using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground_Y : MonoBehaviour
{
    public bool Camera_Move;
    public float Camera_MoveSpeed = 1.5f;

    [Header("Layer Setting")]
    public float[] Layer_Speed = new float[7];
    public GameObject[] Layer_Objects = new GameObject[7];

    public float cameraOffsetY = 0; // Нова променлива за позицията по Y на камерата

    private Transform _camera;
    private float[] startPos = new float[7];
    private float[] boundsSizeY = new float[7]; // Променена на Y
    private float[] layerHeights = new float[7]; // Променена на Y
    private Camera mainCamera;
    private float camHeight;
    private float camWidth;

    void Start()
    {
        mainCamera = Camera.main;
        camHeight = 2f * mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;

        _camera = mainCamera.transform;
        for (int i = 0; i < Layer_Objects.Length; i++)
        {
            if (Layer_Objects[i] != null)
            {
                startPos[i] = Layer_Objects[i].transform.position.y; // Позицията по Y
                boundsSizeY[i] = Layer_Objects[i].GetComponent<SpriteRenderer>().bounds.size.y; // Височина на спрайта
                layerHeights[i] = Layer_Objects[i].transform.localScale.y * boundsSizeY[i]; // Височина на слоя
            }
        }
    }

    void LateUpdate()
    {
        // Move camera
        if (Camera_Move)
        {
            _camera.position += Vector3.up * Time.deltaTime * Camera_MoveSpeed; // Придвижване на камерата по Y
        }

        for (int i = 0; i < Layer_Objects.Length; i++)
        {
            if (Layer_Objects[i] != null)
            {
                float temp = (_camera.position.y * (1 - Layer_Speed[i]));
                float distance = _camera.position.y * Layer_Speed[i];

                // Calculate new position within camera bounds
                Vector3 newPosition = new Vector3(Layer_Objects[i].transform.position.x, startPos[i] + distance, Layer_Objects[i].transform.position.z); // Добавен offset по Y

                // Constrain newPosition to be within camera bounds
                newPosition.y = Mathf.Clamp(newPosition.y, _camera.position.y + cameraOffsetY - camHeight / 2, _camera.position.y + cameraOffsetY + camHeight / 2);

                Layer_Objects[i].transform.position = newPosition;

                if (temp > startPos[i] + layerHeights[i])
                {
                    startPos[i] += layerHeights[i];
                }
                else if (temp < startPos[i] - layerHeights[i])
                {
                    startPos[i] -= layerHeights[i];
                }
            }
        }
    }
}
