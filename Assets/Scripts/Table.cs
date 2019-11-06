using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, IToTake
{
    public GameObject positionTake;
    public GameObject PositionTake { get { return positionTake; } set { positionTake = value; } }
    public ICanTake TakeObjClass { get; set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Take(ICanTake take)
    {
        if (TakeObjClass != null) return;
        take.GameObj.transform.SetParent(PositionTake.transform);
        take.LeaveStayObj();
        TakeObjClass = take;
        take.OnStayObj = this;
    }

    public void Leave()
    {
        TakeObjClass = null;
    }
}
