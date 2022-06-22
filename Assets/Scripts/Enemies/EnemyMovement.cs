using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Path {private get; set; }
    private float moveSpeed;
    private int currentPathNode;
    private int finalPathNode;
    private Vector2[] pathNodes;

    // Start is called before the first frame update
    private void Start()
    {
        currentPathNode = 0;
        pathNodes = FindPathNodes(Path.transform);
        finalPathNode = Path.transform.childCount - 1;
        moveSpeed = GetComponent<EnemyModel>().MoveSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        if ((Vector2)transform.position != pathNodes[currentPathNode])
        {
            transform.position = Vector2.MoveTowards(transform.position, pathNodes[currentPathNode], moveSpeed);
        }
        else if (currentPathNode != finalPathNode) {
            currentPathNode = (currentPathNode + 1);
        }
        else if (currentPathNode == finalPathNode)
        {
            //trigger damage to health
        }
    }

    private Vector2[] FindPathNodes(Transform path)
    {
        Vector2[] nodesList = new Vector2[path.childCount];
        for (int i = 0; i < path.childCount; i++)
        {
            var child = path.GetChild(i);
            nodesList[i] = path.GetChild(i).position;
        }
        return nodesList;
    }
}
