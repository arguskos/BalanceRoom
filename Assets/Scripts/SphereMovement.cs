using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereMovement : MonoBehaviour
{
    //public SphericProjectile prefab;
        
    public float radius = 11;
    public float translateSpeed = 180.0f;
    public float rotateSpeed = 360.0f;
    public float fireInterval = 0.05f;
    public Dictionary<string, bool> _blockedDirections= new Dictionary<string, bool>();

    float angle = 0.0f;
    Vector3 direction = Vector3.one;
    Quaternion rotation = Quaternion.identity;
    public GameObject Camera;
    private Vector3 _lastFramePos;
    //void Fire()
    //{
    //    var clone = (SphericProjectile)Instantiate(prefab);
    //    clone.transform.position = transform.position;
    //    clone.transform.rotation = transform.rotation;
    //    clone.transform.parent = transform.parent;
    //    clone.angle = angle;
    //    clone.rotation = rotation;
    //}
    void Start()
    {
        UpdatePositionRotation();
        _blockedDirections.Add("up",false);
        _blockedDirections.Add("down", false);
        _blockedDirections.Add("left", false);
        _blockedDirections.Add("right", false);
        _blockedDirections.Add("upRight", false);
        _blockedDirections.Add("upLeft", false);
        _blockedDirections.Add("downRight", false);
        _blockedDirections.Add("downLeft", false);


        //Camera.transform.position = transform.position;
        //Camera.transform.position += Camera.transform.forward*(-40);
        //Camera.transform.parent = transform;
    }
    void Update()
    {
        _lastFramePos = transform.position;
       
        direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle));

    
        // Translate left/right with A/D. Bad keys but quick test.
        if (Input.GetKey(KeyCode.A) && !_blockedDirections["left"]) Translate(translateSpeed, 0);
        if (Input.GetKey(KeyCode.D) && !_blockedDirections["right"]) Translate(-translateSpeed, 0);
        if (Input.GetKey(KeyCode.W) && !_blockedDirections["up"]) Translate(0, translateSpeed);
        if (Input.GetKey(KeyCode.S) && !_blockedDirections["down"]) Translate(0, -translateSpeed);

        if (Input.GetKey(KeyCode.L) && !_blockedDirections["downRight"]) Translate(-translateSpeed, -translateSpeed);
        if (Input.GetKey(KeyCode.O) && !_blockedDirections["upRight"]) Translate(-translateSpeed, translateSpeed);
        if (Input.GetKey(KeyCode.K) && !_blockedDirections["downLeft"]) Translate(translateSpeed, -translateSpeed);
        if (Input.GetKey(KeyCode.I) && !_blockedDirections["upLeft"]) Translate(translateSpeed, translateSpeed);
       // Debug.DrawRay(transform.position, transform.position + transform.forward);

        UpdatePositionRotation();
    }

    void Rotate(float amount)
    {
        angle += amount * Mathf.Deg2Rad * Time.deltaTime;
    }

    void Translate(float x, float y)
    {
        var perpendicular = new Vector3(-direction.y, direction.x);
        var verticalRotation = Quaternion.AngleAxis(y * Time.deltaTime, perpendicular);
        var horizontalRotation = Quaternion.AngleAxis(x * Time.deltaTime, direction);
        rotation *= horizontalRotation * verticalRotation;
    }

    void UpdatePositionRotation()
    {
        transform.localPosition = rotation * Vector3.forward * radius;

        transform.rotation = rotation * Quaternion.LookRotation(direction, Vector3.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Hole")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
        {
            transform.position = _lastFramePos;

        }
    }
}
