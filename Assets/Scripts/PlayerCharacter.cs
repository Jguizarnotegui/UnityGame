using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Includes player health, ammo, death and teleport
public class PlayerCharacter : MonoBehaviour {
    public int _health;
    public int _ammo;

    public Slider healthBar;
    public Image damageImage;
    public Text ammoCount;

    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    RayShooter playerShooting;
    FPSInput playerMoving;
    public bool isDamaged;
    public bool isDead;

    public void SavePlayer ()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        _health = data.health;
        _ammo = data.ammo;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    // Use this for initialization
    void Start () {
        _health = 100;
        _ammo = 300;
        playerMoving = GetComponent<FPSInput>();
        playerShooting = GetComponentInChildren<RayShooter>();
	}
	public void Hurt(int damage)
    {
        isDamaged = true;
        _health -= damage;
        healthBar.value = _health;
        //Debug.Log("Player hit hp: " + _health);
        if (_health <= 0  && !isDead)
        {
            Debug.Log("Player Dead!");
            Dead();
        }
    }
	// Update is called once per frame
	void Update () {
        ammoCount.text = _ammo.ToString();
        if(isDamaged)
        {
            damageImage.color = flashColor;
            isDamaged = false;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
    }
    // Disable player shooting and moving when dead
    void Dead()
    {
        if (_health <= 0)
        {
            isDead = true;
            playerShooting.enabled = false;
            playerMoving.enabled = false;
        }
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.collider.gameObject.tag == "Hotspot")
        {
            //Randomize player location on collision with hotspot
            float playerx = Random.Range(-18, 18);
            float playerz = Random.Range(-18, 18);
            Debug.Log("Teleport position: " + playerx + " " + playerz);
            transform.position = new Vector3(playerx, 1, playerz);
        }
        // When player touches health pack increase health by 1 and delete health pack
        if (col.collider.gameObject.tag == "Healthpack")
        {
            _health += 1;
            Destroy(col.gameObject);
            Debug.Log("Touched health pack hp is: " + _health);
        }
        // When player touches ammo pack increase ammo by 10 and delete ammo pack
        if (col.collider.gameObject.tag == "Ammopack")
        {
            _ammo += 10;
            Destroy(col.gameObject);
            Debug.Log("Touched ammo pack: " + _ammo);
        }
    }
}