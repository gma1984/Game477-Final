using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{

    public Animator cameraAnimator;

    public void CamShake()
    {
        cameraAnimator.SetTrigger("ScreenShake");
    }

}
