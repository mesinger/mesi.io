dependencies {
	implementation("org.springframework.boot:spring-boot-starter")
	implementation("org.springframework.boot:spring-boot-starter-web")
	implementation("org.springframework.boot:spring-boot-starter-data-mongodb")
//	implementation("org.springframework.boot:spring-boot-starter-security")

	implementation("com.fasterxml.jackson.module:jackson-module-kotlin:2.10.2")

	implementation(project(":domain-clipboard"))
	implementation(project(":domain-common"))
	implementation(project(":data-clipboard"))
}

tasks.bootRun {
	args = listOf("--spring.profiles.active=dev")
}
