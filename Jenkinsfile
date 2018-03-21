node {
	stage 'checkout'
		checkout scm

	stage 'build'{
		bat "\"${tool 'MSBuild'}\\MSBuild.exe\" ContactManager.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
		}

	stage 'archive'
		archive 'ProjectName/bin/Release/**'

}