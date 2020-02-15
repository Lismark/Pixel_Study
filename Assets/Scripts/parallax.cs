using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    private void LateUpdate()
    {
        var bgPos = new Vector2(camera.transform.position.x, camera.transform.position.y);
        gameObject.transform.position = bgPos;
    }

}
