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

        stage('Generate Allure Report') {
            steps {
                sh '''
                    mkdir -p allure-results
                    cp JenkinsTest/TestResults/*.trx allure-results/ || true
                    allure generate allure-results --clean -o allure-report || true
                '''
            }
        }
    }

    post {
        always {
            echo 'Pipeline completed.'
        }
    }
}