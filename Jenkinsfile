pipeline {
  agent any

  stages {
    stage('test') {
      steps {
        sh(script: "dotnet test", returnStdout: true)
      }
    }

    stage('nuke build') {
      steps {
        sh 'build.sh'
      }
    }
  }
}