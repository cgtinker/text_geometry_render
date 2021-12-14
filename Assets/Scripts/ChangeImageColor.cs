using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageColor : MonoBehaviour
{
	private Image image;

	// Start is called before the first frame update
	void Awake()
	{
		image = this.gameObject.GetComponent<Image>();
	}

	IEnumerator ChangeColor()
	{
		Color tmp = image.color;
		tmp.a = 1;
		image.color = tmp;
		yield return new WaitForEndOfFrame();
		tmp.a = 0;
		image.color = tmp;

	}

	// Update is called once per frame
	void Update()
	{
		int val = Random.Range(0, 25);
		if (val == 1)
		{
			Debug.Log(val);

			StartCoroutine(ChangeColor());
		}
	}
}
