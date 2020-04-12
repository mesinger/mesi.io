dependencies{
    implementation("org.springframework.boot:spring-boot-starter-data-mongodb")
//    implementation("org.springframework.boot:spring-boot-starter-data-jpa")
}

tasks {
    bootJar {
        enabled = false
    }

    jar {
        enabled = true
    }
}