using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Artefact_Script : MonoBehaviour {

	#region Singleton
	static private Artefact_Script s_Instance;
	static public Artefact_Script instance
	{
		get
		{
			return s_Instance;
		}
	}



	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}
	#endregion

	#region members

	public int X;
	public int Y;

	public int base_X;
	public int base_Y;

	public int gain_X;
	public int gain_Y;

	public Text Text_UI_X;
	public Text Text_UI_Y;
	
	#endregion

	// Use this for initialization
	void Start () {

		X = base_X;
		Y = base_Y;

		Text_UI_X.text = X.ToString();
		Text_UI_Y.text = Y.ToString();

		StartCoroutine(gain_automatique_X());

	}


	IEnumerator gain_automatique_X()
	{
		while(this.gameObject)
		{
			yield return new WaitForSeconds(1);
			X += gain_X;
			Text_UI_X.text = X.ToString();
		}
		
	}

	public void GainX(int gain)
	{
		X += gain;
		Text_UI_X.text = X.ToString();
	}


	public void DepenseX(int perte)
	{
		X -= perte;
		if(X<0)
		{
			X = 0;
		}
		Text_UI_X.text = X.ToString();
	}


	public void GainY(int gain)
	{
		Y += gain;
		Text_UI_Y.text = Y.ToString();
	}


	public void DepenseY(int perte)
	{
		Y -= perte;
		if (X < 0)
		{
			X = 0;
		}
		Text_UI_Y.text = Y.ToString();
	}


}
