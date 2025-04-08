pipeline {
    agent any

    stages {
        stage('Hello') {
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:8.0'
                    args '--network=install-jenkins-docker_jenkins'
                }
            }
            environment {
                    DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
                }
            steps {
                sh 'dotnet --version'
                sh 'pwd'
                dir('JenkinsTest') {
                  sh 'pwd'
                  sh 'dotnet test'
                sh 'touch container.txt' 
                }
                
            }
        }
    }
}
