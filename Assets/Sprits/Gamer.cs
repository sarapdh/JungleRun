using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Gamer : MonoBehaviour
{

    private Animator animator;
    public GameManager gm;
    public float fJump;
    private Rigidbody2D RB2; 
    private AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        RB2 = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("isJumping",true);
            RB2.AddForce(new Vector2(0,fJump));
            jumpSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Floor"){
            animator.SetBool("isJumping",false);

        }

        if(collision.gameObject.tag == "Box"){
            gm.GameOver = true;
        }
    }
}
