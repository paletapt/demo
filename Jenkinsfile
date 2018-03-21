node {
    agent any    
    stages {
        stage('checkout') {
          steps {
            checkout([$class: 'GitSCM', ...])
          }
        }
        stage('restore') {
            steps {
                bat 'dotnet restore --configfile NuGet.Config'
            }
        }
        stage('build') {
            steps {
                bat 'dotnet build'
            }
        }
        stage('publish') {
            steps {
              ...
            }
        }
    }
}