using UnityEngine;
using System.Collections;

public class GetImage : MonoBehaviour {
	public GameObject image;

	// Use this for initialization
	void Start () {
#if UNITY_ANDROID
		AndroidCamera.instance.OnImagePicked += OnImagePicked;
		AndroidCamera.instance.GetImageFromGallery();
#endif
#if UNITY_IOS
		{
			IOSCamera.OnImagePicked += OnImage;
			IOSCamera.Instance.PickImage(ISN_ImageSource.Library);

		}
#endif
	}
	
	// Update is called once per frame
	private void OnImagePicked(AndroidImagePickResult result) {
#if UNITY_ANDROID
		Debug.Log("OnImagePicked");
		if (result.IsSucceeded) {
			AN_PoupsProxy.showMessage ("Image Pick Rsult", "Succeeded, path: " + result.ImagePath);
			image.GetComponent<Renderer> ().material.mainTexture = result.Image;
		} else {
			AN_PoupsProxy.showMessage ("Image Pick Rsult", "Failed");
		}
		
		AndroidCamera.instance.OnImagePicked -= OnImagePicked;
		#endif
	}

	private void OnImage (IOSImagePickResult result) {
		#if UNITY_IOS
		if(result.IsSucceeded) {
			image.GetComponent<Renderer> ().material.mainTexture = result.Image;
		}
		IOSCamera.OnImagePicked -= OnImage;
		#endif
	}
}
