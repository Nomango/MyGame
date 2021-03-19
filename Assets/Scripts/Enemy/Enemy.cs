using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public Transform pointA, pointB;
    public Transform targetPoint;

    public List<Transform> attackList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        FilpDirection();
    }

    public void AttackAction()
    {

    }

    public void SkillAction()
    {

    }

    public void FilpDirection()
    {

    }
}
