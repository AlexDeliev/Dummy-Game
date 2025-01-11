
using UnityEngine;
using System.Collections.Generic;

public class TreeGrower : MonoBehaviour
{
    public GameObject treeSegmentPrefab; // Префаб за сегментите на дървото
    public Transform cameraTransform;   // Камерата, която следим
    public float segmentHeight = 1f;    // Височината на един сегмент
    public int initialSegments = 5;     // Брой сегменти в началото
    public float bufferZone = 2f;       // Допълнително пространство над камерата
    public BranchSpawner branchSpawner; // Референция към BranchSpawner

    private List<GameObject> treeSegments = new List<GameObject>(); // Списък със сегменти
    private float highestPoint;         // Най-високата точка на дървото

    void Start()
    {
        // Създаваме началните сегменти
        for (int i = 0; i < initialSegments; i++)
        {
            AddSegment(i * segmentHeight);
        }
    }

    void Update()
    {
        // Проверяваме дали трябва да добавим нов сегмент
        if (cameraTransform.position.y + bufferZone > highestPoint)
        {
            AddSegment(highestPoint);
        }

        // Премахваме старите сегменти, ако са под камерата
        RemoveOldSegments();
    }

    void AddSegment(float yPosition)
    {
        // Създаваме нов сегмент
        GameObject newSegment = Instantiate(treeSegmentPrefab, new Vector3(0, yPosition, 0), Quaternion.identity);
        treeSegments.Add(newSegment);
        highestPoint = yPosition + segmentHeight;

        // Спаунваме клони за този сегмент
        branchSpawner.SpawnBranches(yPosition);
    }

    void RemoveOldSegments()
    {
        // Премахваме сегменти, които са под камерата
        float cameraBottom = cameraTransform.position.y - bufferZone;
        for (int i = treeSegments.Count - 1; i >= 0; i--)
        {
            if (treeSegments[i].transform.position.y + segmentHeight < cameraBottom)
            {
                Destroy(treeSegments[i]);
                treeSegments.RemoveAt(i);
            }
        }
    }
}
