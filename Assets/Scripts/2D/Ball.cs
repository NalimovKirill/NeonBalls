using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] public BallType ballType;

    private Rigidbody2D _rb;
    private AudioSource _audio;
    private Animator _animator;

    //private SpawnerBall _spawner;

    private float _speed = 10;
    private Vector2 _direction;


    private float _minX, _minY;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        // _spawner = FindObjectOfType<SpawnerBall>();

        _minX = Random.Range(-5, 5);
        _minY = Random.Range(-0.75f, 4.75f);

        transform.position = new Vector2(_minX, _minY);

        _direction = Random.insideUnitCircle.normalized;

        // _rb.AddForce(new Vector2(9.8f * 25f, 9.8f * 25f));
    }
    private void FixedUpdate()
    {
        _rb.AddForce(_speed * _direction * Time.deltaTime);
    }

    void Update()
    {
        _rb.velocity = _speed * (_rb.velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ball_Type = collision.gameObject?.GetComponent<Ball>()?.ballType;
        if (this.ballType == ball_Type)
        {
            print("Одинаковы");
        }
        else
        {
            if (collision.collider.tag == "Border")
            {
                _audio?.Play();

                print("стена");
            }
            else
            {
                _animator.SetTrigger("Hit");
                this.enabled = false;
                Destroy(gameObject,.3f);
                //_spawner.currentNumberOfBalls--;
            }

        }

    }

    public enum BallType
    {
        Red_Ball,
        Black_Ball,
    }
}
