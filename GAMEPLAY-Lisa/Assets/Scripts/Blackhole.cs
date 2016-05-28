using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour
{

	public Transform PullObject;
    public float ForceSpeed;

    
    // Use this for initialization
    void Start()
    {
		PullObject = GetComponent<Transform> ();
		//print (PullObject);
    }

	public void OnTriggerStay2D(Collider2D other)
	{

		if (other.CompareTag("Player"))
		{
                if (PullObject != null) {
                    Debug.Log(PullObject);
                PullObject = other.transform;
                    PullObject.transform.position = Vector2.MoveTowards(PullObject.transform.position, this.transform.position, ForceSpeed * Time.deltaTime);
                }
		}
	}

    // Update is called once per frame
    void Update()
    {

    }
}



