using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour{
    private BoxCollider2D boxCollider;
    private Animator anim;
    private Vector3 moveDelta;
    private RaycastHit2D hit;


    private void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        if(moveDelta.x > 0){
            transform.localScale = Vector3.one;
            anim.SetBool("walking", true);
        }
        else if(moveDelta.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("walking", true);
        }
        else if(moveDelta.y != 0){
            anim.SetBool("walking", true);
        }
        else{
            anim.SetBool("walking", false);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null){
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null){
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

        
    }
    
}
