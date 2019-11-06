using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Models
{ 

}

public interface ICanTake
{
    GameObject GameObj { get; }
    /// <summary>
    /// На чем стоит
    /// </summary>
    IToTake OnStayObj { get; set; }
    /// <summary>
    /// тут тот, на ком он стоит, отписывается
    /// </summary>
    void LeaveStayObj();
}

/// <summary>
/// Может взять кого-то
/// </summary>
public interface IToTake
{
    GameObject PositionTake { get; set; }
    /// <summary>
    /// Кто на нём
    /// </summary>
    ICanTake TakeObjClass { get; set; }

    void Take(ICanTake take);
    void Leave();

    
}

public class Product : MonoBehaviour, ICanTake
{
    public GameObject GameObj { get { return this.gameObject; } }
    /// <summary>
    /// На чем стоит
    /// </summary>
    public IToTake OnStayObj { get; set; }
    /// <summary>
    /// тут тот, на ком он стоит, отписывается
    /// </summary>
    public void LeaveStayObj()
    {
        GameObj.transform.localPosition = new Vector3(0, 0, 0);
        if (OnStayObj != null)
        {
            OnStayObj.TakeObjClass = null;
            OnStayObj = null;
        }
    }


    private void Awake()
    {
        GameObj.transform.localPosition = new Vector3(0, 0, 0);
    }
}


public class Posuda : MonoBehaviour, ICanTake, IToTake
{
    public GameObject GameObj { get { return this.gameObject; } }
    /// <summary>
    /// На чем стоит
    /// </summary>
    public IToTake OnStayObj { get; set; }
    /// <summary>
    /// тут тот, на ком он стоит, отписывается
    /// </summary>
    public void LeaveStayObj()
    {
        GameObj.transform.localPosition = new Vector3(0, 0, 0);
        if (OnStayObj != null)
        {
            OnStayObj.TakeObjClass = null;
            OnStayObj = null;
        }
    }

    private void Awake()
    {
        GameObj.transform.localPosition = new Vector3(0, 0, 0);
    }



    public GameObject positionTake;     //+
    public GameObject PositionTake { get { return positionTake; } set { positionTake = value; } }   //+
    /// <summary>
    /// Кто на нём
    /// </summary>
    public ICanTake TakeObjClass { get; set; }

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


