using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    public Transform m_Nucleus;

    Vector3 nucleus;
    Vector2 positionNextTile;
    RaycastHit2D[] nextTile;
    LayerMask walkableTileMask;


    void Awake()
    {
        walkableTileMask = 1 << 8;
        nucleus = m_Nucleus.position;

    }

    void Start()
    {
        SetNextTilePosition();
        Debug.Log(positionNextTile);
    }

    
    void SetNextTilePosition()
    {
        nextTile = Physics2D.BoxCastAll(transform.position, new Vector2(transform.localScale.x, transform.localScale.y), 0f, new Vector2(), 0f, walkableTileMask);


        
        float minDistance = 100;

        for (int i =  0; i< nextTile.Length; i++)
        {
            if (nextTile[i].collider.gameObject != this.gameObject)
            {
                float distance = Mathf.Abs(nucleus.x - nextTile[i].collider.transform.position.x)  + Mathf.Abs(nucleus.y - nextTile[i].collider.transform.position.y);
                
                if ( (Mathf.Abs(nextTile[i].collider.transform.position.x - this.transform.position.x) + Mathf.Abs(nextTile[i].collider.transform.position.y - this.transform.position.y)) <= 1) 
                {
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        positionNextTile = nextTile[i].collider.transform.position;

                    }

                }
            }
         }
     }



    public Vector2 GetNextTilePosition()
    {
        return positionNextTile;
    }

    

}
