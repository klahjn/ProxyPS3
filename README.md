# PS3 Proxy Gui [Beta]
by psykosis

Simple PS3 Proxy w/ GUI by psykosis
Based on:  https://github.com/mondul/PS3-Proxy

Installation Instructions:
1.  install application
2.  Click Start
3.  Setup proxy in ps3 (IP/Port should be listed on main app window)
4.  Sign into PSN

Updated Notes: <2/25/2019>
I have added a check for initial launch
Upon this launch it will:
0. Message you about this being your first launch
1. Exclude Port 8080 from your firewall, this will require administrator priveledge, so click yes.
2. Message you that the process is complete.  
3. Set in the app that it has been launched and setting applied, and continue app as normal.
Clicking cancel will prevent the change, the only way to get this back is to uninstall/reinstall
All subsequent launches will bypass this procedure. This is by design.
This will minimize to the system tray icon.  Double clicking the icon will bring this back.
Hovering over the question mark will produce a help screen and about window
Clicking the question mark will bring up a step by step screenshot instruction for your PS3
Closing the app will stop the server, even if it is not already stopped.
The stop button is not enabled by default, this will enable only when the server is running.  This is by design.
The start button becomes disabled when the server is running, it will enable when the server is stopped.  this is by design.
There is no ps3-updatelist.txt, this is by design.
This server supports: JP, US, EU, KR, UK, MX, AU, NZ, SA, TW, RU, & CN


I also have a "lite" variant written in WPF (WPFProxy)


Notes:
1.  I have had to disable my windows defender firewall.  you may be able to add as exception, but YMMV
2.  This may be false flagged by your antivirus.  
3.  VirusTotal Report: https://www.virustotal.com/#/file/b80f3f91753bec3af642b3565a6832e01d79251c8c7e0f21352f787959a3f8e9/detection
4.  PSNPatch will shut down PSN access until you do R2 + /\ keycombo, which disables CFW and enables PSN
5.  For a pre-compiled "installer", see:  https://ufile.io/3v619 (v.000)
6.  This is massively beta
