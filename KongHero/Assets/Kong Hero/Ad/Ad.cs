using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ad : MonoBehaviour
{
    //public static Ad instance;
    public static int curWorld;

    private void Awake()
    {
        //instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

	// Update is called once per frame
	public void UnlockWorld()
	{
		AdManager.ShowVideoAd("192if3b93qo6991ed0",
		   (bol) => {
			   if (bol)
			   {
				   PlayerPrefs.SetInt("WorldReached", curWorld);
				   gameObject.SetActive(false);
				   MainMenu_World[] list = GameObject.FindObjectsOfType<MainMenu_World>();
				   foreach(var i in list)
                   {
					   i.Refresh();
                   }
				   AdManager.clickid = "";
				   AdManager.getClickid();
				   AdManager.apiSend("game_addiction", AdManager.clickid);
				   AdManager.apiSend("lt_roi", AdManager.clickid);


			   }
			   else
			   {
				   StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
			   }
		   },
		   (it, str) => {
			   Debug.LogError("Error->" + str);
			   //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
		   });
	}




}
