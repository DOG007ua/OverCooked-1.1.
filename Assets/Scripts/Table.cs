using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject positionTake;
    public GameObject PositionTake { get { return positionTake; } set { positionTake = value; } }
    public GameObject TakeObj { get; set; }
    public ICanTake TakeObjClass { get; set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int A1 = 0;
    }

    public void Take(GameObject obj, ICanTake take)
    {
        obj.transform.SetParent(PositionTake.transform);
        obj.transform.localPosition = new Vector3(0, 0, 0);
        take.OnStayObj.Leave();
        TakeObj = obj;
        TakeObjClass = take;
    }

    public void Leave()
    {
        TakeObj = null;
        TakeObjClass = null;
    }
}
