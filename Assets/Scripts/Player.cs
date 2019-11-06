using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IToTake
{

    float speed = 5f;
    public GameObject positionTake;     //+
    public GameObject PositionTake { get { return positionTake; } set { positionTake = value; } }   //+
    public ICanTake TakeObjClass { get; set; }      //+

    bool act = false;
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () 
    {
        act = false;;
        KeyDown();
    }

    public void Take(ICanTake take)
    {

        take.GameObj.transform.SetParent(PositionTake.transform);
        //take.GameObj.transform.localPosition = new Vector3(0, 0, 0);
        //take.OnStayObj.Leave();
        take.LeaveStayObj();
        TakeObjClass = take;
    }

    public void Leave()
    {
        TakeObjClass = null;
    }

    void RotateUp()
    {
        this.transform.rotation = new Quaternion(0, 0.7f, 0, -0.7f  );
        Move();
    }

    void RotateDown()
    {
        transform.rotation = new Quaternion(0, 0.7f, 0, 0.7f);
        Move();
    }

    void RotateLeft()
    {
        this.transform.rotation = new Quaternion(0, 1, 0, 0);
        Move();
    }

    void RotateRigth()
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        Move();
    }

    private void Move()
    {
        transform.position += transform.right * speed  * Time.deltaTime;
    }

    void KeyDown()
    {
        if (Input.GetKey(KeyCode.W))
        {
            RotateUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RotateDown();
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRigth();
        }
    }

    void InteractionKey(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q) && !act)
        {
            if (TakeObjClass == null)
            {
                IsTake(other);
            }
            else
            {
                IsPut(other);
            }            
        }
    }

    void IsTake(Collider other)
    {
        ICanTake take = other.gameObject.GetComponent(typeof(ICanTake)) as ICanTake;
        if (take != null)
        {
            take.Take(this.gameObject);
            act = true;
        }        
    }

    void IsPut(Collider other)
    {
        IToTake take = other.gameObject.GetComponent(typeof(IToTake)) as IToTake;
        if (take != null)
        {
            take.Take(TakeObj, TakeObjClass);
            act = true;
            //TakeObjClass.Take(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        InteractionKey(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    
}
