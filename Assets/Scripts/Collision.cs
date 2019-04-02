/* File: Collision
 * Description: On player collision, gameover and explosion animation
 * written by Hanan Au 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collision : MonoBehaviour
{
    public Playermovement movement;

    public float cubeSize = 0.2f;
    public int cubeInRow = 5;

    float cubePivotDistance;
    Vector3 cubePivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;


    private void Start()
    {
        //calculate pivot distance
        cubePivotDistance = cubeSize * cubeInRow / 2;
        //pivot vector
        cubePivot = new Vector3(cubePivotDistance, cubePivotDistance, cubePivotDistance);
    }

    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        
        // if colliding with obstacle
        if (collisionInfo.collider.tag == "Obstacle")
        {         
            movement.enabled = false;
            Explosion();
            FindObjectOfType<GameManager>().EndGame();  // call Endgame Function
        }
    }

    public void Explosion()
    {
        gameObject.SetActive(false);
        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubeInRow; x++)
        {
            for (int y = 0; y < cubeInRow; y++)
            {
                for (int z = 0; z < cubeInRow; z++)
                {
                    CreateParticle(x, y, z);
                }
            }
        }
        // explosion position
        Vector3 explosionPos = transform.position;
        //explosion vector
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in overlasp sphere
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb!= null)
            {
                rb.AddExplosionForce(explosionForce,explosionPos,explosionRadius, explosionUpward);
            }
        }

    }

    void CreateParticle(int x, int y, int z)
    {
        // creating cube particle
        GameObject particle;
        particle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        // make particle have rigidbody mass
        particle.AddComponent<Rigidbody>();
        particle.GetComponent<Rigidbody>().mass = cubeSize;
        
        // transform position and particle
        particle.transform.position = transform.position + new Vector3(x * cubeSize, y * cubeSize, z * cubeSize) - cubePivot;
        particle.transform.localScale = new Vector3(cubeSize,cubeSize,cubeSize);

        //customize explosion
        Material material = particle.GetComponent<Renderer>().material;
        material.color = new Color32(99, 203, 255,0);        
    }

}
