dependencies{
    implementation("org.springframework.boot:spring-boot-starter-data-mongodb")
//    implementation("org.springframework.boot:spring-boot-starter-data-jpa")
    implementation("com.fasterxml.jackson.module:jackson-module-kotlin:2.10.2")
}

tasks {
    bootJar {
        enabled = false
    }

    jar {
        enabled = true
    }
}