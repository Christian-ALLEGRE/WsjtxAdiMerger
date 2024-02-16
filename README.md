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
Now, each WSJT-X instance has the same QSO list as the other, so you can benefit again of the color code of WSJT-X that show already done locator vs not yet done locator.<br/>
<br/>
You can optionnaly check :<br/>
  - "Générer wsjtx_144MHz.adi" to extract all QSO of the 2m band in a dedicated .adi file.<br/>
  - "Générer wsjtx_432MHz.adi" to extract all QSO of the 70cm band in a dedicated .adi file.<br/>
Those dedicated files are generated in the directory of the 1st WSJT-X instance.<br/>
<br/>
The program memorizes in the Windows Registries the parameters for Instance 1 and 2 of WSJT-X, so if you restart the program later, you only have to click on the "Fusioner puis Remplacer les .ADI" button to get the files synchronized.<br/>
<br/>
This program has been writen using C# language. It has been compiled using Visual Studio 2022 for .Net6 environment.<br/>
So, you may need to install the ".Net6 desktop runtime" to be able to run it on a Windows10 computer.<br/>
<br/>
You can find the .exe, .dll, and requested .json files in the E:\ACSoft\DVLP\Projets\WsjtxAdiMerger\WsjtxAdiMerger\bin\Debug\net6.0-windows directory.

