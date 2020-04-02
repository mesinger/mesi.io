dependencies {
    implementation(project(":mesi.io.clipboard"))
}

tasks {
    bootJar {
        enabled = false
    }

    jar {
        enabled = true
    }
}
