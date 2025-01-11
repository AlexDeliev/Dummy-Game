using UnityEngine;
using System.Collections.Generic;

public class BranchSpawner : MonoBehaviour
{
    public GameObject healthyBranchPrefab;  // Префаб за здрав клон
    public GameObject dryBranchPrefab;      // Префаб за изсъхнал клон
    public float branchOffset = 2f;         // Разстояние на клоните от центъра
    public int branchFrequency = 2;         // На всеки колко сегмента да има клони
    public Transform cameraTransform;       // Камерата, която следим
    public float bufferZone = 2f;           // Допълнително пространство под камерата

    private int segmentCounter = 0;         // Брояч на сегментите
    private List<GameObject> branches = new List<GameObject>(); // Списък с всички клони

    public void SpawnBranches(float yPosition)
{
    // Увеличаваме брояча на сегментите
    segmentCounter++;

    // Добавяме клони само на всеки N-ти сегмент
    if (segmentCounter % branchFrequency == 0)
    {
        // Избираме на случаен принцип кой клон да е отляво и кой отдясно
        bool isHealthyLeft = Random.value > 0.5f;

        // Позиции за клоните
        Vector3 leftBranchPosition = new Vector3(-branchOffset, yPosition, 0);
        Vector3 rightBranchPosition = new Vector3(branchOffset, yPosition, 0);

        // Създаваме клоните и ги добавяме в списъка
        if (isHealthyLeft)
        {
            // Здрав клон отляво, изсъхнал клон отдясно
            GameObject leftBranch = Instantiate(healthyBranchPrefab, leftBranchPosition, Quaternion.identity);
            GameObject rightBranch = Instantiate(dryBranchPrefab, rightBranchPosition, Quaternion.identity);

            // Флипваме десния клон
            FlipBranch(rightBranch, true);
            branches.Add(leftBranch);
            branches.Add(rightBranch);
        }
        else
        {
            // Изсъхнал клон отляво, здрав клон отдясно
            GameObject leftBranch = Instantiate(dryBranchPrefab, leftBranchPosition, Quaternion.identity);
            GameObject rightBranch = Instantiate(healthyBranchPrefab, rightBranchPosition, Quaternion.identity);

            // Флипваме десния клон
            FlipBranch(rightBranch, true);
            branches.Add(leftBranch);
            branches.Add(rightBranch);
        }
    }
}

// Метод за флипване на клони
void FlipBranch(GameObject branch, bool isRightSide)
{
    if (isRightSide)
    {
        // Флипваме клона по оста X
        Vector3 scale = branch.transform.localScale;
        scale.x = -Mathf.Abs(scale.x); // Уверяваме се, че X е отрицателен
        branch.transform.localScale = scale;
    }
    else
    {
        // Уверяваме се, че клонът отляво има положителен X
        Vector3 scale = branch.transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        branch.transform.localScale = scale;
    }
}


    void Update()
    {
        // Премахваме клоните, които са под камерата
        RemoveOldBranches();
    }

    void RemoveOldBranches()
    {
        float cameraBottom = cameraTransform.position.y - bufferZone;

        for (int i = branches.Count - 1; i >= 0; i--)
        {
            if (branches[i].transform.position.y < cameraBottom)
            {
                Destroy(branches[i]);       // Унищожаваме клона
                branches.RemoveAt(i);      // Премахваме го от списъка
            }
        }
    }
    
}
