package mesi.io.app

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication
import org.springframework.context.annotation.ComponentScan
import org.springframework.data.mongodb.repository.config.EnableMongoRepositories

@SpringBootApplication
@ComponentScan(basePackages = ["mesi.io.app", "mesi.io.clipboard"])
@EnableMongoRepositories("mesi.io.clipboard")
class App

fun main(args : Array<String>){
    runApplication<App>(*args)
}
