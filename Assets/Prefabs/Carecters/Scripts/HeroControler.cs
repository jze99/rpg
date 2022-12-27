using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroControler : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    HeroInventory heroInventory;
    public float spead;
    public float distans;
    public Vector3 target;
    public string act;
    void Start()
    {
        agent =GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        heroInventory=GetComponent<HeroInventory>();
    }
    void Update()
    {
        switch(act)
        {
            case "Move": 
                Move();
            break;
        }
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 100f))
            {
                ClickUpdate(hit);
            }
        }
    }
    void ClickUpdate(RaycastHit _hit)
    {
        if(_hit.transform.tag=="Ground")
        {
            target=_hit.point;
            act="Move";
        }
        else if(_hit.transform.tag=="Item")
        {
            TakeItem(_hit);
        }
    }
    void Move()
    {
        distans=Vector3.Distance(transform.position,target);
        anim.SetFloat("Spead",spead);
        spead=Mathf.Clamp(spead,0,1);
        if(distans>0.5f)
        {
            agent.SetDestination(target);
            agent.isStopped=false;
            spead+=2*Time.deltaTime;
            anim.SetBool("Walk",true);
        }
        else if(distans<=0.5f)
        {
            spead-=5*Time.deltaTime;  
            if(spead<=0.2f)
            {
                anim.SetBool("Walk",false);
                agent.isStopped=true;
                act="";
            }
        }
    }
    void TakeItem(RaycastHit _item)
    {
        distans=Vector3.Distance(transform.position+transform.up,_item.transform.position);
        if(distans<4)
        {
            heroInventory.item.Add(_item.transform.GetComponent<Item>());
            Destroy(_item.transform.gameObject);
        }
        else
        {
            print("Далеко");
        }
    }
}
