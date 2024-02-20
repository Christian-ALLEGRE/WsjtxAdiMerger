# WsjtxAdiMerger by F4LAA V1.2 (2024/02/20 18:48)
A Program to merge two WSJT-X instances ADI log files<br/>
<br/>
If you use two instances of WSJT-X program running for two different Rigs<br/>
each instances has it's own <b>wsjtx_log.adi</b> file which contain the list of QSOs made with this instance.<br/>
<br/>
if you want an instance to know about the QSOs made with the other instance, you have to compensate those wsjtx_log.adi files.<br/>
<br/>
<b>This program do it for you automatically.</b><br/>
<br/>
You select the two directories where wsjtx_log.adi files resides, and click on "Merge then Replace .ADI files" button.<br/>
The program read both files in memory, merge them, then rewrite them in each directory so that the two files becomes the same.<br/>
<br/>
Now, each WSJT-X instance has the same QSO list as the other, so you can benefit again from the color code provided by WSJT-X to show already done locator vs not yet done locator.<br/>
<br/>
You can optionnaly check :<br/>
<ul>
  <li>"Generate wsjtx_144MHz.adi file" to extract all QSO of the 2m band in a dedicated .adi file.</li>
  <li>"Generate wsjtx_432MHz.adi file" to extract all QSO of the 70cm band in a dedicated .adi file.</li>
</ul>
Those dedicated files are generated in the directory of the first WSJT-X instance.<br/>
<br/>
The program memorizes in the Windows Registries the parameters for Instance 1 and 2 of WSJT-X, so if you restart the program later, you only have to click on the "Merge then Replace .ADI files" button to get the files synchronized.<br/>
<br/>
This program is write using C# language. It is compiled using Visual Studio 2022 for .Net6 environment.<br/>
So, you may need to install the ".Net6 desktop runtime" to be able to run it on a Windows10 computer.<br/>
<br/>
You can find the .exe, .dll, and requested .json files in the WsjtxAdiMerger\bin\Debug\net6.0-windows directory.<br/>
<br/>
Enjoy it.<br/>
<br/>
<hr/>
<b>Version History :</b><br/>
V1.0  (2024/02/16 18:00): <br/>
<ul>
  <li>First release.</li>
</ul>
V1.1  (2024/02/17 10:00): <br/>
<ul>
  <li>Add the language management (English and French)</li>
</ul>
V1.1a (2024/02/17 16:00): <br/>
<ul>
  <li>Fix a bug detected by F8CND (issue #1) where the program fail to start after a fresh install.</li>
</ul>
V1.1b (2024/02/17 23:13): <br/>
<ul>
  <li>Fix a bug detected by F8CND (issue #2) where the program fail to create the wsjtx_144MHz.adi file.</li>
  <li>Check that the selected files names contains the "wsjtx_log.adi" string.</li>
  <li>Do nothing on files if :<br/>
    <ul>
      <li>No record was found in the 1st wsjtx_log.adi file.</li>
      <li>No correct Header was found in the 1st wsjtx_log.adi file.</li>
    </ul>
  </li>
  <li>Add backup of the selected files (under .bak_yyyyMMddhhmmss) to prevent file lost in case of program failure.</li>
  <li>Add translation for all messages.</li>
</ul>
V1.1c (2024/02/19 20:00): <br/>
<ul>
  <li>Add a more explicit final message that tells how many records where added in each files.</li>
  <li>Do not backup and rewrite files if no record were added.</li>
</ul>
<ul>
V1.2 (2024/02/20 18:48): <br/>
<ul>
  <li>New feature: You can now add a <b>QRZ.com exported ADI file</b> to your wsjtx_log.adi files.</li>
<ul>
<hr/>


