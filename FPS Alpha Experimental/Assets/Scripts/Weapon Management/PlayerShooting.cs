﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.
<<<<<<< Updated upstream
=======
    public int ammo = 30;
    public Camera fpsCamera;                        // FPS Camera

>>>>>>> Stashed changes

    float timer;                                    // A timer to determine when to fire.
    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
<<<<<<< Updated upstream
    ParticleSystem gunParticles;                    // Reference to the particle system.
=======
    // ParticleSystem[] particleList;
    ParticleSystem gunParticles;                    // Reference to the particle system.
    ParticleSystem hitParticles;                    // Reference to the particle system.

>>>>>>> Stashed changes
    LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

<<<<<<< Updated upstream
    void Awake()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("Shootable");

        // Set up the references.
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
=======
    void Awake() 
    { 
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("Shootable");
        // Set up the references.
        gunParticles = transform.Find("GunParticles").GetComponent<ParticleSystem>();
        hitParticles = transform.Find("HitParticles").GetComponent<ParticleSystem>();

        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        // fpsCamera = GameObject.Find("FPS Camera").GetComponent<Camera>();
>>>>>>> Stashed changes
    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the Fire1 button is being press and it's time to fire...
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
<<<<<<< Updated upstream
            // ... shoot the gun.
            Shoot();
=======
            if (ammo > 0)
            {
                // ... shoot the gun.
                Shoot();
            }
>>>>>>> Stashed changes
        }

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
<<<<<<< Updated upstream
        gunLine.enabled = false;
        gunLight.enabled = false;
=======
        // gunLine.enabled = false;
        // gunLight.enabled = false;
>>>>>>> Stashed changes
    }

    void Shoot()
    {
        // Reset the timer.
        timer = 0f;

        // Play the gun shot audioclip.
        gunAudio.Play();

        // Enable the light.
        gunLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
        gunParticles.Stop();
        gunParticles.Play();

<<<<<<< Updated upstream
        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
=======

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        // shootRay.origin = transform.position;
        // shootRay.direction = transform.forward;

        shootRay.origin = fpsCamera.transform.position;
        shootRay.direction = fpsCamera.transform.forward;

        // Enable the line renderer and set it's first position to be the end of the gun.
        // gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position + transform.forward);


        gunLine.enabled = true;
        //gunLine.SetPosition(1, shootRay.origin + shootRay.direction * 3);

        // ammo -= 1;
>>>>>>> Stashed changes

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
<<<<<<< Updated upstream
          
            ObjectHealth enemyHealth = shootHit.collider.GetComponent<ObjectHealth>();
            //Debug.Log(shootHit);
            //Debug.Log(shootHit.collider);
=======

            ObjectHealth enemyHealth = shootHit.collider.GetComponent<ObjectHealth>();
            //Debug.Log(shootHit);
            Debug.Log(shootHit.collider);
>>>>>>> Stashed changes
            //Debug.Log(enemyHealth);
            // Try and find an EnemyHealth script on the gameobject hit.
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
<<<<<<< Updated upstream

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition(1, shootHit.point);
=======
            else
            {
                Debug.Log("Playing hit particles");
                hitParticles.transform.position = shootHit.point;
                hitParticles.Play();
            }

            // Set the second position of the line renderer to the point the raycast hit.
            //gunLine.SetPosition(1, shootHit.point);
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * 30);
>>>>>>> Stashed changes
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
