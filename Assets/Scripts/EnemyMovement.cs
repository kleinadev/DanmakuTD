using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Path {private get; set; }
    private float moveSpeed;
    private int currentPathNode;
    private int finalPathNode;
    private Vector3[] pathNodes;

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
        if (transform.position != pathNodes[currentPathNode])
        {
            transform.position = Vector3.MoveTowards(transform.position, pathNodes[currentPathNode], moveSpeed);
        }
        else if (currentPathNode != finalPathNode) {
            currentPathNode = (currentPathNode + 1);
        }
        else if (currentPathNode == finalPathNode)
        {
            //trigger damage to health
        }
    }

    private Vector3[] FindPathNodes(Transform path)
    {
        Vector3[] nodesList = new Vector3[path.childCount];
        for (int i = 0; i < path.childCount; i++)
        {
            var child = path.GetChild(i);
            nodesList[i] = path.GetChild(i).position;
        }
        return nodesList;
    }
}
