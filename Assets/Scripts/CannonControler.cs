using UnityEngine;

public class CannonControler : MonoBehaviour
{
    public float speed = 10f;
    public float minX = -20f;
    public float maxX = 20f;

    public GameObject cannonBall;
    public Transform cannon;

    Material material;

    bool isDisolving = false;
    float fade = 0f;
    float dissolveRate = 0.1f;

    private float _nextFire;
    private float _fireRate;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("_Fade", fade);

        _nextFire = 1f;
        _fireRate = 1f;
    }

    void Update()
    {
        if (isDisolving)
        {
            fade -= Time.deltaTime * dissolveRate;

            if (fade <= 0f)
            {
                fade = 0f;
                isDisolving = false;
                GameManager.Instance.BreakoutMode();
            }
            material.SetFloat("_Fade", fade);
        }

        if (GameManager.Instance.gameOn && !GameManager.Instance.isBreaker)
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x >= minX)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x <= maxX)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
            {
                SoundManager.Instance.PlaySoundEffect(SoundEffect.Cannon);
                _nextFire = Time.time + _fireRate;
                Instantiate(cannonBall, cannon.position, Quaternion.identity);
            }
        }
    }

    public void FadeIn()
    {
        fade += 0.08f;
        material.SetFloat("_Fade", fade);
        if (fade >= 1)
        {
            fade = 1f;
            isDisolving = true;
            // set game mode
            GameManager.Instance.InvaderMode();
        }
    }
}
