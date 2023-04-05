using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FeedBack", menuName = "Singletons/LavaFeedBack")]
public class FeedBackLavaDamage : ScriptableObject
{
    #region Expose
    public UnityEvent _feedBackEnd;
    #endregion

    #region Unity Life Cycle
    private void Awake()
    {
        //PlayerHealth.Instance._damageReceived.AddListener(LavaDamageCallBack);
    }
    #endregion

    #region methods
    public void LavaDamageCallBack()
    {
        Debug.Log("FeedBack");
        GameObject.Find("Ghost_White").GetComponentInChildren<Animator>().SetBool("Loop", true);
        GameObject.Find("Ghost_White").GetComponentInChildren<Animator>().SetTrigger("LavaDamage");

    }

    public void FeedBackEndCallBack()
    {
        GameObject.Find("Ghost_White").GetComponentInChildren<Animator>().SetBool("Loop", false);
    }
    #endregion
}
