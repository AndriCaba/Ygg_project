using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EggOpening : MonoBehaviour
{

    public Animator BeginCrack;
    public Animator HatchUI;
    public Animator RewardUI;

    public float AnimationDuration1;
    public float AnimationDuration2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        BeginCrack.SetTrigger("BEGIN");

        yield return new WaitForSeconds(AnimationDuration1);

        HatchUI.SetTrigger("FADE");

        yield return new WaitForSeconds(AnimationDuration2);

        RewardUI.SetTrigger("LoadReward");
    }
}
