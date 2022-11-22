using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{ 
    [SerializeField]
    private float _enemySpeed = 4f;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0 , 4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    //Methods
    void EnemyMovement()
    { 
     transform.Translate (Vector3.down * _enemySpeed * Time.deltaTime);

        if (transform.position.y <= -5.5f)
        {
            float randomX = Random.Range(-10f, 10f);
            transform.position = new Vector3(randomX, 7.4f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.transform.name);

        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        else if (other.tag == "PlayerLaser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
        }

    }

    void EnemySpawn()
    { 
    
    }
}
