package mesi.io.app.controller

import org.springframework.security.authentication.AnonymousAuthenticationToken
import org.springframework.security.core.context.SecurityContextHolder
import org.springframework.stereotype.Controller
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.ResponseBody

@Controller
@RequestMapping("echo")
class EchoController {
    @GetMapping
    @ResponseBody
    fun echo() : String {
        return when(val auth = SecurityContextHolder.getContext().authentication){
            is AnonymousAuthenticationToken -> "echo"
            else -> "echo ${auth.name}"
        }
    }
}