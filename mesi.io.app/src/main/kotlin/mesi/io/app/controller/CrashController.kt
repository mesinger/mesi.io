package mesi.io.app.controller

import org.springframework.stereotype.Controller
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.ResponseBody

@Controller
@RequestMapping("crash")
class CrashController {
    @GetMapping(
            path = ["me"]
    )
    @ResponseBody
    fun crashMe() : String {
        HomeController.crashFlag = true
        return "i got crashed"
    }
}