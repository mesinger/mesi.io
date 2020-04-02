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
        annotation("mesi.io.domain.AllOpenNoArg")
    }

    noArg {
        annotation("mesi.io.domain.AllOpenNoArg")
    }
}

tasks.register("prepareDeploy") {

    group = "mesi.io"
    description = "Prepares artifacts and docker files for AWS"

    println("Prepare for deployment")

    if(File("deploy").exists()) {
        delete("deploy")
    }

    dependsOn("copyProjectJarsToDeploy")
    dependsOn("copyDockerFilesToDeploy")

    doLast {
        println("Finished")
    }
}

tasks.register<Copy>("copyProjectJarsToDeploy") {

    println("Copying artifacts to deploy")

    dependsOn(":mesi.io.app:build")
    dependsOn(":mesi.io.domain:build")
    dependsOn(":mesi.io.clipboard:build")

    from(subprojects.map { "${it.buildDir}/libs" })
    include("*.jar")
    into("deploy/bin")

    println("Copied")
}

tasks.register<Copy>("copyDockerFilesToDeploy") {
    println("Copying docker files to deploy")

    from("${projectDir}/docker/Dockerfile", "${projectDir}/docker/docker-compose.yml")
    into("deploy")

    println("Copied")
}
