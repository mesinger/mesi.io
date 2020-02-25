package mesi.io.clipboard

import org.springframework.boot.SpringApplication
import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.autoconfigure.domain.EntityScan
import org.springframework.context.annotation.ComponentScan
import kotlin.reflect.KClass

@SpringBootApplication
@ComponentScan(basePackages = ["mesi.io.clipboard"])
@EntityScan(basePackages = ["mesi.io.common.clipboard"])
class Application

fun main(args : Array<String>) {
    SpringApplication.run(Application::class.java, *args)
}
