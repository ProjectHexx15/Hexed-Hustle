using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class ProjectileController : MonoBehaviour
{
    // variables
    public GameObject magicPrefab; // stores the magicSpell prefab GO
    [SerializeField] private float fireRate = 0.5f; // stores the fireRate of the spell
    private float Fireable = -1; // will be used to check if we can fire a spell

    public Player player; // references the player class object
    public Transform ProjTransform; // stores the transform position of the projectile spawn

    private PlayerCastingAnimation PCA;

    public void Start()
    {
         PCA = GameObject.FindWithTag("Player").GetComponent<PlayerCastingAnimation>(); // finds the playermanager GO and gets the ProjectileController component
    } // end of start

    private void Update()
    {
        player = FindAnyObjectByType<Player>(); // finds the player object
        ProjTransform = player.transform.Find("ProjectileSpawnPoint"); // finds the projectile spawn point object

    } // end of update

    public void Onclicked(Button button)
    {

        if (Time.time > Fireable) // checks if the time that has passed is greater then Fireable
        {
            Fireable = Time.time + fireRate; // sets firable to the time that has passed and our firerate
            GameObject magic = Instantiate(magicPrefab, ProjTransform.transform);
            PCA.castingSpell(); // loads the casting spell function from the player casting animation script


        }
     
    } // end of button clicked


} // end of class
