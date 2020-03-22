using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    float HP = 100;
    Transform ship;

    [SerializeField]
    float speed = 1.5f;
    [SerializeField]
    float rotateSpeed = 5;

    [SerializeField]
    Transform fireDir1, fireDir2;
    Transform fireDir;
    LineDraw line;

    public CameraController cam1;
    int cannonBallnum = 10;

    public GameObject cannonBall;


    void Start()
    {
        ship = gameObject.GetComponent<Transform>();
        cam1 = GameObject.FindGameObjectWithTag("Cam1").GetComponent<CameraController>();
        fireDir1 = transform.GetChild(0).GetComponent<Transform>();
        fireDir2 = transform.GetChild(1).GetComponent<Transform>();
        fireDir = fireDir1;
        line = fireDir.GetComponent<LineDraw>();
        
    }

    private Vector3 targetPosition;
    private float targetDistance;

    private void Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, transform.forward, Time.deltaTime * rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, transform.forward, Time.deltaTime * -rotateSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            fireDir = fireDir == fireDir1 ? fireDir2 : fireDir1;
        }
    }
    void Zoom()
    {
        if (Input.GetKey(KeyCode.R))
        {
            cam1.ZoomOut();
        }
        else
        {
            cam1.ZoomIn();
        }
    }
    private float range = 0;
    private float cooldown = 0;
    private void Fire()
    {
        Vector2 target;
        if (Input.GetKey(KeyCode.Q) && cooldown <=0) 
        {
            range += 10 * Time.deltaTime;
            range = Mathf.Clamp(range, 1, 10);
        }

        if ((Input.GetKeyUp(KeyCode.Q) || range == 10) && cooldown <= 0)
        {
            target = line.endPos;
            range = 0;
            cooldown = 3f;
            FireCannonball(line.endPos);
            line.endPos = line.startPos;
            cannonBallnum -= 1;
        }

    }


    void FireCannonball(Vector2 target){
        Vector2 firePos = fireDir.position;
        GameObject ball = PoolManager.instance.ReuseObject(cannonBall, firePos, Quaternion.identity);
        Vector2 dir = (target - (Vector2)fireDir.position);
            
        ball.GetComponent<Cannonball>().setTarget(firePos, target, dir, Vector2.Distance(firePos,target));
        ball.GetComponent<Rigidbody2D>().velocity = dir;
        ball.transform.position += (Vector3)dir * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        line = fireDir.GetComponent<LineDraw>();
        Controller();
        Zoom();
        Fire();
        line.startPos = ship.position;
        line.endPos = line.startPos + range*(Vector2)(fireDir.position - ship.position);
        cooldown -= Time.deltaTime;
    }
}
