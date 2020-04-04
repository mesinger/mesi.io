dependencies {
    implementation(project(":mesi.io.clipboard"))

    testImplementation("org.springframework.boot:spring-boot-starter-test")
    testImplementation("io.mockk:mockk:1.9.3")

}

tasks {
    bootJar {
        enabled = false
    }

    jar {
        enabled = true
    }
}
