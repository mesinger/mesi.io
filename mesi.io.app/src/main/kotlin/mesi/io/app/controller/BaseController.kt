package mesi.io.app.controller

import org.springframework.web.bind.annotation.ModelAttribute

abstract class BaseController {

    @ModelAttribute("isLoggedIn")
    fun isLoggedIn() : Boolean {
        return false
    }

    @ModelAttribute("userName")
    fun userName() : String {
        return ""
    }
}