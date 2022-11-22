using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 1f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _playerFireRate = 0.15f;
    private float _canFire = -1f;
    [SerializeField]
    private int _playerLives = 3;



    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        { PlayerFire(); }
    }



    //Methods
    void CalculateMovement()
    {
        //variables
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Direction
        transform.Translate(Vector3.right * 2.5f * horizontalInput * _playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _playerSpeed * Time.deltaTime);

        //saving code for clean unilateral speed
        //Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        //transform.Translate(direction * _playerSpeed * Time.deltaTime);

        //Setting player boundaries
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9, 9), Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
    }

    void PlayerFire()

    {
        
        {

            _canFire = Time.time + _playerFireRate;
            Debug.Log("Space Key Pressed");
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }

    }

    public void Damage()
    {
        _playerLives -= 1;

        if (_playerLives < 1)
        {
            Destroy(this.gameObject);
        }

    }




    //Placeholder if I want to go back to wrap method for X axis
    //        if (transform.position.x >= 11.3f)
    //       {
    //          transform.position = new Vector3(-11.3f, transform.position.y, transform.position.z);
    //      }
    //      else if (transform.position.x <= -11.3f)
    //    {
    //      transform.position = new Vector3(11.3f, transform.position.y, transform.position.z);
    // }

}
