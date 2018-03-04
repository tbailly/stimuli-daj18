using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCloud : MonoBehaviour {

    public Player player;
    public GameObject[] cloudShadow;
    private GameObject cloud;

    //FADE       
    private SpriteRenderer sprite;

    //LERP
    private Vector3 endPos;    
    public float speed;

    private void Awake()
    {        
        player = (Player)FindObjectOfType(typeof(Player));
        int index = Random.Range(0, 4);
        cloud = Instantiate(cloudShadow[index], new Vector3(this.transform.position.x, 0.1f, this.transform.position.z), cloudShadow[index].transform.rotation);
        cloud.transform.parent = this.transform;
        sprite = cloud.gameObject.GetComponent<SpriteRenderer>();
        Color tmp = sprite.color;
        tmp.a = 0.0f;
        sprite.color = tmp;
    }

    void Start()
    {
        StartCoroutine(SpriteFadeIn(sprite));
        float angle = Random.Range(0.0f, Mathf.PI * 2);
        endPos = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        endPos *= 50;     
    }

    IEnumerator SpriteFadeIn(SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;
        while (tmpColor.a < 1.0f)
        {
            tmpColor.a += Time.deltaTime / 5.0f;
            _sprite.color = tmpColor;

            if (tmpColor.a >= 1)
                tmpColor.a = 1.0f;
            yield return null;
        }
        _sprite.color = tmpColor;
    }

    IEnumerator SpriteFadeOut(SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;
        while(tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / speed;
            _sprite.color = tmpColor;

            if (tmpColor.a <= 0)
                tmpColor.a = 0.0f;
            yield return null;
        }
        _sprite.color = tmpColor;
    }

	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos, step);        
    }
}
