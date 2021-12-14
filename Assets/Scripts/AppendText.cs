using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class AppendText : MonoBehaviour
{
	private TextMeshProUGUI textObject;
	private string text;
	System.Random random = new System.Random();

	private void Awake()
	{
		textObject = this.gameObject.GetComponent<TextMeshProUGUI>();
		text = "";
	}


	public string RandomString(int length)
	{
		const string chars = "01010*  ";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}

	private IEnumerator AssignChar(char letter)
	{
		text += letter;
		textObject.text = text;
		yield return new WaitForEndOfFrame();

		if (text.Count() > 6500)
		{
			text = "";
		}
	}

	private void AssignMsg(string msg)
	{
		textObject.text = text + msg;
	}

	private void Update()
	{
		int rand = Random.Range(0, 10);
		if (rand == 1)
		{
			int length = Random.Range(0, 500);
			string msg = RandomString(length);

			foreach (char entry in "$" + msg)
			{
				StartCoroutine(AssignChar(entry));
			}

			string str = "#";
			for (int i = 0; i < rand; i++)
			{
				str += "#";
			}
			AssignMsg(str);
		}
	}


}
