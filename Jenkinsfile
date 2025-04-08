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
                    sh 'dotnet test --logger:"trx;LogFileName=test_results.trx"'
                }
            }
        }

        stage('Generate Allure Report') {
            steps {
                // Предполагается, что Allure results уже где-то сохранены
                // Заменить путь, если сохраняешь в другое место
                sh '''
                    mkdir -p allure-results
                    # Предположим, что после dotnet test у тебя где-то генерируются результаты
                    # Например, копируем *.trx в allure-results
                    cp JenkinsTest/TestResults/*.trx allure-results/ || true

                    allure generate allure-results --clean -o allure-report
                    allure open -h 0.0.0.0 -p 9000 &
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