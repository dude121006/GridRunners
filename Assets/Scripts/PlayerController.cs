using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    Rigidbody myRigidBody;
    float inputX;
    float inputY;
    public float speed;
    Vector3 moveVelocity;
    Vector3 moveInput;

    public int playerHealth;
    public float timeBetweenDamage;
    public int damageDone;

    private void Awake()
    {
        myRigidBody = transform.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(inputX, 0, inputY);
        moveVelocity = moveInput.normalized * speed;
        
    }

    private void FixedUpdate()
    {
        myRigidBody.MovePosition(myRigidBody.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collision");
        StartCoroutine(TakeDamage());
    }

    private void OnCollisionExit(Collision collision)
    {
        StopCoroutine(TakeDamage());
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    DealDamage(damageDone);

    //    nextDamageTime = Time.time + timeBetweenDamage;
    //}



    void DealDamage(int damageDone)
    {
        playerHealth -= damageDone;
        print(playerHealth);

        if (playerHealth <= 0) 
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        Destroy(this.gameObject);
    }

    IEnumerator TakeDamage()
    {
        print("Coroutine started");
        DealDamage(damageDone);
        //yield return new WaitForSeconds(timeBetweenDamage);
        yield return null;
    }
}
