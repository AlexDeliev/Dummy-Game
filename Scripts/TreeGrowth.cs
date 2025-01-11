
using UnityEngine;
using System.Collections.Generic;

public class TreeGrower : MonoBehaviour
{
    public GameObject treeSegmentPrefab; 
    public Transform cameraTransform;   
    public float segmentHeight = 1f;    
    public int initialSegments = 5;     
    public float bufferZone = 2f;       
    public BranchSpawner branchSpawner; 

    private List<GameObject> treeSegments = new List<GameObject>(); // List of segments
    private float highestPoint;        

    void Start()
    {
        // Creating initial segments
        for (int i = 0; i < initialSegments; i++)
        {
            AddSegment(i * segmentHeight);
        }
    }

    void Update()
    {
        // Checking if we need to add a new segment
        if (cameraTransform.position.y + bufferZone > highestPoint)
        {
            AddSegment(highestPoint);
        }

        // Removing old segments
        RemoveOldSegments();
    }

    void AddSegment(float yPosition)
    {
        // Creating a new segment
        GameObject newSegment = Instantiate(treeSegmentPrefab, new Vector3(0, yPosition, 0), Quaternion.identity);
        treeSegments.Add(newSegment);
        highestPoint = yPosition + segmentHeight;

        // Spawning branches
        branchSpawner.SpawnBranches(yPosition);
    }

    void RemoveOldSegments()
    {
        // Removing segments that are below the camera
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
