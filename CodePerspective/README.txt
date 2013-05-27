
Run DotNet4_Installer.exe if XBuilder.exe give's you an error starting up.

To run Code Perspective against your application open XBuilder.exe, click 'Add' to add the .Net assemblies (exe/dll) you wan to look at, and click 'Recompile.' The 'Analyze' button is for static analysis. The 'Launch' button will launch your application with Code Perspective's dynamic analysis.

For ASP applications, run Code Perspective against your project's dll in the bin folder of your ASP project. Check the checkbox 'Overwrite originals' in XBuilder.exe before recompiling.  To launch your ASP app with Code Perspective, 'Run without Debugging' from your IDE so the modified DLLs aren't replaced.

Notes about the Demoes included:

demoA - OldFashionedFun - Run XRay.OldFashionedFun.exe to run this program with the Code Perspective viewer. OldFashionedFun gives your windows gravity.

demoB - DeOps - Run XRay.DeOps.exe to see this program with Code Perspective.  DeOps is a large communications app built in C#, to log in you need to create a test network or IM profile.

Checkout CodePerspective.com for help!