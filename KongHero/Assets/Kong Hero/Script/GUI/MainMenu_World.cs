using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu_World : MonoBehaviour {
	public int worldNumber = 1;
	public GameObject Locked;
	public Button unlockBtn;
	public GameObject AdPanel;


    // Use this for initialization
    void Start () {
		Refresh();
	}

	public void Refresh()
    {
		var worldreached = PlayerPrefs.GetInt(GlobalValue.WorldReached, 1);
		if (worldNumber <= worldreached)
		{
			Locked.SetActive(false);
			GetComponent<Button>().interactable = true;
			unlockBtn.gameObject.SetActive(false);
		}
		else
		{
			Locked.SetActive(true);
			GetComponent<Button>().interactable = false;
		}
	}

	public void SetAdPanel(bool a)
    {
		AdPanel.SetActive(a);
		Ad.curWorld = worldNumber;
    }

	public void OpenWorld(){
		MainMenuHomeScene.Instance.OpenWorld (worldNumber);
	}

	

}
