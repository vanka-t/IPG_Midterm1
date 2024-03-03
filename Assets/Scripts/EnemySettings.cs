using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySettings : MonoBehaviour
{
    protected NavMeshAgent nav;
    protected Transform target;

    //current health
    protected float hp = 0;
    //Total health
    [SerializeField]
    protected float hpTotal = 100;
    private float timer = 0f;
    [SerializeField]
    private float timerTotal = 1f;


    // Start is called before the first frame update
    protected virtual void Start() //protected virtual = enables overriding it in later scripts
    {
        hp = hpTotal;
        nav = GetComponent<NavMeshAgent>();

        //Temp
        //nav.SetDestination(Vector3.zero);

        target = GameManager.instance.player;

        
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        TimerTool();
        nav.SetDestination(target.position); //target.position
    }


    //basic manual timer
    private void TimerTool()
    {
        if(timer> timerTotal)
        {
            timer = 0;
            TimerContent();
        }
        else
        {
            timer += Time.deltaTime;
        }

    }


    protected virtual void TimerContent()
    {

    }


    protected virtual void Damaged(float damage)
    {
        hp = Mathf.Max(0, hp - damage);
        if(hp == 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
