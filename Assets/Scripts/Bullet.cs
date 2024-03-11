using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 50;
    float damage = 100;


    //visual fx 
    [SerializeField]
    ParticleSystem particle;
    MeshRenderer bulletMesh;

  //  Self destroy funsction
    float timer = 0;
    float timerTotal = 3;
    bool isBulletTriggered = false;



    // Start is called before the first frame update
    private void Start()
    {
        bulletMesh = GetComponent<MeshRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBulletTriggered)
        {
            if (timer > timerTotal)
            {

                BulletTriggered();
            }
            else
            {
                //while moving thru air
                
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);// moves based on its own direction + rotation
                timer += Time.deltaTime;

            }
        }
    }

    void BulletTriggered() //when bulet hits something
    {
        isBulletTriggered = true;
        bulletMesh.enabled = false;
        //Play particle system after 2 secs
        Invoke("DestroySelf", 2);

    }

    void DestroySelf()
    {
        SpawnerManager.instance.RemoveBullet(this);
        Destroy(gameObject);
    }

    //when shooting enemy
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if(!isBulletTriggered && !other.CompareTag("Player") && !other.CompareTag("Bullet")) //&& !other.CompareTag("MovingPlatform") && !other.CompareTag("Environment")) //excluding contact w player + other bullets + platform
         {
            BulletTriggered();
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("ENEMY HIT!!!!");
                var enemy = other.GetComponent<EnemySettings>();
                enemy.Damaged(damage);
                particle.Play();
            }




         }

    }


}
