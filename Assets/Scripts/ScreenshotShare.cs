using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotShare : MonoBehaviour
{
	[SerializeField] private Button shareButton;

	private bool isFocus = false;

	private bool isProcessing = false;
	private string screenshotName;

	void Start()
	{
		shareButton.onClick.AddListener(OnShareButtonClick);
	}


	void OnApplicationFocus(bool focus)
	{
		isFocus = focus;
	}

	public void OnShareButtonClick()
	{

		screenshotName = "fireblock_highscore.png";

		ShareScreenshot();
	}


	private void ShareScreenshot()
	{

#if UNITY_ANDROID
		if (!isProcessing)
		{
			StartCoroutine(ShareScreenshotInAnroid());
		}

#else
		Debug.Log("No sharing set up for this platform.");
#endif
	}



#if UNITY_ANDROID
	public IEnumerator ShareScreenshotInAnroid()
	{

		isProcessing = true;
		// wait for graphics to render
		yield return new WaitForEndOfFrame();

		string screenShotPath = Application.persistentDataPath + "/" + screenshotName;
		ScreenCapture.CaptureScreenshot(screenshotName, 1);
		yield return new WaitForSeconds(0.5f);

		if (!Application.isEditor)
		{
			//current activity context
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

			//Create intent for action send
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

			//create file object of the screenshot captured
			AndroidJavaObject fileObject = new AndroidJavaObject("java.io.File", screenShotPath);

			//create FileProvider class object
			AndroidJavaClass fileProviderClass = new AndroidJavaClass("android.support.v4.content.FileProvider");

			object[] providerParams = new object[3];
			providerParams[0] = currentActivity;
			providerParams[1] = "com.DefaultCompany.GroceryList.provider";
			providerParams[2] = fileObject;

			//instead of parsing the uri, will get the uri from file using FileProvider
			AndroidJavaObject uriObject = fileProviderClass.CallStatic<AndroidJavaObject>("getUriForFile", providerParams);

			//put image and string extra
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			intentObject.Call<AndroidJavaObject>("setType", "image/png");

			//additionally grant permission to read the uri
			intentObject.Call<AndroidJavaObject>("addFlags", intentClass.GetStatic<int>("FLAG_GRANT_READ_URI_PERMISSION"));

			AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share the product list");
			currentActivity.Call("startActivity", chooser);
		}

		yield return new WaitUntil(() => isFocus);
		isProcessing = false;
	}
#endif

}
