package mesi.io.controller

import org.springframework.stereotype.Controller
import org.springframework.ui.Model
import org.springframework.web.bind.annotation.GetMapping

@Controller
class HomeController {

    @GetMapping(
            path = ["", "index"],
            produces = ["text/html"]
    )
    fun index(model : Model) : String {
        return "index"
    }

    @GetMapping(
            path = ["clipboard"],
            produces = ["text/html"]
    )
    fun clipboard(model: Model) : String {
        return "clipboard"
    }
}