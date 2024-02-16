# WsjtxAdiMerger by F4LAA V1.0 (2024/02/16)
A Program to merge two WSJT-X instances ADI log file<br/>
<br/>
If you have 2 instances of WSJT-X running for two TX<br/>
each instances has it's own wsjtx_log.adi file which contains the list of QSO's made with this instance.<br/>
<br/>
if you want an instance to know about the QSOmade with the other instance, you have to compensate those wsjtx_log.adi file<br/>
<br/>
This program do it for you automatically.<br/>
<br/>
You select the two directories where wsjtx_log.adi files resides, this program read them, merge them, <br/>
then rewrite them in each directory so that the two files becomes the same.<br/>
<br/>
Now, each WSJT-X instance has the same QSO list as the other<br/>
<br/>
You can optionnaly check :<br/>
  - "Générer wsjtx_144MHz.adi" to extract all QSO of the 2m band.<br/>
  - "Générer wsjtx_432MHz.adi" to extract all QSO of the 70cm band.<br/>
<br/>
This program is writen using C# language.<br/>
It has been compiled using Visual Studio 2022 for .Net6 environment.<br/>
<br/>
You may need to install .Net6 desktop runtime to be able to use it.

