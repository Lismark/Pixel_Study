using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    public bool IsGrounded {set; get;}

private void OnCollisionEnter2D(Collision2D coll) {
    if(coll.gameObject.CompareTag("Platform")){
        IsGrounded = true;
}
}
private void OnCollisionExit2D(Collision2D coll) {
    if(coll.gameObject.CompareTag("Platform")){
        IsGrounded = false;

    }
}
}
