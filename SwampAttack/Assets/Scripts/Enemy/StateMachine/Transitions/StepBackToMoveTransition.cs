using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepBackToMoveTransition : Transition
{
    private void Update()
    {
        StartCoroutine(WaitForTransit());
    }

    private IEnumerator WaitForTransit()
    {
        yield return new WaitForSeconds(1);
        NeedTransit = true;
    }
}
