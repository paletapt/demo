node {
	stage ('Checkout') {
		checkout scm
		}
	stage('Build + SonarQube analysis') {
     def sqScannerMsBuildHome = tool 'Scanner for MSBuild 2.2'
     withSonarQubeEnv('My SonarQube Server') { 
      bat "${sqScannerMsBuildHome}\\SonarQube.Scanner.MSBuild.exe begin /k:deleteme2 /n:deleteme2 /v:1.0 /d:sonar.host.url=http://192.168.3.90:9000/ /d:sonar.login=9532ae5a08fdecdb65b22862e35bc704704eaa5f"
      bat "\"${tool 'MSBuild'}\\MSBuild.exe\" ContactManager.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
      bat "${sqScannerMsBuildHome}\\SonarQube.Scanner.MSBuild.exe end"
	  }
	  }
	stage ('Archive') {
		archive 'ProjectName/bin/Release/**'
		}
}