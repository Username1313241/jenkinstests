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
                    // Не прерываем сборку, если тесты упали
                    catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE') {
                        sh 'dotnet test --logger:"trx;LogFileName=test_results.trx" --results-directory TestResults'
                    }
                }
            }
        }
    }

    post {
        always {
            script {
                echo '🔁 Пост-обработка: генерация Allure-репорта'
                sh '''
                    mkdir -p allure-results

                    cp JenkinsTest/TestResults/*.trx allure-results/ || true

                    allure generate allure-results --clean -o allure-report || true
                    allure open -h 0.0.0.0 -p 9000 || true
                '''
            }
        }
    }
}