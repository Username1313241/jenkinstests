pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
    }

    stages {
        stage('Check Environment') {
            steps {
                sh 'dotnet --version'
                sh 'allure --version'
            }
        }

        stage('Run Tests') {
            steps {
                dir('JenkinsTest') {
                    catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE') {
                        sh 'dotnet test --logger:"trx;LogFileName=test_results.trx" --results-directory TestResults'
                    }
                }
            }
        }

        stage('Prepare Allure Results') {
            steps {
                sh '''
                    mkdir -p allure-results
                    cp JenkinsTest/TestResults/*.trx allure-results/ || true
                '''
            }
        }
    }

    post {
        always {
            echo 'Pipeline completed.'
            allure includeProperties: false, jdk: '', results: [[path: 'allure-results']]
        }
    }
}