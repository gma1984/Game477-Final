using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.localPosition = target.transform.localPosition + offset;
        }
    }
}