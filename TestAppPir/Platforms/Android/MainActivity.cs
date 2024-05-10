﻿using Android.App;
using Android.Content.PM;
using Android.Credentials;
using Android.OS;
using Android.Security.Identity;
using Java.Net;
using Plugin.Fingerprint;

namespace TestAppPir;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        //base.OnCreate(savedInstanceState);
        //CrossFingerprint.SetCurrentActivityResolver(() => this);
        //CrossFingerprint.Current.AuthenticateAsync(new Plugin.Fingerprint.Abstractions.AuthenticationRequestConfiguration("AUTHORIZATION NEEDED", "Putin Must Die!"));
    }
}
