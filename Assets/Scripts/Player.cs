// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public float Speed;
//     public float JumpForce;
//     private bool isGrounded;
//     private Rigidbody2D rigidBody;
//     private Animator animator;
//     private SpriteRenderer sprite;
    

//     // Start is called before the first frame update
//     void Start()
//     {
//         rigidBody = GetComponent<Rigidbody2D>();
//         animator = GetComponent<Animator>();
//         sprite = GetComponent<SpriteRenderer>();    
//     }

//     void FixedUpdate()
//     {
//         if(Input.GetKey(KeyCode.LeftArrow))
//         {
//             rigidBody.velocity = new Vector2(-Speed, rigidBody.velocity.y);
//             animator.SetBool("isWalking", true);
//             sprite.flipX = true;
//         }else{
//             rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
//             animator.SetBool("isWalking", false);
//         }

//         if(Input.GetKey(KeyCode.RightArrow))
//         {
//             rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);
//             animator.SetBool("isWalking", true);
//             sprite.flipX = false;
//         }

//         if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
//             rigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse); 
//             isGrounded = false;
//             animator.SetBool("isJumping", true);
//         }
//     }

//     void onCollisionEnter2D(Collision2D coll){
//         if(coll.gameObject.layer == 8){
//             isGrounded = true;
//             animator.SetBool("isJumping", false);
//         }
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    private float timeAttack;
    public float startTimeAttack;
    private bool isGrounded;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Logica do personagem se movimentando
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector2(-Speed, rigidBody.velocity.y);

            //Incluindo animação de caminhada
            animator.SetBool("isWalking", true);

            //Rotacionar player para esquerda
            sprite.flipX = true;
        }
        else {
            //Assim que soltar a seta parar ao invés de continuar deslizando
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);

            //Não tem tecla pressionada desativo walking 
            animator.SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);

            //Incluindo animação de caminhada
            animator.SetBool("isWalking", true);

            //Rotacionar player para direita
            sprite.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
        if(timeAttack <= 0 ){
            if(Input.GetKeyDown(KeyCode.Z)){
                animator.SetTrigger("isAttacking");
                timeAttack = startTimeAttack;
            }
        }
        else{
            timeAttack -= Time.deltaTime;
            animator.SetTrigger("isAttacking");
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {

        //Personagem esta tocando o chao
        if(coll.gameObject.layer == 8)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        
    }

}