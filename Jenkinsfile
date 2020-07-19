pipeline {
  agent any

  stages {
    stage('test') {
      steps {
        sh 'dotnet test'
      }
    }

    stage('nuke build') {
      steps {
        sh 'build.sh'
      }
    }
  }
}