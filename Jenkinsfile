node {
	stage ('Checkout') {
		checkout scm
		}
	stage('Build + SonarQube analysis') {
     def sqScannerMsBuildHome = tool 'Scanner for MSBuild 2.2'
     withSonarQubeEnv('My SonarQube Server') { 
      bat "${sqScannerMsBuildHome}\\SonarScanner.MSBuild.exe begin /k:myKey /n:myName /v:1.0 /d:sonar.host.url=%SONAR_HOST_URL% /d:sonar.login=%SONAR_AUTH_TOKEN%"
      bat "\"${tool 'MSBuild'}\\MSBuild.exe\" \"${WORKSPACE}\\ContactManager.sln\" /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
      bat "${sqScannerMsBuildHome}\\SonarScanner.MSBuild.exe end /d:sonar.login=%SONAR_AUTH_TOKEN%"
	  }
	  }
	stage ('Archive') {
		archive 'ProjectName/bin/Release/**'
		}
}