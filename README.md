# WsjtxAdiMerger by F4LAA V1.1 (2024/02/17)
A Program to merge two WSJT-X instances ADI log files<br/>
<br/>
If you have two instances of WSJT-X program running for two different Rig<br/>
each instances has it's own <b>wsjtx_log.adi</b> file which contain the list of QSOs made with this instance.<br/>
<br/>
if you want an instance to know about the QSO made with the other instance, you have to compensate those wsjtx_log.adi files.<br/>
<br/>
This program do it for you automatically.<br/>
<br/>
You select the two directories where wsjtx_log.adi files resides, and click on "Merge then Replace .ADI files" button.<br/>
The program read both files in memory, merge them, then rewrite them in each directory so that the two files becomes the same.<br/>
<br/>
Now, each WSJT-X instance has the same QSO list as the other, so you can benefit again from the color code provided by WSJT-X to show already done locator vs not yet done locator.<br/>
<br/>
You can optionnaly check :<br/>
<li>
  <ul>"Generate wsjtx_144MHz.adi file" to extract all QSO of the 2m band in a dedicated .adi file.</ul>
  <ul>"Generate wsjtx_432MHz.adi file" to extract all QSO of the 70cm band in a dedicated .adi file.</ul>
</li>
Those dedicated files are generated in the directory of the first WSJT-X instance.<br/>
<br/>
The program memorizes in the Windows Registries the parameters for Instance 1 and 2 of WSJT-X, so if you restart the program later, you only have to click on the "Merge then Replace .ADI files" button to get the files synchronized.<br/>
<br/>
This program is write using C# language. It is compiled using Visual Studio 2022 for .Net6 environment.<br/>
So, you may need to install the ".Net6 desktop runtime" to be able to run it on a Windows10 computer.<br/>
<br/>
You can find the .exe, .dll, and requested .json files in the WsjtxAdiMerger\bin\Debug\net6.0-windows directory.<br/>
<br/>
Enjoy it.

