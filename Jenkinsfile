pipeline {
    agent any

    stages {
        stage('Hello') {
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:8.0'
                }
            }
            steps {
                sh 'dotnet --version'
                sh 'dotnet test'
                sh 'touch container.txt' 
            }
        }
    }
}
