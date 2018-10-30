using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Player shooting ammo tracking and bullet generating based on gun used
public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    GameObject player;
    GameObject weaponHolder;
    PlayerCharacter playerAmmo;
    //PlayerCharacter playerHealth;
    WeaponSwitching currentWeapon;
    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerAmmo = player.GetComponent<PlayerCharacter>();
        //playerHealth = player.GetComponent<PlayerCharacter>();
        weaponHolder = GameObject.FindGameObjectWithTag("Guns");
        currentWeapon = weaponHolder.GetComponent<WeaponSwitching>();
    }
    /*void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }*/
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerAmmo._ammo > 0)
        {
            playerAmmo._ammo -= 1;
            //Debug.Log("Player ammo: " + playerAmmo._ammo);
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject gameObject = hit.transform.gameObject;
                ReactiveTarget target = gameObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                    //Debug.Log("Target hit hp is: " + target.enemyHealth);
                }
                // Shows on enemy when its hit
                if (currentWeapon.selectedWeapon == 0)
                    StartCoroutine(PistolIndicator(hit.point));
                else
                    StartCoroutine(AkIndicator(hit.point));
            }
        }
    }
    // Generate the sphere where player shot
    private IEnumerator PistolIndicator(Vector3 pos)
    {
        GameObject pistolBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pistolBullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);// Bullet size
        pistolBullet.transform.position = pos;
        yield return new WaitForSeconds(0.01f);
        Destroy(pistolBullet);
    }
    private IEnumerator AkIndicator(Vector3 pos)
    {
        GameObject akBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        akBullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);// Bullet size
        akBullet.transform.position = pos;
        yield return new WaitForSeconds(0.01f);
        Destroy(akBullet);
    }
}