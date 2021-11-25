using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Stats")]
    //Movement speed in units per second
    public float moveSpeed;
    //Force applied upwards
    public float jumpForce;

    //Added Player HP
    public int curHP;
    public int maxHP;

    [Header("Mouse Look")]
    //Mouse looke sensititivity
    public float lookSensitivity;
    //Lowest down we can look
    public float maxLookX;
    //Highest up we can look
    public float minLookX;
    //Current x rotation of the camera
    private float rotX;

    private Camera camera;
    private Rigidbody rb;
    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();

        //Initialize the UI
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
    //Applies Damage to the player
    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
            Die();

        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }
    //If player health is reduced zero or below then run Die()
    void Die()
    {
        GameManager.instance.LoseGame();
    }
    
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //rb.velocity = new Vector3(x, rb.velocity.y, z); - old code
            //Move direction relative to the camera
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rb.velocity.y;
        //Jump with direction relative to the camera
        rb.velocity = dir;
    }
    
    void CamLook()
    {
        //Mouse look sensitivity
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            //Add force to jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void GiveHealth(int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        
        //Fire Button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        //Jump Button
        if(Input.GetButtonDown("Jump"))
            Jump();

        //Pause the game when pause button is pressed
        if(GameManager.instance.gamePaused == true)
            return;

    }

}
