using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
    public Animator myAnim;

    void Start(){
        myAnim = GetComponent<Animator>();
    }
    IEnumerator OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            Destroy(gameObject);
            myAnim.Play("PlayerShieldAnimation");
            yield return new WaitForSeconds(10.0f);
        }
    }
}
