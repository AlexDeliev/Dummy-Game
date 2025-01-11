using UnityEngine;
using System.Collections.Generic;

public class BranchSpawner : MonoBehaviour
{
    public GameObject healthyBranchPrefab;  
    public GameObject dryBranchPrefab;      
    public float branchOffset = 2f;        
    public int branchFrequency = 2;         
    public Transform cameraTransform;       
    public float bufferZone = 2f;           

    private int segmentCounter = 0;         
    private List<GameObject> branches = new List<GameObject>(); 

    public void SpawnBranches(float yPosition)
    {
        // Increase the segment counter
        segmentCounter++;

        // Add branches to the tree on evry 3th segment
        if (segmentCounter % branchFrequency == 0)
        {
            // Randomize the health of the branches
            bool isHealthyLeft = Random.value > 0.5f;

            // Calculate the position of the branches
            Vector3 leftBranchPosition = new Vector3(-branchOffset, yPosition, 0);
            Vector3 rightBranchPosition = new Vector3(branchOffset, yPosition, 0);

            // Spawn the branches
            if (isHealthyLeft)
            {
                // Healthy branch on the left, dry branch on the right
                GameObject leftBranch = Instantiate(healthyBranchPrefab, leftBranchPosition, Quaternion.identity);
                GameObject rightBranch = Instantiate(dryBranchPrefab, rightBranchPosition, Quaternion.identity);

                // Flip the right branch
                FlipBranch(rightBranch, true);
                branches.Add(leftBranch);
                branches.Add(rightBranch);
            }
            else
            {
                // Dry branch on the left, healthy branch on the right
                GameObject leftBranch = Instantiate(dryBranchPrefab, leftBranchPosition, Quaternion.identity);
                GameObject rightBranch = Instantiate(healthyBranchPrefab, rightBranchPosition, Quaternion.identity);

                // Flip the left branch
                FlipBranch(rightBranch, true);
                branches.Add(leftBranch);
                branches.Add(rightBranch);
            }
        }
    }

    // Flip the branch method
    void FlipBranch(GameObject branch, bool isRightSide)
    {
        if (isRightSide)
        {
            // flip the branch on x axis
            Vector3 scale = branch.transform.localScale;
            scale.x = -Mathf.Abs(scale.x); 
            branch.transform.localScale = scale;
        }
        else
        {
            // flip the branch on x axis if it is on the left side
            Vector3 scale = branch.transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            branch.transform.localScale = scale;
        }
    }


    void Update()
    {
        // Remove old branches
        RemoveOldBranches();
    }

    void RemoveOldBranches()
    {
        float cameraBottom = cameraTransform.position.y - bufferZone;

        for (int i = branches.Count - 1; i >= 0; i--)
        {
            if (branches[i].transform.position.y < cameraBottom)
            {
                Destroy(branches[i]);       // Destroy the branch
                branches.RemoveAt(i);      // Remove the branch from the list
            }
        }
    }
    
}
