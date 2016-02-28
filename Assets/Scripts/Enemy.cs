using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public LayerMask m_Mask;
    public Vector2 target;
    public float Speed;
    public float life;
    public float banishmentCost;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TakeTarget();
        Move();
        if (life <= 0)
        {
            Destroy(gameObject);
        }
	}

    void TakeTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(), 0f, m_Mask, 0f, 2f);
        if (hit.collider != null)
        {

            target = hit.collider.GetComponent<Tile>().GetNextTilePosition();
            Debug.Log(target);
        }
    }
    void Move()
    {
        transform.LookAt(target);
        transform.Translate(Speed * transform.forward * Time.deltaTime);
    }
}
