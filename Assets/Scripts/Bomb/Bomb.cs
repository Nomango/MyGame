using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator anim;
    private Collider2D collider;
    private Rigidbody2D rigidbody;

    public float startTime;
    public float waitTime;
    public float bombForce;

    [Header("Check")]
    public float radius;
    public LayerMask targetLayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > startTime + waitTime)
        {
            anim.Play("BombExplotion");
        }
    }

    public void Explotion()
    {
        collider.enabled = false;
        rigidbody.gravityScale = 0;

        Collider2D[] aroundObjects = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var item in aroundObjects)
        {
            Vector3 pos = transform.position - item.transform.position;
            item.GetComponent<Rigidbody2D>().AddForce((-pos + Vector3.up) * bombForce, ForceMode2D.Impulse);
        }

        collider.enabled = true;
        rigidbody.gravityScale = 1;
    }

    public void DestroyBomb()
    {
        Destroy(gameObject);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
