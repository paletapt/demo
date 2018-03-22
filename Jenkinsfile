node {
	stage ('Checkout') {
		checkout scm
		}
	stage('Build + SonarQube analysis') {
     def sonarQubeRunner = tool 'Scanner for MSBuild 2.2'
     withSonarQubeEnv('My SonarQube Server') { 
		bat "\"${sonarQubeRunner}\\MSBuild.SonarQube.Runner.exe\" begin /d:sonar.resharper.solutionFile=ContactManager.sln /d:sonar.resharper.cs.reportPath=ReSharperResult.xml /k:test.delete /n:myDemo /v:1.0 /d:sonar.host.url=%SONAR_HOST_URL% /d:sonar.login=%SONAR_AUTH_TOKEN%"
		bat "\"${tool 'MSBuild'}\\MSBuild.exe\" /t:Clean,Build /p:Platform=ARM ContactManager.sln"
		bat "\"C:\\Program Files (x86)\\JetBrains\\jb-commandline\\inspectcode.exe\" ContactManager.sln /o=ReSharperResult.xml"
		bat "for /D %%f in (.sonarqube\\out\\SensorbergSDK_x*) do rmdir %%f /s /q"
		bat "\"${sonarQubeRunner}\\MSBuild.SonarQube.Runner.exe\" end /d:sonar.login=%SONAR_AUTH_TOKEN%"
	  }
	  }
	stage ('Archive') {
		archive 'ProjectName/bin/Release/**'
		}
}