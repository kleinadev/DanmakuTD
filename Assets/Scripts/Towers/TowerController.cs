using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public ITowerBehavior Behavior;
    private List<GameObject> EnemiesInRange = new List<GameObject> { };

    // Start is called before the first frame update
    void Start()
    {
        if (Behavior == null)
        {
            Behavior = (ITowerBehavior) GetComponent(typeof(ITowerBehavior));
        }
        GetComponent<CircleCollider2D>().radius = Behavior.Range;
    }

    // Update is called once per frame
    void Update()
    {
        Behavior.Cooldown -= Time.deltaTime;
        if (Behavior.Cooldown <= 0)
        {
            var nextTarget = GetNextTarget();
            if (nextTarget != null)
            {
                Behavior.FireBullet(nextTarget);
            }
        }
    }

    private GameObject GetNextTarget()
    {
        if (EnemiesInRange.Count > 0)
        {
            return EnemiesInRange[0];
        }
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemiesInRange.Remove(collision.gameObject);
        }
    }
}
