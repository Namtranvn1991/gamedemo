using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
	public float moveSpeed = 2;

    private Animator playerAnim;

    private bool isCoolDown;
    private float coolDownTime = 1;
    private float timeCoolDown;


    private Shot _shot;

    private List<Key> movement_queue = new List<Key>();
    public KeyCode keyAction1 = KeyCode.J;

    void Start()
    {
		_movement = GetComponent<Movement>();
		playerAnim = GetComponentInChildren<Animator>();
        _shot = GetComponent<Shot>();
	}


    void Update()
    {
       ControllButton();
    }



    public Key GetLastKey()
    {
        if (movement_queue.Count == 0)
        {
            return Key.None;
        }
        return movement_queue[movement_queue.Count - 1];
    }

    public void ControllButton()
    {
        PushKeyToQueue();
        RemoveKeyFromQueue();

        if (GetLastKey() == Key.Up)
        {
            _movement.TurnTo(Direction.North);  
            _movement.Move(moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
        else if (GetLastKey() == Key.Down)
        {
            _movement.TurnTo(Direction.South);
            _movement.Move(moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
        else if (GetLastKey() == Key.Left)
        {
            _movement.TurnTo(Direction.West);
            _movement.Move(moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
        else if (GetLastKey() == Key.Right)
        {

            _movement.TurnTo(Direction.East);
            _movement.Move(moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
        else
        {
            _movement.Stop();
            playerAnim.SetFloat("Speed_f", 0.0f);
        }
        if (Input.GetKeyDown(keyAction1) && _shot.remainBullet > 0)
        {
            _shot.Call();
            /*            Bullet bullet = Object.Instantiate(this.bullet, initPoint.position, transform.rotation);
                        bullet.Init(base.transform.rotation * Vector3.forward, bulletSpeed, _range, _damage, hitLayer, blockLayer);*/
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Collider[] array = Physics.OverlapSphere(base.transform.position, 2, _shot.blockLayer);
            foreach(Collider collider in array)
            {
                
                
            }

            bool check = Physics.CheckSphere(base.transform.position + _movement.direction.ToVector3() * 0.2f, 0.4f, _shot.blockLayer);
            Debug.Log(check);
        }
    }


    private void PushKeyToQueue()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement_queue.Add(Key.Up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement_queue.Add(Key.Down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement_queue.Add(Key.Left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement_queue.Add(Key.Right);
        }
    }

    private void RemoveKeyFromQueue()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            movement_queue.Remove(Key.Up);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movement_queue.Remove(Key.Down);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movement_queue.Remove(Key.Left);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movement_queue.Remove(Key.Right);
        }
    }

    //Not use
    public void ControllButtonOld()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _movement.TurnTo(Direction.North);
            _movement.Move(moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _movement.TurnTo(Direction.South);
            _movement.Move(moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _movement.TurnTo(Direction.West);
            _movement.Move(moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _movement.TurnTo(Direction.East);
            _movement.Move(moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
        else
        {
            _movement.Stop();
            playerAnim.SetFloat("Speed_f", 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
/*            Bullet bullet = Object.Instantiate(this.bullet, initPoint.position, transform.rotation);
            bullet.Init(base.transform.rotation * Vector3.forward, bulletSpeed, _range, _damage, hitLayer, blockLayer);*/
        }
    }
}
