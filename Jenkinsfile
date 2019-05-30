pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                bat "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\amd64\MSBuild.exe" TheSolution.sln
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                bat "C:\Program Files (x86)\NUnit.org\nunit-console\nunit3-console.exe" Tests.nunit /xml=nunit-result.xml
            }
        }
    }
}
