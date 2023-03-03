Unity version: 2022.2 (and also 2021.3)
Fish-Networking version: 3.4.3

When I try to check if my NetworkBehaviour class has CustomAttribute attributes, when NetworkInitialize___Early comes in the loop, the game crashes on android if I use IL2CPP. At the same time with Scripting Backand = Mono and in the editor everything works fine. How to fix this problem?
Also, the game does not crash if you specify in IsDefined inherit = false.

```cs
// If the inherit = false, it works
if (methodInfo.IsDefined(typeof(CustomAttribute), false))
{
    // do...
}

// But if the inherit = true and there is a "NetworkInitialize___Early" method, the game crashes in IL2CPP build on Adroid
if (methodInfo.IsDefined(typeof(CustomAttribute), true))
{
    // do...
}
```

I reproduced this bag in this project and made an apk build.
The Bootstrap.cs file contains calls to the Debug.Log() method. This is done to track the progress of program execution with Android Logcat.
You need to open Logcat in Unity and install Build.apk on your smartphone. Then the game will immediately crash and you can look at the logs in the Logcat window. From them you can see that what I described above is happening.
