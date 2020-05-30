using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (speed != 0 && _rb != null)
        {
            //PlayerController.CharacterType characterType = character.GetComponent<PlayerController>().characterType;
            //if (characterType == PlayerController.CharacterType.enemy)
            //{
            //    speed = 45;
            //    _rb.position += (-transform.forward + offset) * (speed * Time.deltaTime);
            //}
            //else
            //{
            //    speed = 95;
            //    _rb.position += (transform.forward + offset) * (speed * Time.deltaTime);
            //}
        }
    }
}
