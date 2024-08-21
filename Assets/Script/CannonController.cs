using System.Collections;
using System.Collections.Generic;
// 2024-08-17 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject projectilePrefab; // Le prefab du projectile à tirer
    public Transform shootPoint; // Le point à l'extrémité du canon où les projectiles seront instanciés
    public float maxPower = 20f; // La puissance maximale de tir
    public float maxChargeTime = 5f; // Temps maximum de charge de tir
    public float rotationSpeed = 100f; // Vitesse de rotation du canon
    public float minY = -20f; // Rotation minimale verticale
    public float maxY = 20f; // Rotation maximale verticale
    public float minX = -45f; // Rotation minimale horizontale
    public float maxX = 45f; // Rotation maximale horizontale
    private float rotationX = 0f;
    private float rotationY = 0f;

    private float currentChargeTime = 0f;

    void Update()
    {
        RotateCannon();
        if (Input.GetKey(KeyCode.Space))
        {
            // Accumuler le temps de charge sans dépasser le maximum
            currentChargeTime += Time.deltaTime;
            currentChargeTime = Mathf.Min(currentChargeTime, maxChargeTime);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FireProjectile();
            currentChargeTime = 0f; // Réinitialiser le temps de charge
        }
    }

    void RotateCannon()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX + mouseY, minY, maxY);
        rotationY = Mathf.Clamp(rotationY + mouseX, minX, maxX);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float power = (currentChargeTime / maxChargeTime) * maxPower;
            rb.AddForce(transform.forward * power, ForceMode.Impulse);
        }
    }
}

