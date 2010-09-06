Steps to take in order to run the Barista and the cashier using the host.

1. Go to the properties of the Barista project and there switch to the Debug - tab.

2. Under "Start Action" choose option "Start external program" and specify the absolute path to the Rhino.ServiceBus.Host.exe.
   For this solution the host can be found in the lib folder. A full path might look like this:

	C:\Coding\OS\LearningRhinoServiceBus\Lib\Rhino.ServiceBus.Host.exe

3. Under "Start Options / Command line arguments" you'll need to specify at least 3 options for the host:

	/Name: This needs to be a unique name. The host uses this name for the win32 service if you choose to install it (not for debugging)
	/Action: This needs to be set to "Debug"
	/Assembly: Full path to the assemlby which should be loaded by the host.
	
	My command line arguments look like this:

	/Name:Cashier /Action:Debug /Assembly:"C:\Coding\OS\LearningRhinoServiceBus\Source\E9_Deployment_with_the_service_host\Cashier\bin\Debug\Cashier.dll"

========================================================================================================================================================

A more detailed description of the configuration options of the Rhino.ServiceBus.Host.exe tool and how to set it up for debugging can be found under the following URL:

	http://hibernatingrhinos.com/open-source/rhino-service-bus/hosting

 