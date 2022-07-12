using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class BannerAds : MonoBehaviour {

	private BannerView Banniere;


	public void playad () {
		MobileAds.Initialize (initStatus => {});
		this.RequestBanner ();
	}
	
	private void RequestBanner(){
		#if UNITY_ANDROID
		string BarnerAds="ca-app-6141312762471247/9813089534";
		#elif UNITY_IPHONE
		string BarnerAds = "ca-app-pub-6141312762471247/9813089534";
		#else
		string BarnerAds = "unexpected_platform";
		#endif
		// Create a 320x50 banner at the top of the screen.
		AdRequest request = new AdRequest.Builder().Build();
		this.Banniere = new BannerView(BarnerAds, AdSize.Leaderboard, AdPosition.Top);
		this.Banniere.LoadAd(request);
	}
}
