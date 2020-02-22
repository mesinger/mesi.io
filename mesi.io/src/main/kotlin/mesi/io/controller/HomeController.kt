package mesi.io.controller

import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Controller
import org.springframework.ui.Model
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.ModelAttribute
import org.springframework.web.bind.annotation.PostMapping

@Controller
class HomeController {

    @GetMapping(
            path = ["", "index"],
            produces = ["text/html"]
    )
    fun index(model : Model) : String {
        return "index"
    }
}