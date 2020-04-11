package mesi.io.app.controller

import org.springframework.security.authentication.AnonymousAuthenticationToken
import org.springframework.security.core.context.SecurityContextHolder
import org.springframework.web.bind.annotation.ModelAttribute

abstract class BaseController {

    @ModelAttribute("isLoggedIn")
    fun isLoggedIn() : Boolean {
        return when(SecurityContextHolder.getContext().authentication){
            is AnonymousAuthenticationToken -> false
            else -> true
        }
    }

    @ModelAttribute("userName")
    fun userName() : String {
        return when(val auth = SecurityContextHolder.getContext().authentication){
            is AnonymousAuthenticationToken -> ""
            else -> auth.name
        }
    }
}