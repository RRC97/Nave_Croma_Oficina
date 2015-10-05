using UnityEngine;
using System.Collections;

public class UnityToastExample : MonoBehaviour
{
	
	private AndroidJavaObject toastExample = null;
	private AndroidJavaObject activityContext = null;
	
	void OnMouseDown()
	{
		if(this.enabled && toastExample == null)
		{
			using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
			
			using(AndroidJavaClass pluginClass = new AndroidJavaClass("rexproducoes.plugintoast.ToastMessage"))
			{
				if(pluginClass != null)
				{
					toastExample = pluginClass.CallStatic<AndroidJavaObject>("instance");
					toastExample.Call("setContext", activityContext);
					activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
					{
						toastExample.Call("showMessage", "Função não disponível no momento");
					}));
				}
			}
		}
	}
}