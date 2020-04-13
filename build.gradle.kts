import org.jetbrains.kotlin.gradle.tasks.KotlinCompile

plugins {
    kotlin("jvm") version "1.3.70" apply false
    id("org.springframework.boot") version "2.2.2.RELEASE" apply false
    id("io.spring.dependency-management") version "1.0.8.RELEASE" apply false
    kotlin("plugin.spring") version "1.3.70" apply false
    kotlin("plugin.allopen") version "1.3.70"
    kotlin("plugin.noarg") version "1.3.70"
}

allprojects {

    group = "mesi.io"
    version = "0.0.2"

    repositories {
        mavenCentral()
        jcenter()
    }
}

subprojects {
    apply {
        plugin("org.jetbrains.kotlin.jvm")
        plugin("org.springframework.boot")
        plugin("io.spring.dependency-management")
        plugin("org.jetbrains.kotlin.plugin.spring")
        plugin("org.jetbrains.kotlin.plugin.allopen")
        plugin("org.jetbrains.kotlin.plugin.noarg")
    }

    val implementation by configurations

    dependencies {
        implementation(kotlin("stdlib-jdk8"))
        implementation(kotlin("reflect"))

        implementation("org.springframework.boot:spring-boot-starter")
    }

    tasks.withType<KotlinCompile> {
        kotlinOptions.jvmTarget = "1.8"
    }

    tasks.withType<Test> {
        useJUnitPlatform()
    }

    allOpen {
        annotation("mesi.io.domain.common.AllOpenNoArg")
    }

    noArg {
        annotation("mesi.io.domain.common.AllOpenNoArg")
    }
}

tasks.register("bundle") {

    group = "mesi.io"
    description = "Generates a bundle with artifacts and docker files for deployment"

    dependsOn("zipBundle")
}

tasks.register<Copy>("createBundle") {
    dependsOn(":app:build")
    dependsOn(":data-clipboard:build")
    dependsOn(":domain-common:build")
    dependsOn(":domain-clipboard:build")

    if(File("bundle").exists()) {
        delete("bundle")
    }

    from(subprojects.map { "${it.buildDir}/libs" }) {
        include("*.jar")
        into("api")
    }

    from("docker/api") {
        into("api")
    }

    from("mesi.io.frontend/app") {
        exclude("node_modules")
        into("frontend/app")
    }

    from("docker/frontend") {
        into("frontend")
    }

    from("docker/docker-compose.yml")

    into("bundle")
}

tasks.register<Zip>("zipBundle") {

    dependsOn("createBundle")

    if(File("bundle.zip").exists()) {
        delete("bundle.zip")
    }

    archiveFileName.set("bundle.zip")
    destinationDirectory.set(file("$projectDir"))

    from("bundle")

    doLast {
        delete("bundle")
    }
}
